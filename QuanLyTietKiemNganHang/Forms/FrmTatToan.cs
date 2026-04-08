using QuanLyTietKiemNganHang.Helpers;
using QuanLyTietKiemNganHang.Models;
using QuanLyTietKiemNganHang.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTietKiemNganHang.Forms
{
    public partial class FrmTatToan : Form
    {
        private readonly XuLyGiaoDich service = new XuLyGiaoDich();
        private readonly NhanVien currentUser;
        private KetQuaTatToan ketQua;

        public FrmTatToan()
            : this(null, null)
        {
        }

        public FrmTatToan(NhanVien currentUser, string maSoMacDinh)
        {
            this.currentUser = currentUser;
            InitializeComponent();
            ApplyTheme();
            WireEvents();
            LoadDanhSachSo(maSoMacDinh);
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

            StylePrimaryButton(btnTinh);
            StyleSecondaryButton(btnXacNhan);
            btnTinh.BringToFront();
        }

        private void WireEvents()
        {
            rdRutGoc.CheckedChanged += (s, e) => numRut.Enabled = rdRutGoc.Checked;
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

        private void LoadDanhSachSo(string maSoMacDinh)
        {
            try
            {
                var ds = service.GetDanhSachSoDangMo();
                cboSo.DataSource = ds;
                cboSo.DisplayMember = "MaSo";
                cboSo.ValueMember = "MaSo";
                if (!string.IsNullOrWhiteSpace(maSoMacDinh))
                {
                    cboSo.SelectedValue = maSoMacDinh;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được danh sách sổ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
