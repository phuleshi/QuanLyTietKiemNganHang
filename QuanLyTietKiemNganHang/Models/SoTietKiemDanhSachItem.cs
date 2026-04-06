using System;

namespace QuanLyTietKiemNganHang.Models
{
    public class SoTietKiemDanhSachItem
    {
        public string MaSo { get; set; }
        public string MaKhachHang { get; set; }
        public string ChuSoHuu { get; set; }
        public string TenGoiTietKiem { get; set; }
        public decimal SoTienGui { get; set; }
        public decimal SoDuHienTai { get; set; }
        public decimal LaiSuatApDung { get; set; }
        public DateTime NgayMo { get; set; }
        public DateTime? NgayDaoHan { get; set; }
        public string TrangThai { get; set; }
        public string TrangThaiHienThi { get; set; }
        public string MaNhanVienMo { get; set; }
        public string TenNhanVienMo { get; set; }
    }
}
