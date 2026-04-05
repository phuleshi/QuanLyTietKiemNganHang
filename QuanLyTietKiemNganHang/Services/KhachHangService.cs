using QuanLyTietKiemNganHang.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace QuanLyTietKiemNganHang.Services
{
    public class KhachHangService
    {
        public List<KhachHang> GetAll()
        {
            var table = Db.ExecuteDataTable(
                @"SELECT ma_khach_hang, so_cccd, ho_ten, so_dien_thoai, dia_chi
                  FROM khach_hang
                  ORDER BY ma_khach_hang",
                CommandType.Text);

            return table.AsEnumerable().Select(Map).ToList();
        }

        public List<KhachHang> Search(string keyword)
        {
            keyword = (keyword ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return GetAll();
            }

            var table = Db.ExecuteDataTable(
                @"SELECT ma_khach_hang, so_cccd, ho_ten, so_dien_thoai, dia_chi
                  FROM khach_hang
                  WHERE ma_khach_hang LIKE @keyword
                     OR so_cccd LIKE @keyword
                     OR ho_ten LIKE @keyword
                     OR so_dien_thoai LIKE @keyword
                     OR dia_chi LIKE @keyword
                  ORDER BY ma_khach_hang",
                CommandType.Text,
                new SqlParameter("@keyword", "%" + keyword + "%"));

            return table.AsEnumerable().Select(Map).ToList();
        }

        public bool ExistsMaKhachHang(string maKhachHang)
        {
            var result = Db.ExecuteScalar(
                "SELECT COUNT(*) FROM khach_hang WHERE ma_khach_hang = @maKhachHang",
                CommandType.Text,
                new SqlParameter("@maKhachHang", maKhachHang));
            return result != null && (int)result > 0;
        }

        public void Add(KhachHang model)
        {
            Db.ExecuteNonQuery(
                "sp_them_khach_hang",
                CommandType.StoredProcedure,
                new SqlParameter("@so_cccd", model.CCCD),
                new SqlParameter("@ho_ten", model.HoTen),
                new SqlParameter("@so_dien_thoai", model.SoDienThoai),
                new SqlParameter("@dia_chi", model.DiaChi));
        }

        public void Update(KhachHang model)
        {
            Db.ExecuteNonQuery(
                "sp_sua_khach_hang",
                CommandType.StoredProcedure,
                new SqlParameter("@ma_khach_hang", model.MaKhachHang),
                new SqlParameter("@ho_ten", model.HoTen),
                new SqlParameter("@so_dien_thoai", model.SoDienThoai),
                new SqlParameter("@dia_chi", model.DiaChi));
        }

        public void Delete(string maKhachHang)
        {
            Db.ExecuteNonQuery(
                "sp_xoa_khach_hang",
                CommandType.StoredProcedure,
                new SqlParameter("@ma_khach_hang", maKhachHang));
        }

        private static KhachHang Map(DataRow row)
        {
            return new KhachHang
            {
                MaKhachHang = row["ma_khach_hang"].ToString(),
                CCCD = row["so_cccd"].ToString(),
                HoTen = row["ho_ten"].ToString(),
                SoDienThoai = row["so_dien_thoai"].ToString(),
                DiaChi = row["dia_chi"].ToString()
            };
        }
    }
}
