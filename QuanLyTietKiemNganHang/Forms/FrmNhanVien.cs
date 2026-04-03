using QuanLyTietKiemNganHang.Helpers;
using QuanLyTietKiemNganHang.Models;
using QuanLyTietKiemNganHang.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyTietKiemNganHang.Forms
{
    public partial class FrmNhanVien : Form
    {
        private readonly NhanVienService service = new NhanVienService();
        private int selectedId;

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
            StyleTextBox(txtEmail);
            StyleTextBox(txtChucVu);
            StyleTextBox(txtLuong);
            StyleDatePicker(dtpNgayVaoLam);
            StyleComboBox(cboTrangThai);
            GridStyler.Apply(grid);

            StylePrimaryButton(btnThem);
            StyleSecondaryButton(btnSua);
            StyleDangerButton(btnXoa);
            StyleSecondaryButton(btnMoi);
        }

        private void BuildFields()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new object[] { "Đang làm", "Nghỉ phép", "Nghỉ việc" });

            fieldsPanel.SuspendLayout();
            fieldsPanel.Controls.Clear();
            fieldsPanel.Controls.Add(CreateInputGroup("Mã nhân viên", txtMa));
            fieldsPanel.Controls.Add(CreateInputGroup("Họ tên", txtHoTen));
            fieldsPanel.Controls.Add(CreateInputGroup("Số điện thoại", txtSDT));
            fieldsPanel.Controls.Add(CreateInputGroup("Email", txtEmail));
            fieldsPanel.Controls.Add(CreateInputGroup("Chức vụ", txtChucVu));
            fieldsPanel.Controls.Add(CreateInputGroup("Lương cơ bản", txtLuong));
            fieldsPanel.Controls.Add(CreateInputGroup("Ngày vào làm", dtpNgayVaoLam));
            fieldsPanel.Controls.Add(CreateInputGroup("Trạng thái", cboTrangThai));
            fieldsPanel.ResumeLayout();
        }

        private Panel CreateInputGroup(string labelText, Control inputControl)
        {
            var container = new Panel
            {
                Width = 304,
                Height = 74,
                Margin = new Padding(0, 0, 0, 10)
            };

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

            if (inputControl is DateTimePicker picker)
            {
                picker.Format = DateTimePickerFormat.Short;
            }

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

        private static void StyleDatePicker(DateTimePicker picker)
        {
            picker.Font = new Font("Segoe UI", 10);
            picker.CalendarForeColor = ControlFactory.TextColor;
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
                x.Id,
                x.MaNhanVien,
                x.HoTen,
                x.SoDienThoai,
                x.Email,
                x.ChucVu,
                NgayVaoLam = x.NgayVaoLam.ToString("dd/MM/yyyy"),
                LuongCoBan = x.LuongCoBan.ToString("N0"),
                x.TrangThai
            }).ToList();

            if (grid.Columns["Id"] != null) grid.Columns["Id"].Visible = false;
            if (grid.Columns["MaNhanVien"] != null) grid.Columns["MaNhanVien"].HeaderText = "Mã NV";
            if (grid.Columns["HoTen"] != null) grid.Columns["HoTen"].HeaderText = "Họ tên";
            if (grid.Columns["SoDienThoai"] != null) grid.Columns["SoDienThoai"].HeaderText = "SĐT";
            if (grid.Columns["NgayVaoLam"] != null) grid.Columns["NgayVaoLam"].HeaderText = "Ngày vào làm";
            if (grid.Columns["LuongCoBan"] != null) grid.Columns["LuongCoBan"].HeaderText = "Lương";
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = grid.Rows[e.RowIndex];
            selectedId = Convert.ToInt32(row.Cells["Id"].Value);
            txtMa.Text = row.Cells["MaNhanVien"].Value?.ToString() ?? string.Empty;
            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? string.Empty;
            txtSDT.Text = row.Cells["SoDienThoai"].Value?.ToString() ?? string.Empty;
            txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? string.Empty;
            txtChucVu.Text = row.Cells["ChucVu"].Value?.ToString() ?? string.Empty;
            txtLuong.Text = (row.Cells["LuongCoBan"].Value?.ToString() ?? string.Empty).Replace(",", string.Empty);
            dtpNgayVaoLam.Value = DateTime.ParseExact(row.Cells["NgayVaoLam"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            cboTrangThai.Text = row.Cells["TrangThai"].Value?.ToString() ?? "Đang làm";
            lblSelected.Text = "Đang chọn: " + txtMa.Text + " - " + txtHoTen.Text;
        }

        private void Save(bool isUpdate)
        {
            var currentId = isUpdate ? selectedId : 0;
            var maNhanVien = txtMa.Text.Trim();
            var errors = new List<string>();
            if (!FormValidator.Required(maNhanVien)) errors.Add("- Mã nhân viên không được để trống");
            if (!FormValidator.Required(txtHoTen.Text)) errors.Add("- Họ tên không được để trống");
            if (!FormValidator.IsPhone(txtSDT.Text)) errors.Add("- Số điện thoại không hợp lệ");
            if (!FormValidator.IsEmail(txtEmail.Text)) errors.Add("- Email không hợp lệ");
            if (!FormValidator.Required(txtChucVu.Text)) errors.Add("- Chức vụ không được để trống");
            if (FormValidator.Required(maNhanVien) && service.IsDuplicateMaNhanVien(maNhanVien, currentId)) errors.Add("- Mã nhân viên đã tồn tại");

            decimal luong;
            if (!decimal.TryParse(txtLuong.Text, out luong) || !FormValidator.Positive(luong))
                errors.Add("- Lương cơ bản phải lớn hơn 0");

            if (errors.Any())
            {
                MessageBox.Show(FormValidator.JoinErrors(errors), "Validate form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var model = new NhanVien
            {
                Id = selectedId,
                MaNhanVien = maNhanVien,
                HoTen = txtHoTen.Text.Trim(),
                SoDienThoai = txtSDT.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                ChucVu = txtChucVu.Text.Trim(),
                NgayVaoLam = dtpNgayVaoLam.Value.Date,
                LuongCoBan = luong,
                TrangThai = cboTrangThai.Text
            };

            if (isUpdate)
            {
                if (selectedId == 0)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần sửa.");
                    return;
                }
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
            if (selectedId == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            service.Delete(selectedId);
            LoadData();
            ResetForm();
            MessageBox.Show("Xóa nhân viên thành công.");
        }

        private void ResetForm(bool reloadGrid = true)
        {
            selectedId = 0;
            txtMa.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtChucVu.Clear();
            txtLuong.Clear();
            dtpNgayVaoLam.Value = DateTime.Today;
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
