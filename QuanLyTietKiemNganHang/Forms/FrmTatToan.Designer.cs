namespace QuanLyTietKiemNganHang.Forms
{
    partial class FrmTatToan
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel contentWrap;
        private System.Windows.Forms.Panel contentCard;
        private System.Windows.Forms.Panel pnlSo;
        private System.Windows.Forms.Label lblSo;
        private System.Windows.Forms.ComboBox cboSo;
        private System.Windows.Forms.RadioButton rdTatToanToanBo;
        private System.Windows.Forms.RadioButton rdRutGoc;
        private System.Windows.Forms.Panel pnlRut;
        private System.Windows.Forms.Label lblRut;
        private System.Windows.Forms.NumericUpDown numRut;
        private System.Windows.Forms.Button btnTinh;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Label lblThongTin;
        private System.Windows.Forms.Label lblThongBao;

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
            this.lblThongBao = new System.Windows.Forms.Label();
            this.lblThongTin = new System.Windows.Forms.Label();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnTinh = new System.Windows.Forms.Button();
            this.pnlRut = new System.Windows.Forms.Panel();
            this.numRut = new System.Windows.Forms.NumericUpDown();
            this.lblRut = new System.Windows.Forms.Label();
            this.rdRutGoc = new System.Windows.Forms.RadioButton();
            this.rdTatToanToanBo = new System.Windows.Forms.RadioButton();
            this.pnlSo = new System.Windows.Forms.Panel();
            this.cboSo = new System.Windows.Forms.ComboBox();
            this.lblSo = new System.Windows.Forms.Label();
            this.topPanel.SuspendLayout();
            this.contentWrap.SuspendLayout();
            this.contentCard.SuspendLayout();
            this.pnlRut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRut)).BeginInit();
            this.pnlSo.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.lblTitle);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(24, 14, 24, 14);
            this.topPanel.Size = new System.Drawing.Size(1000, 74);
            this.topPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(24, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(107, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Tất toán / Rút gốc";
            // 
            // contentWrap
            // 
            this.contentWrap.Controls.Add(this.contentCard);
            this.contentWrap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentWrap.Location = new System.Drawing.Point(0, 74);
            this.contentWrap.Name = "contentWrap";
            this.contentWrap.Padding = new System.Windows.Forms.Padding(24);
            this.contentWrap.Size = new System.Drawing.Size(1000, 626);
            this.contentWrap.TabIndex = 1;
            // 
            // contentCard
            // 
            this.contentCard.Controls.Add(this.lblThongBao);
            this.contentCard.Controls.Add(this.lblThongTin);
            this.contentCard.Controls.Add(this.btnXacNhan);
            this.contentCard.Controls.Add(this.btnTinh);
            this.contentCard.Controls.Add(this.pnlRut);
            this.contentCard.Controls.Add(this.rdRutGoc);
            this.contentCard.Controls.Add(this.rdTatToanToanBo);
            this.contentCard.Controls.Add(this.pnlSo);
            this.contentCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentCard.Location = new System.Drawing.Point(24, 24);
            this.contentCard.Name = "contentCard";
            this.contentCard.Padding = new System.Windows.Forms.Padding(18);
            this.contentCard.Size = new System.Drawing.Size(952, 578);
            this.contentCard.TabIndex = 0;
            // 
            // lblThongBao
            // 
            this.lblThongBao.Location = new System.Drawing.Point(410, 310);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(510, 100);
            this.lblThongBao.TabIndex = 7;
            // 
            // lblThongTin
            // 
            this.lblThongTin.Location = new System.Drawing.Point(410, 24);
            this.lblThongTin.Name = "lblThongTin";
            this.lblThongTin.Size = new System.Drawing.Size(510, 270);
            this.lblThongTin.TabIndex = 6;
            this.lblThongTin.Text = "Chọn sổ và nhấn Tính để xem số tiền nhận.";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(150, 320);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(120, 40);
            this.btnXacNhan.TabIndex = 5;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            // 
            // btnTinh
            // 
            this.btnTinh.Location = new System.Drawing.Point(18, 320);
            this.btnTinh.Name = "btnTinh";
            this.btnTinh.Size = new System.Drawing.Size(120, 40);
            this.btnTinh.TabIndex = 4;
            this.btnTinh.Text = "Tính tiền";
            this.btnTinh.UseVisualStyleBackColor = true;
            // 
            // pnlRut
            // 
            this.pnlRut.Controls.Add(this.numRut);
            this.pnlRut.Controls.Add(this.lblRut);
            this.pnlRut.Location = new System.Drawing.Point(18, 220);
            this.pnlRut.Name = "pnlRut";
            this.pnlRut.Size = new System.Drawing.Size(360, 80);
            this.pnlRut.TabIndex = 3;
            // 
            // numRut
            // 
            this.numRut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numRut.Enabled = false;
            this.numRut.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numRut.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numRut.Location = new System.Drawing.Point(0, 35);
            this.numRut.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numRut.Name = "numRut";
            this.numRut.Size = new System.Drawing.Size(320, 25);
            this.numRut.TabIndex = 1;
            this.numRut.ThousandsSeparator = true;
            // 
            // lblRut
            // 
            this.lblRut.AutoSize = true;
            this.lblRut.Location = new System.Drawing.Point(0, 10);
            this.lblRut.Name = "lblRut";
            this.lblRut.Size = new System.Drawing.Size(174, 13);
            this.lblRut.TabIndex = 0;
            this.lblRut.Text = "Số tiền rút (khi rút từng phần)";
            // 
            // rdRutGoc
            // 
            this.rdRutGoc.AutoSize = true;
            this.rdRutGoc.Location = new System.Drawing.Point(18, 180);
            this.rdRutGoc.Name = "rdRutGoc";
            this.rdRutGoc.Size = new System.Drawing.Size(123, 17);
            this.rdRutGoc.TabIndex = 2;
            this.rdRutGoc.Text = "Rút gốc từng phần";
            this.rdRutGoc.UseVisualStyleBackColor = true;
            // 
            // rdTatToanToanBo
            // 
            this.rdTatToanToanBo.AutoSize = true;
            this.rdTatToanToanBo.Checked = true;
            this.rdTatToanToanBo.Location = new System.Drawing.Point(18, 150);
            this.rdTatToanToanBo.Name = "rdTatToanToanBo";
            this.rdTatToanToanBo.Size = new System.Drawing.Size(114, 17);
            this.rdTatToanToanBo.TabIndex = 1;
            this.rdTatToanToanBo.TabStop = true;
            this.rdTatToanToanBo.Text = "Tất toán toàn bộ";
            this.rdTatToanToanBo.UseVisualStyleBackColor = true;
            // 
            // pnlSo
            // 
            this.pnlSo.Controls.Add(this.cboSo);
            this.pnlSo.Controls.Add(this.lblSo);
            this.pnlSo.Location = new System.Drawing.Point(18, 24);
            this.pnlSo.Name = "pnlSo";
            this.pnlSo.Size = new System.Drawing.Size(360, 90);
            this.pnlSo.TabIndex = 0;
            // 
            // cboSo
            // 
            this.cboSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSo.FormattingEnabled = true;
            this.cboSo.Location = new System.Drawing.Point(0, 38);
            this.cboSo.Name = "cboSo";
            this.cboSo.Size = new System.Drawing.Size(320, 21);
            this.cboSo.TabIndex = 1;
            // 
            // lblSo
            // 
            this.lblSo.AutoSize = true;
            this.lblSo.Location = new System.Drawing.Point(0, 12);
            this.lblSo.Name = "lblSo";
            this.lblSo.Size = new System.Drawing.Size(69, 13);
            this.lblSo.TabIndex = 0;
            this.lblSo.Text = "Sổ tiết kiệm";
            // 
            // FrmTatToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.contentWrap);
            this.Controls.Add(this.topPanel);
            this.MinimumSize = new System.Drawing.Size(900, 620);
            this.Name = "FrmTatToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tất toán / Rút gốc từng phần";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.contentWrap.ResumeLayout(false);
            this.contentCard.ResumeLayout(false);
            this.contentCard.PerformLayout();
            this.pnlRut.ResumeLayout(false);
            this.pnlRut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRut)).EndInit();
            this.pnlSo.ResumeLayout(false);
            this.pnlSo.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}