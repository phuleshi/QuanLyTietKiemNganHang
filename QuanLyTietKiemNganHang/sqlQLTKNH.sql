-- Tạo database
CREATE DATABASE QuanLyTietKiem;
GO

USE QuanLyTietKiem;
GO

--------------------------------------------------
-- 1. Bảng Khách Hàng
--------------------------------------------------
CREATE TABLE khach_hang (
    ma_khach_hang VARCHAR(10) PRIMARY KEY, -- KH001
    so_cccd VARCHAR(20) UNIQUE NOT NULL,
    ho_ten NVARCHAR(100) NOT NULL,
    so_dien_thoai VARCHAR(15),
    dia_chi NVARCHAR(255)
);

--------------------------------------------------
-- 2. Bảng Gói Tiết Kiệm
--------------------------------------------------
CREATE TABLE goi_tiet_kiem (
    ma_goi VARCHAR(10) PRIMARY KEY, -- GT001
    ten_goi NVARCHAR(100) NOT NULL,
    lai_suat_nam DECIMAL(5,2) NOT NULL,
    ky_han_thang INT NOT NULL
);

--------------------------------------------------
-- 3. Bảng Nhân Viên
--------------------------------------------------
CREATE TABLE nhan_vien (
    ma_nv VARCHAR(10) PRIMARY KEY, -- NV001
    tai_khoan VARCHAR(50) UNIQUE NOT NULL,
    mat_khau NVARCHAR(255) NOT NULL,
    vai_tro NVARCHAR(20) CHECK (vai_tro IN (N'Admin', N'Giao_dich_vien'))
);

--------------------------------------------------
-- 4. Bảng Sổ Tiết Kiệm
--------------------------------------------------
CREATE TABLE so_tiet_kiem (
    ma_so VARCHAR(10) PRIMARY KEY, -- STK001

    ma_khach_hang VARCHAR(10),
    ma_goi VARCHAR(10),
    ma_nv_mo VARCHAR(10),

    so_tien_goc DECIMAL(18,2) NOT NULL,
    so_du_hien_tai DECIMAL(18,2) NOT NULL,
    lai_suat_chot DECIMAL(5,2) NOT NULL,

    ngay_mo DATETIME DEFAULT GETDATE(),
    ngay_dao_han DATETIME,

    trang_thai NVARCHAR(20) DEFAULT N'Dang_mo',

    FOREIGN KEY (ma_khach_hang) REFERENCES khach_hang(ma_khach_hang),
    FOREIGN KEY (ma_goi) REFERENCES goi_tiet_kiem(ma_goi),
    FOREIGN KEY (ma_nv_mo) REFERENCES nhan_vien(ma_nv)
);

--------------------------------------------------
-- 5. Bảng Giao Dịch
--------------------------------------------------
CREATE TABLE giao_dich (
    ma_gd VARCHAR(10) PRIMARY KEY, -- GD001

    ma_so VARCHAR(10),
    ma_nv VARCHAR(10),

    loai_gd NVARCHAR(20) CHECK (loai_gd IN (N'Gui_them', N'Rut_tien', N'Tra_lai')),
    so_tien DECIMAL(18,2) NOT NULL,

    ngay_gd DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (ma_so) REFERENCES so_tiet_kiem(ma_so),
    FOREIGN KEY (ma_nv) REFERENCES nhan_vien(ma_nv)
);

--------------------------------------------------
-- 6. Bảng Nhật Ký Hệ Thống
--------------------------------------------------
CREATE TABLE nhat_ky_he_thong (
    ma_nhat_ky VARCHAR(10) PRIMARY KEY, -- NK001

    ma_nhan_vien VARCHAR(10),
    hanh_dong NVARCHAR(100),
    ten_bang NVARCHAR(50),

    gia_tri_cu NVARCHAR(MAX),
    gia_tri_moi NVARCHAR(MAX),

    thoi_gian DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (ma_nhan_vien) REFERENCES nhan_vien(ma_nv)
);

INSERT INTO khach_hang VALUES
('KH001', '001234567890', N'Nguyễn Văn An', '0901234567', N'Hà Nội'),
('KH002', '001234567891', N'Trần Thị Bình', '0901234568', N'Hải Phòng'),
('KH003', '001234567892', N'Lê Văn Cường', '0901234569', N'Đà Nẵng'),
('KH004', '001234567893', N'Phạm Thị Dung', '0901234570', N'TP. Hồ Chí Minh'),
('KH005', '001234567894', N'Hoàng Văn Đức', '0901234571', N'Cần Thơ');

INSERT INTO goi_tiet_kiem VALUES
('GTK001', N'Không kỳ hạn', 0.50, 0),
('GTK002', N'3 tháng', 4.50, 3),
('GTK003', N'6 tháng', 5.50, 6),
('GTK004', N'12 tháng', 6.80, 12),
('GTK005', N'24 tháng', 7.20, 24);

