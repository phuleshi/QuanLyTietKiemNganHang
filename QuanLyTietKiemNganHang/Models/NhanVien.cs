using System;

namespace QuanLyTietKiemNganHang.Models
{
    public class NhanVien
    {
        public int Id { get; set; }
        public string MaNhanVien { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string ChucVu { get; set; }
        public string MatKhau { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public decimal LuongCoBan { get; set; }
        public string TrangThai { get; set; }
    }
}
