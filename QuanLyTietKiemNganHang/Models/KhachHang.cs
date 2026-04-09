namespace QuanLyTietKiemNganHang.Models
{
    public class KhachHang
    {
        public string MaKhachHang { get; set; }
        public string CCCD { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string TrangThai { get; set; }

        public bool DangHoatDong
        {
            get { return string.IsNullOrWhiteSpace(TrangThai) || TrangThai == "Active"; }
        }

        public string TrangThaiHienThi
        {
            get { return DangHoatDong ? "Active" : "Unactive"; }
        }

        public string HienThiCombo
        {
            get { return MaKhachHang + " - " + HoTen; }
        }
    }
}
