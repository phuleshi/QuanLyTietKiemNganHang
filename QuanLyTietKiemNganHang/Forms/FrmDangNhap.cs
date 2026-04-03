using QuanLyTietKiemNganHang.Helpers;
using QuanLyTietKiemNganHang.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTietKiemNganHang.Forms
{
    public partial class FrmDangNhap : Form
    {
        private readonly AuthService authService = new AuthService();

        public FrmDangNhap()
        {
            InitializeComponent();
            ApplyTheme();
            WireEvents();
        }

        private void ApplyTheme()
        {
            BackColor = ControlFactory.BackgroundColor;
            mainLayout.BackColor = ControlFactory.BackgroundColor;
            card.BackColor = ControlFactory.SurfaceColor;
            card.BorderStyle = BorderStyle.FixedSingle;

            lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitle.ForeColor = ControlFactory.TextColor;
            lblUser.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblUser.ForeColor = ControlFactory.TextColor;
            lblPass.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblPass.ForeColor = ControlFactory.TextColor;

            txtUsername.Font = new Font("Segoe UI", 10);
            txtPassword.Font = new Font("Segoe UI", 10);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.BackColor = Color.White;
            txtPassword.BackColor = Color.White;
            txtUsername.ForeColor = ControlFactory.TextColor;
            txtPassword.ForeColor = ControlFactory.TextColor;

            lblError.ForeColor = ControlFactory.DangerColor;
            lblError.Font = new Font("Segoe UI", 9);
            lblHint.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            lblHint.ForeColor = ControlFactory.MutedTextColor;

            StylePrimaryButton(btnLogin);
            StyleSecondaryButton(btnExit);
        }

        private void WireEvents()
        {
            AcceptButton = btnLogin;
            btnLogin.Click += BtnLogin_Click;
            btnExit.Click += (s, e) => Close();
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

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            if (!FormValidator.Required(txtUsername.Text) || !FormValidator.Required(txtPassword.Text))
            {
                lblError.Text = "Vui lòng nhập tài khoản và mật khẩu.";
                return;
            }

            var user = authService.Login(txtUsername.Text.Trim(), txtPassword.Text.Trim());
            if (user == null)
            {
                lblError.Text = "Sai thông tin đăng nhập.";
                return;
            }

            Hide();
            using (var dashboard = new FrmDashboard(user))
            {
                dashboard.ShowDialog();
            }
            Show();
            txtPassword.SelectAll();
            txtPassword.Focus();
        }
    }
}
