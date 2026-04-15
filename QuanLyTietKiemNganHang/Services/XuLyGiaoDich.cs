using QuanLyTietKiemNganHang.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace QuanLyTietKiemNganHang.Services
{
    public class XuLyGiaoDich
    {
        private readonly XuLySoTietKiem soTietKiemService = new XuLySoTietKiem();

        public List<GiaoDich> GetDanhSach(DateTime? tuNgay, DateTime? denNgay, string loaiGiaoDich)
        {
            var query = @"SELECT gd.ma_gd, gd.ma_so, gd.ma_nv, gd.loai_gd, gd.so_tien, gd.ngay_gd, kh.ho_ten
                          FROM giao_dich gd
                          INNER JOIN so_tiet_kiem stk ON gd.ma_so = stk.ma_so
                          INNER JOIN khach_hang kh ON stk.ma_khach_hang = kh.ma_khach_hang
                          WHERE 1=1";
            var parameters = new List<SqlParameter>();

            if (tuNgay.HasValue)
            {
                query += " AND gd.ngay_gd >= @tuNgay";
                parameters.Add(new SqlParameter("@tuNgay", tuNgay.Value.Date));
            }

            if (denNgay.HasValue)
            {
                query += " AND gd.ngay_gd < @denNgay";
                parameters.Add(new SqlParameter("@denNgay", denNgay.Value.Date.AddDays(1)));
            }

            if (!string.IsNullOrWhiteSpace(loaiGiaoDich) && !string.Equals(loaiGiaoDich, "Tất cả", StringComparison.OrdinalIgnoreCase))
            {
                query += " AND gd.loai_gd = @loai";
                parameters.Add(new SqlParameter("@loai", loaiGiaoDich));
            }

            query += " ORDER BY gd.ngay_gd DESC, gd.ma_gd DESC";

            var table = Db.ExecuteDataTable(query, CommandType.Text, parameters.ToArray());
            return table.AsEnumerable().Select(MapGiaoDich).ToList();
        }

        public List<SoTietKiemDanhSachItem> GetDanhSachSoDangMo()
        {
            return soTietKiemService.GetDanhSach(string.Empty)
                .Where(x => !string.Equals(x.TrangThai, "Da_tat_toan", StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<SoTietKiemDanhSachItem> GetDanhSachSoDangMoTheoKhachHang(string maKhachHang)
        {
            if (string.IsNullOrWhiteSpace(maKhachHang))
            {
                return new List<SoTietKiemDanhSachItem>();
            }

            return soTietKiemService.GetDanhSachTheoKhachHang(maKhachHang)
                .Where(x => !string.Equals(x.TrangThai, "Da_tat_toan", StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public KetQuaTatToan TinhTatToan(string maSo, decimal? soTienRut, bool tatToanToanBo)
        {
            var so = soTietKiemService.GetByMaSo(maSo);
            if (so == null)
            {
                throw new InvalidOperationException("Không tìm thấy sổ tiết kiệm.");
            }

            if (string.Equals(so.TrangThai, "Da_tat_toan", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Sổ đã tất toán.");
            }

            var gocRut = tatToanToanBo ? so.SoDuGocConLai : soTienRut.GetValueOrDefault();
            if (gocRut <= 0)
            {
                throw new InvalidOperationException("Số tiền rút phải lớn hơn 0.");
            }

            if (!tatToanToanBo && gocRut >= so.SoDuGocConLai)
            {
                throw new InvalidOperationException("Rút gốc từng phần phải nhỏ hơn số dư hiện tại.");
            }

            var ngayTinh = DateTime.Today;
            var soDuGocConLai = so.SoDuGocConLai - gocRut;
            var tongLaiTheoGocBanDau = XuLySoTietKiem.TinhLaiTamTinhChuaLamTron(
                so.SoTienGui,
                so.LaiSuatApDung,
                so.NgayMo,
                so.NgayDaoHan,
                so.TrangThai,
                ngayTinh);
            var tongLaiChoPhanGocConLai = so.SoTienGui <= 0
                ? 0
                : tongLaiTheoGocBanDau * so.SoDuGocConLai / so.SoTienGui;
            var lai = so.SoDuGocConLai <= 0
                ? 0
                : tongLaiChoPhanGocConLai * gocRut / so.SoDuGocConLai;
            var laiConLai = tatToanToanBo
                ? 0
                : Math.Max(0, tongLaiChoPhanGocConLai - lai);
            var denHan = so.NgayDaoHan.HasValue && DateTime.Today >= so.NgayDaoHan.Value.Date;

            return new KetQuaTatToan
            {
                MaSo = so.MaSo,
                GocRut = gocRut,
                LaiTinhDuoc = Math.Round(lai, 0),
                TongNhan = Math.Round(gocRut + lai, 0),
                SoDuConLai = Math.Round(soDuGocConLai + laiConLai, 0),
                ThongBao = (denHan ? "Tất toán đúng hạn - áp dụng lãi suất kỳ hạn." : "Tất toán/rút trước hạn - áp dụng lãi suất không kỳ hạn.")
                    + " Lãi được phân bổ theo số tiền gốc ban đầu đến ngày giao dịch."
            };
        }

        public void XacNhanTatToan(string maSo, string maNhanVien)
        {
            soTietKiemService.TatToan(maSo, maNhanVien);
        }

        public void XacNhanRutGoc(string maSo, decimal soTienRut, string maNhanVien)
        {
            soTietKiemService.RutGocTungPhan(maSo, soTienRut, maNhanVien);
        }

        public List<LichSuHoatDongItem> GetLichSuHoatDong()
        {
            var table = Db.ExecuteDataTable(
                @"SELECT TOP 1000 su_kien.ma_su_kien,
                                   su_kien.loai_su_kien,
                                   su_kien.nguoi_thuc_hien,
                                   su_kien.noi_dung,
                                   su_kien.thoi_gian
                  FROM
                  (
                      SELECT nk.ma_nhat_ky AS ma_su_kien,
                             N'Nhật ký hệ thống' AS loai_su_kien,
                             ISNULL(nv.ten_nhan_vien + N' (' + nk.ma_nhan_vien + N')', nk.ma_nhan_vien) AS nguoi_thuc_hien,
                             nk.hanh_dong AS noi_dung,
                             nk.thoi_gian
                      FROM nhat_ky_he_thong nk
                      LEFT JOIN nhan_vien nv ON nk.ma_nhan_vien = nv.ma_nv

                      UNION ALL

                      SELECT gd.ma_gd AS ma_su_kien,
                             N'Giao dịch tiền' AS loai_su_kien,
                             ISNULL(nv.ten_nhan_vien + N' (' + gd.ma_nv + N')', gd.ma_nv) AS nguoi_thuc_hien,
                             CASE
                                 WHEN gd.loai_gd = N'Rut_tien' THEN N'Giao dịch rút tiền sổ ' + gd.ma_so + N' - ' + CONVERT(NVARCHAR(50), CAST(gd.so_tien AS DECIMAL(18,0))) + N' VND'
                                 WHEN gd.loai_gd = N'Gui_them' THEN N'Giao dịch gửi thêm sổ ' + gd.ma_so + N' - ' + CONVERT(NVARCHAR(50), CAST(gd.so_tien AS DECIMAL(18,0))) + N' VND'
                                 WHEN gd.loai_gd = N'Tra_lai' THEN N'Giao dịch trả lãi sổ ' + gd.ma_so + N' - ' + CONVERT(NVARCHAR(50), CAST(gd.so_tien AS DECIMAL(18,0))) + N' VND'
                                 ELSE gd.loai_gd
                             END AS noi_dung,
                             gd.ngay_gd AS thoi_gian
                      FROM giao_dich gd
                      LEFT JOIN nhan_vien nv ON gd.ma_nv = nv.ma_nv
                  ) su_kien
                  ORDER BY su_kien.thoi_gian DESC, su_kien.ma_su_kien DESC",
                CommandType.Text);

            return table.AsEnumerable()
                .Select(row => new LichSuHoatDongItem
                {
                    MaSuKien = row[0].ToString(),
                    LoaiSuKien = row[1].ToString(),
                    NguoiThucHien = row[2].ToString(),
                    NoiDung = row[3].ToString(),
                    ThoiGian = row[4] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row[4])
                })
                .OrderByDescending(x => x.ThoiGian)
                .ToList();
        }

        private static GiaoDich MapGiaoDich(DataRow row)
        {
            return new GiaoDich
            {
                MaGiaoDich = row["ma_gd"].ToString(),
                MaSo = row["ma_so"].ToString(),
                MaNhanVien = row["ma_nv"].ToString(),
                LoaiGiaoDich = row["loai_gd"].ToString(),
                SoTien = row["so_tien"] == DBNull.Value ? 0 : Convert.ToDecimal(row["so_tien"]),
                NgayGiaoDich = row["ngay_gd"] == DBNull.Value ? DateTime.Today : Convert.ToDateTime(row["ngay_gd"]),
                TenKhachHang = row["ho_ten"].ToString()
            };
        }
    }

    public class KetQuaTatToan
    {
        public string MaSo { get; set; }
        public decimal GocRut { get; set; }
        public decimal LaiTinhDuoc { get; set; }
        public decimal TongNhan { get; set; }
        public decimal SoDuConLai { get; set; }
        public string ThongBao { get; set; }
    }
}