INSERT INTO nhan_vien VALUES
('NV001', 'admin', '123456', N'Admin'),
('NV002', 'gdv01', '123456', N'Giao_dich_vien'),
('NV003', 'gdv02', '123456', N'Giao_dich_vien');

INSERT INTO so_tiet_kiem VALUES
('STK001', 'KH001', 'GT002', 'NV002', 10000000, 10000000, 4.50, GETDATE(), DATEADD(MONTH, 3, GETDATE()), N'Dang_mo'),
('STK002', 'KH002', 'GT003', 'NV002', 20000000, 20000000, 5.50, GETDATE(), DATEADD(MONTH, 6, GETDATE()), N'Dang_mo'),
('STK003', 'KH003', 'GT004', 'NV003', 50000000, 50000000, 6.80, GETDATE(), DATEADD(MONTH, 12, GETDATE()), N'Dang_mo'),
('STK004', 'KH004', 'GT001', 'NV003', 15000000, 15000000, 0.50, GETDATE(), NULL, N'Dang_mo'),
('STK005', 'KH005', 'GT005', 'NV002', 30000000, 30000000, 7.20, GETDATE(), DATEADD(MONTH, 24, GETDATE()), N'Dang_mo');

INSERT INTO giao_dich VALUES
('GD001', 'STK001', 'NV002', N'Gui_them', 2000000, GETDATE()),
('GD002', 'STK002', 'NV002', N'Rut_tien', 5000000, GETDATE()),
('GD003', 'STK003', 'NV003', N'Tra_lai', 1000000, GETDATE()),
('GD004', 'STK004', 'NV003', N'Gui_them', 3000000, GETDATE()),
('GD005', 'STK005', 'NV002', N'Tra_lai', 2000000, GETDATE());

INSERT INTO nhat_ky_he_thong VALUES
('NK001', 'NV001', N'Thêm khách hàng', N'khach_hang', NULL, N'KH001', GETDATE()),
('NK002', 'NV002', N'Mở sổ tiết kiệm', N'so_tiet_kiem', NULL, N'STK001', GETDATE()),
('NK003', 'NV003', N'Thực hiện giao dịch', N'giao_dich', NULL, N'GD001', GETDATE());

CREATE OR ALTER PROC sp_them_khach_hang
    @so_cccd VARCHAR(20),
    @ho_ten NVARCHAR(100),
    @so_dien_thoai VARCHAR(15),
    @dia_chi NVARCHAR(255)
AS
BEGIN
    DECLARE @new_id VARCHAR(10);
    DECLARE @max_num INT;

    -- Lấy số lớn nhất hiện tại
    SELECT @max_num = MAX(CAST(SUBSTRING(ma_khach_hang, 3, LEN(ma_khach_hang)) AS INT))
    FROM khach_hang;

    -- Nếu chưa có dữ liệu
    IF @max_num IS NULL
        SET @max_num = 0;

    -- Tạo mã mới KH001
    SET @new_id = 'KH' + RIGHT('000' + CAST(@max_num + 1 AS VARCHAR), 3);

    -- Insert
    INSERT INTO khach_hang
    VALUES (@new_id, @so_cccd, @ho_ten, @so_dien_thoai, @dia_chi);
END;

CREATE OR ALTER PROC sp_sua_khach_hang
    @ma_khach_hang VARCHAR(10),
    @ho_ten NVARCHAR(100),
    @so_dien_thoai VARCHAR(15),
    @dia_chi NVARCHAR(255)
AS
BEGIN
    UPDATE khach_hang
    SET ho_ten = @ho_ten,
        so_dien_thoai = @so_dien_thoai,
        dia_chi = @dia_chi
    WHERE ma_khach_hang = @ma_khach_hang;
END;

CREATE OR ALTER PROC sp_xoa_khach_hang
    @ma_khach_hang VARCHAR(10)
AS
BEGIN
    DELETE FROM khach_hang
    WHERE ma_khach_hang = @ma_khach_hang;
END;

CREATE OR ALTER PROC sp_them_nhan_vien
    @tai_khoan VARCHAR(50),
    @mat_khau NVARCHAR(255),
    @vai_tro NVARCHAR(20)
AS
BEGIN
    DECLARE @new_id VARCHAR(10);
    DECLARE @max_num INT;

    SELECT @max_num = MAX(CAST(SUBSTRING(ma_nv, 3, LEN(ma_nv)) AS INT))
    FROM nhan_vien;

    IF @max_num IS NULL SET @max_num = 0;

    SET @new_id = 'NV' + RIGHT('000' + CAST(@max_num + 1 AS VARCHAR), 3);

    INSERT INTO nhan_vien
    VALUES (@new_id, @tai_khoan, @mat_khau, @vai_tro);
