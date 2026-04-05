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
    public partial class FrmNhanVien : Form
    {
        private readonly NhanVienService service = new NhanVienService();
        private string selectedMaNhanVien = string.Empty;

        public FrmNhanVien()
        {
            InitializeComponent();
            ApplyTheme();
            BuildFields();
            WireEvents();
            LoadData();
            ResetForm(false);
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
            StyleComboBox(cboTrangThai);
            GridStyler.Apply(grid);

            txtMa.ReadOnly = true;
            txtSDT.UseSystemPasswordChar = true;

            StylePrimaryButton(btnThem);
            StyleSecondaryButton(btnSua);
            StyleDangerButton(btnXoa);
            StyleSecondaryButton(btnMoi);
        }

        private void BuildFields()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new object[] { "Admin", "Giao_dich_vien" });

            fieldsPanel.SuspendLayout();
            fieldsPanel.Controls.Clear();
            fieldsPanel.Controls.Add(CreateInputGroup("Mã nhân viên", txtMa));
            fieldsPanel.Controls.Add(CreateInputGroup("Tài khoản", txtHoTen));
            fieldsPanel.Controls.Add(CreateInputGroup("Mật khẩu", txtSDT));
            fieldsPanel.Controls.Add(CreateInputGroup("Vai trò", cboTrangThai));
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
            btnXoa.Click += BtnXoa_Click;
            btnMoi.Click += (s, e) => ResetForm();
        }

        private static void StyleTextBox(TextBox textBox)
        {
            textBox.Font = new Font("Segoe UI", 10);
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = Color.White;
            textBox.ForeColor = ControlFactory.TextColor;
        }

        private static void StyleComboBox(ComboBox comboBox)
        {
            comboBox.Font = new Font("Segoe UI", 10);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.BackColor = Color.White;
            comboBox.ForeColor = ControlFactory.TextColor;
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

        private void BindGrid(List<NhanVien> data)
        {
            grid.DataSource = null;
            grid.DataSource = data.Select(x => new
            {
                x.MaNhanVien,
                x.TaiKhoan,
                MatKhau = new string('*', string.IsNullOrEmpty(x.MatKhau) ? 0 : x.MatKhau.Length),
                x.VaiTro
            }).ToList();

            if (grid.Columns["MaNhanVien"] != null) grid.Columns["MaNhanVien"].HeaderText = "Mã NV";
            if (grid.Columns["TaiKhoan"] != null) grid.Columns["TaiKhoan"].HeaderText = "Tài khoản";
            if (grid.Columns["MatKhau"] != null) grid.Columns["MatKhau"].HeaderText = "Mật khẩu";
            if (grid.Columns["VaiTro"] != null) grid.Columns["VaiTro"].HeaderText = "Vai trò";
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var maNhanVien = grid.Rows[e.RowIndex].Cells["MaNhanVien"].Value?.ToString() ?? string.Empty;
            var model = service.GetAll().FirstOrDefault(x => x.MaNhanVien == maNhanVien);
            if (model == null) return;

            selectedMaNhanVien = model.MaNhanVien;
            txtMa.Text = model.MaNhanVien;
            txtHoTen.Text = model.TaiKhoan;
            txtSDT.Text = model.MatKhau;
            cboTrangThai.Text = model.VaiTro;
            lblSelected.Text = "Đang chọn: " + model.MaNhanVien + " - " + model.TaiKhoan;
        }

        private void Save(bool isUpdate)
        {
            var taiKhoan = txtHoTen.Text.Trim();
            var matKhau = txtSDT.Text.Trim();
            var vaiTro = cboTrangThai.Text.Trim();
            var errors = new List<string>();

            if (!FormValidator.Required(taiKhoan)) errors.Add("- Tài khoản không được để trống");
            if (!FormValidator.Required(matKhau)) errors.Add("- Mật khẩu không được để trống");
            if (!FormValidator.Required(vaiTro)) errors.Add("- Vai trò không được để trống");
            if (service.ExistsTaiKhoan(taiKhoan, isUpdate ? selectedMaNhanVien : string.Empty)) errors.Add("- Tài khoản đã tồn tại");

            if (errors.Any())
            {
                MessageBox.Show(FormValidator.JoinErrors(errors), "Validate form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var model = new NhanVien
            {
                MaNhanVien = txtMa.Text.Trim(),
                TaiKhoan = taiKhoan,
                MatKhau = matKhau,
                VaiTro = vaiTro
            };

            if (isUpdate)
            {
                if (string.IsNullOrWhiteSpace(selectedMaNhanVien))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần sửa.");
                    return;
                }
                model.MaNhanVien = selectedMaNhanVien;
                service.Update(model);
                MessageBox.Show("Cập nhật nhân viên thành công.");
            }
            else
            {
                service.Add(model);
                MessageBox.Show("Thêm nhân viên thành công.");
            }

            LoadData();
            ResetForm();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedMaNhanVien))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            service.Delete(selectedMaNhanVien);
            LoadData();
            ResetForm();
            MessageBox.Show("Xóa nhân viên thành công.");
        }

        private void ResetForm(bool reloadGrid = true)
        {
            selectedMaNhanVien = string.Empty;
            txtMa.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            cboTrangThai.SelectedIndex = cboTrangThai.Items.Count > 0 ? 0 : -1;
            lblSelected.Text = "Chưa chọn nhân viên nào.";

            if (reloadGrid)
            {
                txtSearch.Clear();
                LoadData();
            }
        }
    }
}
