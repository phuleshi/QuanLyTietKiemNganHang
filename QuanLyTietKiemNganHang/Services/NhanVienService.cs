using QuanLyTietKiemNganHang.Helpers;
using QuanLyTietKiemNganHang.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace QuanLyTietKiemNganHang.Services
{
    public class NhanVienService
    {
        private readonly NhatKyHeThongService nhatKyService = new NhatKyHeThongService();

        public List<NhanVien> GetAll()
        {
            var table = Db.ExecuteDataTable(
                @"SELECT ma_nv, ten_nhan_vien, tai_khoan, mat_khau, vai_tro
                  FROM nhan_vien
                  ORDER BY ma_nv",
                CommandType.Text);

            return table.AsEnumerable().Select(Map).ToList();
        }

        public List<NhanVien> Search(string keyword)
        {
            keyword = (keyword ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return GetAll();
            }

            var table = Db.ExecuteDataTable(
                @"SELECT ma_nv, ten_nhan_vien, tai_khoan, mat_khau, vai_tro
                  FROM nhan_vien
                  WHERE ma_nv LIKE @keyword
                     OR ten_nhan_vien LIKE @keyword
                     OR tai_khoan LIKE @keyword
                     OR vai_tro LIKE @keyword
                  ORDER BY ma_nv",
                CommandType.Text,
                new SqlParameter("@keyword", "%" + keyword + "%"));

            return table.AsEnumerable().Select(Map).ToList();
        }

        public bool ExistsMaNhanVien(string maNhanVien)
        {
            var result = Db.ExecuteScalar(
                "SELECT COUNT(*) FROM nhan_vien WHERE ma_nv = @maNv",
                CommandType.Text,
                new SqlParameter("@maNv", maNhanVien));
            return result != null && (int)result > 0;
        }

        public bool ExistsTaiKhoan(string taiKhoan, string excludeMaNhanVien)
        {
            var query = @"SELECT COUNT(*) 
                          FROM nhan_vien 
                          WHERE tai_khoan = @taiKhoan
                            AND (@excludeMaNv = '' OR ma_nv <> @excludeMaNv)";
            var result = Db.ExecuteScalar(
                query,
                CommandType.Text,
                new SqlParameter("@taiKhoan", taiKhoan),
                new SqlParameter("@excludeMaNv", excludeMaNhanVien ?? string.Empty));
            return result != null && (int)result > 0;
        }

        public void Add(NhanVien model, string maNhanVienThucHien = null)
        {
            Db.ExecuteNonQuery(
                "sp_them_nhan_vien",
                CommandType.StoredProcedure,
                new SqlParameter("@ten_nhan_vien", model.TenNhanVien),
                new SqlParameter("@tai_khoan", model.TaiKhoan),
                new SqlParameter("@mat_khau", model.MatKhau),
                new SqlParameter("@vai_tro", RoleHelper.NormalizeRole(model.VaiTro)));

            var nhanVienMoi = GetByTaiKhoan(model.TaiKhoan) ?? model;
            nhatKyService.Ghi(
                maNhanVienThucHien,
                "Thêm nhân viên " + BuildNhanVienSummary(nhanVienMoi),
                "nhan_vien",
                null,
                BuildNhanVienSnapshot(nhanVienMoi));
        }

        public void Update(NhanVien model, string maNhanVienThucHien = null)
        {
            var nhanVienCu = GetByMa(model.MaNhanVien);

            Db.ExecuteNonQuery(
                "sp_sua_nhan_vien",
                CommandType.StoredProcedure,
                new SqlParameter("@ten_nhan_vien", model.TenNhanVien),
                new SqlParameter("@ma_nv", model.MaNhanVien),
                new SqlParameter("@tai_khoan", model.TaiKhoan),
                new SqlParameter("@mat_khau", model.MatKhau),
                new SqlParameter("@vai_tro", RoleHelper.NormalizeRole(model.VaiTro)));

            var nhanVienMoi = GetByMa(model.MaNhanVien) ?? model;
            nhatKyService.Ghi(
                maNhanVienThucHien,
                "Cập nhật nhân viên " + BuildNhanVienSummary(nhanVienMoi),
                "nhan_vien",
                BuildNhanVienSnapshot(nhanVienCu),
                BuildNhanVienSnapshot(nhanVienMoi));
        }

        public void Delete(string maNhanVien, string maNhanVienThucHien = null)
        {
            var nhanVienCu = GetByMa(maNhanVien);

            Db.ExecuteNonQuery(
                "sp_xoa_nhan_vien",
                CommandType.StoredProcedure,
                new SqlParameter("@ma_nv", maNhanVien));

            nhatKyService.Ghi(
                maNhanVienThucHien,
                "Xóa nhân viên " + BuildNhanVienSummary(nhanVienCu),
                "nhan_vien",
                BuildNhanVienSnapshot(nhanVienCu),
                null);
        }

        private NhanVien GetByMa(string maNhanVien)
        {
            if (string.IsNullOrWhiteSpace(maNhanVien))
            {
                return null;
            }

            var table = Db.ExecuteDataTable(
                @"SELECT TOP 1 ma_nv, ten_nhan_vien, tai_khoan, mat_khau, vai_tro
                  FROM nhan_vien
                  WHERE ma_nv = @maNv",
                CommandType.Text,
                new SqlParameter("@maNv", maNhanVien));

            return table.Rows.Count == 0 ? null : Map(table.Rows[0]);
        }

        private NhanVien GetByTaiKhoan(string taiKhoan)
        {
            if (string.IsNullOrWhiteSpace(taiKhoan))
            {
                return null;
            }

            var table = Db.ExecuteDataTable(
                @"SELECT TOP 1 ma_nv, ten_nhan_vien, tai_khoan, mat_khau, vai_tro
                  FROM nhan_vien
                  WHERE tai_khoan = @taiKhoan",
                CommandType.Text,
                new SqlParameter("@taiKhoan", taiKhoan));

            return table.Rows.Count == 0 ? null : Map(table.Rows[0]);
        }

        private static NhanVien Map(DataRow row)
        {
            return new NhanVien
            {
                MaNhanVien = row["ma_nv"].ToString(),
                TenNhanVien = row["ten_nhan_vien"].ToString(),
                TaiKhoan = row["tai_khoan"].ToString(),
                MatKhau = row["mat_khau"].ToString(),
                VaiTro = RoleHelper.NormalizeRole(row["vai_tro"].ToString())
            };
        }

        private static string BuildNhanVienSummary(NhanVien model)
        {
            if (model == null)
            {
                return "không xác định";
            }

            return string.Format("{0} - {1}", model.MaNhanVien, model.TenNhanVien);
        }

        private static string BuildNhanVienSnapshot(NhanVien model)
        {
            if (model == null)
            {
                return string.Empty;
            }

            return string.Format(
                "Mã NV: {0}; Tên: {1}; Tài khoản: {2}; Mật khẩu: {3}; Vai trò: {4}",
                model.MaNhanVien,
                model.TenNhanVien,
                model.TaiKhoan,
                MaskPassword(model.MatKhau),
                model.VaiTroHienThi);
        }

        private static string MaskPassword(string matKhau)
        {
            if (string.IsNullOrEmpty(matKhau))
            {
                return "(trống)";
            }

            return new string('*', matKhau.Length);
        }
    }
}
