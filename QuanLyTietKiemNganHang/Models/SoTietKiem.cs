using System;

namespace QuanLyTietKiemNganHang.Models
{
    public class SoTietKiem
    {
        public string MaSo { get; set; }
        public string MaKhachHang { get; set; }
        public string MaGoi { get; set; }
        public string MaNhanVienMo { get; set; }
        public decimal SoTienGoc { get; set; }
        public decimal SoDuHienTai { get; set; }
        public decimal LaiSuatChot { get; set; }
        public DateTime NgayMo { get; set; }
        public DateTime? NgayDaoHan { get; set; }
        public string TrangThai { get; set; }
    }
}
