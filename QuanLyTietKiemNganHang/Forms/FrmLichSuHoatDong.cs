using QuanLyTietKiemNganHang.Helpers;
using QuanLyTietKiemNganHang.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyTietKiemNganHang.Forms
{
    public partial class FrmLichSuHoatDong : Form
    {
        private readonly XuLyGiaoDich service = new XuLyGiaoDich();

        // Added control fields referenced elsewhere in the class
        private Panel topPanel;
        private Panel contentWrap;
        private Panel contentCard;
        private Label lblTitle;
        private Button btnTaiLai;
        private DataGridView grid;

        public FrmLichSuHoatDong()
        {
            InitializeComponent();
            ApplyTheme();
            WireEvents();
            LoadData();
        }

        private void ApplyTheme()
        {
            BackColor = ControlFactory.BackgroundColor;
            topPanel.BackColor = Color.White;
            contentWrap.BackColor = ControlFactory.BackgroundColor;
            contentCard.BackColor = ControlFactory.SurfaceColor;
            contentCard.BorderStyle = BorderStyle.FixedSingle;

            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.ForeColor = ControlFactory.TextColor;

            btnTaiLai.BackColor = Color.White;
            btnTaiLai.ForeColor = ControlFactory.PrimaryColor;
            btnTaiLai.FlatStyle = FlatStyle.Flat;
            btnTaiLai.Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold);
            btnTaiLai.Cursor = Cursors.Hand;
            btnTaiLai.FlatAppearance.BorderColor = ControlFactory.BorderColor;
            btnTaiLai.FlatAppearance.BorderSize = 1;
            GridStyler.Apply(grid);
        }

        private void WireEvents()
        {
            btnTaiLai.Click += (s, e) => LoadData();
        }

        private void LoadData()
        {
            try
            {
                var items = service.GetLichSuHoatDong();
                grid.DataSource = items.Select(x => new
                {
                    x.MaSuKien,
                    x.LoaiSuKien,
                    x.NguoiThucHien,
                    x.NoiDung,
                    ThoiGian = x.ThoiGian == DateTime.MinValue ? string.Empty : x.ThoiGian.ToString("dd/MM/yyyy HH:mm:ss")
                }).ToList();

                if (grid.Columns["MaSuKien"] != null) grid.Columns["MaSuKien"].HeaderText = "Mã";
                if (grid.Columns["LoaiSuKien"] != null) grid.Columns["LoaiSuKien"].HeaderText = "Loại";
                if (grid.Columns["NguoiThucHien"] != null) grid.Columns["NguoiThucHien"].HeaderText = "Người thực hiện";
                if (grid.Columns["NoiDung"] != null) grid.Columns["NoiDung"].HeaderText = "Nội dung";
                if (grid.Columns["ThoiGian"] != null) grid.Columns["ThoiGian"].HeaderText = "Thời gian";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được lịch sử hoạt động: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.contentWrap = new System.Windows.Forms.Panel();
            this.contentCard = new System.Windows.Forms.Panel();
            this.grid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Height = 64;
            this.topPanel.Padding = new Padding(12);
            this.topPanel.Controls.Add(this.lblTitle);
            this.topPanel.Controls.Add(this.btnTaiLai);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Lịch sử hoạt động";
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Text = "Tải lại";
            this.btnTaiLai.Size = new System.Drawing.Size(90, 32);
            this.btnTaiLai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnTaiLai.Location = new System.Drawing.Point(700, 16);
            // 
            // contentWrap
            // 
            this.contentWrap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentWrap.Padding = new Padding(12);
            this.contentWrap.Controls.Add(this.contentCard);
            // 
            // contentCard
            // 
            this.contentCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentCard.Padding = new Padding(8);
            this.contentCard.Controls.Add(this.grid);
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.AllowUserToAddRows = false;
            this.grid.ReadOnly = true;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.AutoGenerateColumns = true;

            // 
            // FrmLichSuHoatDong
            // 
            this.ClientSize = new System.Drawing.Size(827, 529);
            this.Controls.Add(this.contentWrap);
            this.Controls.Add(this.topPanel);
            this.Name = "FrmLichSuHoatDong";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
