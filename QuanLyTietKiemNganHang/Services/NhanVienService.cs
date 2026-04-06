using QuanLyTietKiemNganHang.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace QuanLyTietKiemNganHang.Services
{
    public class NhanVienService
    {
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

        public void Add(NhanVien model)
        {
            Db.ExecuteNonQuery(
                "sp_them_nhan_vien",
                CommandType.StoredProcedure,
                new SqlParameter("@ten_nhan_vien", model.TenNhanVien),
                new SqlParameter("@tai_khoan", model.TaiKhoan),
                new SqlParameter("@mat_khau", model.MatKhau),
                new SqlParameter("@vai_tro", model.VaiTro));
        }

        public void Update(NhanVien model)
        {
            Db.ExecuteNonQuery(
                "sp_sua_nhan_vien",
                CommandType.StoredProcedure,
                new SqlParameter("@ten_nhan_vien", model.TenNhanVien),
                new SqlParameter("@ma_nv", model.MaNhanVien),
                new SqlParameter("@tai_khoan", model.TaiKhoan),
                new SqlParameter("@mat_khau", model.MatKhau),
                new SqlParameter("@vai_tro", model.VaiTro));
        }

        public void Delete(string maNhanVien)
        {
            Db.ExecuteNonQuery(
                "sp_xoa_nhan_vien",
                CommandType.StoredProcedure,
                new SqlParameter("@ma_nv", maNhanVien));
        }

        private static NhanVien Map(DataRow row)
        {
            return new NhanVien
            {
                MaNhanVien = row["ma_nv"].ToString(),
                TenNhanVien = row["ten_nhan_vien"].ToString(),
                TaiKhoan = row["tai_khoan"].ToString(),
                MatKhau = row["mat_khau"].ToString(),
                VaiTro = row["vai_tro"].ToString()
            };
        }
    }
}
