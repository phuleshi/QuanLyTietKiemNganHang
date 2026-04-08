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
        private const decimal LaiSuatKhongKyHan = 0.5m;
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

            var gocRut = tatToanToanBo ? so.SoDuHienTai : soTienRut.GetValueOrDefault();
            if (gocRut <= 0)
            {
                throw new InvalidOperationException("Số tiền rút phải lớn hơn 0.");
            }

            if (!tatToanToanBo && gocRut >= so.SoDuHienTai)
            {
                throw new InvalidOperationException("Rút gốc từng phần phải nhỏ hơn số dư hiện tại.");
            }

            var denHan = so.NgayDaoHan.HasValue && DateTime.Today >= so.NgayDaoHan.Value.Date;
            var laiSuat = denHan ? so.LaiSuatApDung : LaiSuatKhongKyHan;
            var soNgay = Math.Max(0, (DateTime.Today - so.NgayMo.Date).Days);
            var lai = Math.Round(gocRut * laiSuat / 100m * soNgay / 365m, 0);

            return new KetQuaTatToan
            {
                MaSo = so.MaSo,
                GocRut = gocRut,
                LaiTinhDuoc = lai,
                TongNhan = gocRut + lai,
                SoDuConLai = so.SoDuHienTai - gocRut,
                ThongBao = denHan ? "Tất toán đúng hạn - áp dụng lãi suất kỳ hạn." : "Tất toán/rút trước hạn - áp dụng lãi suất không kỳ hạn."
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
                @"SELECT TOP 500 ma_nhat_ky, N'Nhật ký hệ thống' AS loai, ma_nhan_vien, hanh_dong, thoi_gian
                  FROM nhat_ky_he_thong
                  UNION ALL
                  SELECT TOP 500 ma_gd, N'Giao dịch', ma_nv, loai_gd, ngay_gd
                  FROM giao_dich",
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
