using QuanLyTietKiemNganHang.Helpers;
using QuanLyTietKiemNganHang.Models;
using QuanLyTietKiemNganHang.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyTietKiemNganHang.Forms
{
    public class FrmKhachHang : Form
    {
        private readonly KhachHangService service = new KhachHangService();
        private readonly DataGridView grid = new DataGridView();
        private readonly TextBox txtSearch = ControlFactory.CreateTextBox();
        private readonly TextBox txtMa = ControlFactory.CreateTextBox();
        private readonly TextBox txtHoTen = ControlFactory.CreateTextBox();
        private readonly TextBox txtSDT = ControlFactory.CreateTextBox();
        private readonly TextBox txtEmail = ControlFactory.CreateTextBox();
        private readonly TextBox txtCCCD = ControlFactory.CreateTextBox();
        private readonly TextBox txtDiaChi = ControlFactory.CreateTextBox();
        private readonly DateTimePicker dtpNgaySinh = ControlFactory.CreateDateTimePicker();
        private readonly ComboBox cboTrangThai = ControlFactory.CreateComboBox();
        private readonly Label lblSelected = ControlFactory.CreateMutedLabel("Chưa chọn khách hàng nào.");
        private int selectedId;

        public FrmKhachHang()
        {
            InitializeUi();
            LoadData();
        }

        private void InitializeUi()
        {
            Text = "Quản lý Khách hàng";
            Size = new Size(1380, 780);
            MinimumSize = new Size(1280, 720);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = ControlFactory.BackgroundColor;

            var topPanel = new Panel { Dock = DockStyle.Top, Height = 64, BackColor = Color.White, Padding = new Padding(24, 14, 24, 14) };
            var lblTitle = ControlFactory.CreateTitleLabel("Quản lý Khách hàng", 18);
            lblTitle.Location = new Point(24, 16);
            topPanel.Controls.AddRange(new Control[] { lblTitle });

            var leftWrap = new Panel { Dock = DockStyle.Left, Width = 380, Padding = new Padding(24, 24, 12, 24), BackColor = ControlFactory.BackgroundColor };
            var rightWrap = new Panel { Dock = DockStyle.Fill, Padding = new Padding(12, 24, 24, 24), BackColor = ControlFactory.BackgroundColor };

            var formCard = ControlFactory.CreateSectionCard(DockStyle.Fill, new Padding(20));
            leftWrap.Controls.Add(formCard);

            var cardTitle = ControlFactory.CreateTitleLabel("Thông tin khách hàng", 14);
            cardTitle.Location = new Point(20, 18);
            lblSelected.Location = new Point(20, 50);

            var fieldsPanel = new FlowLayoutPanel
            {
                Location = new Point(20, 82),
                Size = new Size(318, 470),
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true
            };

            txtDiaChi.Width = 300;
            cboTrangThai.Items.AddRange(new[] { "Hoạt động", "Tạm khóa" });
            cboTrangThai.SelectedIndex = 0;

            fieldsPanel.Controls.Add(ControlFactory.CreateInputGroup("Mã khách hàng", txtMa));
            fieldsPanel.Controls.Add(ControlFactory.CreateInputGroup("Họ tên", txtHoTen));
            fieldsPanel.Controls.Add(ControlFactory.CreateInputGroup("Số điện thoại", txtSDT));
            fieldsPanel.Controls.Add(ControlFactory.CreateInputGroup("Email", txtEmail));
            fieldsPanel.Controls.Add(ControlFactory.CreateInputGroup("CCCD", txtCCCD));
            fieldsPanel.Controls.Add(ControlFactory.CreateInputGroup("Địa chỉ", txtDiaChi));
            fieldsPanel.Controls.Add(ControlFactory.CreateInputGroup("Ngày sinh", dtpNgaySinh));
            fieldsPanel.Controls.Add(ControlFactory.CreateInputGroup("Trạng thái", cboTrangThai));

            var actionPanel = new Panel { Location = new Point(20, 590), Size = new Size(320, 110) };
            var btnThem = ControlFactory.CreatePrimaryButton("Thêm");
            var btnSua = ControlFactory.CreateSecondaryButton("Sửa");
            var btnXoa = ControlFactory.CreateDangerButton("Xóa");
            var btnMoi = ControlFactory.CreateSecondaryButton("Làm mới");
            btnThem.Location = new Point(0, 0);
            btnSua.Location = new Point(136, 0);
            btnXoa.Location = new Point(0, 54);
            btnMoi.Location = new Point(136, 54);
            btnThem.Click += (s, e) => Save(false);
            btnSua.Click += (s, e) => Save(true);
            btnXoa.Click += BtnXoa_Click;
            btnMoi.Click += (s, e) => ResetForm();
            actionPanel.Controls.AddRange(new Control[] { btnThem, btnSua, btnXoa, btnMoi });

            formCard.Controls.AddRange(new Control[] { cardTitle, lblSelected, fieldsPanel, actionPanel });

            var listCard = ControlFactory.CreateSectionCard(DockStyle.Fill, new Padding(18));
            rightWrap.Controls.Add(listCard);

            var listTitle = ControlFactory.CreateTitleLabel("Danh sách khách hàng", 14);
            listTitle.Location = new Point(18, 18);
            txtSearch.Width = 320;
            txtSearch.Location = new Point(18, 52);
            txtSearch.TextChanged += (s, e) => BindGrid(service.Search(txtSearch.Text));

            grid.Location = new Point(18, 92);
            grid.Size = new Size(920, 560);
            grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GridStyler.Apply(grid);
            grid.CellClick += Grid_CellClick;

            listCard.Controls.AddRange(new Control[] { listTitle, txtSearch, grid });

            Controls.Add(rightWrap);
            Controls.Add(leftWrap);
            Controls.Add(topPanel);
        }

        private void LoadData()
        {
            BindGrid(service.GetAll());
        }

        private void BindGrid(List<KhachHang> data)
        {
            grid.DataSource = null;
            grid.DataSource = data.Select(x => new
            {
                x.Id,
                x.MaKhachHang,
                x.HoTen,
                x.SoDienThoai,
                x.Email,
                x.CCCD,
                x.DiaChi,
                NgaySinh = x.NgaySinh.ToString("dd/MM/yyyy"),
                x.TrangThai
            }).ToList();

            if (grid.Columns["Id"] != null) grid.Columns["Id"].Visible = false;
            if (grid.Columns["MaKhachHang"] != null) grid.Columns["MaKhachHang"].HeaderText = "Mã KH";
            if (grid.Columns["HoTen"] != null) grid.Columns["HoTen"].HeaderText = "Họ tên";
            if (grid.Columns["SoDienThoai"] != null) grid.Columns["SoDienThoai"].HeaderText = "SĐT";
            if (grid.Columns["NgaySinh"] != null) grid.Columns["NgaySinh"].HeaderText = "Ngày sinh";
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = grid.Rows[e.RowIndex];
            selectedId = Convert.ToInt32(row.Cells["Id"].Value);
            txtMa.Text = row.Cells["MaKhachHang"].Value.ToString();
            txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
            txtSDT.Text = row.Cells["SoDienThoai"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();
            txtCCCD.Text = row.Cells["CCCD"].Value.ToString();
            txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
            dtpNgaySinh.Value = DateTime.Parse(row.Cells["NgaySinh"].Value.ToString());
            cboTrangThai.Text = row.Cells["TrangThai"].Value.ToString();
            lblSelected.Text = "Đang chọn: " + txtMa.Text + " - " + txtHoTen.Text;
        }

        private void Save(bool isUpdate)
        {
            var currentId = isUpdate ? selectedId : 0;
            var maKhachHang = txtMa.Text.Trim();
            var cccd = txtCCCD.Text.Trim();
            var errors = new List<string>();
            if (!FormValidator.Required(maKhachHang)) errors.Add("- Mã khách hàng không được để trống");
            if (!FormValidator.Required(txtHoTen.Text)) errors.Add("- Họ tên không được để trống");
            if (!FormValidator.IsPhone(txtSDT.Text)) errors.Add("- Số điện thoại không hợp lệ");
            if (!FormValidator.IsEmail(txtEmail.Text)) errors.Add("- Email không hợp lệ");
            if (!FormValidator.IsCitizenId(cccd)) errors.Add("- CCCD phải có 12 số");
            if (!FormValidator.Required(txtDiaChi.Text)) errors.Add("- Địa chỉ không được để trống");
            if (FormValidator.Required(maKhachHang) && service.IsDuplicateMaKhachHang(maKhachHang, currentId)) errors.Add("- Mã khách hàng đã tồn tại");
            if (FormValidator.IsCitizenId(cccd) && service.IsDuplicateCccd(cccd, currentId)) errors.Add("- CCCD đã tồn tại");

            if (errors.Any())
            {
                MessageBox.Show(FormValidator.JoinErrors(errors), "Validate form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var model = new KhachHang
            {
                Id = selectedId,
                MaKhachHang = maKhachHang,
                HoTen = txtHoTen.Text.Trim(),
                SoDienThoai = txtSDT.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                CCCD = cccd,
                DiaChi = txtDiaChi.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value.Date,
                TrangThai = cboTrangThai.Text
            };

            if (isUpdate)
            {
                if (selectedId == 0)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng cần sửa.");
                    return;
                }
                service.Update(model);
                MessageBox.Show("Cập nhật khách hàng thành công.");
            }
            else
            {
                service.Add(model);
                MessageBox.Show("Thêm khách hàng thành công.");
            }
            LoadData();
            ResetForm();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            service.Delete(selectedId);
            LoadData();
            ResetForm();
            MessageBox.Show("Xóa khách hàng thành công.");
        }

        private void ResetForm()
        {
            selectedId = 0;
            txtMa.Clear(); txtHoTen.Clear(); txtSDT.Clear(); txtEmail.Clear(); txtCCCD.Clear(); txtDiaChi.Clear();
            dtpNgaySinh.Value = DateTime.Today;
            cboTrangThai.SelectedIndex = 0;
            txtSearch.Clear();
            lblSelected.Text = "Chưa chọn khách hàng nào.";
            LoadData();
        }
    }
}
