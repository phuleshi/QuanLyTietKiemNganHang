using QuanLyTietKiemNganHang.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace QuanLyTietKiemNganHang.Services
{
    public class XuLyLoaiTietKiem
    {
        public List<LoaiTietKiem> GetDanhSach(string keyword)
        {
            keyword = (keyword ?? string.Empty).Trim();
            var table = Db.ExecuteDataTable(
                @"SELECT ma_goi, ten_goi, lai_suat_nam, ky_han_thang
                  FROM goi_tiet_kiem
                  WHERE @keyword = '' OR ten_goi LIKE @search OR ma_goi LIKE @search
                  ORDER BY ky_han_thang, ten_goi",
                CommandType.Text,
                new SqlParameter("@keyword", keyword),
                new SqlParameter("@search", "%" + keyword + "%"));
            return table.AsEnumerable().Select(Map).ToList();
        }

        public void Them(string tenGoi, decimal laiSuatNam, int kyHanThang)
        {
            Validate(tenGoi, laiSuatNam, kyHanThang);
            Db.ExecuteNonQuery(
                "sp_them_goi",
                CommandType.StoredProcedure,
                new SqlParameter("@ten_goi", tenGoi.Trim()),
                new SqlParameter("@lai_suat", laiSuatNam),
                new SqlParameter("@ky_han", kyHanThang));
        }

        public void Sua(string maGoi, string tenGoi, decimal laiSuatNam, int kyHanThang)
        {
            if (string.IsNullOrWhiteSpace(maGoi))
            {
                throw new InvalidOperationException("Mã gói không hợp lệ.");
            }

            Validate(tenGoi, laiSuatNam, kyHanThang);
            Db.ExecuteNonQuery(
                "sp_sua_goi",
                CommandType.StoredProcedure,
                new SqlParameter("@ma_goi", maGoi),
                new SqlParameter("@ten_goi", tenGoi.Trim()),
                new SqlParameter("@lai_suat", laiSuatNam),
                new SqlParameter("@ky_han", kyHanThang));
        }

        public void Xoa(string maGoi)
        {
            if (string.IsNullOrWhiteSpace(maGoi))
            {
                throw new InvalidOperationException("Mã gói không hợp lệ.");
            }

            Db.ExecuteNonQuery(
                "sp_xoa_goi",
                CommandType.StoredProcedure,
                new SqlParameter("@ma_goi", maGoi));
        }

        private static void Validate(string tenGoi, decimal laiSuatNam, int kyHanThang)
        {
            if (string.IsNullOrWhiteSpace(tenGoi))
            {
                throw new InvalidOperationException("Tên gói không được để trống.");
            }

            if (laiSuatNam < 0)
            {
                throw new InvalidOperationException("Lãi suất không được âm.");
            }

            if (kyHanThang < 0)
            {
                throw new InvalidOperationException("Kỳ hạn không được âm.");
            }
        }

        private static LoaiTietKiem Map(DataRow row)
        {
            return new LoaiTietKiem
            {
                MaGoi = row["ma_goi"].ToString(),
                TenGoi = row["ten_goi"].ToString(),
                LaiSuatNam = row["lai_suat_nam"] == DBNull.Value ? 0 : Convert.ToDecimal(row["lai_suat_nam"]),
                KyHanThang = row["ky_han_thang"] == DBNull.Value ? 0 : Convert.ToInt32(row["ky_han_thang"])
            };
        }
    }
}
