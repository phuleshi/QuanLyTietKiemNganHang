namespace QuanLyTietKiemNganHang.Forms
{
    partial class FrmDanhSachSo
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel contentWrap;
        private System.Windows.Forms.Panel contentCard;
        private System.Windows.Forms.Label lblCardTitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel actionPanel;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Button btnXemChiTiet;
        private System.Windows.Forms.Button btnSuaSo;
        private System.Windows.Forms.Button btnXoaSo;
        private System.Windows.Forms.Button btnTatToan;
        private System.Windows.Forms.Button btnRutGoc;

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
            this.contentWrap = new System.Windows.Forms.Panel();
            this.contentCard = new System.Windows.Forms.Panel();
            this.actionPanel = new System.Windows.Forms.Panel();
            this.btnTatToan = new System.Windows.Forms.Button();
            this.btnRutGoc = new System.Windows.Forms.Button();
            this.btnXoaSo = new System.Windows.Forms.Button();
            this.btnSuaSo = new System.Windows.Forms.Button();
            this.btnXemChiTiet = new System.Windows.Forms.Button();
            this.lblSelected = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblCardTitle = new System.Windows.Forms.Label();
            this.topPanel.SuspendLayout();
            this.contentWrap.SuspendLayout();
            this.contentCard.SuspendLayout();
            this.actionPanel.SuspendLayout();
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
            this.topPanel.Size = new System.Drawing.Size(1280, 64);
            this.topPanel.TabIndex = 0;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Location = new System.Drawing.Point(24, 18);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(126, 13);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Danh sách sổ tiết kiệm";
            // 
            // contentWrap
            // 
            this.contentWrap.Controls.Add(this.contentCard);
            this.contentWrap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentWrap.Location = new System.Drawing.Point(0, 64);
            this.contentWrap.Name = "contentWrap";
            this.contentWrap.Padding = new System.Windows.Forms.Padding(24);
            this.contentWrap.Size = new System.Drawing.Size(1280, 676);
            this.contentWrap.TabIndex = 1;
            // 
            // contentCard
            // 
            this.contentCard.Controls.Add(this.actionPanel);
            this.contentCard.Controls.Add(this.grid);
            this.contentCard.Controls.Add(this.btnRefresh);
            this.contentCard.Controls.Add(this.txtSearch);
            this.contentCard.Controls.Add(this.lblCardTitle);
            this.contentCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentCard.Location = new System.Drawing.Point(24, 24);
            this.contentCard.Name = "contentCard";
            this.contentCard.Padding = new System.Windows.Forms.Padding(18);
            this.contentCard.Size = new System.Drawing.Size(1232, 628);
            this.contentCard.TabIndex = 0;
            // 
            // actionPanel
            // 
            this.actionPanel.Controls.Add(this.btnTatToan);
            this.actionPanel.Controls.Add(this.btnRutGoc);
            this.actionPanel.Controls.Add(this.btnXoaSo);
            this.actionPanel.Controls.Add(this.btnSuaSo);
            this.actionPanel.Controls.Add(this.btnXemChiTiet);
            this.actionPanel.Controls.Add(this.lblSelected);
            this.actionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.actionPanel.Location = new System.Drawing.Point(18, 548);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(1196, 62);
            this.actionPanel.TabIndex = 4;
            // 
            // btnTatToan
            // 
            this.btnTatToan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTatToan.Location = new System.Drawing.Point(1076, 10);
            this.btnTatToan.Name = "btnTatToan";
            this.btnTatToan.Size = new System.Drawing.Size(116, 40);
            this.btnTatToan.TabIndex = 5;
            this.btnTatToan.Text = "Tất toán";
            this.btnTatToan.UseVisualStyleBackColor = true;
            // 
            // btnRutGoc
            // 
            this.btnRutGoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRutGoc.Location = new System.Drawing.Point(946, 10);
            this.btnRutGoc.Name = "btnRutGoc";
            this.btnRutGoc.Size = new System.Drawing.Size(116, 40);
            this.btnRutGoc.TabIndex = 4;
            this.btnRutGoc.Text = "Rút gốc";
            this.btnRutGoc.UseVisualStyleBackColor = true;
            // 
            // btnXoaSo
            // 
            this.btnXoaSo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaSo.Location = new System.Drawing.Point(816, 10);
            this.btnXoaSo.Name = "btnXoaSo";
            this.btnXoaSo.Size = new System.Drawing.Size(116, 40);
            this.btnXoaSo.TabIndex = 3;
            this.btnXoaSo.Text = "Xóa sổ";
            this.btnXoaSo.UseVisualStyleBackColor = true;
            // 
            // btnSuaSo
            // 
            this.btnSuaSo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSuaSo.Location = new System.Drawing.Point(686, 10);
            this.btnSuaSo.Name = "btnSuaSo";
            this.btnSuaSo.Size = new System.Drawing.Size(116, 40);
            this.btnSuaSo.TabIndex = 2;
            this.btnSuaSo.Text = "Sửa sổ";
            this.btnSuaSo.UseVisualStyleBackColor = true;
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXemChiTiet.Location = new System.Drawing.Point(556, 10);
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.Size = new System.Drawing.Size(116, 40);
            this.btnXemChiTiet.TabIndex = 1;
            this.btnXemChiTiet.Text = "Xem chi tiết";
            this.btnXemChiTiet.UseVisualStyleBackColor = true;
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Location = new System.Drawing.Point(0, 22);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(137, 13);
            this.lblSelected.TabIndex = 0;
            this.lblSelected.Text = "Chưa chọn sổ tiết kiệm nào.";
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(18, 96);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(1196, 434);
            this.grid.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(344, 50);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 34);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Tải lại";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(18, 56);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(310, 20);
            this.txtSearch.TabIndex = 1;
            // 
            // lblCardTitle
            // 
            this.lblCardTitle.AutoSize = true;
            this.lblCardTitle.Location = new System.Drawing.Point(18, 18);
            this.lblCardTitle.Name = "lblCardTitle";
            this.lblCardTitle.Size = new System.Drawing.Size(186, 13);
            this.lblCardTitle.TabIndex = 0;
            this.lblCardTitle.Text = "Danh sách sổ tiết kiệm đang quản lý";
            // 
            // FrmDanhSachSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 740);
            this.Controls.Add(this.contentWrap);
            this.Controls.Add(this.topPanel);
            this.MinimumSize = new System.Drawing.Size(1200, 720);
            this.Name = "FrmDanhSachSo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách sổ tiết kiệm";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.contentWrap.ResumeLayout(false);
            this.contentCard.ResumeLayout(false);
            this.contentCard.PerformLayout();
            this.actionPanel.ResumeLayout(false);
            this.actionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
