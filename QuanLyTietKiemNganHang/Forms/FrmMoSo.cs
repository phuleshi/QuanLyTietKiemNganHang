using QuanLyTietKiemNganHang.Helpers;
using QuanLyTietKiemNganHang.Models;
using QuanLyTietKiemNganHang.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTietKiemNganHang.Forms
{
    public partial class FrmMoSo : Form
    {
        private readonly XuLySoTietKiem service = new XuLySoTietKiem();
        private readonly NhanVien currentUser;
        private List<KhachHang> khachHangs = new List<KhachHang>();
        private List<LoaiTietKiem> loaiTietKiems = new List<LoaiTietKiem>();

        public FrmMoSo()
            : this(null)
        {
        }

        public FrmMoSo(NhanVien currentUser)
        {
            this.currentUser = currentUser;
            InitializeComponent();
            ApplyTheme();
            BuildFields();
            WireEvents();
            LoadLookups();
            ResetForm();
        }

        private void ApplyTheme()
        {
            BackColor = ControlFactory.BackgroundColor;
            topPanel.BackColor = Color.White;
            leftWrap.BackColor = ControlFactory.BackgroundColor;
            rightWrap.BackColor = ControlFactory.BackgroundColor;
            formCard.BackColor = ControlFactory.SurfaceColor;
            previewCard.BackColor = ControlFactory.SurfaceColor;
            formCard.BorderStyle = BorderStyle.FixedSingle;
            previewCard.BorderStyle = BorderStyle.FixedSingle;

            lblPageTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblPageTitle.ForeColor = ControlFactory.TextColor;
            lblFormTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblFormTitle.ForeColor = ControlFactory.TextColor;
            lblCurrentUser.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            lblCurrentUser.ForeColor = ControlFactory.MutedTextColor;
            lblPreviewTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblPreviewTitle.ForeColor = ControlFactory.TextColor;
            lblPreviewText.Font = new Font("Segoe UI", 10);
            lblPreviewText.ForeColor = ControlFactory.TextColor;

            StyleComboBox(cboKhachHang);
            StyleComboBox(cboLoaiTietKiem);
            StyleNumericUpDown(numSoTienGui);
            StyleReadOnlyTextBox(txtLaiSuat);
            StyleReadOnlyTextBox(txtNgayDaoHan);
            StyleReadOnlyTextBox(txtNhanVienMo);

            StylePrimaryButton(btnXacNhan);
            StyleSecondaryButton(btnLamMoi);
        }

        private void BuildFields()
        {
            fieldsPanel.SuspendLayout();
            fieldsPanel.Controls.Clear();
            fieldsPanel.Controls.Add(ControlFactory.CreateInputGroup("Chọn khách hàng", cboKhachHang));
            fieldsPanel.Controls.Add(ControlFactory.CreateInputGroup("Chọn gói tiết kiệm", cboLoaiTietKiem));
            fieldsPanel.Controls.Add(ControlFactory.CreateInputGroup("Nhập số tiền gửi", numSoTienGui));
            fieldsPanel.Controls.Add(ControlFactory.CreateInputGroup("Lãi suất áp dụng", txtLaiSuat));
            fieldsPanel.Controls.Add(ControlFactory.CreateInputGroup("Ngày đáo hạn", txtNgayDaoHan));
            fieldsPanel.Controls.Add(ControlFactory.CreateInputGroup("Nhân viên mở sổ", txtNhanVienMo));
            fieldsPanel.ResumeLayout();
        }

        private void WireEvents()
        {
            cboKhachHang.SelectedIndexChanged += (s, e) => UpdateCalculatedFields();
            cboLoaiTietKiem.SelectedIndexChanged += (s, e) => UpdateCalculatedFields();
            numSoTienGui.ValueChanged += (s, e) => UpdateCalculatedFields();
            btnLamMoi.Click += (s, e) => ResetForm();
            btnXacNhan.Click += BtnXacNhan_Click;
        }

        private void LoadLookups()
        {
            try
            {
                khachHangs = service.GetKhachHangs();
                loaiTietKiems = service.GetLoaiTietKiems();

                cboKhachHang.DataSource = khachHangs;
                cboKhachHang.DisplayMember = "HienThiCombo";
                cboKhachHang.ValueMember = "MaKhachHang";

                cboLoaiTietKiem.DataSource = loaiTietKiems;
                cboLoaiTietKiem.DisplayMember = "HienThiCombo";
                cboLoaiTietKiem.ValueMember = "MaGoi";

                var tenNhanVien = currentUser != null && !string.IsNullOrWhiteSpace(currentUser.TenNhanVien)
                    ? currentUser.TenNhanVien
                    : "Nhân viên mặc định";
                txtNhanVienMo.Text = currentUser == null
                    ? "NV001 - Nhân viên mặc định"
                    : currentUser.MaNhanVien + " - " + tenNhanVien;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được dữ liệu mở sổ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXacNhan_Click(object sender, EventArgs e)
        {
            var selectedKhachHang = cboKhachHang.SelectedItem as KhachHang;
            var selectedGoi = cboLoaiTietKiem.SelectedItem as LoaiTietKiem;

            if (selectedKhachHang == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedGoi == null)
            {
                MessageBox.Show("Vui lòng chọn gói tiết kiệm.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numSoTienGui.Value <= 0)
            {
                MessageBox.Show("Số tiền gửi phải lớn hơn 0.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                service.MoSo(selectedKhachHang.MaKhachHang, selectedGoi.MaGoi, currentUser != null ? currentUser.MaNhanVien : null, numSoTienGui.Value);
                MessageBox.Show("Mở sổ tiết kiệm thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở sổ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetForm()
        {
            if (khachHangs.Count > 0)
            {
                cboKhachHang.SelectedIndex = 0;
            }

            if (loaiTietKiems.Count > 0)
            {
                cboLoaiTietKiem.SelectedIndex = 0;
            }

            numSoTienGui.Value = 1000000;
            UpdateCalculatedFields();
        }

        private void UpdateCalculatedFields()
        {
            var selectedKhachHang = cboKhachHang.SelectedItem as KhachHang;
            var selectedLoai = cboLoaiTietKiem.SelectedItem as LoaiTietKiem;

            if (selectedLoai == null)
            {
                txtLaiSuat.Clear();
                txtNgayDaoHan.Clear();
                lblPreviewText.Text = "Chọn khách hàng, gói tiết kiệm và số tiền để xem thông tin mở sổ.";
                return;
            }

            txtLaiSuat.Text = selectedLoai.LaiSuatNam.ToString("0.00") + "%/năm";
            txtNgayDaoHan.Text = selectedLoai.KyHanThang <= 0
                ? "Không kỳ hạn"
                : DateTime.Today.AddMonths(selectedLoai.KyHanThang).ToString("dd/MM/yyyy");

            lblPreviewText.Text =
                "Khách hàng: " + (selectedKhachHang != null ? selectedKhachHang.HienThiCombo : "Chưa chọn") + Environment.NewLine +
                "Gói tiết kiệm: " + selectedLoai.HienThiCombo + Environment.NewLine +
                "Số tiền gửi: " + numSoTienGui.Value.ToString("N0") + " VND" + Environment.NewLine +
                "Lãi suất áp dụng: " + txtLaiSuat.Text + Environment.NewLine +
                "Ngày đáo hạn: " + txtNgayDaoHan.Text + Environment.NewLine +
                "Nhân viên mở sổ: " + txtNhanVienMo.Text;
        }

        private static void StyleComboBox(ComboBox comboBox)
        {
            comboBox.Font = new Font("Segoe UI", 10);
            comboBox.Width = 286;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.FlatStyle = FlatStyle.Flat;
        }

        private static void StyleNumericUpDown(NumericUpDown numericUpDown)
        {
            numericUpDown.Font = new Font("Segoe UI", 10);
            numericUpDown.Width = 286;
            numericUpDown.BorderStyle = BorderStyle.FixedSingle;
            numericUpDown.Maximum = 1000000000;
            numericUpDown.Minimum = 0;
            numericUpDown.Increment = 100000;
            numericUpDown.ThousandsSeparator = true;
        }

        private static void StyleReadOnlyTextBox(TextBox textBox)
        {
            textBox.Font = new Font("Segoe UI", 10);
            textBox.Width = 286;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.ReadOnly = true;
            textBox.BackColor = Color.FromArgb(248, 250, 252);
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
    }
}
