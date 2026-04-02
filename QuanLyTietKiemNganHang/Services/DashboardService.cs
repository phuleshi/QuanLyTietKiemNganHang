using QuanLyTietKiemNganHang.Models;
using System.Linq;

namespace QuanLyTietKiemNganHang.Services
{
    public class DashboardService
    {
        public DashboardStats GetStats()
        {
            return new DashboardStats
            {
                TongKhachHang = MockDatabase.KhachHangs.Count,
                KhachHangHoatDong = MockDatabase.KhachHangs.Count(x => x.TrangThai == "Hoạt động"),
                TongNhanVien = MockDatabase.NhanViens.Count,
                NhanVienDangLam = MockDatabase.NhanViens.Count(x => x.TrangThai == "Đang làm"),
                TongSoTietKiem = MockDatabase.SoTietKiems.Count,
                SoTietKiemDangHoatDong = MockDatabase.SoTietKiems.Count(x => x.TrangThai == "Đang gửi"),
                ThongBaoHeThong = "Đăng nhập bằng mã nhân viên. Dữ liệu hiện dùng mock data trong bộ nhớ, bao gồm thông tin sổ tiết kiệm và lãi suất."
            };
        }
    }
}
