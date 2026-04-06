using QuanLyTietKiemNganHang.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace QuanLyTietKiemNganHang.Services
{
    public class XuLySoTietKiem
    {
        public List<KhachHang> GetKhachHangs()
        {
            var service = new KhachHangService();
            return service.GetAll();
        }

        public List<LoaiTietKiem> GetLoaiTietKiems()
        {
            var table = Db.ExecuteDataTable(
                @"SELECT ma_goi, ten_goi, lai_suat_nam, ky_han_thang
                  FROM goi_tiet_kiem
                  ORDER BY ky_han_thang, ten_goi",
                CommandType.Text);

            return table.AsEnumerable().Select(MapLoaiTietKiem).ToList();
        }

        public List<SoTietKiemDanhSachItem> GetDanhSach(string keyword)
        {
            keyword = (keyword ?? string.Empty).Trim();

            var table = Db.ExecuteDataTable(
                @"SELECT s.ma_so,
                         s.ma_khach_hang,
                         k.ho_ten,
                         g.ten_goi,
                         s.so_tien_goc,
                         s.so_du_hien_tai,
                         s.lai_suat_chot,
                         s.ngay_mo,
                         s.ngay_dao_han,
                         s.trang_thai,
                         s.ma_nv_mo,
                         nv.ten_nhan_vien
                  FROM so_tiet_kiem s
                  INNER JOIN khach_hang k ON s.ma_khach_hang = k.ma_khach_hang
                  INNER JOIN goi_tiet_kiem g ON s.ma_goi = g.ma_goi
                  LEFT JOIN nhan_vien nv ON s.ma_nv_mo = nv.ma_nv
                  WHERE @keyword = ''
                     OR s.ma_so LIKE @search
                     OR s.ma_khach_hang LIKE @search
                     OR k.ho_ten LIKE @search
                     OR g.ten_goi LIKE @search
                     OR s.trang_thai LIKE @search
                  ORDER BY s.ngay_mo DESC, s.ma_so DESC",
                CommandType.Text,
                new SqlParameter("@keyword", keyword),
                new SqlParameter("@search", "%" + keyword + "%"));

            return table.AsEnumerable().Select(MapDanhSachItem).ToList();
        }

        public SoTietKiemDanhSachItem GetByMaSo(string maSo)
        {
            var table = Db.ExecuteDataTable(
                @"SELECT TOP 1 s.ma_so,
                                s.ma_khach_hang,
                                k.ho_ten,
                                g.ten_goi,
                                s.so_tien_goc,
                                s.so_du_hien_tai,
                                s.lai_suat_chot,
                                s.ngay_mo,
                                s.ngay_dao_han,
                                s.trang_thai,
                                s.ma_nv_mo,
                                nv.ten_nhan_vien
                  FROM so_tiet_kiem s
                  INNER JOIN khach_hang k ON s.ma_khach_hang = k.ma_khach_hang
                  INNER JOIN goi_tiet_kiem g ON s.ma_goi = g.ma_goi
                  LEFT JOIN nhan_vien nv ON s.ma_nv_mo = nv.ma_nv
                  WHERE s.ma_so = @maSo",
                CommandType.Text,
                new SqlParameter("@maSo", maSo));

            if (table.Rows.Count == 0)
            {
                return null;
            }

            return MapDanhSachItem(table.Rows[0]);
        }

        public void MoSo(string maKhachHang, string maGoi, string maNhanVien, decimal soTien)
        {
            if (string.IsNullOrWhiteSpace(maKhachHang))
            {
                throw new InvalidOperationException("Khách hàng chưa được chọn.");
            }

            if (string.IsNullOrWhiteSpace(maGoi))
            {
                throw new InvalidOperationException("Loại tiết kiệm chưa được chọn.");
            }

            if (soTien <= 0)
            {
                throw new InvalidOperationException("Số tiền gửi phải lớn hơn 0.");
            }

            Db.ExecuteNonQuery(
                "sp_mo_so",
                CommandType.StoredProcedure,
                new SqlParameter("@ma_khach_hang", maKhachHang),
                new SqlParameter("@ma_goi", maGoi),
                new SqlParameter("@ma_nv", ResolveMaNhanVien(maNhanVien)),
                new SqlParameter("@so_tien", soTien));
        }

        public void SuaSo(string maSo, decimal soDu, string trangThai)
        {
            if (string.IsNullOrWhiteSpace(maSo))
            {
                throw new InvalidOperationException("Sổ tiết kiệm không hợp lệ.");
            }

            if (soDu < 0)
            {
                throw new InvalidOperationException("Số dư không được nhỏ hơn 0.");
            }

            Db.ExecuteNonQuery(
                "sp_sua_so",
                CommandType.StoredProcedure,
                new SqlParameter("@ma_so", maSo),
                new SqlParameter("@so_du", soDu),
                new SqlParameter("@trang_thai", trangThai));
        }

        public void XoaSo(string maSo)
        {
            if (string.IsNullOrWhiteSpace(maSo))
            {
                throw new InvalidOperationException("Sổ tiết kiệm không hợp lệ.");
            }

            using (var connection = Db.CreateConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    using (var deleteGiaoDich = new SqlCommand(
                        "DELETE FROM giao_dich WHERE ma_so = @maSo",
                        connection,
                        transaction))
                    {
                        deleteGiaoDich.Parameters.AddWithValue("@maSo", maSo);
                        deleteGiaoDich.ExecuteNonQuery();
                    }

                    using (var deleteSo = new SqlCommand(
                        "DELETE FROM so_tiet_kiem WHERE ma_so = @maSo",
                        connection,
                        transaction))
                    {
                        deleteSo.Parameters.AddWithValue("@maSo", maSo);
                        deleteSo.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }
        }

        public void TatToan(string maSo, string maNhanVien)
        {
            ExecuteRutTien(maSo, ResolveMaNhanVien(maNhanVien), null, true);
        }

        public void RutGocTungPhan(string maSo, decimal soTienRut, string maNhanVien)
        {
            if (soTienRut <= 0)
            {
                throw new InvalidOperationException("Số tiền rút phải lớn hơn 0.");
            }

            ExecuteRutTien(maSo, ResolveMaNhanVien(maNhanVien), soTienRut, false);
        }

        private void ExecuteRutTien(string maSo, string maNhanVien, decimal? soTienRut, bool tatToan)
        {
            using (var connection = Db.CreateConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var so = GetSoTietKiemForUpdate(connection, transaction, maSo);
                    if (so == null)
                    {
                        throw new InvalidOperationException("Không tìm thấy sổ tiết kiệm.");
                    }

                    if (!string.Equals(so.TrangThai, "Dang_mo", StringComparison.OrdinalIgnoreCase))
                    {
                        throw new InvalidOperationException("Sổ đã tất toán, không thể thực hiện giao dịch này.");
                    }

                    var amount = tatToan ? so.SoDuHienTai : soTienRut.GetValueOrDefault();
                    if (amount <= 0)
                    {
                        throw new InvalidOperationException("Sổ không còn số dư để xử lý.");
                    }

                    if (!tatToan && amount >= so.SoDuHienTai)
                    {
                        throw new InvalidOperationException("Rút gốc từng phần phải nhỏ hơn số dư hiện tại.");
                    }

                    var soDuConLai = so.SoDuHienTai - amount;
                    var trangThaiMoi = tatToan ? "Da_tat_toan" : so.TrangThai;

                    using (var updateCommand = new SqlCommand(
                        @"UPDATE so_tiet_kiem
                          SET so_du_hien_tai = @soDu,
                              trang_thai = @trangThai
                          WHERE ma_so = @maSo", connection, transaction))
                    {
                        updateCommand.Parameters.AddWithValue("@soDu", soDuConLai);
                        updateCommand.Parameters.AddWithValue("@trangThai", trangThaiMoi);
                        updateCommand.Parameters.AddWithValue("@maSo", maSo);
                        updateCommand.ExecuteNonQuery();
                    }

                    InsertGiaoDichRutTien(connection, transaction, maSo, maNhanVien, amount);
                    transaction.Commit();
                }
            }
        }

        private static SoTietKiem GetSoTietKiemForUpdate(SqlConnection connection, SqlTransaction transaction, string maSo)
        {
            using (var command = new SqlCommand(
                @"SELECT TOP 1 ma_so, so_tien_goc, so_du_hien_tai, lai_suat_chot, ngay_mo, ngay_dao_han, trang_thai
                  FROM so_tiet_kiem
                  WHERE ma_so = @maSo", connection, transaction))
            {
                command.Parameters.AddWithValue("@maSo", maSo);
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }

                    return new SoTietKiem
                    {
                        MaSo = reader["ma_so"].ToString(),
                        SoTienGoc = reader["so_tien_goc"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["so_tien_goc"]),
                        SoDuHienTai = reader["so_du_hien_tai"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["so_du_hien_tai"]),
                        LaiSuatChot = reader["lai_suat_chot"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["lai_suat_chot"]),
                        NgayMo = reader["ngay_mo"] == DBNull.Value ? DateTime.Today : Convert.ToDateTime(reader["ngay_mo"]),
                        NgayDaoHan = reader["ngay_dao_han"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["ngay_dao_han"]),
                        TrangThai = reader["trang_thai"].ToString()
                    };
                }
            }
        }

        private static void InsertGiaoDichRutTien(SqlConnection connection, SqlTransaction transaction, string maSo, string maNhanVien, decimal soTien)
        {
            var maGiaoDich = TaoMaGiaoDich(connection, transaction);
            using (var command = new SqlCommand(
                @"INSERT INTO giao_dich (ma_gd, ma_so, ma_nv, loai_gd, so_tien, ngay_gd)
                  VALUES (@maGd, @maSo, @maNv, N'Rut_tien', @soTien, GETDATE())", connection, transaction))
            {
                command.Parameters.AddWithValue("@maGd", maGiaoDich);
                command.Parameters.AddWithValue("@maSo", maSo);
                command.Parameters.AddWithValue("@maNv", maNhanVien);
                command.Parameters.AddWithValue("@soTien", soTien);
                command.ExecuteNonQuery();
            }
        }

        private static string TaoMaGiaoDich(SqlConnection connection, SqlTransaction transaction)
        {
            using (var command = new SqlCommand(
                "SELECT MAX(CAST(SUBSTRING(ma_gd, 3, LEN(ma_gd)) AS INT)) FROM giao_dich",
                connection,
                transaction))
            {
                var result = command.ExecuteScalar();
                var currentMax = result == DBNull.Value || result == null ? 0 : Convert.ToInt32(result);
                return "GD" + (currentMax + 1).ToString("000");
            }
        }

        private static LoaiTietKiem MapLoaiTietKiem(DataRow row)
        {
            return new LoaiTietKiem
            {
                MaGoi = row["ma_goi"].ToString(),
                TenGoi = row["ten_goi"].ToString(),
                LaiSuatNam = row["lai_suat_nam"] == DBNull.Value ? 0 : Convert.ToDecimal(row["lai_suat_nam"]),
                KyHanThang = row["ky_han_thang"] == DBNull.Value ? 0 : Convert.ToInt32(row["ky_han_thang"])
            };
        }

        private static SoTietKiemDanhSachItem MapDanhSachItem(DataRow row)
        {
            var item = new SoTietKiemDanhSachItem
            {
                MaSo = row["ma_so"].ToString(),
                MaKhachHang = row["ma_khach_hang"].ToString(),
                ChuSoHuu = row["ho_ten"].ToString(),
                TenGoiTietKiem = row["ten_goi"].ToString(),
                SoTienGui = row["so_tien_goc"] == DBNull.Value ? 0 : Convert.ToDecimal(row["so_tien_goc"]),
                SoDuHienTai = row["so_du_hien_tai"] == DBNull.Value ? 0 : Convert.ToDecimal(row["so_du_hien_tai"]),
                LaiSuatApDung = row["lai_suat_chot"] == DBNull.Value ? 0 : Convert.ToDecimal(row["lai_suat_chot"]),
                NgayMo = row["ngay_mo"] == DBNull.Value ? DateTime.Today : Convert.ToDateTime(row["ngay_mo"]),
                NgayDaoHan = row["ngay_dao_han"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["ngay_dao_han"]),
                TrangThai = row["trang_thai"].ToString(),
                MaNhanVienMo = row["ma_nv_mo"].ToString(),
                TenNhanVienMo = row.Table.Columns.Contains("ten_nhan_vien") ? row["ten_nhan_vien"].ToString() : string.Empty
            };

            item.TrangThaiHienThi = GetDisplayTrangThai(item);
            return item;
        }

        private static string GetDisplayTrangThai(SoTietKiemDanhSachItem item)
        {
            if (string.Equals(item.TrangThai, "Da_tat_toan", StringComparison.OrdinalIgnoreCase))
            {
                return "Đã tất toán";
            }

            if (item.NgayDaoHan.HasValue && item.NgayDaoHan.Value.Date < DateTime.Today)
            {
                return "Đến hạn";
            }

            if (!item.NgayDaoHan.HasValue)
            {
                return "Không kỳ hạn";
            }

            return "Đang mở";
        }

        private static string ResolveMaNhanVien(string maNhanVien)
        {
            return string.IsNullOrWhiteSpace(maNhanVien) ? "NV001" : maNhanVien;
        }
    }
}
