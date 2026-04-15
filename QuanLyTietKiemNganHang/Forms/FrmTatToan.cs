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
    public partial class FrmTatToan : Form
    {
        private readonly XuLyGiaoDich service = new XuLyGiaoDich();
        private readonly KhachHangService khachHangService = new KhachHangService();
        private readonly XuLySoTietKiem soTietKiemService = new XuLySoTietKiem();
        private readonly NhanVien currentUser;
        private readonly string maSoMacDinh;
        private KetQuaTatToan ketQua;
        private List<KhachHang> khachHangs = new List<KhachHang>();
        private KhachHang selectedKhachHang;

        public FrmTatToan()
            : this(null, null)
        {
        }

        public FrmTatToan(NhanVien currentUser, string maSoMacDinh)
        {
            this.currentUser = currentUser;
            this.maSoMacDinh = maSoMacDinh;
            InitializeComponent();
            ApplyTheme();
            WireEvents();
            LoadLookups();
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

            lblThongTin.ForeColor = ControlFactory.TextColor;
            lblThongBao.ForeColor = ControlFactory.WarningColor;
            StyleTextBox(txtHoTenKhachHang);
            StyleTextBox(txtCccdKhachHang);
            StyleReadOnlyTextBox(txtMaKhachHang);
            cboSo.Font = new Font("Segoe UI", 10F);
            cboSo.FlatStyle = FlatStyle.Flat;

            StylePrimaryButton(btnTinh);
            StylePrimaryButton(btnXacDinhKhachHang);
            StyleSecondaryButton(btnXacNhan);
            btnTinh.BringToFront();
        }

        private void WireEvents()
        {
            txtHoTenKhachHang.TextChanged += CustomerLookupInput_TextChanged;
            txtCccdKhachHang.TextChanged += CustomerLookupInput_TextChanged;
            txtHoTenKhachHang.KeyDown += CustomerLookupInput_KeyDown;
            txtCccdKhachHang.KeyDown += CustomerLookupInput_KeyDown;
            btnXacDinhKhachHang.Click += (s, e) => ResolveSelectedKhachHang();
            cboSo.SelectedIndexChanged += (s, e) => ResetKetQuaHienThi();
            rdRutGoc.CheckedChanged += (s, e) => numRut.Enabled = rdRutGoc.Checked && cboSo.Enabled;
            rdTatToanToanBo.CheckedChanged += (s, e) => ResetKetQuaHienThi();
            btnTinh.Click += (s, e) => TinhKetQua();
            btnXacNhan.Click += (s, e) => XacNhan();
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

        private static void StyleTextBox(TextBox textBox)
        {
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = Color.White;
            textBox.ForeColor = ControlFactory.TextColor;
            textBox.Font = new Font("Segoe UI", 10F);
        }

        private static void StyleReadOnlyTextBox(TextBox textBox)
        {
            StyleTextBox(textBox);
            textBox.ReadOnly = true;
            textBox.BackColor = Color.FromArgb(248, 250, 252);
        }

        private void LoadLookups()
        {
            try
            {
                khachHangs = khachHangService.GetAll();
                ClearSelectedKhachHang();
                TryPreselectFromMaSoMacDinh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được dữ liệu tất toán/rút gốc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TryPreselectFromMaSoMacDinh()
        {
            if (string.IsNullOrWhiteSpace(maSoMacDinh))
            {
                return;
            }

            var soMacDinh = soTietKiemService.GetByMaSo(maSoMacDinh);
            if (soMacDinh == null)
            {
                return;
            }

            var khachHangMacDinh = khachHangs.FirstOrDefault(x => x.MaKhachHang == soMacDinh.MaKhachHang);
            if (khachHangMacDinh == null)
            {
                return;
            }

            txtHoTenKhachHang.TextChanged -= CustomerLookupInput_TextChanged;
            txtCccdKhachHang.TextChanged -= CustomerLookupInput_TextChanged;

            txtHoTenKhachHang.Text = khachHangMacDinh.HoTen;
            txtCccdKhachHang.Text = khachHangMacDinh.CCCD;

            txtHoTenKhachHang.TextChanged += CustomerLookupInput_TextChanged;
            txtCccdKhachHang.TextChanged += CustomerLookupInput_TextChanged;

            ApplySelectedKhachHang(khachHangMacDinh, soMacDinh.MaSo);
        }

        private void CustomerLookupInput_TextChanged(object sender, EventArgs e)
        {
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
                var duplicateCccd = khachHangs.FirstOrDefault(x =>
                    string.Equals((x.CCCD ?? string.Empty).Trim(), cccd, StringComparison.OrdinalIgnoreCase));

                ClearSelectedKhachHang();

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
                MessageBox.Show("Khách hàng này đang ở trạng thái Unactive, không thể thực hiện giao dịch.", "Khách hàng không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ApplySelectedKhachHang(matchedKhachHang, maSoMacDinh);
        }

        private void ApplySelectedKhachHang(KhachHang khachHang, string maSoUuTien)
        {
            selectedKhachHang = khachHang;
            txtMaKhachHang.Text = khachHang.MaKhachHang;
            LoadDanhSachSoTheoKhachHang(khachHang.MaKhachHang, maSoUuTien);
        }

        private void LoadDanhSachSoTheoKhachHang(string maKhachHang, string maSoUuTien)
        {
            ketQua = null;
            lblThongBao.Text = string.Empty;

            var ds = service.GetDanhSachSoDangMoTheoKhachHang(maKhachHang);
            cboSo.DataSource = null;
            cboSo.DisplayMember = "HienThiCombo";
            cboSo.ValueMember = "MaSo";
            cboSo.DataSource = ds;
            cboSo.Enabled = ds.Count > 0;

            if (!string.IsNullOrWhiteSpace(maSoUuTien) && ds.Any(x => x.MaSo == maSoUuTien))
            {
                cboSo.SelectedValue = maSoUuTien;
            }
            else if (ds.Count > 0)
            {
                cboSo.SelectedIndex = 0;
            }

            SetTransactionInputsEnabled(ds.Count > 0);

            lblThongTin.Text = ds.Count == 0
                ? "Khách hàng này hiện không có sổ tiết kiệm đang mở để tất toán hoặc rút gốc."
                : "Đã tìm thấy " + ds.Count + " sổ đang mở của khách hàng. Chọn sổ tiết kiệm và nhấn Tính để xem số tiền nhận.";
        }

        private void ClearSelectedKhachHang()
        {
            selectedKhachHang = null;
            txtMaKhachHang.Clear();
            cboSo.DataSource = null;
            cboSo.Enabled = false;
            SetTransactionInputsEnabled(false);
            ResetKetQuaHienThi();
            lblThongTin.Text = "Nhập họ tên và CCCD khách hàng, sau đó bấm Xác định khách hàng để tải danh sách sổ tiết kiệm.";
        }

        private void SetTransactionInputsEnabled(bool enabled)
        {
            cboSo.Enabled = enabled;
            rdTatToanToanBo.Enabled = enabled;
            rdRutGoc.Enabled = enabled;
            btnTinh.Enabled = enabled;
            btnXacNhan.Enabled = enabled;
            numRut.Enabled = enabled && rdRutGoc.Checked;
        }

        private void ResetKetQuaHienThi()
        {
            ketQua = null;
            lblThongBao.Text = string.Empty;

            if (selectedKhachHang == null)
            {
                lblThongTin.Text = "Nhập họ tên và CCCD khách hàng, sau đó bấm Xác định khách hàng để tải danh sách sổ tiết kiệm.";
                return;
            }

            if (!cboSo.Enabled || cboSo.Items.Count == 0)
            {
                lblThongTin.Text = "Khách hàng này hiện không có sổ tiết kiệm đang mở để tất toán hoặc rút gốc.";
                return;
            }

            lblThongTin.Text = "Chọn sổ tiết kiệm của khách hàng và nhấn Tính để xem số tiền nhận.";
        }

        private static string NormalizeText(string value)
        {
            return string.Join(" ", (value ?? string.Empty)
                .Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        private void TinhKetQua()
        {
            var selected = cboSo.SelectedItem as SoTietKiemDanhSachItem;
            if (selected == null)
            {
                MessageBox.Show("Vui lòng chọn sổ tiết kiệm.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ketQua = service.TinhTatToan(selected.MaSo, numRut.Value, rdTatToanToanBo.Checked);
                lblThongTin.Text =
                    "Mã sổ: " + ketQua.MaSo + Environment.NewLine +
                    "Số tiền gốc rút: " + ketQua.GocRut.ToString("N0") + " VND" + Environment.NewLine +
                    "Lãi tính được: " + ketQua.LaiTinhDuoc.ToString("N0") + " VND" + Environment.NewLine +
                    "Tổng nhận: " + ketQua.TongNhan.ToString("N0") + " VND" + Environment.NewLine +
                    "Số dư còn lại: " + ketQua.SoDuConLai.ToString("N0") + " VND";
                lblThongBao.Text = ketQua.ThongBao;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tính tất toán/rút gốc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XacNhan()
        {
            var selected = cboSo.SelectedItem as SoTietKiemDanhSachItem;
            if (selected == null)
            {
                MessageBox.Show("Vui lòng chọn sổ tiết kiệm.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ketQua == null)
            {
                MessageBox.Show("Vui lòng nhấn Tính trước khi xác nhận.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (rdTatToanToanBo.Checked)
                {
                    service.XacNhanTatToan(selected.MaSo, currentUser != null ? currentUser.MaNhanVien : null);
                }
                else
                {
                    service.XacNhanRutGoc(selected.MaSo, ketQua.GocRut, currentUser != null ? currentUser.MaNhanVien : null);
                }

                MessageBox.Show("Xử lý giao dịch thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xác nhận giao dịch: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