END;

CREATE OR ALTER PROC sp_sua_nhan_vien
    @ma_nv VARCHAR(10),
    @tai_khoan VARCHAR(50),
    @mat_khau NVARCHAR(255),
    @vai_tro NVARCHAR(20)
AS
BEGIN
    UPDATE nhan_vien
    SET tai_khoan = @tai_khoan,
        mat_khau = @mat_khau,
        vai_tro = @vai_tro
    WHERE ma_nv = @ma_nv;
END;

CREATE OR ALTER PROC sp_xoa_nhan_vien
    @ma_nv VARCHAR(10)
AS
BEGIN
    DELETE FROM nhan_vien
    WHERE ma_nv = @ma_nv;
END;

CREATE OR ALTER PROC sp_them_goi
    @ten_goi NVARCHAR(100),
    @lai_suat DECIMAL(5,2),
    @ky_han INT
AS
BEGIN
    DECLARE @new_id VARCHAR(10);
    DECLARE @max_num INT;

    SELECT @max_num = MAX(CAST(SUBSTRING(ma_goi, 4, LEN(ma_goi)) AS INT))
    FROM goi_tiet_kiem;

    IF @max_num IS NULL SET @max_num = 0;

    SET @new_id = 'GTK' + RIGHT('000' + CAST(@max_num + 1 AS VARCHAR), 3);

    INSERT INTO goi_tiet_kiem
    VALUES (@new_id, @ten_goi, @lai_suat, @ky_han);
END;

CREATE OR ALTER PROC sp_sua_goi
    @ma_goi VARCHAR(10),
    @ten_goi NVARCHAR(100),
    @lai_suat DECIMAL(5,2),
    @ky_han INT
AS
BEGIN
    UPDATE goi_tiet_kiem
    SET ten_goi = @ten_goi,
        lai_suat_nam = @lai_suat,
        ky_han_thang = @ky_han
    WHERE ma_goi = @ma_goi;
END;

CREATE OR ALTER PROC sp_xoa_goi
    @ma_goi VARCHAR(10)
AS
BEGIN
    DELETE FROM goi_tiet_kiem
    WHERE ma_goi = @ma_goi;
END;

CREATE OR ALTER PROC sp_mo_so
    @ma_khach_hang VARCHAR(10),
    @ma_goi VARCHAR(10),
    @ma_nv VARCHAR(10),
    @so_tien DECIMAL(18,2)
AS
BEGIN
    DECLARE @new_id VARCHAR(10);
    DECLARE @max_num INT;
    DECLARE @lai_suat DECIMAL(5,2);
    DECLARE @ky_han INT;

    SELECT @max_num = MAX(CAST(SUBSTRING(ma_so, 4, LEN(ma_so)) AS INT))
    FROM so_tiet_kiem;

    IF @max_num IS NULL SET @max_num = 0;

    SET @new_id = 'STK' + RIGHT('000' + CAST(@max_num + 1 AS VARCHAR), 3);

    -- Lấy thông tin gói
    SELECT @lai_suat = lai_suat_nam, @ky_han = ky_han_thang
    FROM goi_tiet_kiem
    WHERE ma_goi = @ma_goi;

    INSERT INTO so_tiet_kiem
    VALUES (
        @new_id,
        @ma_khach_hang,
        @ma_goi,
        @ma_nv,
        @so_tien,
        @so_tien,
        @lai_suat,
        GETDATE(),
        CASE WHEN @ky_han = 0 THEN NULL ELSE DATEADD(MONTH, @ky_han, GETDATE()) END,
        N'Dang_mo'
    );
END;

CREATE OR ALTER PROC sp_sua_so
    @ma_so VARCHAR(10),
    @so_du DECIMAL(18,2),
    @trang_thai NVARCHAR(20)
AS
BEGIN
    UPDATE so_tiet_kiem
    SET so_du_hien_tai = @so_du,
        trang_thai = @trang_thai
    WHERE ma_so = @ma_so;
END;

CREATE OR ALTER PROC sp_xoa_so
    @ma_so VARCHAR(10)
AS
BEGIN
    DELETE FROM so_tiet_kiem
    WHERE ma_so = @ma_so;
END;

CREATE OR ALTER PROC sp_xoa_giao_dich
    @ma_gd VARCHAR(10)
AS
BEGIN
    DELETE FROM giao_dich
    WHERE ma_gd = @ma_gd;
END;

CREATE OR ALTER PROC sp_xoa_nhat_ky
    @ma_nhat_ky VARCHAR(10)
AS
BEGIN
    DELETE FROM nhat_ky_he_thong
    WHERE ma_nhat_ky = @ma_nhat_ky;
END;    