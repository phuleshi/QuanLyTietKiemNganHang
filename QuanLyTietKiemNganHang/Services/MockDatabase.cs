using QuanLyTietKiemNganHang.Models;
using System;
using System.Collections.Generic;

namespace QuanLyTietKiemNganHang.Services
{
    public static class MockDatabase
    {
        public static readonly List<KhachHang> KhachHangs = new List<KhachHang>
        {
            new KhachHang { Id = 1, MaKhachHang = "KH001", HoTen = "Nguyễn Văn An", SoDienThoai = "0912345678", Email = "nvan@gmail.com", CCCD = "079123456789", DiaChi = "Hà Nội", NgaySinh = new DateTime(1995,1,10), TrangThai = "Hoạt động" },
            new KhachHang { Id = 2, MaKhachHang = "KH002", HoTen = "Trần Thị Bình", SoDienThoai = "0987654321", Email = "ttbinh@gmail.com", CCCD = "079123456780", DiaChi = "Đà Nẵng", NgaySinh = new DateTime(1998,7,22), TrangThai = "Hoạt động" },
            new KhachHang { Id = 3, MaKhachHang = "KH003", HoTen = "Lê Minh Cường", SoDienThoai = "0901234567", Email = "lmcuong@gmail.com", CCCD = "079123456781", DiaChi = "TP HCM", NgaySinh = new DateTime(1992,11,3), TrangThai = "Tạm khóa" }
        };

        public static readonly List<NhanVien> NhanViens = new List<NhanVien>
        {
            new NhanVien { Id = 1, MaNhanVien = "NV001", HoTen = "Phạm Anh Dũng", SoDienThoai = "0911111111", Email = "pad@bank.local", ChucVu = "Giao dịch viên", MatKhau = "123456", NgayVaoLam = new DateTime(2023,1,15), LuongCoBan = 12000000, TrangThai = "Đang làm" },
            new NhanVien { Id = 2, MaNhanVien = "NV002", HoTen = "Võ Thị Em", SoDienThoai = "0922222222", Email = "vte@bank.local", ChucVu = "Chuyên viên khách hàng", MatKhau = "123456", NgayVaoLam = new DateTime(2022,9,1), LuongCoBan = 14500000, TrangThai = "Đang làm" },
            new NhanVien { Id = 3, MaNhanVien = "NV003", HoTen = "Hoàng Quốc Phong", SoDienThoai = "0933333333", Email = "hqp@bank.local", ChucVu = "Trưởng nhóm giao dịch", MatKhau = "123456", NgayVaoLam = new DateTime(2021,6,20), LuongCoBan = 22000000, TrangThai = "Nghỉ phép" }
        };

        public static readonly List<SoTietKiem> SoTietKiems = new List<SoTietKiem>
        {
            new SoTietKiem { Id = 1, MaSo = "STK001", KhachHangId = 1, NhanVienMoSoId = 1, SoTienGui = 50000000, LaiSuat = 5.2m, NgayMoSo = new DateTime(2026, 1, 5), TrangThai = "Đang gửi" },
            new SoTietKiem { Id = 2, MaSo = "STK002", KhachHangId = 1, NhanVienMoSoId = 2, SoTienGui = 120000000, LaiSuat = 5.8m, NgayMoSo = new DateTime(2026, 2, 10), TrangThai = "Đang gửi" },
            new SoTietKiem { Id = 3, MaSo = "STK003", KhachHangId = 2, NhanVienMoSoId = 1, SoTienGui = 80000000, LaiSuat = 4.9m, NgayMoSo = new DateTime(2026, 3, 1), TrangThai = "Tất toán" }
        };
    }
}
