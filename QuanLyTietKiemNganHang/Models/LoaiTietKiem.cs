namespace QuanLyTietKiemNganHang.Models
{
    public class LoaiTietKiem
    {
        public string MaGoi { get; set; }
        public string TenGoi { get; set; }
        public decimal LaiSuatNam { get; set; }
        public int KyHanThang { get; set; }

        public string KyHanHienThi
        {
            get { return KyHanThang <= 0 ? "Không kỳ hạn" : KyHanThang + " tháng"; }
        }

        public string HienThiCombo
        {
            get { return TenGoi + " - " + KyHanHienThi; }
        }
    }
}
