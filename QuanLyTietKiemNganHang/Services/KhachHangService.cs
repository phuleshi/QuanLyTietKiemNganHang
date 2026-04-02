using QuanLyTietKiemNganHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyTietKiemNganHang.Services
{
    public class KhachHangService
    {
        public List<KhachHang> GetAll() => MockDatabase.KhachHangs.OrderBy(x => x.Id).ToList();

        public List<KhachHang> Search(string keyword)
        {
            keyword = (keyword ?? string.Empty).Trim().ToLower();
            return GetAll().Where(x =>
                x.MaKhachHang.ToLower().Contains(keyword) ||
                x.HoTen.ToLower().Contains(keyword) ||
                x.SoDienThoai.ToLower().Contains(keyword) ||
                x.Email.ToLower().Contains(keyword)).ToList();
        }

        public bool IsDuplicateMaKhachHang(string maKhachHang, int excludeId)
        {
            var value = (maKhachHang ?? string.Empty).Trim();
            return MockDatabase.KhachHangs.Any(x =>
                x.Id != excludeId &&
                string.Equals(x.MaKhachHang, value, StringComparison.OrdinalIgnoreCase));
        }

        public bool IsDuplicateCccd(string cccd, int excludeId)
        {
            var value = (cccd ?? string.Empty).Trim();
            return MockDatabase.KhachHangs.Any(x =>
                x.Id != excludeId &&
                string.Equals(x.CCCD, value, StringComparison.OrdinalIgnoreCase));
        }

        public void Add(KhachHang model)
        {
            model.Id = MockDatabase.KhachHangs.Any() ? MockDatabase.KhachHangs.Max(x => x.Id) + 1 : 1;
            MockDatabase.KhachHangs.Add(model);
        }

        public void Update(KhachHang model)
        {
            var current = MockDatabase.KhachHangs.FirstOrDefault(x => x.Id == model.Id);
            if (current == null) return;
            current.MaKhachHang = model.MaKhachHang;
            current.HoTen = model.HoTen;
            current.SoDienThoai = model.SoDienThoai;
            current.Email = model.Email;
            current.CCCD = model.CCCD;
            current.DiaChi = model.DiaChi;
            current.NgaySinh = model.NgaySinh;
            current.TrangThai = model.TrangThai;
        }

        public void Delete(int id)
        {
            var current = MockDatabase.KhachHangs.FirstOrDefault(x => x.Id == id);
            if (current != null) MockDatabase.KhachHangs.Remove(current);
        }
    }
}
