using System.Windows.Forms;

namespace QuanLyTietKiemNganHang.Forms
{
    partial class FrmMoSo
    {
        private System.ComponentModel.IContainer components = null;
        private Panel topPanel;
        private Label lblPageTitle;
        private Panel leftWrap;
        private Panel rightWrap;
        private Panel formCard;
        private Panel previewCard;
        private Label lblFormTitle;
        private Label lblCurrentUser;
        private FlowLayoutPanel fieldsPanel;
        private Panel actionPanel;
        private Button btnLamMoi;
        private Button btnXacNhan;
        private Label lblPreviewTitle;
        private Label lblPreviewHint;
        private DataGridView dgvPreview;
        private ComboBox cboKhachHang;
        private ComboBox cboLoaiTietKiem;
        private NumericUpDown numSoTienGui;
        private TextBox txtLaiSuat;
        private TextBox txtNgayDaoHan;
        private TextBox txtNhanVienMo;

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
            this.topPanel = new Panel();
            this.lblPageTitle = new Label();
            this.leftWrap = new Panel();
            this.formCard = new Panel();
            this.fieldsPanel = new FlowLayoutPanel();
            this.actionPanel = new Panel();
            this.btnLamMoi = new Button();
            this.btnXacNhan = new Button();
            this.lblCurrentUser = new Label();
            this.lblFormTitle = new Label();
            this.rightWrap = new Panel();
            this.previewCard = new Panel();
            this.dgvPreview = new DataGridView();
            this.lblPreviewHint = new Label();
            this.lblPreviewTitle = new Label();
            this.cboKhachHang = new ComboBox();
            this.cboLoaiTietKiem = new ComboBox();
            this.numSoTienGui = new NumericUpDown();
            this.txtLaiSuat = new TextBox();
            this.txtNgayDaoHan = new TextBox();
            this.txtNhanVienMo = new TextBox();
            this.topPanel.SuspendLayout();
            this.leftWrap.SuspendLayout();
            this.formCard.SuspendLayout();
            this.actionPanel.SuspendLayout();
            this.rightWrap.SuspendLayout();
            this.previewCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTienGui)).BeginInit();
            this.SuspendLayout();
            //
            // topPanel
            //
            this.topPanel.Controls.Add(this.lblPageTitle);
            this.topPanel.Dock = DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new Padding(4);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new Padding(32, 17, 32, 17);
            this.topPanel.Size = new System.Drawing.Size(1707, 79);
            this.topPanel.TabIndex = 0;
            //
            // lblPageTitle
            //
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Location = new System.Drawing.Point(32, 22);
            this.lblPageTitle.Margin = new Padding(4, 0, 4, 0);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(96, 16);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Mở sổ tiết kiệm";
            //
            // leftWrap
            //
            this.leftWrap.Controls.Add(this.formCard);
            this.leftWrap.Dock = DockStyle.Left;
            this.leftWrap.Location = new System.Drawing.Point(0, 79);
            this.leftWrap.Margin = new Padding(4);
            this.leftWrap.Name = "leftWrap";
            this.leftWrap.Padding = new Padding(32, 30, 24, 30);
            this.leftWrap.Size = new System.Drawing.Size(680, 832);
            this.leftWrap.TabIndex = 1;
            //
            // formCard
            //
            this.formCard.Controls.Add(this.fieldsPanel);
            this.formCard.Controls.Add(this.actionPanel);
            this.formCard.Controls.Add(this.lblCurrentUser);
            this.formCard.Controls.Add(this.lblFormTitle);
            this.formCard.Dock = DockStyle.Fill;
            this.formCard.Location = new System.Drawing.Point(32, 30);
            this.formCard.Margin = new Padding(4);
            this.formCard.Name = "formCard";
            this.formCard.Padding = new Padding(30, 28, 30, 28);
            this.formCard.Size = new System.Drawing.Size(624, 772);
            this.formCard.TabIndex = 0;
            //
            // fieldsPanel
            //
            this.fieldsPanel.AutoScroll = true;
            this.fieldsPanel.Dock = DockStyle.Fill;
            this.fieldsPanel.FlowDirection = FlowDirection.TopDown;
            this.fieldsPanel.Location = new System.Drawing.Point(30, 60);
            this.fieldsPanel.Margin = new Padding(4);
            this.fieldsPanel.Name = "fieldsPanel";
            this.fieldsPanel.Size = new System.Drawing.Size(564, 628);
            this.fieldsPanel.TabIndex = 2;
            this.fieldsPanel.WrapContents = false;
            //
            // actionPanel
            //
            this.actionPanel.Controls.Add(this.btnLamMoi);
            this.actionPanel.Controls.Add(this.btnXacNhan);
            this.actionPanel.Dock = DockStyle.Bottom;
            this.actionPanel.Location = new System.Drawing.Point(30, 688);
            this.actionPanel.Margin = new Padding(4);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(564, 56);
            this.actionPanel.TabIndex = 3;
            //
            // btnLamMoi
            //
            this.btnLamMoi.Location = new System.Drawing.Point(216, 4);
            this.btnLamMoi.Margin = new Padding(4);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(173, 49);
            this.btnLamMoi.TabIndex = 1;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            //
            // btnXacNhan
            //
            this.btnXacNhan.Location = new System.Drawing.Point(0, 4);
            this.btnXacNhan.Margin = new Padding(4);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(200, 49);
            this.btnXacNhan.TabIndex = 0;
            this.btnXacNhan.Text = "Xác nhận mở sổ";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            //
            // lblCurrentUser
            //
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Dock = DockStyle.Top;
            this.lblCurrentUser.Location = new System.Drawing.Point(30, 44);
            this.lblCurrentUser.Margin = new Padding(4, 0, 4, 0);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(107, 16);
            this.lblCurrentUser.TabIndex = 1;
            this.lblCurrentUser.Text = "Nhân viên mở sổ";
            //
            // lblFormTitle
            //
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Dock = DockStyle.Top;
            this.lblFormTitle.Location = new System.Drawing.Point(30, 28);
            this.lblFormTitle.Margin = new Padding(4, 0, 4, 0);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(154, 16);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Thông tin mở sổ tiết kiệm";
            //
            // rightWrap
            //
            this.rightWrap.Controls.Add(this.previewCard);
            this.rightWrap.Dock = DockStyle.Fill;
            this.rightWrap.Location = new System.Drawing.Point(680, 79);
            this.rightWrap.Margin = new Padding(4);
            this.rightWrap.Name = "rightWrap";
            this.rightWrap.Padding = new Padding(8, 30, 32, 30);
            this.rightWrap.Size = new System.Drawing.Size(1027, 832);
            this.rightWrap.TabIndex = 2;
            //
            // previewCard
            //
            this.previewCard.Controls.Add(this.dgvPreview);
            this.previewCard.Controls.Add(this.lblPreviewHint);
            this.previewCard.Controls.Add(this.lblPreviewTitle);
            this.previewCard.Dock = DockStyle.Fill;
            this.previewCard.Location = new System.Drawing.Point(8, 30);
            this.previewCard.Margin = new Padding(4);
            this.previewCard.Name = "previewCard";
            this.previewCard.Padding = new Padding(32, 30, 32, 30);
            this.previewCard.Size = new System.Drawing.Size(987, 772);
            this.previewCard.TabIndex = 0;
            //
            // dgvPreview
            //
            this.dgvPreview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreview.Dock = DockStyle.Fill;
            this.dgvPreview.Location = new System.Drawing.Point(32, 128);
            this.dgvPreview.Margin = new Padding(4);
            this.dgvPreview.Name = "dgvPreview";
            this.dgvPreview.RowHeadersWidth = 51;
            this.dgvPreview.Size = new System.Drawing.Size(923, 614);
            this.dgvPreview.TabIndex = 2;
            //
            // lblPreviewHint
            //
            this.lblPreviewHint.Dock = DockStyle.Top;
            this.lblPreviewHint.Location = new System.Drawing.Point(32, 72);
            this.lblPreviewHint.Margin = new Padding(4, 0, 4, 0);
            this.lblPreviewHint.Name = "lblPreviewHint";
            this.lblPreviewHint.Padding = new Padding(0, 8, 0, 14);
            this.lblPreviewHint.Size = new System.Drawing.Size(923, 56);
            this.lblPreviewHint.TabIndex = 1;
            this.lblPreviewHint.Text = "Chờ xác định khách hàng để hiển thị thông tin tóm tắt.";
            //
            // lblPreviewTitle
            //
            this.lblPreviewTitle.Dock = DockStyle.Top;
            this.lblPreviewTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblPreviewTitle.Location = new System.Drawing.Point(32, 30);
            this.lblPreviewTitle.Margin = new Padding(4, 0, 4, 0);
            this.lblPreviewTitle.Name = "lblPreviewTitle";
            this.lblPreviewTitle.Size = new System.Drawing.Size(923, 42);
            this.lblPreviewTitle.TabIndex = 0;
            this.lblPreviewTitle.Text = "Thông tin tự động tính";
            //
            // cboKhachHang
            //
            this.cboKhachHang.FormattingEnabled = true;
            this.cboKhachHang.Location = new System.Drawing.Point(0, 0);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(121, 24);
            this.cboKhachHang.TabIndex = 0;
            //
            // cboLoaiTietKiem
            //
            this.cboLoaiTietKiem.FormattingEnabled = true;
            this.cboLoaiTietKiem.Location = new System.Drawing.Point(0, 0);
            this.cboLoaiTietKiem.Name = "cboLoaiTietKiem";
            this.cboLoaiTietKiem.Size = new System.Drawing.Size(121, 24);
            this.cboLoaiTietKiem.TabIndex = 0;
            //
            // numSoTienGui
            //
            this.numSoTienGui.Location = new System.Drawing.Point(0, 0);
            this.numSoTienGui.Name = "numSoTienGui";
            this.numSoTienGui.Size = new System.Drawing.Size(120, 22);
            this.numSoTienGui.TabIndex = 0;
            //
            // txtLaiSuat
            //
            this.txtLaiSuat.Location = new System.Drawing.Point(0, 0);
            this.txtLaiSuat.Name = "txtLaiSuat";
            this.txtLaiSuat.Size = new System.Drawing.Size(100, 22);
            this.txtLaiSuat.TabIndex = 0;
            //
            // txtNgayDaoHan
            //
            this.txtNgayDaoHan.Location = new System.Drawing.Point(0, 0);
            this.txtNgayDaoHan.Name = "txtNgayDaoHan";
            this.txtNgayDaoHan.Size = new System.Drawing.Size(100, 22);
            this.txtNgayDaoHan.TabIndex = 0;
            //
            // txtNhanVienMo
            //
            this.txtNhanVienMo.Location = new System.Drawing.Point(0, 0);
            this.txtNhanVienMo.Name = "txtNhanVienMo";
            this.txtNhanVienMo.Size = new System.Drawing.Size(100, 22);
            this.txtNhanVienMo.TabIndex = 0;
            //
            // FrmMoSo
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1707, 911);
            this.Controls.Add(this.rightWrap);
            this.Controls.Add(this.leftWrap);
            this.Controls.Add(this.topPanel);
            this.Margin = new Padding(4);
            this.MinimumSize = new System.Drawing.Size(1594, 875);
            this.Name = "FrmMoSo";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Má»Ÿ sá»• tiáº¿t kiá»‡m";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.leftWrap.ResumeLayout(false);
            this.formCard.ResumeLayout(false);
            this.formCard.PerformLayout();
            this.actionPanel.ResumeLayout(false);
            this.rightWrap.ResumeLayout(false);
            this.previewCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTienGui)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
