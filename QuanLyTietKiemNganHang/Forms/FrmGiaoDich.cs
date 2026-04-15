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
    public partial class FrmGiaoDich : Form
    {
        private readonly XuLyGiaoDich service = new XuLyGiaoDich();
        private List<GiaoDich> items = new List<GiaoDich>();

        public FrmGiaoDich()
        {
            InitializeComponent();
            ApplyTheme();
            WireEvents();
            dtFrom.Value = DateTime.Today.AddDays(-7);
            dtTo.Value = DateTime.Today;
            cboLoai.Items.AddRange(new object[] { "Tất cả", "Rut_tien", "Gui_them", "Tra_lai" });
            cboLoai.SelectedIndex = 0;
            LoadData();
        }

        private void ApplyTheme()
        {
            BackColor = ControlFactory.BackgroundColor;
            topPanel.BackColor = Color.White;
            contentWrap.BackColor = ControlFactory.BackgroundColor;
            contentCard.BackColor = ControlFactory.SurfaceColor;
            contentCard.BorderStyle = BorderStyle.FixedSingle;
            detailCard.BackColor = Color.FromArgb(248, 250, 252);
            detailCard.BorderStyle = BorderStyle.FixedSingle;

            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.ForeColor = ControlFactory.TextColor;
            lblDetailTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblDetailTitle.ForeColor = ControlFactory.TextColor;
            lblDetail.Font = new Font("Segoe UI", 10);
            lblDetail.ForeColor = ControlFactory.MutedTextColor;
            lblTongGiaoDich.Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold);
            lblTongGiaoDich.ForeColor = ControlFactory.TextColor;
            lblTongSoTien.Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold);
            lblTongSoTien.ForeColor = ControlFactory.PrimaryColor;

            dtFrom.Font = new Font("Segoe UI", 10);
            dtTo.Font = new Font("Segoe UI", 10);
            cboLoai.Font = new Font("Segoe UI", 10);
            cboLoai.FlatStyle = FlatStyle.Flat;

            StyleSecondaryButton(btnLoc);
            StyleSecondaryButton(btnLamMoi);
            GridStyler.Apply(grid);
        }

        private void WireEvents()
        {
            btnLoc.Click += (s, e) => LoadData();
            btnLamMoi.Click += (s, e) =>
            {
                dtFrom.Value = DateTime.Today.AddMonths(-1);
                dtTo.Value = DateTime.Today;
                cboLoai.SelectedIndex = 0;
                LoadData();
            };
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

        private void LoadData()
        {
            try
            {
                items = service.GetDanhSach(dtFrom.Value.Date, dtTo.Value.Date, cboLoai.SelectedItem != null ? cboLoai.SelectedItem.ToString() : "Tất cả");
                grid.DataSource = items.Select(x => new
                {
                    x.MaGiaoDich,
                    x.MaSo,
                    x.TenKhachHang,
                    Loai = x.LoaiGiaoDichHienThi,
                    SoTien = x.SoTien.ToString("N0") + " VND",
                    Ngay = x.NgayGiaoDich.ToString("dd/MM/yyyy HH:mm")
                }).ToList();
                if (grid.Columns["MaGiaoDich"] != null) grid.Columns["MaGiaoDich"].HeaderText = "Mã GD";
                if (grid.Columns["MaSo"] != null) grid.Columns["MaSo"].HeaderText = "Mã sổ";
                if (grid.Columns["TenKhachHang"] != null) grid.Columns["TenKhachHang"].HeaderText = "Khách hàng";
                if (grid.Columns["Loai"] != null) grid.Columns["Loai"].HeaderText = "Loại giao dịch";
                if (grid.Columns["SoTien"] != null) grid.Columns["SoTien"].HeaderText = "Số tiền";
                if (grid.Columns["Ngay"] != null) grid.Columns["Ngay"].HeaderText = "Ngày giao dịch";

                var tongTien = items.Sum(x => x.SoTien);
                lblTongGiaoDich.Text = "Tổng giao dịch: " + items.Count;
                lblTongSoTien.Text = "Tổng giá trị: " + tongTien.ToString("N0") + " VND";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được danh sách giao dịch: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var maGd = grid.Rows[e.RowIndex].Cells["MaGiaoDich"].Value.ToString();
            var selected = items.FirstOrDefault(x => x.MaGiaoDich == maGd);
            if (selected == null) return;
            lblDetail.Text =
                "Mã GD: " + selected.MaGiaoDich +
                " | Mã sổ: " + selected.MaSo +
                " | Khách hàng: " + selected.TenKhachHang + Environment.NewLine +
                "Loại: " + selected.LoaiGiaoDichHienThi +
                " | Số tiền: " + selected.SoTien.ToString("N0") + " VND" +
                " | Nhân viên: " + selected.MaNhanVien +
                " | Thời gian: " + selected.NgayGiaoDich.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}
