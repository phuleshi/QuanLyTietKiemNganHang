using QuanLyTietKiemNganHang.Helpers;
using QuanLyTietKiemNganHang.Models;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyTietKiemNganHang.Services
{
    public class AuthService
    {
        private readonly NhatKyHeThongService nhatKyService = new NhatKyHeThongService();

        public NhanVien Login(string username, string password)
        {
            var table = Db.ExecuteDataTable(
                @"SELECT TOP 1 ma_nv, ten_nhan_vien, tai_khoan, mat_khau, vai_tro
                  FROM nhan_vien
                  WHERE tai_khoan = @taiKhoan AND mat_khau = @matKhau",
                CommandType.Text,
                new SqlParameter("@taiKhoan", username),
                new SqlParameter("@matKhau", password));

            if (table.Rows.Count == 0)
            {
                return null;
            }

            var row = table.Rows[0];
            var nhanVien = new NhanVien
            {
                MaNhanVien = row["ma_nv"].ToString(),
                TenNhanVien = row["ten_nhan_vien"].ToString(),
                TaiKhoan = row["tai_khoan"].ToString(),
                MatKhau = row["mat_khau"].ToString(),
                VaiTro = RoleHelper.NormalizeRole(row["vai_tro"].ToString())
            };

            nhatKyService.Ghi(
                nhanVien.MaNhanVien,
                "Đăng nhập hệ thống",
                "nhan_vien",
                null,
                "Tài khoản: " + nhanVien.TaiKhoan + "; Vai trò: " + nhanVien.VaiTroHienThi);

            return nhanVien;
        }
    }
}
