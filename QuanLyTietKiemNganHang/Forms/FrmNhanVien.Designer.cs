namespace QuanLyTietKiemNganHang.Forms
{
    partial class FrmNhanVien
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel leftWrap;
        private System.Windows.Forms.Panel rightWrap;
        private System.Windows.Forms.Panel formCard;
        private System.Windows.Forms.Panel listCard;
        private System.Windows.Forms.Label lblCardTitle;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.FlowLayoutPanel fieldsPanel;
        private System.Windows.Forms.Panel actionPanel;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnMoi;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtChucVu;
        private System.Windows.Forms.TextBox txtLuong;
        private System.Windows.Forms.DateTimePicker dtpNgayVaoLam;
        private System.Windows.Forms.ComboBox cboTrangThai;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.leftWrap = new System.Windows.Forms.Panel();
            this.formCard = new System.Windows.Forms.Panel();
            this.actionPanel = new System.Windows.Forms.Panel();
            this.btnMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.fieldsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSelected = new System.Windows.Forms.Label();
            this.lblCardTitle = new System.Windows.Forms.Label();
            this.rightWrap = new System.Windows.Forms.Panel();
            this.listCard = new System.Windows.Forms.Panel();
            this.grid = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtChucVu = new System.Windows.Forms.TextBox();
            this.txtLuong = new System.Windows.Forms.TextBox();
            this.dtpNgayVaoLam = new System.Windows.Forms.DateTimePicker();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.topPanel.SuspendLayout();
            this.leftWrap.SuspendLayout();
            this.formCard.SuspendLayout();
            this.actionPanel.SuspendLayout();
            this.rightWrap.SuspendLayout();
            this.listCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.lblPageTitle);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(24, 14, 24, 14);
            this.topPanel.Size = new System.Drawing.Size(1364, 64);
            this.topPanel.TabIndex = 0;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Location = new System.Drawing.Point(24, 18);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(97, 13);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Quản lý Nhân viên";
            // 
            // leftWrap
            // 
            this.leftWrap.Controls.Add(this.formCard);
            this.leftWrap.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftWrap.Location = new System.Drawing.Point(0, 64);
            this.leftWrap.Name = "leftWrap";
            this.leftWrap.Padding = new System.Windows.Forms.Padding(24, 24, 12, 24);
            this.leftWrap.Size = new System.Drawing.Size(380, 677);
            this.leftWrap.TabIndex = 1;
            // 
            // formCard
            // 
            this.formCard.Controls.Add(this.actionPanel);
            this.formCard.Controls.Add(this.fieldsPanel);
            this.formCard.Controls.Add(this.lblSelected);
            this.formCard.Controls.Add(this.lblCardTitle);
            this.formCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formCard.Location = new System.Drawing.Point(24, 24);
            this.formCard.Name = "formCard";
            this.formCard.Padding = new System.Windows.Forms.Padding(20);
            this.formCard.Size = new System.Drawing.Size(344, 629);
            this.formCard.TabIndex = 0;
            // 
            // actionPanel
            // 
            this.actionPanel.Controls.Add(this.btnMoi);
            this.actionPanel.Controls.Add(this.btnXoa);
            this.actionPanel.Controls.Add(this.btnSua);
            this.actionPanel.Controls.Add(this.btnThem);
            this.actionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.actionPanel.Location = new System.Drawing.Point(20, 513);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(302, 96);
            this.actionPanel.TabIndex = 3;
            // 
            // btnMoi
            // 
            this.btnMoi.Location = new System.Drawing.Point(156, 52);
            this.btnMoi.Name = "btnMoi";
            this.btnMoi.Size = new System.Drawing.Size(130, 40);
            this.btnMoi.TabIndex = 3;
            this.btnMoi.Text = "Làm mới";
            this.btnMoi.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(0, 52);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(130, 40);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(156, 0);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(130, 40);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(0, 0);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(130, 40);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // fieldsPanel
            // 
            this.fieldsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldsPanel.AutoScroll = true;
            this.fieldsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fieldsPanel.Location = new System.Drawing.Point(20, 82);
            this.fieldsPanel.Name = "fieldsPanel";
            this.fieldsPanel.Size = new System.Drawing.Size(304, 421);
            this.fieldsPanel.TabIndex = 2;
            this.fieldsPanel.WrapContents = false;
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Location = new System.Drawing.Point(20, 50);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(135, 13);
            this.lblSelected.TabIndex = 1;
            this.lblSelected.Text = "Chưa chọn nhân viên nào.";
            // 
            // lblCardTitle
            // 
            this.lblCardTitle.AutoSize = true;
            this.lblCardTitle.Location = new System.Drawing.Point(20, 18);
            this.lblCardTitle.Name = "lblCardTitle";
            this.lblCardTitle.Size = new System.Drawing.Size(95, 13);
            this.lblCardTitle.TabIndex = 0;
            this.lblCardTitle.Text = "Thông tin nhân viên";
            // 
            // rightWrap
            // 
            this.rightWrap.Controls.Add(this.listCard);
            this.rightWrap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightWrap.Location = new System.Drawing.Point(380, 64);
            this.rightWrap.Name = "rightWrap";
            this.rightWrap.Padding = new System.Windows.Forms.Padding(12, 24, 24, 24);
            this.rightWrap.Size = new System.Drawing.Size(984, 677);
            this.rightWrap.TabIndex = 2;
            // 
            // listCard
            // 
            this.listCard.Controls.Add(this.grid);
            this.listCard.Controls.Add(this.txtSearch);
            this.listCard.Controls.Add(this.lblListTitle);
            this.listCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listCard.Location = new System.Drawing.Point(12, 24);
            this.listCard.Name = "listCard";
            this.listCard.Padding = new System.Windows.Forms.Padding(18);
            this.listCard.Size = new System.Drawing.Size(948, 629);
            this.listCard.TabIndex = 0;
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(18, 92);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(912, 519);
            this.grid.TabIndex = 2;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(18, 52);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(320, 20);
            this.txtSearch.TabIndex = 1;
            // 
            // lblListTitle
            // 
            this.lblListTitle.AutoSize = true;
            this.lblListTitle.Location = new System.Drawing.Point(18, 18);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(103, 13);
            this.lblListTitle.TabIndex = 0;
            this.lblListTitle.Text = "Danh sách nhân viên";
            // 
            // txtMa
            // 
            this.txtMa.Name = "txtMa";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Name = "txtHoTen";
            // 
            // txtSDT
            // 
            this.txtSDT.Name = "txtSDT";
            // 
            // txtEmail
            // 
            this.txtEmail.Name = "txtEmail";
            // 
            // txtChucVu
            // 
            this.txtChucVu.Name = "txtChucVu";
            // 
            // txtLuong
            // 
            this.txtLuong.Name = "txtLuong";
            // 
            // dtpNgayVaoLam
            // 
            this.dtpNgayVaoLam.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayVaoLam.Name = "dtpNgayVaoLam";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Name = "cboTrangThai";
            // 
            // FrmNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 741);
            this.Controls.Add(this.rightWrap);
            this.Controls.Add(this.leftWrap);
            this.Controls.Add(this.topPanel);
            this.Name = "FrmNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Nhân viên";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.leftWrap.ResumeLayout(false);
            this.formCard.ResumeLayout(false);
            this.formCard.PerformLayout();
            this.actionPanel.ResumeLayout(false);
            this.rightWrap.ResumeLayout(false);
            this.listCard.ResumeLayout(false);
            this.listCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
