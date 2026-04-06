namespace QuanLyTietKiemNganHang.Forms
{
    partial class FrmMoSo
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel leftWrap;
        private System.Windows.Forms.Panel rightWrap;
        private System.Windows.Forms.Panel formCard;
        private System.Windows.Forms.Panel previewCard;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.FlowLayoutPanel fieldsPanel;
        private System.Windows.Forms.Panel actionPanel;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Label lblPreviewTitle;
        private System.Windows.Forms.Label lblPreviewText;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.ComboBox cboLoaiTietKiem;
        private System.Windows.Forms.NumericUpDown numSoTienGui;
        private System.Windows.Forms.TextBox txtLaiSuat;
        private System.Windows.Forms.TextBox txtNgayDaoHan;
        private System.Windows.Forms.TextBox txtNhanVienMo;

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
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.fieldsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.rightWrap = new System.Windows.Forms.Panel();
            this.previewCard = new System.Windows.Forms.Panel();
            this.lblPreviewText = new System.Windows.Forms.Label();
            this.lblPreviewTitle = new System.Windows.Forms.Label();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.cboLoaiTietKiem = new System.Windows.Forms.ComboBox();
            this.numSoTienGui = new System.Windows.Forms.NumericUpDown();
            this.txtLaiSuat = new System.Windows.Forms.TextBox();
            this.txtNgayDaoHan = new System.Windows.Forms.TextBox();
            this.txtNhanVienMo = new System.Windows.Forms.TextBox();
            this.topPanel.SuspendLayout();
            this.leftWrap.SuspendLayout();
            this.formCard.SuspendLayout();
            this.actionPanel.SuspendLayout();
            this.rightWrap.SuspendLayout();
            this.previewCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTienGui)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.lblPageTitle);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(24, 14, 24, 14);
            this.topPanel.Size = new System.Drawing.Size(1280, 64);
            this.topPanel.TabIndex = 0;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Location = new System.Drawing.Point(24, 18);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(90, 15);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Mở sổ tiết kiệm";
            // 
            // leftWrap
            // 
            this.leftWrap.Controls.Add(this.formCard);
            this.leftWrap.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftWrap.Location = new System.Drawing.Point(0, 64);
            this.leftWrap.Name = "leftWrap";
            this.leftWrap.Padding = new System.Windows.Forms.Padding(24);
            this.leftWrap.Size = new System.Drawing.Size(420, 676);
            this.leftWrap.TabIndex = 1;
            // 
            // formCard
            // 
            this.formCard.Controls.Add(this.actionPanel);
            this.formCard.Controls.Add(this.fieldsPanel);
            this.formCard.Controls.Add(this.lblCurrentUser);
            this.formCard.Controls.Add(this.lblFormTitle);
            this.formCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formCard.Location = new System.Drawing.Point(24, 24);
            this.formCard.Name = "formCard";
            this.formCard.Padding = new System.Windows.Forms.Padding(20);
            this.formCard.Size = new System.Drawing.Size(372, 628);
            this.formCard.TabIndex = 0;
            // 
            // actionPanel
            // 
            this.actionPanel.Controls.Add(this.btnLamMoi);
            this.actionPanel.Controls.Add(this.btnXacNhan);
            this.actionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.actionPanel.Location = new System.Drawing.Point(20, 548);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(332, 60);
            this.actionPanel.TabIndex = 3;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(142, 10);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(130, 40);
            this.btnLamMoi.TabIndex = 1;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(0, 10);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(130, 40);
            this.btnXacNhan.TabIndex = 0;
            this.btnXacNhan.Text = "Xác nhận mở sổ";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            // 
            // fieldsPanel
            // 
            this.fieldsPanel.AutoScroll = true;
            this.fieldsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fieldsPanel.Location = new System.Drawing.Point(20, 20);
            this.fieldsPanel.Name = "fieldsPanel";
            this.fieldsPanel.Size = new System.Drawing.Size(332, 588);
            this.fieldsPanel.TabIndex = 2;
            this.fieldsPanel.WrapContents = false;
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Location = new System.Drawing.Point(20, 46);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(99, 15);
            this.lblCurrentUser.TabIndex = 1;
            this.lblCurrentUser.Text = "Nhân viên mở sổ";
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Location = new System.Drawing.Point(20, 18);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(144, 15);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Thông tin mở sổ tiết kiệm";
            // 
            // rightWrap
            // 
            this.rightWrap.Controls.Add(this.previewCard);
            this.rightWrap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightWrap.Location = new System.Drawing.Point(420, 64);
            this.rightWrap.Name = "rightWrap";
            this.rightWrap.Padding = new System.Windows.Forms.Padding(0, 24, 24, 24);
            this.rightWrap.Size = new System.Drawing.Size(860, 676);
            this.rightWrap.TabIndex = 2;
            // 
            // previewCard
            // 
            this.previewCard.Controls.Add(this.lblPreviewText);
            this.previewCard.Controls.Add(this.lblPreviewTitle);
            this.previewCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewCard.Location = new System.Drawing.Point(0, 24);
            this.previewCard.Name = "previewCard";
            this.previewCard.Padding = new System.Windows.Forms.Padding(24);
            this.previewCard.Size = new System.Drawing.Size(836, 628);
            this.previewCard.TabIndex = 0;
            // 
            // lblPreviewText
            // 
            this.lblPreviewText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPreviewText.Location = new System.Drawing.Point(24, 58);
            this.lblPreviewText.Name = "lblPreviewText";
            this.lblPreviewText.Size = new System.Drawing.Size(788, 546);
            this.lblPreviewText.TabIndex = 1;
            this.lblPreviewText.Text = "Chọn khách hàng, gói tiết kiệm và số tiền để xem thông tin mở sổ.";
            // 
            // lblPreviewTitle
            // 
            this.lblPreviewTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPreviewTitle.Location = new System.Drawing.Point(24, 24);
            this.lblPreviewTitle.Name = "lblPreviewTitle";
            this.lblPreviewTitle.Size = new System.Drawing.Size(788, 34);
            this.lblPreviewTitle.TabIndex = 0;
            this.lblPreviewTitle.Text = "Thông tin tự động tính";
            // 
            // cboKhachHang
            // 
            this.cboKhachHang.FormattingEnabled = true;
            this.cboKhachHang.Location = new System.Drawing.Point(0, 0);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(121, 23);
            this.cboKhachHang.TabIndex = 0;
            // 
            // cboLoaiTietKiem
            // 
            this.cboLoaiTietKiem.FormattingEnabled = true;
            this.cboLoaiTietKiem.Location = new System.Drawing.Point(0, 0);
            this.cboLoaiTietKiem.Name = "cboLoaiTietKiem";
            this.cboLoaiTietKiem.Size = new System.Drawing.Size(121, 23);
            this.cboLoaiTietKiem.TabIndex = 0;
            // 
            // numSoTienGui
            // 
            this.numSoTienGui.Location = new System.Drawing.Point(0, 0);
            this.numSoTienGui.Name = "numSoTienGui";
            this.numSoTienGui.Size = new System.Drawing.Size(120, 20);
            this.numSoTienGui.TabIndex = 0;
            // 
            // txtLaiSuat
            // 
            this.txtLaiSuat.Location = new System.Drawing.Point(0, 0);
            this.txtLaiSuat.Name = "txtLaiSuat";
            this.txtLaiSuat.Size = new System.Drawing.Size(100, 20);
            this.txtLaiSuat.TabIndex = 0;
            // 
            // txtNgayDaoHan
            // 
            this.txtNgayDaoHan.Location = new System.Drawing.Point(0, 0);
            this.txtNgayDaoHan.Name = "txtNgayDaoHan";
            this.txtNgayDaoHan.Size = new System.Drawing.Size(100, 20);
            this.txtNgayDaoHan.TabIndex = 0;
            // 
            // txtNhanVienMo
            // 
            this.txtNhanVienMo.Location = new System.Drawing.Point(0, 0);
            this.txtNhanVienMo.Name = "txtNhanVienMo";
            this.txtNhanVienMo.Size = new System.Drawing.Size(100, 20);
            this.txtNhanVienMo.TabIndex = 0;
            // 
            // FrmMoSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 740);
            this.Controls.Add(this.rightWrap);
            this.Controls.Add(this.leftWrap);
            this.Controls.Add(this.topPanel);
            this.MinimumSize = new System.Drawing.Size(1200, 720);
            this.Name = "FrmMoSo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mở sổ tiết kiệm";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.leftWrap.ResumeLayout(false);
            this.formCard.ResumeLayout(false);
            this.formCard.PerformLayout();
            this.actionPanel.ResumeLayout(false);
            this.rightWrap.ResumeLayout(false);
            this.previewCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numSoTienGui)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
