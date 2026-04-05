using QuanLyTietKiemNganHang.Models;
using System;
using System.Data;

namespace QuanLyTietKiemNganHang.Services
{
    public class DashboardService
    {
        public DashboardStats GetStats()
        {
            var table = Db.ExecuteDataTable(
                @"SELECT 
                    (SELECT COUNT(*) FROM khach_hang) AS TongKhachHang,
                    (SELECT COUNT(*) FROM nhan_vien) AS TongNhanVien,
                    (SELECT COUNT(*) FROM so_tiet_kiem) AS TongSoTietKiem,
                    (SELECT COUNT(*) FROM so_tiet_kiem WHERE trang_thai = N'Dang_mo') AS SoTietKiemDangMo,
                    (SELECT COUNT(*) FROM giao_dich) AS SoGiaoDich,
                    (SELECT COUNT(*) FROM goi_tiet_kiem) AS SoGoiTietKiem",
                CommandType.Text);

            var row = table.Rows[0];
            return new DashboardStats
            {
                TongKhachHang = Convert.ToInt32(row["TongKhachHang"]),
                TongNhanVien = Convert.ToInt32(row["TongNhanVien"]),
                TongSoTietKiem = Convert.ToInt32(row["TongSoTietKiem"]),
                SoTietKiemDangMo = Convert.ToInt32(row["SoTietKiemDangMo"]),
                SoGiaoDich = Convert.ToInt32(row["SoGiaoDich"]),
                SoGoiTietKiem = Convert.ToInt32(row["SoGoiTietKiem"]),
                ThongBaoHeThong = "Dữ liệu đang được đọc trực tiếp từ SQL Server. CRUD Khách hàng và Nhân viên sử dụng stored procedure có sẵn trong file SQL."
            };
        }
    }
}
