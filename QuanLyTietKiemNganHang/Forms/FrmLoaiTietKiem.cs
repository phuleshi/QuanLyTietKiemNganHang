using QuanLyTietKiemNganHang.Helpers;
using QuanLyTietKiemNganHang.Models;
using QuanLyTietKiemNganHang.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyTietKiemNganHang.Forms
{
    public partial class FrmLoaiTietKiem : Form
    {
        private readonly XuLyLoaiTietKiem service = new XuLyLoaiTietKiem();
        private readonly NhanVien currentUser;
        private List<LoaiTietKiem> items = new List<LoaiTietKiem>();
        private string selectedMaGoi = string.Empty;

        public FrmLoaiTietKiem(NhanVien currentUser)
        {
            this.currentUser = currentUser;
            InitializeComponent();
            ApplyTheme();
            WireEvents();
            EnsureAuthorization();
            LoadData();
        }

        private void EnsureAuthorization()
        {
            if (currentUser == null || !currentUser.LaAdmin)
            {
                MessageBox.Show("Chỉ admin mới có chức năng quản lý gói tiết kiệm.", "Không có quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
        }

        private void ApplyTheme()
        {
            BackColor = ControlFactory.BackgroundColor;
            topPanel.BackColor = Color.White;
            contentWrap.BackColor = ControlFactory.BackgroundColor;
            contentCard.BackColor = ControlFactory.SurfaceColor;
            contentCard.BorderStyle = BorderStyle.FixedSingle;

            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.ForeColor = ControlFactory.TextColor;
            lblSelected.ForeColor = ControlFactory.MutedTextColor;

            StyleSecondaryButton(btnTaiLai);
            StyleSecondaryButton(btnSua);
            StyleDangerButton(btnXoa);
            StylePrimaryButton(btnThem);
            GridStyler.Apply(grid);
        }

        private void WireEvents()
        {
            txtSearch.TextChanged += (s, e) => LoadData();
            btnTaiLai.Click += (s, e) => LoadData();
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            grid.CellClick += Grid_CellClick;
        }

        private static void StyleSecondaryButton(Button button)
        {
            button.BackColor = Color.White;
            button.ForeColor = ControlFactory.PrimaryColor;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
            button.FlatAppearance.BorderColor = ControlFactory.BorderColor;
            button.FlatAppearance.BorderSize = 1;
        }

        private static void StylePrimaryButton(Button button)
        {
            button.BackColor = ControlFactory.PrimaryColor;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
            button.FlatAppearance.BorderSize = 0;
        }

        private static void StyleDangerButton(Button button)
        {
            button.BackColor = Color.FromArgb(220, 38, 38);
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
            button.FlatAppearance.BorderSize = 0;
        }

        private void LoadData()
        {
            try
            {
                items = service.GetDanhSach(txtSearch != null ? txtSearch.Text : string.Empty);
                grid.DataSource = items.Select(x => new
                {
                    x.MaGoi,
                    x.TenGoi,
                    LaiSuat = x.LaiSuatNam.ToString("0.00") + "%/năm",
                    x.KyHanHienThi
                }).ToList();
                if (grid.Columns["MaGoi"] != null) grid.Columns["MaGoi"].HeaderText = "Mã gói";
                if (grid.Columns["TenGoi"] != null) grid.Columns["TenGoi"].HeaderText = "Tên gói";
                if (grid.Columns["LaiSuat"] != null) grid.Columns["LaiSuat"].HeaderText = "Lãi suất";
                if (grid.Columns["KyHanHienThi"] != null) grid.Columns["KyHanHienThi"].HeaderText = "Kỳ hạn";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được danh sách gói: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            selectedMaGoi = grid.Rows[e.RowIndex].Cells["MaGoi"].Value.ToString();
            var selected = items.Find(x => x.MaGoi == selectedMaGoi);
            if (selected == null) return;
            txtTenGoi.Text = selected.TenGoi;
            numLaiSuat.Value = selected.LaiSuatNam;
            numKyHan.Value = selected.KyHanThang;
            lblSelected.Text = "Đang chọn: " + selected.MaGoi;
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                service.Them(txtTenGoi.Text, numLaiSuat.Value, (int)numKyHan.Value);
                MessageBox.Show("Thêm gói tiết kiệm thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thêm gói: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedMaGoi))
            {
                MessageBox.Show("Vui lòng chọn gói cần cập nhật.", "Chưa chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                service.Sua(selectedMaGoi, txtTenGoi.Text, numLaiSuat.Value, (int)numKyHan.Value);
                MessageBox.Show("Cập nhật gói tiết kiệm thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể cập nhật gói: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedMaGoi))
            {
                MessageBox.Show("Vui lòng chọn gói cần xóa.", "Chưa chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa gói " + selectedMaGoi + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                service.Xoa(selectedMaGoi);
                selectedMaGoi = string.Empty;
                lblSelected.Text = "Chưa chọn gói.";
                MessageBox.Show("Xóa gói tiết kiệm thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa gói: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FrmLoaiTietKiem_Load(object sender, EventArgs e)
        {

        }

    }
}
