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
    public partial class FrmMoSo : Form
    {
        private readonly XuLySoTietKiem service = new XuLySoTietKiem();
        private readonly NhanVien currentUser;
        private readonly TextBox txtHoTenKhachHang = new TextBox();
        private readonly TextBox txtCccdKhachHang = new TextBox();
        private readonly TextBox txtMaKhachHang = new TextBox();
        private readonly Button btnXacDinhKhachHang = new Button();
        private List<KhachHang> khachHangs = new List<KhachHang>();
        private List<LoaiTietKiem> loaiTietKiems = new List<LoaiTietKiem>();
        private KhachHang selectedKhachHang;
        private bool suppressCustomerInputChange;
        private const int InputWidth = 360;
        private const int InputGroupWidth = 380;
        private const int InputGroupHeight = 74;

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
            Font = new Font("Segoe UI", 10F);
            Text = "Mở sổ tiết kiệm";

            lblPageTitle.Text = "Mở sổ tiết kiệm";
            lblPageTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblPageTitle.ForeColor = ControlFactory.TextColor;

            lblFormTitle.Text = "Thông tin mở sổ tiết kiệm";
            lblFormTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblFormTitle.ForeColor = ControlFactory.TextColor;

            lblCurrentUser.Text = "Nhân viên mở sổ";
            lblCurrentUser.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblCurrentUser.ForeColor = ControlFactory.MutedTextColor;

            lblPreviewTitle.Text = "Thông tin tự động tính";
            lblPreviewTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblPreviewTitle.ForeColor = ControlFactory.TextColor;

            lblPreviewHint.Font = new Font("Segoe UI", 10F);
            lblPreviewHint.ForeColor = ControlFactory.MutedTextColor;
            lblPreviewHint.TextAlign = ContentAlignment.MiddleLeft;

            fieldsPanel.Padding = new Padding(0, 10, 0, 0);
            actionPanel.Height = 56;

            StyleComboBox(cboKhachHang);
            StyleComboBox(cboLoaiTietKiem);
            StyleTextBox(txtHoTenKhachHang);
            StyleTextBox(txtCccdKhachHang);
            StyleReadOnlyTextBox(txtMaKhachHang);
            StyleNumericUpDown(numSoTienGui);
            StyleReadOnlyTextBox(txtLaiSuat);
            StyleReadOnlyTextBox(txtNgayDaoHan);
            StyleReadOnlyTextBox(txtNhanVienMo);
            StylePreviewGrid();

            btnXacDinhKhachHang.Text = "Xác định khách hàng";
            StylePrimaryButton(btnXacDinhKhachHang);

            btnXacNhan.Text = "Xác nhận mở sổ";
            btnLamMoi.Text = "Làm mới";
            StylePrimaryButton(btnXacNhan);
            StyleSecondaryButton(btnLamMoi);
        }

        private void BuildFields()
        {
            fieldsPanel.SuspendLayout();
            fieldsPanel.Controls.Clear();
            fieldsPanel.Controls.Add(CreateInputGroup("Họ tên khách hàng", txtHoTenKhachHang));
            fieldsPanel.Controls.Add(CreateInputGroup("CCCD khách hàng", txtCccdKhachHang));
            fieldsPanel.Controls.Add(CreateInputGroup("Mã khách hàng", txtMaKhachHang));
            fieldsPanel.Controls.Add(CreateActionGroup(btnXacDinhKhachHang));
            fieldsPanel.Controls.Add(CreateInputGroup("Chọn gói tiết kiệm", cboLoaiTietKiem));
            fieldsPanel.Controls.Add(CreateInputGroup("Nhập số tiền gửi", numSoTienGui));
            fieldsPanel.Controls.Add(CreateInputGroup("Lãi suất áp dụng", txtLaiSuat));
            fieldsPanel.Controls.Add(CreateInputGroup("Ngày đáo hạn", txtNgayDaoHan));
            fieldsPanel.Controls.Add(CreateInputGroup("Nhân viên mở sổ", txtNhanVienMo));
            fieldsPanel.ResumeLayout();
        }

        private void WireEvents()
        {
            txtHoTenKhachHang.TextChanged += CustomerLookupInput_TextChanged;
            txtCccdKhachHang.TextChanged += CustomerLookupInput_TextChanged;
            txtHoTenKhachHang.KeyDown += CustomerLookupInput_KeyDown;
            txtCccdKhachHang.KeyDown += CustomerLookupInput_KeyDown;
            btnXacDinhKhachHang.Click += (s, e) => ResolveSelectedKhachHang();
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
            var selectedGoi = cboLoaiTietKiem.SelectedItem as LoaiTietKiem;

            if (selectedKhachHang == null)
            {
                MessageBox.Show("Vui lòng xác định khách hàng bằng họ tên và CCCD trước.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            suppressCustomerInputChange = true;
            selectedKhachHang = null;
            txtHoTenKhachHang.Clear();
            txtCccdKhachHang.Clear();
            txtMaKhachHang.Clear();

            if (loaiTietKiems.Count > 0)
            {
                cboLoaiTietKiem.SelectedIndex = 0;
            }

            numSoTienGui.Value = 1000000;
            suppressCustomerInputChange = false;
            SetSavingsInputsEnabled(false);
            UpdateCalculatedFields();
        }

        private void UpdateCalculatedFields()
        {
            var selectedLoai = cboLoaiTietKiem.SelectedItem as LoaiTietKiem;

            if (selectedKhachHang == null)
            {
                txtLaiSuat.Clear();
                txtNgayDaoHan.Clear();
                SetPreviewHint("Bước 1: nhập họ tên và CCCD khách hàng, sau đó bấm Xác định khách hàng để hệ thống suy ra mã khách hàng.");
                RenderPreviewRows(selectedLoai);
                return;
            }

            if (selectedLoai == null)
            {
                txtLaiSuat.Clear();
                txtNgayDaoHan.Clear();
                SetPreviewHint("Khách hàng đã được xác định. Vui lòng chọn gói tiết kiệm để xem chi tiết mở sổ.");
                RenderPreviewRows(selectedLoai);
                return;
            }

            txtLaiSuat.Text = selectedLoai.LaiSuatNam.ToString("0.00") + "%/năm";
            txtNgayDaoHan.Text = selectedLoai.KyHanThang <= 0
                ? "Không kỳ hạn"
                : DateTime.Today.AddMonths(selectedLoai.KyHanThang).ToString("dd/MM/yyyy");

            SetPreviewHint("Bảng bên dưới tóm tắt toàn bộ thông tin sẽ được dùng để mở sổ.");
            RenderPreviewRows(selectedLoai);
        }

        private static void StyleComboBox(ComboBox comboBox)
        {
            comboBox.Font = new Font("Segoe UI", 10F);
            comboBox.Width = InputWidth;
            comboBox.Height = 32;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.FlatStyle = FlatStyle.Flat;
        }

        private static void StyleTextBox(TextBox textBox)
        {
            textBox.Font = new Font("Segoe UI", 10F);
            textBox.Width = InputWidth;
            textBox.Height = 32;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = Color.White;
            textBox.ForeColor = ControlFactory.TextColor;
        }

        private static void StyleNumericUpDown(NumericUpDown numericUpDown)
        {
            numericUpDown.Font = new Font("Segoe UI", 10F);
            numericUpDown.Width = InputWidth;
            numericUpDown.Height = 32;
            numericUpDown.BorderStyle = BorderStyle.FixedSingle;
            numericUpDown.Maximum = 1000000000;
            numericUpDown.Minimum = 0;
            numericUpDown.Increment = 100000;
            numericUpDown.ThousandsSeparator = true;
        }

        private static void StyleReadOnlyTextBox(TextBox textBox)
        {
            textBox.Font = new Font("Segoe UI", 10F);
            textBox.Width = InputWidth;
            textBox.Height = 32;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.ReadOnly = true;
            textBox.BackColor = Color.FromArgb(248, 250, 252);
            textBox.ForeColor = ControlFactory.TextColor;
        }

        private void StylePreviewGrid()
        {
            GridStyler.Apply(dgvPreview);
            dgvPreview.AllowUserToResizeColumns = false;
            dgvPreview.AllowUserToResizeRows = false;
            dgvPreview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPreview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPreview.RowTemplate.Height = 42;
            dgvPreview.RowHeadersVisible = false;
            dgvPreview.Columns.Clear();

            dgvPreview.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ThuocTinh",
                HeaderText = "Nội dung",
                FillWeight = 34,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });

            dgvPreview.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GiaTri",
                HeaderText = "Giá trị",
                FillWeight = 66,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    WrapMode = DataGridViewTriState.True,
                    Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                    ForeColor = ControlFactory.TextColor
                }
            });

            dgvPreview.ClearSelection();
        }

        private static void StylePrimaryButton(Button button)
        {
            button.BackColor = ControlFactory.PrimaryColor;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
            button.FlatAppearance.BorderSize = 0;
            button.Width = 200;
            button.Height = 44;
        }

        private static void StyleSecondaryButton(Button button)
        {
            button.BackColor = Color.White;
            button.ForeColor = ControlFactory.PrimaryColor;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
            button.FlatAppearance.BorderColor = ControlFactory.BorderColor;
            button.FlatAppearance.BorderSize = 1;
            button.Width = 173;
            button.Height = 44;
        }

        private void CustomerLookupInput_TextChanged(object sender, EventArgs e)
        {
            if (suppressCustomerInputChange)
            {
                return;
            }

            ClearSelectedKhachHang();
        }

        private void CustomerLookupInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            e.SuppressKeyPress = true;
            ResolveSelectedKhachHang();
        }

        private void ResolveSelectedKhachHang()
        {
            var hoTen = txtHoTenKhachHang.Text.Trim();
            var cccd = txtCccdKhachHang.Text.Trim();

            if (!FormValidator.Required(hoTen))
            {
                MessageBox.Show("Vui lòng nhập họ tên khách hàng.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTenKhachHang.Focus();
                return;
            }

            if (!FormValidator.IsCitizenId(cccd))
            {
                MessageBox.Show("CCCD phải gồm đúng 12 chữ số.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCccdKhachHang.Focus();
                txtCccdKhachHang.SelectAll();
                return;
            }

            var matchedKhachHang = khachHangs.FirstOrDefault(x =>
                string.Equals(NormalizeText(x.HoTen), NormalizeText(hoTen), StringComparison.OrdinalIgnoreCase) &&
                string.Equals((x.CCCD ?? string.Empty).Trim(), cccd, StringComparison.OrdinalIgnoreCase));

            if (matchedKhachHang == null)
            {
                ClearSelectedKhachHang();

                var duplicateCccd = khachHangs.FirstOrDefault(x =>
                    string.Equals((x.CCCD ?? string.Empty).Trim(), cccd, StringComparison.OrdinalIgnoreCase));

                if (duplicateCccd != null)
                {
                    MessageBox.Show("CCCD tồn tại nhưng họ tên không khớp với hồ sơ khách hàng.", "Không tìm thấy khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHoTenKhachHang.Focus();
                    txtHoTenKhachHang.SelectAll();
                    return;
                }

                MessageBox.Show("Không tìm thấy khách hàng phù hợp với họ tên và CCCD đã nhập.", "Không tìm thấy khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCccdKhachHang.Focus();
                txtCccdKhachHang.SelectAll();
                return;
            }

            if (!matchedKhachHang.DangHoatDong)
            {
                ClearSelectedKhachHang();
                MessageBox.Show("Khách hàng này đang ở trạng thái Unactive, không thể mở sổ.", "Khách hàng không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            selectedKhachHang = matchedKhachHang;
            txtMaKhachHang.Text = matchedKhachHang.MaKhachHang;
            SetSavingsInputsEnabled(true);
            UpdateCalculatedFields();

            if (cboLoaiTietKiem.Enabled)
            {
                cboLoaiTietKiem.Focus();
            }
        }

        private void ClearSelectedKhachHang()
        {
            selectedKhachHang = null;
            txtMaKhachHang.Clear();
            SetSavingsInputsEnabled(false);
            UpdateCalculatedFields();
        }

        private void SetSavingsInputsEnabled(bool enabled)
        {
            cboLoaiTietKiem.Enabled = enabled;
            numSoTienGui.Enabled = enabled;
            btnXacNhan.Enabled = enabled;
        }

        private void SetPreviewHint(string text)
        {
            lblPreviewHint.Text = text;
        }

        private void RenderPreviewRows(LoaiTietKiem selectedLoai)
        {
            dgvPreview.Rows.Clear();

            var rows = new[]
            {
                new[] { "Khách hàng", selectedKhachHang != null ? selectedKhachHang.HienThiCombo : "Chưa xác định" },
                new[] { "CCCD", selectedKhachHang != null ? selectedKhachHang.CCCD : "Chưa xác định" },
                new[] { "Mã khách hàng", selectedKhachHang != null ? selectedKhachHang.MaKhachHang : "Chưa suy ra" },
                new[] { "Gói tiết kiệm", selectedLoai != null ? selectedLoai.HienThiCombo : "Chưa chọn" },
                new[] { "Số tiền gửi", selectedKhachHang != null ? numSoTienGui.Value.ToString("N0") + " VND" : "Chưa nhập" },
                new[] { "Lãi suất áp dụng", !string.IsNullOrWhiteSpace(txtLaiSuat.Text) ? txtLaiSuat.Text : "Chưa có" },
                new[] { "Ngày đáo hạn", !string.IsNullOrWhiteSpace(txtNgayDaoHan.Text) ? txtNgayDaoHan.Text : "Chưa có" },
                new[] { "Nhân viên mở sổ", txtNhanVienMo.Text }
            };

            foreach (var row in rows)
            {
                dgvPreview.Rows.Add(row[0], row[1]);
            }

            dgvPreview.ClearSelection();
        }

        private static string NormalizeText(string value)
        {
            return string.Join(" ", (value ?? string.Empty)
                .Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        private static Panel CreateActionGroup(Button button)
        {
            var panel = new Panel
            {
                Width = InputGroupWidth,
                Height = 56,
                Margin = new Padding(0, 0, 0, 14),
                BackColor = Color.Transparent
            };

            button.Location = new Point(0, 0);
            button.Width = InputWidth;
            panel.Controls.Add(button);
            return panel;
        }

        private static Panel CreateInputGroup(string labelText, Control input)
        {
            var panel = new Panel
            {
                Width = InputGroupWidth,
                Height = InputGroupHeight,
                Margin = new Padding(0, 0, 0, 14),
                BackColor = Color.Transparent
            };

            var label = new Label
            {
                Text = labelText,
                AutoSize = true,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = ControlFactory.TextColor,
                Location = new Point(0, 0)
            };

            input.Location = new Point(0, 28);
            panel.Controls.Add(label);
            panel.Controls.Add(input);
            return panel;
        }
    }
}
