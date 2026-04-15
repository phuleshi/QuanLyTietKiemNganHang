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
    public partial class FrmDanhSachSo : Form
    {
        private readonly XuLySoTietKiem service = new XuLySoTietKiem();
        private readonly NhanVien currentUser;
        private List<SoTietKiemDanhSachItem> items = new List<SoTietKiemDanhSachItem>();
        private string selectedMaSo = string.Empty;

        public FrmDanhSachSo()
            : this(null)
        {
        }

        public FrmDanhSachSo(NhanVien currentUser)
        {
            this.currentUser = currentUser;
            InitializeComponent();
            ApplyTheme();
            WireEvents();
            LoadData();
        }

        private void ApplyTheme()
        {
            BackColor = ControlFactory.BackgroundColor;
            topPanel.BackColor = Color.White;
            contentWrap.BackColor = ControlFactory.BackgroundColor;
            contentCard.BackColor = ControlFactory.SurfaceColor;
            contentCard.BorderStyle = BorderStyle.FixedSingle;

            lblPageTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblPageTitle.ForeColor = ControlFactory.TextColor;
            lblCardTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblCardTitle.ForeColor = ControlFactory.TextColor;
            lblSelected.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            lblSelected.ForeColor = ControlFactory.MutedTextColor;

            txtSearch.Font = new Font("Segoe UI", 10);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.BackColor = Color.White;
            txtSearch.ForeColor = ControlFactory.TextColor;

            GridStyler.Apply(grid);

            StyleSecondaryButton(btnRefresh);
            StyleSecondaryButton(btnXemChiTiet);
            StyleSecondaryButton(btnSuaSo);
            StyleSecondaryButton(btnRutGoc);
            StyleDangerButton(btnXoaSo);
            StyleDangerButton(btnTatToan);
        }

        private void WireEvents()
        {
            txtSearch.TextChanged += (s, e) => LoadData();
            btnRefresh.Click += (s, e) => LoadData();
            grid.CellClick += Grid_CellClick;
            btnXemChiTiet.Click += BtnXemChiTiet_Click;
            btnSuaSo.Click += BtnSuaSo_Click;
            btnXoaSo.Click += BtnXoaSo_Click;
            btnRutGoc.Click += BtnRutGoc_Click;
            btnTatToan.Click += BtnTatToan_Click;
        }

        private void LoadData()
        {
            try
            {
                items = service.GetDanhSach(txtSearch.Text);
                BindGrid(items);
                UpdateSelectedState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được danh sách sổ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindGrid(List<SoTietKiemDanhSachItem> data)
        {
            grid.DataSource = null;
            grid.DataSource = data.Select(x => new
            {
                x.MaSo,
                ChuSoHuu = x.ChuSoHuu,
                SoTienGui = x.SoTienGui.ToString("N0") + " VND",
                NgayMo = x.NgayMo.ToString("dd/MM/yyyy"),
                NgayDaoHan = x.NgayDaoHan.HasValue ? x.NgayDaoHan.Value.ToString("dd/MM/yyyy") : "Không kỳ hạn",
                TrangThai = x.TrangThaiHienThi
            }).ToList();

            if (grid.Columns["MaSo"] != null) grid.Columns["MaSo"].HeaderText = "Mã sổ";
            if (grid.Columns["ChuSoHuu"] != null) grid.Columns["ChuSoHuu"].HeaderText = "Chủ sở hữu";
            if (grid.Columns["SoTienGui"] != null) grid.Columns["SoTienGui"].HeaderText = "Số tiền gửi";
            if (grid.Columns["NgayMo"] != null) grid.Columns["NgayMo"].HeaderText = "Ngày mở";
            if (grid.Columns["NgayDaoHan"] != null) grid.Columns["NgayDaoHan"].HeaderText = "Ngày đáo hạn";
            if (grid.Columns["TrangThai"] != null) grid.Columns["TrangThai"].HeaderText = "Trạng thái";
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var value = grid.Rows[e.RowIndex].Cells["MaSo"].Value;
            selectedMaSo = value != null ? value.ToString() : string.Empty;
            UpdateSelectedState();
        }

        private void BtnXemChiTiet_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedItem();
            if (selected == null)
            {
                MessageBox.Show("Vui lòng chọn một sổ tiết kiệm.", "Chưa chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var detailForm = new FrmChiTietSo(selected, false))
            {
                detailForm.ShowDialog(this);
            }
        }

        private void BtnSuaSo_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedItem();
            if (selected == null)
            {
                MessageBox.Show("Vui lòng chọn một sổ tiết kiệm.", "Chưa chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var editForm = new FrmChiTietSo(selected, true))
            {
                if (editForm.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    service.SuaSo(selected.MaSo, editForm.SoDuSauKhiSua, editForm.TrangThaiSauKhiSua, currentUser != null ? currentUser.MaNhanVien : null);
                    MessageBox.Show("Cập nhật sổ tiết kiệm thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể cập nhật sổ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnXoaSo_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedItem();
            if (selected == null)
            {
                MessageBox.Show("Vui lòng chọn một sổ tiết kiệm.", "Chưa chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(
                "Bạn có chắc muốn xóa sổ " + selected.MaSo + " của khách hàng " + selected.ChuSoHuu + "?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                service.XoaSo(selected.MaSo, currentUser != null ? currentUser.MaNhanVien : null);
                selectedMaSo = string.Empty;
                MessageBox.Show("Xóa sổ tiết kiệm thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa sổ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTatToan_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedItem();
            if (selected == null)
            {
                MessageBox.Show("Vui lòng chọn một sổ tiết kiệm.", "Chưa chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var form = new FrmTatToan(currentUser, selected.MaSo))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void BtnRutGoc_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedItem();
            if (selected == null)
            {
                MessageBox.Show("Vui lòng chọn một sổ tiết kiệm.", "Chưa chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var form = new FrmTatToan(currentUser, selected.MaSo))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private SoTietKiemDanhSachItem GetSelectedItem()
        {
            if (string.IsNullOrWhiteSpace(selectedMaSo))
            {
                return null;
            }

            return items.FirstOrDefault(x => x.MaSo == selectedMaSo);
        }

        private void UpdateSelectedState()
        {
            var selected = GetSelectedItem();
            lblSelected.Text = selected == null
                ? "Chưa chọn sổ tiết kiệm nào."
                : "Đang chọn: " + selected.MaSo + " - " + selected.ChuSoHuu;
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

        private static void StyleDangerButton(Button button)
        {
            button.BackColor = ControlFactory.DangerColor;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
            button.FlatAppearance.BorderSize = 0;
        }
    }
}
