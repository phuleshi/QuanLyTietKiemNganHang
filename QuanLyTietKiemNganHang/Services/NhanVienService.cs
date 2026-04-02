using QuanLyTietKiemNganHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyTietKiemNganHang.Services
{
    public class NhanVienService
    {
        public List<NhanVien> GetAll() => MockDatabase.NhanViens.OrderBy(x => x.Id).ToList();

        public List<NhanVien> Search(string keyword)
        {
            keyword = (keyword ?? string.Empty).Trim().ToLower();
            return GetAll().Where(x =>
                x.MaNhanVien.ToLower().Contains(keyword) ||
                x.HoTen.ToLower().Contains(keyword) ||
                x.SoDienThoai.ToLower().Contains(keyword) ||
                x.Email.ToLower().Contains(keyword) ||
                x.ChucVu.ToLower().Contains(keyword)).ToList();
        }

        public bool IsDuplicateMaNhanVien(string maNhanVien, int excludeId)
        {
            var value = (maNhanVien ?? string.Empty).Trim();
            return MockDatabase.NhanViens.Any(x =>
                x.Id != excludeId &&
                string.Equals(x.MaNhanVien, value, StringComparison.OrdinalIgnoreCase));
        }

        public void Add(NhanVien model)
        {
            model.Id = MockDatabase.NhanViens.Any() ? MockDatabase.NhanViens.Max(x => x.Id) + 1 : 1;
            if (string.IsNullOrWhiteSpace(model.MatKhau)) model.MatKhau = "123456";
            MockDatabase.NhanViens.Add(model);
        }

        public void Update(NhanVien model)
        {
            var current = MockDatabase.NhanViens.FirstOrDefault(x => x.Id == model.Id);
            if (current == null) return;
            current.MaNhanVien = model.MaNhanVien;
            current.HoTen = model.HoTen;
            current.SoDienThoai = model.SoDienThoai;
            current.Email = model.Email;
            current.ChucVu = model.ChucVu;
            if (!string.IsNullOrWhiteSpace(model.MatKhau)) current.MatKhau = model.MatKhau;
            current.NgayVaoLam = model.NgayVaoLam;
            current.LuongCoBan = model.LuongCoBan;
            current.TrangThai = model.TrangThai;
        }

        public void Delete(int id)
        {
            var current = MockDatabase.NhanViens.FirstOrDefault(x => x.Id == id);
            if (current != null) MockDatabase.NhanViens.Remove(current);
        }
    }
}
