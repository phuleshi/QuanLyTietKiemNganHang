using QuanLyTietKiemNganHang.Helpers;
using QuanLyTietKiemNganHang.Models;
using QuanLyTietKiemNganHang.Services;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTietKiemNganHang.Forms
{
    public partial class FrmDashboard : Form
    {
        private readonly DashboardService dashboardService = new DashboardService();
        private readonly NhanVien currentUser;

        public FrmDashboard(NhanVien currentUser)
        {
            this.currentUser = currentUser;
            InitializeComponent();
            ApplyTheme();
            WireEvents();
            try
            {
                LoadStats();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Không tải được dữ liệu dashboard từ SQL Server: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyTheme()
        {
            BackColor = ControlFactory.BackgroundColor;
            topPanel.BackColor = Color.White;
            sidebar.BackColor = ControlFactory.SecondaryColor;
            contentPanel.BackColor = ControlFactory.BackgroundColor;
            announceCard.BackColor = ControlFactory.SurfaceColor;
            announceCard.BorderStyle = BorderStyle.FixedSingle;

            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.ForeColor = ControlFactory.TextColor;
            lblUser.Font = new Font("Segoe UI", 9);
            lblUser.ForeColor = ControlFactory.MutedTextColor;

            var tenNhanVien = string.IsNullOrWhiteSpace(currentUser.TenNhanVien) ? currentUser.TaiKhoan : currentUser.TenNhanVien;
            lblUser.Text = "Xin chào, " + tenNhanVien + " (" + currentUser.MaNhanVien + " - " + currentUser.VaiTro + ")";

            lblMenu.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblMenu.ForeColor = Color.FromArgb(191, 219, 254);
            lblApp.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblApp.ForeColor = Color.White;
            lblAnnTitle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            lblAnnTitle.ForeColor = ControlFactory.TextColor;
            lblThongBao.Font = new Font("Segoe UI", 10);
            lblThongBao.ForeColor = ControlFactory.TextColor;

            StyleSecondaryButton(btnLogout);
            StyleSidebarButton(btnKhachHang);
            StyleSidebarButton(btnNhanVien);
            StyleSidebarButton(btnMoSo);
            StyleSidebarButton(btnDanhSachSo);
        }

        private void WireEvents()
        {
            btnLogout.Click += (s, e) => Close();
            btnKhachHang.Click += (s, e) => new FrmKhachHang().ShowDialog();
            btnNhanVien.Click += (s, e) => new FrmNhanVien().ShowDialog();
            btnMoSo.Click += (s, e) => new FrmMoSo(currentUser).ShowDialog();
            btnDanhSachSo.Click += (s, e) => new FrmDanhSachSo(currentUser).ShowDialog();
            topPanel.Resize += (s, e) => btnLogout.Left = topPanel.Width - btnLogout.Width - 24;
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

        private static void StyleSidebarButton(Button button)
        {
            button.BackColor = Color.FromArgb(30, 41, 59);
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.Padding = new Padding(14, 0, 0, 0);
            button.FlatAppearance.BorderSize = 0;
        }

        private void LoadStats()
        {
            var stats = dashboardService.GetStats();
            cardsPanel.Controls.Clear();
            cardsPanel.Controls.Add(ControlFactory.CreateCard("Tổng khách hàng", stats.TongKhachHang.ToString(), ControlFactory.SuccessColor), 0, 0);
            cardsPanel.Controls.Add(ControlFactory.CreateCard("Tổng nhân viên", stats.TongNhanVien.ToString(), Color.FromArgb(168, 85, 247)), 1, 0);
            cardsPanel.Controls.Add(ControlFactory.CreateCard("Tổng sổ tiết kiệm", stats.TongSoTietKiem.ToString(), Color.FromArgb(14, 165, 233)), 2, 0);
            cardsPanel.Controls.Add(ControlFactory.CreateCard("Sổ đang mở", stats.SoTietKiemDangMo.ToString(), ControlFactory.WarningColor), 0, 1);
            cardsPanel.Controls.Add(ControlFactory.CreateCard("Tổng giao dịch", stats.SoGiaoDich.ToString(), ControlFactory.PrimaryColor), 1, 1);
            cardsPanel.Controls.Add(ControlFactory.CreateCard("Gói tiết kiệm", stats.SoGoiTietKiem.ToString(), Color.FromArgb(5, 150, 105)), 2, 1);
            lblThongBao.Text = stats.ThongBaoHeThong;
        }
    }
}
