using QuanLyTietKiemNganHang.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace QuanLyTietKiemNganHang.Services
{
    public class KhachHangService
    {
        private static bool daKiemTraMigration;
        private static readonly object syncRoot = new object();
        private readonly NhatKyHeThongService nhatKyService = new NhatKyHeThongService();

        public KhachHangService()
        {
            EnsureTrangThaiColumn();
        }

        public List<KhachHang> GetAll()
        {
            var table = Db.ExecuteDataTable(
                @"SELECT ma_khach_hang, so_cccd, ho_ten, so_dien_thoai, dia_chi,
                         ISNULL(trang_thai, 'Active') AS trang_thai
                  FROM khach_hang
                  ORDER BY ma_khach_hang",
                CommandType.Text);

            return table.AsEnumerable().Select(Map).ToList();
        }

        public List<KhachHang> Search(string keyword)
        {
            keyword = (keyword ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return GetAll();
            }

            var table = Db.ExecuteDataTable(
                @"SELECT ma_khach_hang, so_cccd, ho_ten, so_dien_thoai, dia_chi,
                         ISNULL(trang_thai, 'Active') AS trang_thai
                  FROM khach_hang
                  WHERE ma_khach_hang LIKE @keyword
                     OR so_cccd LIKE @keyword
                     OR ho_ten LIKE @keyword
                     OR so_dien_thoai LIKE @keyword
                     OR dia_chi LIKE @keyword
                     OR ISNULL(trang_thai, 'Active') LIKE @keyword
                  ORDER BY ma_khach_hang",
                CommandType.Text,
                new SqlParameter("@keyword", "%" + keyword + "%"));

            return table.AsEnumerable().Select(Map).ToList();
        }


        public bool CccdDaTonTai(string cccd, string maKhachHangBoQua = null)
        {
            cccd = (cccd ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(cccd))
            {
                return false;
            }

            const string query = @"SELECT COUNT(1)
FROM khach_hang
WHERE so_cccd = @so_cccd
  AND (@ma_khach_hang_bo_qua IS NULL OR ma_khach_hang <> @ma_khach_hang_bo_qua)";

            var count = Convert.ToInt32(Db.ExecuteScalar(
                query,
                CommandType.Text,
                new SqlParameter("@so_cccd", cccd),
                new SqlParameter("@ma_khach_hang_bo_qua", string.IsNullOrWhiteSpace(maKhachHangBoQua) ? (object)DBNull.Value : maKhachHangBoQua)));

            return count > 0;
        }

        public void Add(KhachHang model, string maNhanVien = null)
        {
            Db.ExecuteNonQuery(
                "sp_them_khach_hang",
                CommandType.StoredProcedure,
                new SqlParameter("@so_cccd", model.CCCD),
                new SqlParameter("@ho_ten", model.HoTen),
                new SqlParameter("@so_dien_thoai", model.SoDienThoai),
                new SqlParameter("@dia_chi", model.DiaChi));

            var khachHangMoi = GetByCccd(model.CCCD) ?? model;
            nhatKyService.Ghi(
                maNhanVien,
                "Thêm khách hàng " + BuildKhachHangSummary(khachHangMoi),
                "khach_hang",
                null,
                BuildKhachHangSnapshot(khachHangMoi));
        }

        public void Update(KhachHang model, string maNhanVien = null)
        {
            var khachHangCu = GetByMa(model.MaKhachHang);
            Db.ExecuteNonQuery(
                "sp_sua_khach_hang",
                CommandType.StoredProcedure,
                new SqlParameter("@ma_khach_hang", model.MaKhachHang),
                new SqlParameter("@ho_ten", model.HoTen),
                new SqlParameter("@so_dien_thoai", model.SoDienThoai),
                new SqlParameter("@dia_chi", model.DiaChi));

            var khachHangMoi = GetByMa(model.MaKhachHang) ?? model;
            nhatKyService.Ghi(
                maNhanVien,
                "Cập nhật khách hàng " + BuildKhachHangSummary(khachHangMoi),
                "khach_hang",
                BuildKhachHangSnapshot(khachHangCu),
                BuildKhachHangSnapshot(khachHangMoi));
        }

        public void CapNhatTrangThai(string maKhachHang, bool kichHoat, string maNhanVien = null)
        {
            var khachHangCu = GetByMa(maKhachHang);
            Db.ExecuteNonQuery(
                "sp_cap_nhat_trang_thai_khach_hang",
                CommandType.StoredProcedure,
                new SqlParameter("@ma_khach_hang", maKhachHang),
                new SqlParameter("@trang_thai", kichHoat ? "Active" : "Unactive"));

            var khachHangMoi = GetByMa(maKhachHang) ?? khachHangCu;
            nhatKyService.Ghi(
                maNhanVien,
                "Cập nhật trạng thái khách hàng " + BuildKhachHangSummary(khachHangMoi) + " sang " + (kichHoat ? "Active" : "Unactive"),
                "khach_hang",
                BuildKhachHangSnapshot(khachHangCu),
                BuildKhachHangSnapshot(khachHangMoi));
        }

        private KhachHang GetByMa(string maKhachHang)
        {
            if (string.IsNullOrWhiteSpace(maKhachHang))
            {
                return null;
            }

            var table = Db.ExecuteDataTable(
                @"SELECT TOP 1 ma_khach_hang, so_cccd, ho_ten, so_dien_thoai, dia_chi,
                         ISNULL(trang_thai, 'Active') AS trang_thai
                  FROM khach_hang
                  WHERE ma_khach_hang = @maKhachHang",
                CommandType.Text,
                new SqlParameter("@maKhachHang", maKhachHang));

            return table.Rows.Count == 0 ? null : Map(table.Rows[0]);
        }

        private KhachHang GetByCccd(string cccd)
        {
            if (string.IsNullOrWhiteSpace(cccd))
            {
                return null;
            }

            var table = Db.ExecuteDataTable(
                @"SELECT TOP 1 ma_khach_hang, so_cccd, ho_ten, so_dien_thoai, dia_chi,
                         ISNULL(trang_thai, 'Active') AS trang_thai
                  FROM khach_hang
                  WHERE so_cccd = @cccd",
                CommandType.Text,
                new SqlParameter("@cccd", cccd));

            return table.Rows.Count == 0 ? null : Map(table.Rows[0]);
        }

        private static KhachHang Map(DataRow row)
        {
            return new KhachHang
            {
                MaKhachHang = row["ma_khach_hang"].ToString(),
                CCCD = row["so_cccd"].ToString(),
                HoTen = row["ho_ten"].ToString(),
                SoDienThoai = row["so_dien_thoai"].ToString(),
                DiaChi = row["dia_chi"].ToString(),
                TrangThai = row.Table.Columns.Contains("trang_thai") ? row["trang_thai"].ToString() : "Active"
            };
        }

        private static string BuildKhachHangSummary(KhachHang model)
        {
            if (model == null)
            {
                return "không xác định";
            }

            return string.Format("{0} - {1}", model.MaKhachHang, model.HoTen);
        }

        private static string BuildKhachHangSnapshot(KhachHang model)
        {
            if (model == null)
            {
                return string.Empty;
            }

            return string.Format(
                "Mã KH: {0}; Họ tên: {1}; CCCD: {2}; SĐT: {3}; Địa chỉ: {4}; Trạng thái: {5}",
                model.MaKhachHang,
                model.HoTen,
                model.CCCD,
                model.SoDienThoai,
                model.DiaChi,
                model.TrangThaiHienThi);
        }

        private static void EnsureTrangThaiColumn()
        {
            if (daKiemTraMigration)
            {
                return;
            }

            lock (syncRoot)
            {
                if (daKiemTraMigration)
                {
                    return;
                }

                Db.ExecuteNonQuery(@"
IF COL_LENGTH('khach_hang', 'trang_thai') IS NULL
BEGIN
    ALTER TABLE khach_hang ADD trang_thai NVARCHAR(20) NOT NULL CONSTRAINT DF_khach_hang_trang_thai DEFAULT N'Active';
    UPDATE khach_hang SET trang_thai = N'Active' WHERE trang_thai IS NULL;
END;

IF NOT EXISTS (
    SELECT 1 FROM sys.check_constraints 
    WHERE name = 'CK_khach_hang_trang_thai'
)
BEGIN
    ALTER TABLE khach_hang WITH NOCHECK
    ADD CONSTRAINT CK_khach_hang_trang_thai CHECK (trang_thai IN (N'Active', N'Unactive'));
END;

EXEC('CREATE OR ALTER PROC sp_cap_nhat_trang_thai_khach_hang
    @ma_khach_hang VARCHAR(10),
    @trang_thai NVARCHAR(20)
AS
BEGIN
    UPDATE khach_hang
    SET trang_thai = @trang_thai
    WHERE ma_khach_hang = @ma_khach_hang;
END;');
", CommandType.Text);

                daKiemTraMigration = true;
            }
        }
    }
}
