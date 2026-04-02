using System;

namespace QuanLyTietKiemNganHang.Models
{
    public class KhachHang
    {
        public int Id { get; set; }
        public string MaKhachHang { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string CCCD { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        public string TrangThai { get; set; }
    }
}
