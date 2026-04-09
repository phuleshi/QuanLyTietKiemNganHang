using System;

namespace QuanLyTietKiemNganHang.Helpers
{
    public static class RoleHelper
    {
        public const string Admin = "Admin";
        public const string NhanVienDb = "Giao_dich_vien";
        public const string NhanVienUi = "Nhan_vien";

        public static string NormalizeRole(string vaiTro)
        {
            var value = (vaiTro ?? string.Empty).Trim();
            if (value.Equals(Admin, StringComparison.OrdinalIgnoreCase))
            {
                return Admin;
            }

            if (value.Equals(NhanVienDb, StringComparison.OrdinalIgnoreCase)
                || value.Equals(NhanVienUi, StringComparison.OrdinalIgnoreCase)
                || value.Equals("Nhân viên", StringComparison.OrdinalIgnoreCase))
            {
                return NhanVienDb;
            }

            return value;
        }

        public static bool IsAdmin(string vaiTro)
        {
            return NormalizeRole(vaiTro).Equals(Admin, StringComparison.OrdinalIgnoreCase);
        }

        public static string ToDisplayName(string vaiTro)
        {
            return IsAdmin(vaiTro) ? "Admin" : "Nhân viên";
        }
    }
}
