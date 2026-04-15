using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyTietKiemNganHang.Services
{
    public class NhatKyHeThongService
    {
        public void Ghi(string maNhanVien, string hanhDong, string tenBang, string giaTriCu = null, string giaTriMoi = null)
        {
            using (var connection = Db.CreateConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    Ghi(connection, transaction, maNhanVien, hanhDong, tenBang, giaTriCu, giaTriMoi);
                    transaction.Commit();
                }
            }
        }

        public void Ghi(SqlConnection connection, SqlTransaction transaction, string maNhanVien, string hanhDong, string tenBang, string giaTriCu = null, string giaTriMoi = null)
        {
            if (connection == null)
            {
                throw new InvalidOperationException("Kết nối ghi nhật ký không hợp lệ.");
            }

            if (string.IsNullOrWhiteSpace(hanhDong))
            {
                throw new InvalidOperationException("Hành động nhật ký không hợp lệ.");
            }

            using (var command = new SqlCommand(
                @"INSERT INTO nhat_ky_he_thong (ma_nhat_ky, ma_nhan_vien, hanh_dong, ten_bang, gia_tri_cu, gia_tri_moi, thoi_gian)
                  VALUES (@maNhatKy, @maNhanVien, @hanhDong, @tenBang, @giaTriCu, @giaTriMoi, GETDATE())",
                connection,
                transaction))
            {
                command.Parameters.AddWithValue("@maNhatKy", TaoMaNhatKy(connection, transaction));
                command.Parameters.AddWithValue("@maNhanVien", ResolveMaNhanVien(maNhanVien));
                command.Parameters.AddWithValue("@hanhDong", hanhDong.Trim());
                command.Parameters.AddWithValue("@tenBang", string.IsNullOrWhiteSpace(tenBang) ? (object)DBNull.Value : tenBang.Trim());
                command.Parameters.AddWithValue("@giaTriCu", string.IsNullOrWhiteSpace(giaTriCu) ? (object)DBNull.Value : giaTriCu.Trim());
                command.Parameters.AddWithValue("@giaTriMoi", string.IsNullOrWhiteSpace(giaTriMoi) ? (object)DBNull.Value : giaTriMoi.Trim());
                command.ExecuteNonQuery();
            }
        }

        private static string TaoMaNhatKy(SqlConnection connection, SqlTransaction transaction)
        {
            using (var command = new SqlCommand(
                "SELECT MAX(CAST(SUBSTRING(ma_nhat_ky, 3, LEN(ma_nhat_ky)) AS INT)) FROM nhat_ky_he_thong",
                connection,
                transaction))
            {
                var result = command.ExecuteScalar();
                var currentMax = result == DBNull.Value || result == null ? 0 : Convert.ToInt32(result);
                return "NK" + (currentMax + 1).ToString("000");
            }
        }

        private static string ResolveMaNhanVien(string maNhanVien)
        {
            return string.IsNullOrWhiteSpace(maNhanVien) ? "NV001" : maNhanVien.Trim();
        }
    }
}
