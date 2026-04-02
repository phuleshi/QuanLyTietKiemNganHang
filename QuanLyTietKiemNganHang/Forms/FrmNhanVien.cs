using QuanLyTietKiemNganHang.Helpers;
using QuanLyTietKiemNganHang.Models;
using QuanLyTietKiemNganHang.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyTietKiemNganHang.Forms
{
    public class FrmNhanVien : Form
    {
        private readonly NhanVienService service = new NhanVienService();
        private readonly DataGridView grid = new DataGridView();
        private readonly TextBox txtSearch = ControlFactory.CreateTextBox();
        private readonly TextBox txtMa = ControlFactory.CreateTextBox();
        private readonly TextBox txtHoTen = ControlFactory.CreateTextBox();
        private readonly TextBox txtSDT = ControlFactory.CreateTextBox();
        private readonly TextBox txtEmail = ControlFactory.CreateTextBox();
        private readonly TextBox txtChucVu = ControlFactory.CreateTextBox();
        private readonly TextBox txtLuong = ControlFactory.CreateTextBox();
        private readonly DateTimePicker dtpNgayVaoLam = ControlFactory.CreateDateTimePicker();
        private readonly ComboBox cboTrangThai = ControlFactory.CreateComboBox();
        private readonly Label lblSelected = ControlFactory.CreateMutedLabel("Chưa chọn nhân viên nào.");
        private int selectedId;

        public FrmNhanVien()
        {
            InitializeUi();
            LoadData();
        }

        private void InitializeUi()
        {
            Text = "Quản lý Nhân viên";
            Size = new Size(1380, 780);
            MinimumSize = new Size(1280, 720);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = ControlFactory.BackgroundColor;

            var topPanel = new Panel { Dock = DockStyle.Top, Height = 64, BackColor = Color.White, Padding = new Padding(24, 14, 24, 14) };
            var lblTitle = ControlFactory.CreateTitleLabel("Quản lý Nhân viên", 18);
            lblTitle.Location = new Point(24, 16);
            topPanel.Controls.AddRange(new Control[] { lblTitle });

            var leftWrap = new Panel { Dock = DockStyle.Left, Width = 380, Padding = new Padding(24, 24, 12, 24), BackColor = ControlFactory.BackgroundColor };
            var rightWrap = new Panel { Dock = DockStyle.Fill, Padding = new Padding(12, 24, 24, 24), BackColor = ControlFactory.BackgroundColor };

            var formCard = ControlFactory.CreateSectionCard(DockStyle.Fill, new Padding(20));
            leftWrap.Controls.Add(formCard);

            var cardTitle = ControlFactory.CreateTitleLabel("Thông tin nhân viên", 14);
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

            cboTrangThai.Items.AddRange(new[] { "Đang làm", "Nghỉ phép", "Nghỉ việc" });
            cboTrangThai.SelectedIndex = 0;

            fieldsPanel.Controls.Add(ControlFactory.CreateInputGroup("Mã nhân viên", txtMa));
            fieldsPanel.Controls.Add(ControlFactory.CreateInputGroup("Họ tên", txtHoTen));
            fieldsPanel.Controls.Add(ControlFactory.CreateInputGroup("Số điện thoại", txtSDT));
            fieldsPanel.Controls.Add(ControlFactory.CreateInputGroup("Email", txtEmail));
            fieldsPanel.Controls.Add(ControlFactory.CreateInputGroup("Chức vụ", txtChucVu));
            fieldsPanel.Controls.Add(ControlFactory.CreateInputGroup("Lương cơ bản", txtLuong));
            fieldsPanel.Controls.Add(ControlFactory.CreateInputGroup("Ngày vào làm", dtpNgayVaoLam));
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

            var listTitle = ControlFactory.CreateTitleLabel("Danh sách nhân viên", 14);
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

        private void BindGrid(List<NhanVien> data)
        {
            grid.DataSource = null;
            grid.DataSource = data.Select(x => new
            {
                x.Id,
                x.MaNhanVien,
                x.HoTen,
                x.SoDienThoai,
                x.Email,
                x.ChucVu,
                NgayVaoLam = x.NgayVaoLam.ToString("dd/MM/yyyy"),
                LuongCoBan = x.LuongCoBan.ToString("N0"),
                x.TrangThai
            }).ToList();

            if (grid.Columns["Id"] != null) grid.Columns["Id"].Visible = false;
            if (grid.Columns["MaNhanVien"] != null) grid.Columns["MaNhanVien"].HeaderText = "Mã NV";
            if (grid.Columns["HoTen"] != null) grid.Columns["HoTen"].HeaderText = "Họ tên";
            if (grid.Columns["SoDienThoai"] != null) grid.Columns["SoDienThoai"].HeaderText = "SĐT";
            if (grid.Columns["NgayVaoLam"] != null) grid.Columns["NgayVaoLam"].HeaderText = "Ngày vào làm";
            if (grid.Columns["LuongCoBan"] != null) grid.Columns["LuongCoBan"].HeaderText = "Lương";
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = grid.Rows[e.RowIndex];
            selectedId = Convert.ToInt32(row.Cells["Id"].Value);
            txtMa.Text = row.Cells["MaNhanVien"].Value.ToString();
            txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
            txtSDT.Text = row.Cells["SoDienThoai"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();
            txtChucVu.Text = row.Cells["ChucVu"].Value.ToString();
            txtLuong.Text = row.Cells["LuongCoBan"].Value.ToString().Replace(",", string.Empty);
            dtpNgayVaoLam.Value = DateTime.ParseExact(row.Cells["NgayVaoLam"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            cboTrangThai.Text = row.Cells["TrangThai"].Value.ToString();
            lblSelected.Text = "Đang chọn: " + txtMa.Text + " - " + txtHoTen.Text;
        }

        private void Save(bool isUpdate)
        {
            var currentId = isUpdate ? selectedId : 0;
            var maNhanVien = txtMa.Text.Trim();
            var errors = new List<string>();
            if (!FormValidator.Required(maNhanVien)) errors.Add("- Mã nhân viên không được để trống");
            if (!FormValidator.Required(txtHoTen.Text)) errors.Add("- Họ tên không được để trống");
            if (!FormValidator.IsPhone(txtSDT.Text)) errors.Add("- Số điện thoại không hợp lệ");
            if (!FormValidator.IsEmail(txtEmail.Text)) errors.Add("- Email không hợp lệ");
            if (!FormValidator.Required(txtChucVu.Text)) errors.Add("- Chức vụ không được để trống");
            if (FormValidator.Required(maNhanVien) && service.IsDuplicateMaNhanVien(maNhanVien, currentId)) errors.Add("- Mã nhân viên đã tồn tại");

            decimal luong;
            if (!decimal.TryParse(txtLuong.Text, out luong) || !FormValidator.Positive(luong))
                errors.Add("- Lương cơ bản phải lớn hơn 0");

            if (errors.Any())
            {
                MessageBox.Show(FormValidator.JoinErrors(errors), "Validate form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var model = new NhanVien
            {
                Id = selectedId,
                MaNhanVien = maNhanVien,
                HoTen = txtHoTen.Text.Trim(),
                SoDienThoai = txtSDT.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                ChucVu = txtChucVu.Text.Trim(),
                NgayVaoLam = dtpNgayVaoLam.Value.Date,
                LuongCoBan = luong,
                TrangThai = cboTrangThai.Text
            };

            if (isUpdate)
            {
                if (selectedId == 0)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần sửa.");
                    return;
                }
                service.Update(model);
                MessageBox.Show("Cập nhật nhân viên thành công.");
            }
            else
            {
                service.Add(model);
                MessageBox.Show("Thêm nhân viên thành công.");
            }
            LoadData();
            ResetForm();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            service.Delete(selectedId);
            LoadData();
            ResetForm();
            MessageBox.Show("Xóa nhân viên thành công.");
        }

        private void ResetForm()
        {
            selectedId = 0;
            txtMa.Clear(); txtHoTen.Clear(); txtSDT.Clear(); txtEmail.Clear(); txtChucVu.Clear(); txtLuong.Clear();
            dtpNgayVaoLam.Value = DateTime.Today;
            cboTrangThai.SelectedIndex = 0;
            txtSearch.Clear();
            lblSelected.Text = "Chưa chọn nhân viên nào.";
            LoadData();
        }
    }
}
