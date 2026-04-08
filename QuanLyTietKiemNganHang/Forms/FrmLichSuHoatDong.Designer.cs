namespace QuanLyTietKiemNganHang.Forms
{
    partial class FrmLichSuHoatDong
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel contentWrap;
        private System.Windows.Forms.Panel contentCard;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.DataGridView grid;

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
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.topPanel.SuspendLayout();
            this.contentWrap.SuspendLayout();
            this.contentCard.SuspendLayout();
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
            this.topPanel.Size = new System.Drawing.Size(1200, 74);
            this.topPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(24, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(103, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Lịch sử hoạt động";
            // 
            // contentWrap
            // 
            this.contentWrap.Controls.Add(this.contentCard);
            this.contentWrap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentWrap.Location = new System.Drawing.Point(0, 74);
            this.contentWrap.Name = "contentWrap";
            this.contentWrap.Padding = new System.Windows.Forms.Padding(24);
            this.contentWrap.Size = new System.Drawing.Size(1200, 646);
            this.contentWrap.TabIndex = 1;
            // 
            // contentCard
            // 
            this.contentCard.Controls.Add(this.grid);
            this.contentCard.Controls.Add(this.btnTaiLai);
            this.contentCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentCard.Location = new System.Drawing.Point(24, 24);
            this.contentCard.Name = "contentCard";
            this.contentCard.Padding = new System.Windows.Forms.Padding(18);
            this.contentCard.Size = new System.Drawing.Size(1152, 598);
            this.contentCard.TabIndex = 0;
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Location = new System.Drawing.Point(18, 18);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(120, 40);
            this.btnTaiLai.TabIndex = 0;
            this.btnTaiLai.Text = "Tải lại";
            this.btnTaiLai.UseVisualStyleBackColor = true;
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(18, 74);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(1116, 506);
            this.grid.TabIndex = 1;
            // 
            // FrmLichSuHoatDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.contentWrap);
            this.Controls.Add(this.topPanel);
            this.MinimumSize = new System.Drawing.Size(1100, 650);
            this.Name = "FrmLichSuHoatDong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lịch sử hoạt động";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.contentWrap.ResumeLayout(false);
            this.contentCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
