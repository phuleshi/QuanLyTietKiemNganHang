using QuanLyTietKiemNganHang.Helpers;
using QuanLyTietKiemNganHang.Models;
using QuanLyTietKiemNganHang.Services;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTietKiemNganHang.Forms
{
    public class FrmDashboard : Form
    {
        private readonly DashboardService dashboardService = new DashboardService();
        private readonly TableLayoutPanel cardsPanel = new TableLayoutPanel();
        private readonly Label lblThongBao = new Label();
        private readonly NhanVien currentUser;

        public FrmDashboard(NhanVien currentUser)
        {
            this.currentUser = currentUser;
            InitializeUi();
            LoadStats();
        }

        private void InitializeUi()
        {
            Text = "Dashboard";
            WindowState = FormWindowState.Maximized;
            MinimumSize = new Size(1200, 720);
            BackColor = ControlFactory.BackgroundColor;

            var topPanel = new Panel { Dock = DockStyle.Top, Height = 64, BackColor = Color.White, Padding = new Padding(24, 14, 24, 14) };

            var lblTitle = ControlFactory.CreateTitleLabel("Dashboard - Quản lý sổ tiết kiệm", 18);
            lblTitle.Location = new Point(24, 16);

            var lblUser = ControlFactory.CreateMutedLabel("Xin chào, " + currentUser.HoTen + " (" + currentUser.MaNhanVien + ")");
            lblUser.Location = new Point(400, 22);
            lblUser.AutoSize = true;

            var btnLogout = ControlFactory.CreateSecondaryButton("Đăng xuất");
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.Location = new Point(1040, 12);
            btnLogout.Click += (s, e) => Close();

            topPanel.Controls.AddRange(new Control[] { lblTitle, lblUser, btnLogout });
            topPanel.Resize += (s, e) =>
            {
                btnLogout.Left = topPanel.Width - btnLogout.Width - 24;
            };

            var sidebar = new Panel { Dock = DockStyle.Left, Width = 230, BackColor = ControlFactory.SecondaryColor, Padding = new Padding(20, 24, 20, 24) };
            var lblMenu = new Label
            {
                Text = "ĐIỀU HƯỚNG",
                ForeColor = Color.FromArgb(191, 219, 254),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(24, 24)
            };
            var lblApp = new Label
            {
                Text = "Sổ tiết kiệm",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(24, 48)
            };

            var btnKhachHang = ControlFactory.CreateSidebarButton("Quản lý Khách hàng");
            btnKhachHang.Location = new Point(20, 118);
            btnKhachHang.Click += (s, e) => new FrmKhachHang().ShowDialog();

            var btnNhanVien = ControlFactory.CreateSidebarButton("Quản lý Nhân viên");
            btnNhanVien.Location = new Point(20, 170);
            btnNhanVien.Click += (s, e) => new FrmNhanVien().ShowDialog();

            sidebar.Controls.AddRange(new Control[] { lblMenu, lblApp, btnKhachHang, btnNhanVien });

            var contentPanel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(24) };

            cardsPanel.Dock = DockStyle.Top;
            cardsPanel.Height = 260;
            cardsPanel.ColumnCount = 3;
            cardsPanel.RowCount = 2;
            cardsPanel.AutoSize = false;
            cardsPanel.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            cardsPanel.BackColor = Color.Transparent;
            cardsPanel.Margin = new Padding(0, 0, 0, 18);
            cardsPanel.ColumnStyles.Clear();
            cardsPanel.RowStyles.Clear();
            cardsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
            cardsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
            cardsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34f));
            cardsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
            cardsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));

            var announceCard = ControlFactory.CreateSectionCard(DockStyle.Top, new Padding(22));
            announceCard.Height = 148;
            announceCard.Margin = new Padding(0, 18, 0, 18);
            announceCard.Top = 140;

            var lblAnnTitle = ControlFactory.CreateTitleLabel("Thông báo hệ thống", 13);
            lblAnnTitle.Location = new Point(22, 18);

            lblThongBao.Location = new Point(22, 50);
            lblThongBao.AutoSize = false;
            lblThongBao.Width = 900;
            lblThongBao.Height = 68;
            lblThongBao.Font = new Font("Segoe UI", 10);
            lblThongBao.ForeColor = ControlFactory.TextColor;

            announceCard.Controls.Add(lblAnnTitle);
            announceCard.Controls.Add(lblThongBao);

            contentPanel.Controls.Add(announceCard);
            contentPanel.Controls.Add(cardsPanel);

            Controls.Add(contentPanel);
            Controls.Add(sidebar);
            Controls.Add(topPanel);
        }

        private void LoadStats()
        {
            var stats = dashboardService.GetStats();
            cardsPanel.Controls.Clear();
            cardsPanel.Controls.Add(ControlFactory.CreateCard("Tổng khách hàng", stats.TongKhachHang.ToString(), ControlFactory.SuccessColor), 0, 0);
            cardsPanel.Controls.Add(ControlFactory.CreateCard("Tổng nhân viên", stats.TongNhanVien.ToString(), Color.FromArgb(168, 85, 247)), 1, 0);
            cardsPanel.Controls.Add(ControlFactory.CreateCard("Tổng sổ tiết kiệm", stats.TongSoTietKiem.ToString(), Color.FromArgb(14, 165, 233)), 2, 0);
            cardsPanel.Controls.Add(ControlFactory.CreateCard("Khách hàng hoạt động", stats.KhachHangHoatDong.ToString(), ControlFactory.WarningColor), 0, 1);
            cardsPanel.Controls.Add(ControlFactory.CreateCard("Nhân viên đang làm", stats.NhanVienDangLam.ToString(), ControlFactory.PrimaryColor), 1, 1);
            cardsPanel.Controls.Add(ControlFactory.CreateCard("Sổ đang hoạt động", stats.SoTietKiemDangHoatDong.ToString(), Color.FromArgb(5, 150, 105)), 2, 1);
            lblThongBao.Text = stats.ThongBaoHeThong + "\nPhạm vi hiện tại chỉ gồm Login, Dashboard, CRUD Khách hàng, CRUD Nhân viên và test giao diện.";
        }
    }
}
