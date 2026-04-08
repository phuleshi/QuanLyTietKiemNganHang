using System;

namespace QuanLyTietKiemNganHang.Models
{
    public class GiaoDich
    {
        public string MaGiaoDich { get; set; }
        public string MaSo { get; set; }
        public string MaNhanVien { get; set; }
        public string LoaiGiaoDich { get; set; }
        public decimal SoTien { get; set; }
        public DateTime NgayGiaoDich { get; set; }
        public string TenKhachHang { get; set; }

        public string LoaiGiaoDichHienThi
        {
            get
            {
                if (string.Equals(LoaiGiaoDich, "Rut_tien", StringComparison.OrdinalIgnoreCase))
                {
                    return "Rút tiền";
                }

                if (string.Equals(LoaiGiaoDich, "Gui_them", StringComparison.OrdinalIgnoreCase))
                {
                    return "Gửi thêm";
                }

                if (string.Equals(LoaiGiaoDich, "Tra_lai", StringComparison.OrdinalIgnoreCase))
                {
                    return "Trả lãi";
                }

                return LoaiGiaoDich ?? string.Empty;
            }
        }
    }
}
