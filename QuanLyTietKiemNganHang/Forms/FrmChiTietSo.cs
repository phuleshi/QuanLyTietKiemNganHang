using QuanLyTietKiemNganHang.Helpers;
using QuanLyTietKiemNganHang.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTietKiemNganHang.Forms
{
    public partial class FrmChiTietSo : Form
    {
        private readonly SoTietKiemDanhSachItem item;
        private readonly bool allowEdit;

        public decimal SoDuSauKhiSua
        {
            get { return numSoDu.Value; }
        }

        public string TrangThaiSauKhiSua
        {
            get
            {
                var option = cboTrangThai.SelectedItem as ComboBoxItem;
                return option != null ? option.Value : "Dang_mo";
            }
        }

        public FrmChiTietSo(SoTietKiemDanhSachItem item, bool allowEdit)
        {
            this.item = item;
            this.allowEdit = allowEdit;
            InitializeComponent();
            ApplyTheme();
            LoadData();
        }

        private void ApplyTheme()
        {
            BackColor = ControlFactory.BackgroundColor;
            topPanel.BackColor = Color.White;
            contentCard.BackColor = ControlFactory.SurfaceColor;
            contentCard.BorderStyle = BorderStyle.FixedSingle;

            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.ForeColor = ControlFactory.TextColor;
            lblSubTitle.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            lblSubTitle.ForeColor = ControlFactory.MutedTextColor;

            StyleReadOnlyTextBox(txtMaSo);
            StyleReadOnlyTextBox(txtChuSoHuu);
            StyleReadOnlyTextBox(txtGoiTietKiem);
            StyleReadOnlyTextBox(txtSoTienGui);
            StyleReadOnlyTextBox(txtLaiSuat);
            StyleReadOnlyTextBox(txtNgayMo);
            StyleReadOnlyTextBox(txtNgayDaoHan);
            StyleReadOnlyTextBox(txtNhanVienMo);

            lblSoDuConLai.Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold);
            lblSoDuConLai.ForeColor = ControlFactory.TextColor;

            numSoDu.Font = new Font("Segoe UI", 11);
            numSoDu.BorderStyle = BorderStyle.FixedSingle;
            numSoDu.DecimalPlaces = 2;
            numSoDu.Maximum = decimal.MaxValue;
            numSoDu.Minimum = decimal.Zero;
            numSoDu.ThousandsSeparator = true;
            numSoDu.TextAlign = HorizontalAlignment.Right;

            cboTrangThai.Font = new Font("Segoe UI", 11);
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.FlatStyle = FlatStyle.Flat;

            StylePrimaryButton(btnLuu);
            StyleSecondaryButton(btnDong);

            btnLuu.Visible = allowEdit;
            btnLuu.Enabled = allowEdit;
            numSoDu.Enabled = allowEdit;
            cboTrangThai.Enabled = allowEdit;
        }

        private void LoadData()
        {
            if (item == null)
            {
                return;
            }

            lblTitle.Text = allowEdit ? "Sửa sổ tiết kiệm" : "Chi tiết sổ tiết kiệm";
            lblSubTitle.Text = allowEdit
                ? "Thông tin sổ " + item.MaSo
                : "Thông tin sổ " + item.MaSo + " - lãi tạm tính đến ngày " + DateTime.Today.ToString("dd/MM/yyyy");

            txtMaSo.Text = "Mã sổ" + Environment.NewLine + item.MaSo;
            txtChuSoHuu.Text = "Chủ sở hữu" + Environment.NewLine + item.ChuSoHuu + " (" + item.MaKhachHang + ")";
            txtGoiTietKiem.Text = "Gói tiết kiệm" + Environment.NewLine + item.TenGoiTietKiem;
            txtSoTienGui.Text = "Số tiền gửi ban đầu" + Environment.NewLine + item.SoTienGui.ToString("N0") + " VND";
            txtLaiSuat.Text = "Lãi suất áp dụng" + Environment.NewLine + item.LaiSuatApDung.ToString("0.00") + "%/năm";
            txtNgayMo.Text = "Ngày mở" + Environment.NewLine + item.NgayMo.ToString("dd/MM/yyyy");
            txtNgayDaoHan.Text = "Ngày đáo hạn" + Environment.NewLine + (item.NgayDaoHan.HasValue ? item.NgayDaoHan.Value.ToString("dd/MM/yyyy") : "Không kỳ hạn");

            var nhanVienMo = item.MaNhanVienMo;
            if (!string.IsNullOrWhiteSpace(item.TenNhanVienMo))
            {
                nhanVienMo += " - " + item.TenNhanVienMo;
            }

            txtNhanVienMo.Text = "Nhân viên mở sổ" + Environment.NewLine + nhanVienMo;
            lblSoDuConLai.Text = allowEdit
                ? "Số dư gốc còn lại"
                : "Số dư còn lại (gồm lãi tạm tính)";
            SetNumericValue(numSoDu, allowEdit ? item.SoDuGocConLai : item.SoDuHienTai);

            cboTrangThai.DisplayMember = "Text";
            cboTrangThai.ValueMember = "Value";
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add(new ComboBoxItem("Đang mở", "Dang_mo"));
            cboTrangThai.Items.Add(new ComboBoxItem("Đã tất toán", "Da_tat_toan"));

            foreach (var entry in cboTrangThai.Items)
            {
                var option = entry as ComboBoxItem;
                if (option != null && option.Value == item.TrangThai)
                {
                    cboTrangThai.SelectedItem = entry;
                    break;
                }
            }

            if (cboTrangThai.SelectedIndex < 0)
            {
                cboTrangThai.SelectedIndex = 0;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboTrangThai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn trạng thái.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TrangThaiSauKhiSua == "Dang_mo" && numSoDu.Value <= 0)
            {
                MessageBox.Show("Số dư phải lớn hơn 0 khi sổ đang mở.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private static void SetNumericValue(NumericUpDown numericUpDown, decimal value)
        {
            if (value < numericUpDown.Minimum)
            {
                numericUpDown.Minimum = value;
            }

            if (value > numericUpDown.Maximum)
            {
                numericUpDown.Maximum = value;
            }

            numericUpDown.Value = value;
        }

        private static void StyleReadOnlyTextBox(TextBox textBox)
        {
            textBox.Font = new Font("Segoe UI", 11);
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
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
        }

        private static void StyleSecondaryButton(Button button)
        {
            button.BackColor = Color.White;
            button.ForeColor = ControlFactory.PrimaryColor;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold);
            button.FlatAppearance.BorderColor = ControlFactory.BorderColor;
            button.FlatAppearance.BorderSize = 1;
            button.Cursor = Cursors.Hand;
        }

        private sealed class ComboBoxItem
        {
            public ComboBoxItem(string text, string value)
            {
                Text = text;
                Value = value;
            }

            public string Text { get; private set; }
            public string Value { get; private set; }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}
