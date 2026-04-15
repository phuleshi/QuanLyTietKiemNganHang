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
    public partial class FrmKhachHang : Form
    {
        private readonly KhachHangService service = new KhachHangService();
        private readonly NhanVien currentUser;
        private List<KhachHang> currentItems = new List<KhachHang>();
        private string selectedMaKhachHang = string.Empty;

        public FrmKhachHang(NhanVien currentUser)
        {
            this.currentUser = currentUser;
            InitializeComponent();
            ApplyTheme();
            BuildFields();
            WireEvents();
            LoadData();
            ResetForm(false);
        }

        private bool LaAdmin
        {
            get { return currentUser != null && currentUser.LaAdmin; }
        }

        private void ApplyTheme()
        {
            BackColor = ControlFactory.BackgroundColor;
            topPanel.BackColor = Color.White;
            leftWrap.BackColor = ControlFactory.BackgroundColor;
            rightWrap.BackColor = ControlFactory.BackgroundColor;
            formCard.BackColor = ControlFactory.SurfaceColor;
            listCard.BackColor = ControlFactory.SurfaceColor;
            formCard.BorderStyle = BorderStyle.FixedSingle;
            listCard.BorderStyle = BorderStyle.FixedSingle;

            lblPageTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblPageTitle.ForeColor = ControlFactory.TextColor;
            lblCardTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblCardTitle.ForeColor = ControlFactory.TextColor;
            lblListTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblListTitle.ForeColor = ControlFactory.TextColor;
            lblSelected.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            lblSelected.ForeColor = ControlFactory.MutedTextColor;

            StyleTextBox(txtSearch);
            StyleTextBox(txtMa);
            StyleTextBox(txtHoTen);
            StyleTextBox(txtSDT);
            StyleTextBox(txtCCCD);
            StyleTextBox(txtDiaChi);
            GridStyler.Apply(grid);

            txtMa.ReadOnly = true;

            StylePrimaryButton(btnThem);
            StyleSecondaryButton(btnSua);
            StyleDangerButton(btnXoa);
            StyleSecondaryButton(btnMoi);

            btnXoa.Visible = LaAdmin;
            btnXoa.Text = "Đổi trạng thái";
        }

        private void BuildFields()
        {
            fieldsPanel.SuspendLayout();
            fieldsPanel.Controls.Clear();
            fieldsPanel.Controls.Add(CreateInputGroup("Họ tên", txtHoTen));
            fieldsPanel.Controls.Add(CreateInputGroup("CCCD", txtCCCD));
            fieldsPanel.Controls.Add(CreateInputGroup("Số điện thoại", txtSDT));
            fieldsPanel.Controls.Add(CreateInputGroup("Địa chỉ", txtDiaChi));
            fieldsPanel.ResumeLayout();
        }

        private Panel CreateInputGroup(string labelText, Control inputControl)
        {
            var container = new Panel { Width = 304, Height = 74, Margin = new Padding(0, 0, 0, 10) };
            var label = new Label
            {
                AutoSize = true,
                Text = labelText,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = ControlFactory.TextColor,
                Location = new Point(0, 0)
            };
            inputControl.Location = new Point(0, 28);
            inputControl.Width = 286;
            inputControl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            container.Controls.Add(label);
            container.Controls.Add(inputControl);
            return container;
        }

        private void WireEvents()
        {
            txtSearch.TextChanged += (s, e) => BindGrid(service.Search(txtSearch.Text));
            grid.CellClick += Grid_CellClick;
            btnThem.Click += (s, e) => Save(false);
            btnSua.Click += (s, e) => Save(true);
            btnXoa.Click += BtnTrangThai_Click;
            btnMoi.Click += (s, e) => ResetForm();
        }

        private static void StyleTextBox(TextBox textBox)
        {
            textBox.Font = new Font("Segoe UI", 10);
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = Color.White;
            textBox.ForeColor = ControlFactory.TextColor;
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

        private void LoadData()
        {
            BindGrid(service.GetAll());
        }

        private void BindGrid(List<KhachHang> data)
        {
            currentItems = data ?? new List<KhachHang>();
            grid.DataSource = null;
            grid.DataSource = currentItems.Select(x => new
            {
                x.MaKhachHang,
                x.HoTen,
                x.CCCD,
                x.SoDienThoai,
                x.DiaChi,
                TrangThai = x.TrangThaiHienThi
            }).ToList();

            if (grid.Columns["MaKhachHang"] != null) grid.Columns["MaKhachHang"].HeaderText = "Mã KH";
            if (grid.Columns["HoTen"] != null) grid.Columns["HoTen"].HeaderText = "Họ tên";
            if (grid.Columns["CCCD"] != null) grid.Columns["CCCD"].HeaderText = "CCCD";
            if (grid.Columns["SoDienThoai"] != null) grid.Columns["SoDienThoai"].HeaderText = "SĐT";
            if (grid.Columns["DiaChi"] != null) grid.Columns["DiaChi"].HeaderText = "Địa chỉ";
            if (grid.Columns["TrangThai"] != null) grid.Columns["TrangThai"].HeaderText = "Trạng thái";
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var value = grid.Rows[e.RowIndex].Cells["MaKhachHang"].Value;
            var maKhachHang = value != null ? value.ToString() : string.Empty;
            var model = currentItems.FirstOrDefault(x => x.MaKhachHang == maKhachHang);
            if (model == null) return;

            selectedMaKhachHang = model.MaKhachHang;
            txtMa.Text = model.MaKhachHang;
            txtHoTen.Text = model.HoTen;
            txtCCCD.Text = model.CCCD;
            txtSDT.Text = model.SoDienThoai;
            txtDiaChi.Text = model.DiaChi;
            lblSelected.Text = "Đang chọn: " + model.MaKhachHang + " - " + model.HoTen + " (" + model.TrangThaiHienThi + ")";
            UpdateTrangThaiButton(model);
        }

        private void Save(bool isUpdate)
        {
            var cccd = txtCCCD.Text.Trim();
            var errors = new List<string>();
            if (!FormValidator.Required(txtHoTen.Text)) errors.Add("- Họ tên không được để trống");
            if (!FormValidator.IsCitizenId(cccd)) errors.Add("- CCCD phải có 12 số");
            if (!FormValidator.IsPhone(txtSDT.Text)) errors.Add("- Số điện thoại không hợp lệ");
            if (!FormValidator.Required(txtDiaChi.Text)) errors.Add("- Địa chỉ không được để trống");
            if (isUpdate && string.IsNullOrWhiteSpace(selectedMaKhachHang)) errors.Add("- Vui lòng chọn khách hàng cần sửa");

            if (errors.Any())
            {
                MessageBox.Show(FormValidator.JoinErrors(errors), "Validate form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (service.CccdDaTonTai(cccd, isUpdate ? selectedMaKhachHang : null))
            {
                MessageBox.Show("CCCD đã tồn tại. Vui lòng nhập CCCD khác.", "Trùng CCCD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                txtCCCD.SelectAll();
                return;
            }

            var model = new KhachHang
            {
                MaKhachHang = selectedMaKhachHang,
                HoTen = txtHoTen.Text.Trim(),
                CCCD = cccd,
                SoDienThoai = txtSDT.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim()
            };

            try
            {
                if (isUpdate)
                {
                    service.Update(model, currentUser != null ? currentUser.MaNhanVien : null);
                    MessageBox.Show("Cập nhật khách hàng thành công.");
                }
                else
                {
                    service.Add(model, currentUser != null ? currentUser.MaNhanVien : null);
                    MessageBox.Show("Thêm khách hàng thành công.");
                }

                LoadData();
                ResetForm();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("CCCD đã tồn tại. Vui lòng nhập CCCD khác.", "Trùng CCCD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCCCD.Focus();
                    txtCCCD.SelectAll();
                    return;
                }

                throw;
            }
        }

        private void BtnTrangThai_Click(object sender, EventArgs e)
        {
            if (!LaAdmin)
            {
                MessageBox.Show("Chỉ admin mới có thể đổi trạng thái khách hàng.", "Không có quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(selectedMaKhachHang))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần đổi trạng thái.");
                return;
            }

            var model = currentItems.FirstOrDefault(x => x.MaKhachHang == selectedMaKhachHang);
            if (model == null)
            {
                MessageBox.Show("Không tìm thấy khách hàng đã chọn.");
                return;
            }

            var trangThaiMoi = model.DangHoatDong ? "Unactive" : "Active";
            var thongDiep = model.DangHoatDong
                ? "Bạn có chắc muốn chuyển khách hàng này sang Unactive?"
                : "Bạn có chắc muốn kích hoạt lại khách hàng này?";

            if (MessageBox.Show(thongDiep, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            service.CapNhatTrangThai(selectedMaKhachHang, !model.DangHoatDong, currentUser != null ? currentUser.MaNhanVien : null);
            LoadData();
            ResetForm();
            MessageBox.Show("Đã cập nhật trạng thái khách hàng sang " + trangThaiMoi + ".");
        }

        private void UpdateTrangThaiButton(KhachHang model)
        {
            if (!LaAdmin || model == null)
            {
                return;
            }

            btnXoa.Text = model.DangHoatDong ? "Chuyển Unactive" : "Chuyển Active";
        }

        private void ResetForm(bool reloadGrid = true)
        {
            selectedMaKhachHang = string.Empty;
            txtMa.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtCCCD.Clear();
            txtDiaChi.Clear();
            lblSelected.Text = "Chưa chọn khách hàng nào.";
            if (LaAdmin)
            {
                btnXoa.Text = "Đổi trạng thái";
            }

            if (reloadGrid)
            {
                txtSearch.Clear();
                LoadData();
            }
        }
    }
}
