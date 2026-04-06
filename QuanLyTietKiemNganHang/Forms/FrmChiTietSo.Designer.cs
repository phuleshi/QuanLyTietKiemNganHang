namespace QuanLyTietKiemNganHang.Forms
{
    partial class FrmChiTietSo
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Panel contentCard;
        private System.Windows.Forms.TableLayoutPanel detailsTable;
        private System.Windows.Forms.TextBox txtMaSo;
        private System.Windows.Forms.TextBox txtChuSoHuu;
        private System.Windows.Forms.TextBox txtGoiTietKiem;
        private System.Windows.Forms.TextBox txtSoTienGui;
        private System.Windows.Forms.TextBox txtLaiSuat;
        private System.Windows.Forms.TextBox txtNgayMo;
        private System.Windows.Forms.TextBox txtNgayDaoHan;
        private System.Windows.Forms.TextBox txtNhanVienMo;
        private System.Windows.Forms.NumericUpDown numSoDu;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnLuu;

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
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.contentCard = new System.Windows.Forms.Panel();
            this.detailsTable = new System.Windows.Forms.TableLayoutPanel();
            this.txtMaSo = new System.Windows.Forms.TextBox();
            this.txtChuSoHuu = new System.Windows.Forms.TextBox();
            this.txtGoiTietKiem = new System.Windows.Forms.TextBox();
            this.txtSoTienGui = new System.Windows.Forms.TextBox();
            this.txtLaiSuat = new System.Windows.Forms.TextBox();
            this.txtNgayMo = new System.Windows.Forms.TextBox();
            this.txtNgayDaoHan = new System.Windows.Forms.TextBox();
            this.txtNhanVienMo = new System.Windows.Forms.TextBox();
            this.numSoDu = new System.Windows.Forms.NumericUpDown();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.topPanel.SuspendLayout();
            this.contentCard.SuspendLayout();
            this.detailsTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoDu)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.lblSubTitle);
            this.topPanel.Controls.Add(this.lblTitle);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(24, 18, 24, 18);
            this.topPanel.Size = new System.Drawing.Size(900, 92);
            this.topPanel.TabIndex = 0;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Location = new System.Drawing.Point(27, 52);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(58, 15);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Thông tin";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(24, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(109, 15);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Chi tiết sổ tiết kiệm";
            // 
            // contentCard
            // 
            this.contentCard.Controls.Add(this.detailsTable);
            this.contentCard.Controls.Add(this.bottomPanel);
            this.contentCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentCard.Location = new System.Drawing.Point(0, 92);
            this.contentCard.Name = "contentCard";
            this.contentCard.Padding = new System.Windows.Forms.Padding(24);
            this.contentCard.Size = new System.Drawing.Size(900, 528);
            this.contentCard.TabIndex = 1;
            // 
            // detailsTable
            // 
            this.detailsTable.ColumnCount = 2;
            this.detailsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.detailsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.detailsTable.Controls.Add(this.txtMaSo, 0, 0);
            this.detailsTable.Controls.Add(this.txtChuSoHuu, 1, 0);
            this.detailsTable.Controls.Add(this.txtGoiTietKiem, 0, 1);
            this.detailsTable.Controls.Add(this.txtSoTienGui, 1, 1);
            this.detailsTable.Controls.Add(this.txtLaiSuat, 0, 2);
            this.detailsTable.Controls.Add(this.txtNgayMo, 1, 2);
            this.detailsTable.Controls.Add(this.txtNgayDaoHan, 0, 3);
            this.detailsTable.Controls.Add(this.txtNhanVienMo, 1, 3);
            this.detailsTable.Controls.Add(this.numSoDu, 0, 4);
            this.detailsTable.Controls.Add(this.cboTrangThai, 1, 4);
            this.detailsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsTable.Location = new System.Drawing.Point(24, 24);
            this.detailsTable.Name = "detailsTable";
            this.detailsTable.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.detailsTable.RowCount = 5;
            this.detailsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.detailsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.detailsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.detailsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.detailsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.detailsTable.Size = new System.Drawing.Size(852, 416);
            this.detailsTable.TabIndex = 0;
            // 
            // txtMaSo
            // 
            this.txtMaSo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaSo.Location = new System.Drawing.Point(3, 11);
            this.txtMaSo.Multiline = true;
            this.txtMaSo.Name = "txtMaSo";
            this.txtMaSo.Size = new System.Drawing.Size(420, 76);
            this.txtMaSo.TabIndex = 0;
            // 
            // txtChuSoHuu
            // 
            this.txtChuSoHuu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChuSoHuu.Location = new System.Drawing.Point(429, 11);
            this.txtChuSoHuu.Multiline = true;
            this.txtChuSoHuu.Name = "txtChuSoHuu";
            this.txtChuSoHuu.Size = new System.Drawing.Size(420, 76);
            this.txtChuSoHuu.TabIndex = 1;
            // 
            // txtGoiTietKiem
            // 
            this.txtGoiTietKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGoiTietKiem.Location = new System.Drawing.Point(3, 93);
            this.txtGoiTietKiem.Multiline = true;
            this.txtGoiTietKiem.Name = "txtGoiTietKiem";
            this.txtGoiTietKiem.Size = new System.Drawing.Size(420, 76);
            this.txtGoiTietKiem.TabIndex = 2;
            // 
            // txtSoTienGui
            // 
            this.txtSoTienGui.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSoTienGui.Location = new System.Drawing.Point(429, 93);
            this.txtSoTienGui.Multiline = true;
            this.txtSoTienGui.Name = "txtSoTienGui";
            this.txtSoTienGui.Size = new System.Drawing.Size(420, 76);
            this.txtSoTienGui.TabIndex = 3;
            // 
            // txtLaiSuat
            // 
            this.txtLaiSuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLaiSuat.Location = new System.Drawing.Point(3, 175);
            this.txtLaiSuat.Multiline = true;
            this.txtLaiSuat.Name = "txtLaiSuat";
            this.txtLaiSuat.Size = new System.Drawing.Size(420, 76);
            this.txtLaiSuat.TabIndex = 4;
            // 
            // txtNgayMo
            // 
            this.txtNgayMo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNgayMo.Location = new System.Drawing.Point(429, 175);
            this.txtNgayMo.Multiline = true;
            this.txtNgayMo.Name = "txtNgayMo";
            this.txtNgayMo.Size = new System.Drawing.Size(420, 76);
            this.txtNgayMo.TabIndex = 5;
            // 
            // txtNgayDaoHan
            // 
            this.txtNgayDaoHan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNgayDaoHan.Location = new System.Drawing.Point(3, 257);
            this.txtNgayDaoHan.Multiline = true;
            this.txtNgayDaoHan.Name = "txtNgayDaoHan";
            this.txtNgayDaoHan.Size = new System.Drawing.Size(420, 76);
            this.txtNgayDaoHan.TabIndex = 6;
            // 
            // txtNhanVienMo
            // 
            this.txtNhanVienMo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNhanVienMo.Location = new System.Drawing.Point(429, 257);
            this.txtNhanVienMo.Multiline = true;
            this.txtNhanVienMo.Name = "txtNhanVienMo";
            this.txtNhanVienMo.Size = new System.Drawing.Size(420, 76);
            this.txtNhanVienMo.TabIndex = 7;
            // 
            // numSoDu
            // 
            this.numSoDu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numSoDu.Location = new System.Drawing.Point(3, 339);
            this.numSoDu.Name = "numSoDu";
            this.numSoDu.Size = new System.Drawing.Size(420, 20);
            this.numSoDu.TabIndex = 8;
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Location = new System.Drawing.Point(429, 339);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(420, 21);
            this.cboTrangThai.TabIndex = 9;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.btnDong);
            this.bottomPanel.Controls.Add(this.btnLuu);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(24, 440);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(852, 64);
            this.bottomPanel.TabIndex = 1;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Location = new System.Drawing.Point(718, 12);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(120, 40);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.Location = new System.Drawing.Point(582, 12);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(120, 40);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "Lưu thay đổi";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // FrmChiTietSo
            // 
            this.AcceptButton = this.btnLuu;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(900, 620);
            this.Controls.Add(this.contentCard);
            this.Controls.Add(this.topPanel);
            this.MinimumSize = new System.Drawing.Size(880, 620);
            this.Name = "FrmChiTietSo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết sổ tiết kiệm";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.contentCard.ResumeLayout(false);
            this.detailsTable.ResumeLayout(false);
            this.detailsTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoDu)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
