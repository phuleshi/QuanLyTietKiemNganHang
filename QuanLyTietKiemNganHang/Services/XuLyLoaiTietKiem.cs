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
        private readonly NhatKyHeThongService nhatKyService = new NhatKyHeThongService();

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

        public void Them(string tenGoi, decimal laiSuatNam, int kyHanThang, string maNhanVien = null)
        {
            Validate(tenGoi, laiSuatNam, kyHanThang);
            Db.ExecuteNonQuery(
                "sp_them_goi",
                CommandType.StoredProcedure,
                new SqlParameter("@ten_goi", tenGoi.Trim()),
                new SqlParameter("@lai_suat", laiSuatNam),
                new SqlParameter("@ky_han", kyHanThang));

            var goiMoi = GetByNameAndTerm(tenGoi, kyHanThang) ?? new LoaiTietKiem
            {
                TenGoi = tenGoi.Trim(),
                LaiSuatNam = laiSuatNam,
                KyHanThang = kyHanThang
            };

            nhatKyService.Ghi(
                maNhanVien,
                "Thêm gói tiết kiệm " + BuildLoaiTietKiemSummary(goiMoi),
                "goi_tiet_kiem",
                null,
                BuildLoaiTietKiemSnapshot(goiMoi));
        }

        public void Sua(string maGoi, string tenGoi, decimal laiSuatNam, int kyHanThang, string maNhanVien = null)
        {
            if (string.IsNullOrWhiteSpace(maGoi))
            {
                throw new InvalidOperationException("Mã gói không hợp lệ.");
            }

            Validate(tenGoi, laiSuatNam, kyHanThang);
            var goiCu = GetByMa(maGoi);
            Db.ExecuteNonQuery(
                "sp_sua_goi",
                CommandType.StoredProcedure,
                new SqlParameter("@ma_goi", maGoi),
                new SqlParameter("@ten_goi", tenGoi.Trim()),
                new SqlParameter("@lai_suat", laiSuatNam),
                new SqlParameter("@ky_han", kyHanThang));

            var goiMoi = GetByMa(maGoi) ?? new LoaiTietKiem
            {
                MaGoi = maGoi,
                TenGoi = tenGoi.Trim(),
                LaiSuatNam = laiSuatNam,
                KyHanThang = kyHanThang
            };

            nhatKyService.Ghi(
                maNhanVien,
                "Cập nhật gói tiết kiệm " + BuildLoaiTietKiemSummary(goiMoi),
                "goi_tiet_kiem",
                BuildLoaiTietKiemSnapshot(goiCu),
                BuildLoaiTietKiemSnapshot(goiMoi));
        }

        public void Xoa(string maGoi, string maNhanVien = null)
        {
            if (string.IsNullOrWhiteSpace(maGoi))
            {
                throw new InvalidOperationException("Mã gói không hợp lệ.");
            }

            var goiCu = GetByMa(maGoi);
            Db.ExecuteNonQuery(
                "sp_xoa_goi",
                CommandType.StoredProcedure,
                new SqlParameter("@ma_goi", maGoi));

            nhatKyService.Ghi(
                maNhanVien,
                "Xóa gói tiết kiệm " + BuildLoaiTietKiemSummary(goiCu),
                "goi_tiet_kiem",
                BuildLoaiTietKiemSnapshot(goiCu),
                null);
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

        private LoaiTietKiem GetByMa(string maGoi)
        {
            if (string.IsNullOrWhiteSpace(maGoi))
            {
                return null;
            }

            var table = Db.ExecuteDataTable(
                @"SELECT TOP 1 ma_goi, ten_goi, lai_suat_nam, ky_han_thang
                  FROM goi_tiet_kiem
                  WHERE ma_goi = @maGoi",
                CommandType.Text,
                new SqlParameter("@maGoi", maGoi));

            return table.Rows.Count == 0 ? null : Map(table.Rows[0]);
        }

        private LoaiTietKiem GetByNameAndTerm(string tenGoi, int kyHanThang)
        {
            var table = Db.ExecuteDataTable(
                @"SELECT TOP 1 ma_goi, ten_goi, lai_suat_nam, ky_han_thang
                  FROM goi_tiet_kiem
                  WHERE ten_goi = @tenGoi AND ky_han_thang = @kyHan
                  ORDER BY ma_goi DESC",
                CommandType.Text,
                new SqlParameter("@tenGoi", tenGoi.Trim()),
                new SqlParameter("@kyHan", kyHanThang));

            return table.Rows.Count == 0 ? null : Map(table.Rows[0]);
        }

        private static string BuildLoaiTietKiemSummary(LoaiTietKiem model)
        {
            if (model == null)
            {
                return "không xác định";
            }

            if (!string.IsNullOrWhiteSpace(model.MaGoi))
            {
                return model.MaGoi + " - " + model.TenGoi;
            }

            return model.TenGoi;
        }

        private static string BuildLoaiTietKiemSnapshot(LoaiTietKiem model)
        {
            if (model == null)
            {
                return string.Empty;
            }

            return string.Format(
                "Mã gói: {0}; Tên gói: {1}; Lãi suất: {2:0.00}%/năm; Kỳ hạn: {3} tháng",
                model.MaGoi,
                model.TenGoi,
                model.LaiSuatNam,
                model.KyHanThang);
        }
    }
}
