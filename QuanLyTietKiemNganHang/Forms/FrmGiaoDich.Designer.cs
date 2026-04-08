namespace QuanLyTietKiemNganHang.Forms
{
    partial class FrmGiaoDich
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel contentWrap;
        private System.Windows.Forms.Panel contentCard;
        private System.Windows.Forms.FlowLayoutPanel filterPanel;
        private System.Windows.Forms.Panel grpTuNgay;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Panel grpDenNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Panel grpLoai;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label lblTongGiaoDich;
        private System.Windows.Forms.Label lblTongSoTien;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel detailCard;
        private System.Windows.Forms.Label lblDetailTitle;
        private System.Windows.Forms.Label lblDetail;

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
            this.detailCard = new System.Windows.Forms.Panel();
            this.lblDetail = new System.Windows.Forms.Label();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.lblTongSoTien = new System.Windows.Forms.Label();
            this.lblTongGiaoDich = new System.Windows.Forms.Label();
            this.filterPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.grpTuNgay = new System.Windows.Forms.Panel();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.grpDenNgay = new System.Windows.Forms.Panel();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.grpLoai = new System.Windows.Forms.Panel();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.lblLoai = new System.Windows.Forms.Label();
            this.btnLoc = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.topPanel.SuspendLayout();
            this.contentWrap.SuspendLayout();
            this.contentCard.SuspendLayout();
            this.detailCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.filterPanel.SuspendLayout();
            this.grpTuNgay.SuspendLayout();
            this.grpDenNgay.SuspendLayout();
            this.grpLoai.SuspendLayout();
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
            this.lblTitle.Size = new System.Drawing.Size(89, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý giao dịch";
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
            this.contentCard.Controls.Add(this.detailCard);
            this.contentCard.Controls.Add(this.grid);
            this.contentCard.Controls.Add(this.lblTongSoTien);
            this.contentCard.Controls.Add(this.lblTongGiaoDich);
            this.contentCard.Controls.Add(this.filterPanel);
            this.contentCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentCard.Location = new System.Drawing.Point(24, 24);
            this.contentCard.Name = "contentCard";
            this.contentCard.Padding = new System.Windows.Forms.Padding(18);
            this.contentCard.Size = new System.Drawing.Size(1216, 627);
            this.contentCard.TabIndex = 0;
            // 
            // detailCard
            // 
            this.detailCard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailCard.Controls.Add(this.lblDetail);
            this.detailCard.Controls.Add(this.lblDetailTitle);
            this.detailCard.Location = new System.Drawing.Point(18, 513);
            this.detailCard.Name = "detailCard";
            this.detailCard.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.detailCard.Size = new System.Drawing.Size(1180, 96);
            this.detailCard.TabIndex = 4;
            // 
            // lblDetail
            // 
            this.lblDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetail.Location = new System.Drawing.Point(14, 34);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Size = new System.Drawing.Size(1152, 52);
            this.lblDetail.TabIndex = 1;
            this.lblDetail.Text = "Chọn một giao dịch trong bảng để xem thông tin chi tiết.";
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDetailTitle.Location = new System.Drawing.Point(14, 10);
            this.lblDetailTitle.Name = "lblDetailTitle";
            this.lblDetailTitle.Size = new System.Drawing.Size(1152, 24);
            this.lblDetailTitle.TabIndex = 0;
            this.lblDetailTitle.Text = "Chi tiết giao dịch";
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(18, 142);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(1180, 358);
            this.grid.TabIndex = 3;
            // 
            // lblTongSoTien
            // 
            this.lblTongSoTien.AutoSize = true;
            this.lblTongSoTien.Location = new System.Drawing.Point(280, 115);
            this.lblTongSoTien.Name = "lblTongSoTien";
            this.lblTongSoTien.Size = new System.Drawing.Size(63, 13);
            this.lblTongSoTien.TabIndex = 2;
            this.lblTongSoTien.Text = "Tổng giá trị:";
            // 
            // lblTongGiaoDich
            // 
            this.lblTongGiaoDich.AutoSize = true;
            this.lblTongGiaoDich.Location = new System.Drawing.Point(18, 115);
            this.lblTongGiaoDich.Name = "lblTongGiaoDich";
            this.lblTongGiaoDich.Size = new System.Drawing.Size(81, 13);
            this.lblTongGiaoDich.TabIndex = 1;
            this.lblTongGiaoDich.Text = "Tổng giao dịch:";
            // 
            // filterPanel
            // 
            this.filterPanel.Controls.Add(this.grpTuNgay);
            this.filterPanel.Controls.Add(this.grpDenNgay);
            this.filterPanel.Controls.Add(this.grpLoai);
            this.filterPanel.Controls.Add(this.btnLoc);
            this.filterPanel.Controls.Add(this.btnLamMoi);
            this.filterPanel.Location = new System.Drawing.Point(18, 18);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(1180, 80);
            this.filterPanel.TabIndex = 0;
            this.filterPanel.WrapContents = false;
            // 
            // grpTuNgay
            // 
            this.grpTuNgay.Controls.Add(this.dtFrom);
            this.grpTuNgay.Controls.Add(this.lblTuNgay);
            this.grpTuNgay.Location = new System.Drawing.Point(3, 3);
            this.grpTuNgay.Name = "grpTuNgay";
            this.grpTuNgay.Size = new System.Drawing.Size(290, 74);
            this.grpTuNgay.TabIndex = 0;
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(0, 30);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(286, 20);
            this.dtFrom.TabIndex = 1;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(0, 10);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(46, 13);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày";
            // 
            // grpDenNgay
            // 
            this.grpDenNgay.Controls.Add(this.dtTo);
            this.grpDenNgay.Controls.Add(this.lblDenNgay);
            this.grpDenNgay.Location = new System.Drawing.Point(299, 3);
            this.grpDenNgay.Name = "grpDenNgay";
            this.grpDenNgay.Size = new System.Drawing.Size(290, 74);
            this.grpDenNgay.TabIndex = 1;
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(0, 30);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(286, 20);
            this.dtTo.TabIndex = 1;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(0, 10);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(53, 13);
            this.lblDenNgay.TabIndex = 0;
            this.lblDenNgay.Text = "Đến ngày";
            // 
            // grpLoai
            // 
            this.grpLoai.Controls.Add(this.cboLoai);
            this.grpLoai.Controls.Add(this.lblLoai);
            this.grpLoai.Location = new System.Drawing.Point(595, 3);
            this.grpLoai.Name = "grpLoai";
            this.grpLoai.Size = new System.Drawing.Size(290, 74);
            this.grpLoai.TabIndex = 2;
            // 
            // cboLoai
            // 
            this.cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoai.FormattingEnabled = true;
            this.cboLoai.Location = new System.Drawing.Point(0, 30);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(286, 21);
            this.cboLoai.TabIndex = 1;
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.Location = new System.Drawing.Point(0, 10);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(73, 13);
            this.lblLoai.TabIndex = 0;
            this.lblLoai.Text = "Loại giao dịch";
            // 
            // btnLoc
            // 
            this.btnLoc.Location = new System.Drawing.Point(891, 3);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(120, 40);
            this.btnLoc.TabIndex = 3;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(1017, 3);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(120, 40);
            this.btnLamMoi.TabIndex = 4;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // FrmGiaoDich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 749);
            this.Controls.Add(this.contentWrap);
            this.Controls.Add(this.topPanel);
            this.MinimumSize = new System.Drawing.Size(1200, 720);
            this.Name = "FrmGiaoDich";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý giao dịch";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.contentWrap.ResumeLayout(false);
            this.contentCard.ResumeLayout(false);
            this.contentCard.PerformLayout();
            this.detailCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.filterPanel.ResumeLayout(false);
            this.grpTuNgay.ResumeLayout(false);
            this.grpTuNgay.PerformLayout();
            this.grpDenNgay.ResumeLayout(false);
            this.grpDenNgay.PerformLayout();
            this.grpLoai.ResumeLayout(false);
            this.grpLoai.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}