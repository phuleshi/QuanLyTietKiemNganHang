namespace QuanLyTietKiemNganHang.Forms
{
    partial class FrmDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel sidebar;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Label lblApp;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Button btnMoSo;
        private System.Windows.Forms.Button btnDanhSachSo;
        private System.Windows.Forms.Button btnGiaoDich;
        private System.Windows.Forms.Button btnLoaiTietKiem;
        private System.Windows.Forms.Button btnTatToan;
        private System.Windows.Forms.Button btnLichSu;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.TableLayoutPanel cardsPanel;
        private System.Windows.Forms.Panel announceCard;
        private System.Windows.Forms.Label lblAnnTitle;
        private System.Windows.Forms.Label lblThongBao;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.topPanel = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.sidebar = new System.Windows.Forms.Panel();
            this.btnLichSu = new System.Windows.Forms.Button();
            this.btnTatToan = new System.Windows.Forms.Button();
            this.btnLoaiTietKiem = new System.Windows.Forms.Button();
            this.btnGiaoDich = new System.Windows.Forms.Button();
            this.btnDanhSachSo = new System.Windows.Forms.Button();
            this.btnMoSo = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.lblApp = new System.Windows.Forms.Label();
            this.lblMenu = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.announceCard = new System.Windows.Forms.Panel();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.lblAnnTitle = new System.Windows.Forms.Label();
            this.cardsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.topPanel.SuspendLayout();
            this.sidebar.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.announceCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.btnLogout);
            this.topPanel.Controls.Add(this.lblUser);
            this.topPanel.Controls.Add(this.lblTitle);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(24, 14, 24, 14);
            this.topPanel.Size = new System.Drawing.Size(1264, 64);
            this.topPanel.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Location = new System.Drawing.Point(1120, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(120, 40);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(400, 22);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(48, 13);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "lblUser";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(24, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(182, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Dashboard - Quản lý sổ tiết kiệm";
            // 
            // sidebar
            // 
            this.sidebar.Controls.Add(this.btnLichSu);
            this.sidebar.Controls.Add(this.btnTatToan);
            this.sidebar.Controls.Add(this.btnLoaiTietKiem);
            this.sidebar.Controls.Add(this.btnGiaoDich);
            this.sidebar.Controls.Add(this.btnDanhSachSo);
            this.sidebar.Controls.Add(this.btnMoSo);
            this.sidebar.Controls.Add(this.btnNhanVien);
            this.sidebar.Controls.Add(this.btnKhachHang);
            this.sidebar.Controls.Add(this.lblApp);
            this.sidebar.Controls.Add(this.lblMenu);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 64);
            this.sidebar.Name = "sidebar";
            this.sidebar.Padding = new System.Windows.Forms.Padding(20, 24, 20, 24);
            this.sidebar.Size = new System.Drawing.Size(230, 657);
            this.sidebar.TabIndex = 1;
            // 
            // btnLichSu
            // 
            this.btnLichSu.Location = new System.Drawing.Point(20, 482);
            this.btnLichSu.Name = "btnLichSu";
            this.btnLichSu.Size = new System.Drawing.Size(188, 42);
            this.btnLichSu.TabIndex = 9;
            this.btnLichSu.Text = "Lịch sử hoạt động";
            this.btnLichSu.UseVisualStyleBackColor = true;
            // 
            // btnTatToan
            // 
            this.btnTatToan.Location = new System.Drawing.Point(20, 430);
            this.btnTatToan.Name = "btnTatToan";
            this.btnTatToan.Size = new System.Drawing.Size(188, 42);
            this.btnTatToan.TabIndex = 8;
            this.btnTatToan.Text = "Tất toán / Rút gốc";
            this.btnTatToan.UseVisualStyleBackColor = true;
            // 
            // btnLoaiTietKiem
            // 
            this.btnLoaiTietKiem.Location = new System.Drawing.Point(20, 378);
            this.btnLoaiTietKiem.Name = "btnLoaiTietKiem";
            this.btnLoaiTietKiem.Size = new System.Drawing.Size(188, 42);
            this.btnLoaiTietKiem.TabIndex = 7;
            this.btnLoaiTietKiem.Text = "Gói tiết kiệm";
            this.btnLoaiTietKiem.UseVisualStyleBackColor = true;
            // 
            // btnGiaoDich
            // 
            this.btnGiaoDich.Location = new System.Drawing.Point(20, 326);
            this.btnGiaoDich.Name = "btnGiaoDich";
            this.btnGiaoDich.Size = new System.Drawing.Size(188, 42);
            this.btnGiaoDich.TabIndex = 6;
            this.btnGiaoDich.Text = "Giao dịch";
            this.btnGiaoDich.UseVisualStyleBackColor = true;
            // 
            // btnDanhSachSo
            // 
            this.btnDanhSachSo.Location = new System.Drawing.Point(20, 274);
            this.btnDanhSachSo.Name = "btnDanhSachSo";
            this.btnDanhSachSo.Size = new System.Drawing.Size(188, 42);
            this.btnDanhSachSo.TabIndex = 5;
            this.btnDanhSachSo.Text = "Danh sách sổ";
            this.btnDanhSachSo.UseVisualStyleBackColor = true;
            // 
            // btnMoSo
            // 
            this.btnMoSo.Location = new System.Drawing.Point(20, 222);
            this.btnMoSo.Name = "btnMoSo";
            this.btnMoSo.Size = new System.Drawing.Size(188, 42);
            this.btnMoSo.TabIndex = 4;
            this.btnMoSo.Text = "Mở sổ";
            this.btnMoSo.UseVisualStyleBackColor = true;
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Location = new System.Drawing.Point(20, 170);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(188, 42);
            this.btnNhanVien.TabIndex = 3;
            this.btnNhanVien.Text = "Quản lý Nhân viên";
            this.btnNhanVien.UseVisualStyleBackColor = true;
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Location = new System.Drawing.Point(20, 118);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(188, 42);
            this.btnKhachHang.TabIndex = 2;
            this.btnKhachHang.Text = "Quản lý Khách hàng";
            this.btnKhachHang.UseVisualStyleBackColor = true;
            // 
            // lblApp
            // 
            this.lblApp.AutoSize = true;
            this.lblApp.Location = new System.Drawing.Point(24, 48);
            this.lblApp.Name = "lblApp";
            this.lblApp.Size = new System.Drawing.Size(62, 13);
            this.lblApp.TabIndex = 1;
            this.lblApp.Text = "Sổ tiết kiệm";
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Location = new System.Drawing.Point(24, 24);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(73, 13);
            this.lblMenu.TabIndex = 0;
            this.lblMenu.Text = "ĐIỀU HƯỚNG";
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.announceCard);
            this.contentPanel.Controls.Add(this.cardsPanel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(230, 64);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(24);
            this.contentPanel.Size = new System.Drawing.Size(1034, 657);
            this.contentPanel.TabIndex = 2;
            // 
            // announceCard
            // 
            this.announceCard.Controls.Add(this.lblThongBao);
            this.announceCard.Controls.Add(this.lblAnnTitle);
            this.announceCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.announceCard.Location = new System.Drawing.Point(24, 284);
            this.announceCard.Name = "announceCard";
            this.announceCard.Padding = new System.Windows.Forms.Padding(22);
            this.announceCard.Size = new System.Drawing.Size(986, 148);
            this.announceCard.TabIndex = 1;
            // 
            // lblThongBao
            // 
            this.lblThongBao.Location = new System.Drawing.Point(22, 50);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(900, 68);
            this.lblThongBao.TabIndex = 1;
            // 
            // lblAnnTitle
            // 
            this.lblAnnTitle.AutoSize = true;
            this.lblAnnTitle.Location = new System.Drawing.Point(22, 18);
            this.lblAnnTitle.Name = "lblAnnTitle";
            this.lblAnnTitle.Size = new System.Drawing.Size(99, 13);
            this.lblAnnTitle.TabIndex = 0;
            this.lblAnnTitle.Text = "Thông báo hệ thống";
            // 
            // cardsPanel
            // 
            this.cardsPanel.ColumnCount = 3;
            this.cardsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.cardsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.cardsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.cardsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.cardsPanel.Location = new System.Drawing.Point(24, 24);
            this.cardsPanel.Name = "cardsPanel";
            this.cardsPanel.RowCount = 2;
            this.cardsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.cardsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.cardsPanel.Size = new System.Drawing.Size(986, 260);
            this.cardsPanel.TabIndex = 0;
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 721);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.topPanel);
            this.MinimumSize = new System.Drawing.Size(1200, 720);
            this.Name = "FrmDashboard";
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.sidebar.ResumeLayout(false);
            this.sidebar.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.announceCard.ResumeLayout(false);
            this.announceCard.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
