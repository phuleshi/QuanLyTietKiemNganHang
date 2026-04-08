namespace QuanLyTietKiemNganHang.Forms
{
    partial class FrmLoaiTietKiem
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel contentWrap;
        private System.Windows.Forms.Panel contentCard;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel fieldsPanel;
        private System.Windows.Forms.Label lblTenGoi;
        private System.Windows.Forms.TextBox txtTenGoi;
        private System.Windows.Forms.Label lblLaiSuat;
        private System.Windows.Forms.NumericUpDown numLaiSuat;
        private System.Windows.Forms.Label lblKyHan;
        private System.Windows.Forms.NumericUpDown numKyHan;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;

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
            this.lblTitle = new System.Windows.Forms.Label();
            this.contentWrap = new System.Windows.Forms.Panel();
            this.contentCard = new System.Windows.Forms.Panel();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.lblSelected = new System.Windows.Forms.Label();
            this.fieldsPanel = new System.Windows.Forms.Panel();
            this.numKyHan = new System.Windows.Forms.NumericUpDown();
            this.lblKyHan = new System.Windows.Forms.Label();
            this.numLaiSuat = new System.Windows.Forms.NumericUpDown();
            this.lblLaiSuat = new System.Windows.Forms.Label();
            this.txtTenGoi = new System.Windows.Forms.TextBox();
            this.lblTenGoi = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.topPanel.SuspendLayout();
            this.contentWrap.SuspendLayout();
            this.contentCard.SuspendLayout();
            this.fieldsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKyHan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLaiSuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.lblTitle);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(24, 14, 24, 14);
            this.topPanel.Size = new System.Drawing.Size(1264, 74);
            this.topPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(24, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(102, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý gói tiết kiệm";
            // 
            // contentWrap
            // 
            this.contentWrap.Controls.Add(this.contentCard);
            this.contentWrap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentWrap.Location = new System.Drawing.Point(0, 74);
            this.contentWrap.Name = "contentWrap";
            this.contentWrap.Padding = new System.Windows.Forms.Padding(24);
            this.contentWrap.Size = new System.Drawing.Size(1264, 675);
            this.contentWrap.TabIndex = 1;
            // 
            // contentCard
            // 
            this.contentCard.Controls.Add(this.btnXoa);
            this.contentCard.Controls.Add(this.btnSua);
            this.contentCard.Controls.Add(this.btnThem);
            this.contentCard.Controls.Add(this.lblSelected);
            this.contentCard.Controls.Add(this.fieldsPanel);
            this.contentCard.Controls.Add(this.grid);
            this.contentCard.Controls.Add(this.btnTaiLai);
            this.contentCard.Controls.Add(this.txtSearch);
            this.contentCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentCard.Location = new System.Drawing.Point(24, 24);
            this.contentCard.Name = "contentCard";
            this.contentCard.Padding = new System.Windows.Forms.Padding(18);
            this.contentCard.Size = new System.Drawing.Size(1216, 627);
            this.contentCard.TabIndex = 0;
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Location = new System.Drawing.Point(1078, 430);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(120, 40);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.Location = new System.Drawing.Point(946, 430);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(120, 40);
            this.btnSua.TabIndex = 6;
            this.btnSua.Text = "Cập nhật";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.Location = new System.Drawing.Point(814, 430);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(120, 40);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // lblSelected
            // 
            this.lblSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelected.Location = new System.Drawing.Point(814, 390);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(384, 23);
            this.lblSelected.TabIndex = 4;
            this.lblSelected.Text = "Chưa chọn gói.";
            // 
            // fieldsPanel
            // 
            this.fieldsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldsPanel.Controls.Add(this.numKyHan);
            this.fieldsPanel.Controls.Add(this.lblKyHan);
            this.fieldsPanel.Controls.Add(this.numLaiSuat);
            this.fieldsPanel.Controls.Add(this.lblLaiSuat);
            this.fieldsPanel.Controls.Add(this.txtTenGoi);
            this.fieldsPanel.Controls.Add(this.lblTenGoi);
            this.fieldsPanel.Location = new System.Drawing.Point(814, 74);
            this.fieldsPanel.Name = "fieldsPanel";
            this.fieldsPanel.Size = new System.Drawing.Size(384, 300);
            this.fieldsPanel.TabIndex = 3;
            // 
            // numKyHan
            // 
            this.numKyHan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numKyHan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numKyHan.Location = new System.Drawing.Point(0, 236);
            this.numKyHan.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numKyHan.Name = "numKyHan";
            this.numKyHan.Size = new System.Drawing.Size(320, 25);
            this.numKyHan.TabIndex = 5;
            // 
            // lblKyHan
            // 
            this.lblKyHan.AutoSize = true;
            this.lblKyHan.Location = new System.Drawing.Point(0, 210);
            this.lblKyHan.Name = "lblKyHan";
            this.lblKyHan.Size = new System.Drawing.Size(76, 13);
            this.lblKyHan.TabIndex = 4;
            this.lblKyHan.Text = "Kỳ hạn (tháng)";
            // 
            // numLaiSuat
            // 
            this.numLaiSuat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numLaiSuat.DecimalPlaces = 2;
            this.numLaiSuat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numLaiSuat.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numLaiSuat.Location = new System.Drawing.Point(0, 140);
            this.numLaiSuat.Name = "numLaiSuat";
            this.numLaiSuat.Size = new System.Drawing.Size(320, 25);
            this.numLaiSuat.TabIndex = 3;
            // 
            // lblLaiSuat
            // 
            this.lblLaiSuat.AutoSize = true;
            this.lblLaiSuat.Location = new System.Drawing.Point(0, 114);
            this.lblLaiSuat.Name = "lblLaiSuat";
            this.lblLaiSuat.Size = new System.Drawing.Size(86, 13);
            this.lblLaiSuat.TabIndex = 2;
            this.lblLaiSuat.Text = "Lãi suất (%/năm)";
            // 
            // txtTenGoi
            // 
            this.txtTenGoi.Location = new System.Drawing.Point(0, 44);
            this.txtTenGoi.Name = "txtTenGoi";
            this.txtTenGoi.Size = new System.Drawing.Size(320, 20);
            this.txtTenGoi.TabIndex = 1;
            // 
            // lblTenGoi
            // 
            this.lblTenGoi.AutoSize = true;
            this.lblTenGoi.Location = new System.Drawing.Point(0, 18);
            this.lblTenGoi.Name = "lblTenGoi";
            this.lblTenGoi.Size = new System.Drawing.Size(43, 13);
            this.lblTenGoi.TabIndex = 0;
            this.lblTenGoi.Text = "Tên gói";
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(18, 74);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(780, 535);
            this.grid.TabIndex = 2;
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Location = new System.Drawing.Point(352, 18);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(120, 40);
            this.btnTaiLai.TabIndex = 1;
            this.btnTaiLai.Text = "Tải lại";
            this.btnTaiLai.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(18, 28);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(320, 20);
            this.txtSearch.TabIndex = 0;
            // 
            // FrmLoaiTietKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 749);
            this.Controls.Add(this.contentWrap);
            this.Controls.Add(this.topPanel);
            this.MinimumSize = new System.Drawing.Size(1100, 650);
            this.Name = "FrmLoaiTietKiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý gói tiết kiệm";
            this.Load += new System.EventHandler(this.FrmLoaiTietKiem_Load);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.contentWrap.ResumeLayout(false);
            this.contentCard.ResumeLayout(false);
            this.contentCard.PerformLayout();
            this.fieldsPanel.ResumeLayout(false);
            this.fieldsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKyHan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLaiSuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }
    }
}