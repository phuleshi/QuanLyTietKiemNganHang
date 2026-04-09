using QuanLyTietKiemNganHang.Helpers;

namespace QuanLyTietKiemNganHang.Models
{
    public class NhanVien
    {
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; }

        public bool LaAdmin
        {
            get { return RoleHelper.IsAdmin(VaiTro); }
        }

        public string VaiTroHienThi
        {
            get { return RoleHelper.ToDisplayName(VaiTro); }
        }
    }
}
