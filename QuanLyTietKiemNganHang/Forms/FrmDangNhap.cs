using QuanLyTietKiemNganHang.Helpers;
using QuanLyTietKiemNganHang.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTietKiemNganHang.Forms
{
    public class FrmDangNhap : Form
    {
        private readonly TextBox txtUsername = ControlFactory.CreateTextBox();
        private readonly TextBox txtPassword = ControlFactory.CreateTextBox();
        private readonly Label lblError = new Label();
        private readonly AuthService authService = new AuthService();

        private Panel mainPanel;
        private Panel card;

        public FrmDangNhap()
        {
            InitializeUi();
        }

        private void InitializeUi()
        {
            Text = "Đăng nhập";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(620, 520);
            MinimumSize = new Size(620, 520);
            BackColor = ControlFactory.BackgroundColor;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(70, 55, 70, 55),
                BackColor = ControlFactory.BackgroundColor
            };

            card = ControlFactory.CreateSectionCard(DockStyle.None, new Padding(34));
            card.Size = new Size(430, 360);

            var lblTitle = ControlFactory.CreateTitleLabel("Đăng nhập hệ thống quản lý sổ tiết kiệm", 16);
            lblTitle.Location = new Point(34, 28);
            lblTitle.MaximumSize = new Size(340, 0);

            var lblUser = ControlFactory.CreateFieldLabel("Mã nhân viên / tài khoản");
            lblUser.Location = new Point(34, 96);

            txtUsername.Location = new Point(34, 122);
            txtUsername.Width = 330;
            txtUsername.Text = "NV001";

            var lblPass = ControlFactory.CreateFieldLabel("Mật khẩu");
            lblPass.Location = new Point(34, 172);

            txtPassword.Location = new Point(34, 198);
            txtPassword.Width = 330;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.Text = "123456";

            lblError.Location = new Point(34, 236);
            lblError.ForeColor = ControlFactory.DangerColor;
            lblError.Font = new Font("Segoe UI", 9);
            lblError.AutoSize = true;

            var btnLogin = ControlFactory.CreatePrimaryButton("Đăng nhập");
            btnLogin.Location = new Point(34, 272);
            btnLogin.Width = 145;
            btnLogin.Click += BtnLogin_Click;

            var btnExit = ControlFactory.CreateSecondaryButton("Thoát");
            btnExit.Location = new Point(192, 272);
            btnExit.Width = 120;
            btnExit.Click += (s, e) => Close();

            var hint = new Label
            {
                Text = "Mock account: NV001 / 123456",
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = ControlFactory.MutedTextColor,
                AutoSize = true,
                Location = new Point(34, 320)
            };

            card.Controls.AddRange(new Control[]
            {
                lblTitle, lblUser, txtUsername, lblPass, txtPassword, lblError, btnLogin, btnExit, hint
            });

            mainPanel.Controls.Add(card);
            Controls.Add(mainPanel);

            AcceptButton = btnLogin;

            Load += (s, e) => CenterLoginCard();
            Resize += (s, e) => CenterLoginCard();
            mainPanel.Resize += (s, e) => CenterLoginCard();
        }

        private void CenterLoginCard()
        {
            if (mainPanel == null || card == null) return;

            int x = (mainPanel.ClientSize.Width - card.Width) / 2;
            int y = (mainPanel.ClientSize.Height - card.Height) / 2;

            if (x < 0) x = 0;
            if (y < 0) y = 0;

            card.Location = new Point(x, y);
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