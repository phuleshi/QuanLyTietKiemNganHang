using QuanLyTietKiemNganHang.Models;
using System;
using System.Linq;

namespace QuanLyTietKiemNganHang.Services
{
    public class AuthService
    {
        public NhanVien Login(string username, string password)
        {
            var value = (username ?? string.Empty).Trim();
            return MockDatabase.NhanViens.FirstOrDefault(x =>
                string.Equals(x.MaNhanVien, value, StringComparison.OrdinalIgnoreCase) &&
                x.MatKhau == (password ?? string.Empty).Trim());
        }
    }
}
