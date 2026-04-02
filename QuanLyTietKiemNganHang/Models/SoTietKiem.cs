using System;

namespace QuanLyTietKiemNganHang.Models
{
    public class SoTietKiem
    {
        public int Id { get; set; }
        public string MaSo { get; set; }
        public int KhachHangId { get; set; }
        public int NhanVienMoSoId { get; set; }
        public decimal SoTienGui { get; set; }
        public decimal LaiSuat { get; set; }
        public DateTime NgayMoSo { get; set; }
        public string TrangThai { get; set; }
    }
}
