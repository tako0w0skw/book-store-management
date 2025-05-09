USE [master]
GO
/****** Object:  Database [QuanLyPMBanSach]    Script Date: 06/05/2025 4:27:06 CH ******/
CREATE DATABASE [QuanLyPMBanSach]
 CONTAINMENT = NONE
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QuanLyPMBanSach] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyPMBanSach].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyPMBanSach] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyPMBanSach] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyPMBanSach] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyPMBanSach] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyPMBanSach] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyPMBanSach] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyPMBanSach] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyPMBanSach] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyPMBanSach] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyPMBanSach] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyPMBanSach] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyPMBanSach] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyPMBanSach] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyPMBanSach] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyPMBanSach] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLyPMBanSach] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyPMBanSach] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyPMBanSach] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyPMBanSach] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyPMBanSach] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyPMBanSach] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyPMBanSach] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyPMBanSach] SET RECOVERY FULL 
GO
ALTER DATABASE [QuanLyPMBanSach] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyPMBanSach] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyPMBanSach] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyPMBanSach] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyPMBanSach] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyPMBanSach] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyPMBanSach] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanLyPMBanSach', N'ON'
GO
ALTER DATABASE [QuanLyPMBanSach] SET QUERY_STORE = ON
GO
ALTER DATABASE [QuanLyPMBanSach] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QuanLyPMBanSach]
GO
/****** Object:  Table [dbo].[CHITIETHOADON]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETHOADON](
	[MaHD] [int] NOT NULL,
	[MaSach] [int] NOT NULL,
	[TenSach] [nvarchar](255) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGia] [decimal](18, 0) NOT NULL,
	[ThanhTien] [decimal](18, 0) NULL,
 CONSTRAINT [PK_CTHD] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC,
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DIACHI_KH]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DIACHI_KH](
	[MaDiaChi] [int] IDENTITY(1,1) NOT NULL,
	[MaKH] [int] NULL,
	[DiaChi] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK__DIACHI_K__EB61213E8F143614] PRIMARY KEY CLUSTERED 
(
	[MaDiaChi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DONHANG]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DONHANG](
	[MaHD] [int] IDENTITY(1,1) NOT NULL,
	[TamTinh] [decimal](18, 0) NOT NULL,
	[PhiVanChuyen] [decimal](18, 0) NULL,
	[TongTien] [decimal](18, 0) NOT NULL,
	[PT_ThanhToan] [nvarchar](50) NOT NULL,
	[PT_GiaoHang] [nvarchar](50) NOT NULL,
	[SDT] [varchar](15) NULL,
	[TrangThai] [nvarchar](50) NULL,
	[MaKH] [int] NULL,
	[MaKM] [varchar](20) NULL,
	[MaNV] [int] NULL,
	[NgayLapHD] [datetime] NULL,
 CONSTRAINT [PK__DONHANG__2725A6E08CF44F2C] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](100) NOT NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[Email] [varchar](100) NOT NULL,
	[SDT] [varchar](15) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password_KH] [varchar](255) NOT NULL,
	[TrangThai] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHUYENMAI]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHUYENMAI](
	[MaKM] [varchar](20) NOT NULL,
	[TenMa] [nvarchar](100) NOT NULL,
	[LoaiGiam] [nvarchar](50) NOT NULL,
	[MucGiam] [decimal](18, 0) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[LuotSuDung] [int] NULL,
	[NgayBatDau] [datetime] NULL,
	[NgayKetThuc] [datetime] NOT NULL,
	[TrangThai] [nvarchar](50) NOT NULL,
	[MaNV] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MaNV] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](100) NOT NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[NgaySinh] [datetime] NULL,
	[Email] [varchar](100) NOT NULL,
	[SDT] [varchar](15) NOT NULL,
	[DiaChi] [nvarchar](255) NULL,
	[ChucVu] [nvarchar](50) NOT NULL,
	[NgayVaoLam] [datetime] NULL,
	[Username] [varchar](50) NULL,
	[Password_NV] [varchar](255) NULL,
	[TrangThai] [nvarchar](50) NULL,
 CONSTRAINT [PK__NHANVIEN__2725D70AE111C150] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SACH]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SACH](
	[MaSach] [int] IDENTITY(1,1) NOT NULL,
	[HinhAnh] [nvarchar](255) NULL,
	[TenSach] [nvarchar](255) NOT NULL,
	[Gia] [decimal](18, 0) NULL,
	[SoLuongTon] [int] NULL,
	[NhaXuatBan] [nvarchar](100) NULL,
	[MoTa] [nvarchar](max) NULL,
	[SoTrang] [int] NULL,
	[NgayPhatHanh] [date] NULL,
	[DichGia] [nvarchar](100) NULL,
	[MaKM] [varchar](20) NULL,
	[TrangThai] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TACGIA]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TACGIA](
	[MaTacGia] [int] IDENTITY(1,1) NOT NULL,
	[TenTacGia] [nvarchar](100) NOT NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK__TACGIA__F24E6756029F2221] PRIMARY KEY CLUSTERED 
(
	[MaTacGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TACGIA_SACH]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TACGIA_SACH](
	[MaSach] [int] NOT NULL,
	[MaTacGia] [int] NOT NULL,
 CONSTRAINT [PK_TACGIA_SACH] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC,
	[MaTacGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THELOAI]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THELOAI](
	[MaTheLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenTheLoai] [nvarchar](100) NOT NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK__THELOAI__D73FF34A9D733AF1] PRIMARY KEY CLUSTERED 
(
	[MaTheLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THELOAI_SACH]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THELOAI_SACH](
	[MaSach] [int] NOT NULL,
	[MaTheLoai] [int] NOT NULL,
 CONSTRAINT [PK_THELOAI_SACH] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC,
	[MaTheLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CHITIETHOADON] ([MaHD], [MaSach], [TenSach], [SoLuong], [DonGia], [ThanhTien]) VALUES (31, 4, N'Tuổi trẻ đáng giá bao nhiêu', 1, CAST(98000 AS Decimal(18, 0)), CAST(98000 AS Decimal(18, 0)))
INSERT [dbo].[CHITIETHOADON] ([MaHD], [MaSach], [TenSach], [SoLuong], [DonGia], [ThanhTien]) VALUES (32, 7, N'Mình là cá, việc của mình là bơi', 1, CAST(99000 AS Decimal(18, 0)), CAST(99000 AS Decimal(18, 0)))
INSERT [dbo].[CHITIETHOADON] ([MaHD], [MaSach], [TenSach], [SoLuong], [DonGia], [ThanhTien]) VALUES (32, 9, N'Chiến binh cầu vồng', 2, CAST(130000 AS Decimal(18, 0)), CAST(260000 AS Decimal(18, 0)))
INSERT [dbo].[CHITIETHOADON] ([MaHD], [MaSach], [TenSach], [SoLuong], [DonGia], [ThanhTien]) VALUES (33, 1, N'Nhà Giả Kim', 5, CAST(120000 AS Decimal(18, 0)), CAST(600000 AS Decimal(18, 0)))
INSERT [dbo].[CHITIETHOADON] ([MaHD], [MaSach], [TenSach], [SoLuong], [DonGia], [ThanhTien]) VALUES (33, 6, N'Khéo ăn nói sẽ có được thiên hạ', 2, CAST(140000 AS Decimal(18, 0)), CAST(280000 AS Decimal(18, 0)))
INSERT [dbo].[CHITIETHOADON] ([MaHD], [MaSach], [TenSach], [SoLuong], [DonGia], [ThanhTien]) VALUES (34, 5, N'Không diệt không sinh đừng sợ hãi', 1, CAST(115000 AS Decimal(18, 0)), CAST(115000 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[DIACHI_KH] ON 

INSERT [dbo].[DIACHI_KH] ([MaDiaChi], [MaKH], [DiaChi]) VALUES (1, 1, N'10 Trần Duy Hưng, Hà Nội')
INSERT [dbo].[DIACHI_KH] ([MaDiaChi], [MaKH], [DiaChi]) VALUES (2, 2, N'45 Lê Lợi, Hồ Chí Minh')
INSERT [dbo].[DIACHI_KH] ([MaDiaChi], [MaKH], [DiaChi]) VALUES (3, 3, N'78 Hai Bà Trưng, Đà Nẵng')
INSERT [dbo].[DIACHI_KH] ([MaDiaChi], [MaKH], [DiaChi]) VALUES (4, 4, N'99 Trần Phú, Huế')
INSERT [dbo].[DIACHI_KH] ([MaDiaChi], [MaKH], [DiaChi]) VALUES (5, 5, N'120 Nguyễn Huệ, Cần Thơ')
INSERT [dbo].[DIACHI_KH] ([MaDiaChi], [MaKH], [DiaChi]) VALUES (6, 6, N'150 Phạm Ngũ Lão, Nha Trang')
INSERT [dbo].[DIACHI_KH] ([MaDiaChi], [MaKH], [DiaChi]) VALUES (7, 7, N'180 Võ Văn Tần, Vũng Tàu')
INSERT [dbo].[DIACHI_KH] ([MaDiaChi], [MaKH], [DiaChi]) VALUES (8, 8, N'200 Hoàng Diệu, Hà Nội')
INSERT [dbo].[DIACHI_KH] ([MaDiaChi], [MaKH], [DiaChi]) VALUES (9, 9, N'220 Nguyễn Đình Chiểu, Hồ Chí Minh')
INSERT [dbo].[DIACHI_KH] ([MaDiaChi], [MaKH], [DiaChi]) VALUES (10, 10, N'250 Đinh Tiên Hoàng, Hồ Chí Minh')
SET IDENTITY_INSERT [dbo].[DIACHI_KH] OFF
GO
SET IDENTITY_INSERT [dbo].[DONHANG] ON 

INSERT [dbo].[DONHANG] ([MaHD], [TamTinh], [PhiVanChuyen], [TongTien], [PT_ThanhToan], [PT_GiaoHang], [SDT], [TrangThai], [MaKH], [MaKM], [MaNV], [NgayLapHD]) VALUES (31, CAST(98000 AS Decimal(18, 0)), CAST(20000 AS Decimal(18, 0)), CAST(29800 AS Decimal(18, 0)), N'COD', N'Giao hàng nhanh', N'3333333333', N'Đang xử lý', 1, N'TAKO', 11, CAST(N'2025-05-04T11:33:31.337' AS DateTime))
INSERT [dbo].[DONHANG] ([MaHD], [TamTinh], [PhiVanChuyen], [TongTien], [PT_ThanhToan], [PT_GiaoHang], [SDT], [TrangThai], [MaKH], [MaKM], [MaNV], [NgayLapHD]) VALUES (32, CAST(359000 AS Decimal(18, 0)), CAST(30000 AS Decimal(18, 0)), CAST(379000 AS Decimal(18, 0)), N'VNPAY', N'Giao hàng nhanh', N'123131', N'Đang xử lý', 2, N'SALE10K', 11, CAST(N'2025-05-04T11:34:58.743' AS DateTime))
INSERT [dbo].[DONHANG] ([MaHD], [TamTinh], [PhiVanChuyen], [TongTien], [PT_ThanhToan], [PT_GiaoHang], [SDT], [TrangThai], [MaKH], [MaKM], [MaNV], [NgayLapHD]) VALUES (33, CAST(880000 AS Decimal(18, 0)), CAST(150000 AS Decimal(18, 0)), CAST(854000 AS Decimal(18, 0)), N'VNPAY', N'Giao hàng nhanh', N'0912380214', N'Đang xử lý', 9, N'SALE20', 11, CAST(N'2025-05-04T14:04:02.230' AS DateTime))
INSERT [dbo].[DONHANG] ([MaHD], [TamTinh], [PhiVanChuyen], [TongTien], [PT_ThanhToan], [PT_GiaoHang], [SDT], [TrangThai], [MaKH], [MaKM], [MaNV], [NgayLapHD]) VALUES (34, CAST(115000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(15000 AS Decimal(18, 0)), N'MOMO', N'Giao hàng tiết kiệm', N'099247184', N'Đang xử lý', 4, N'DAT3K', 11, CAST(N'2025-05-04T14:11:10.407' AS DateTime))
SET IDENTITY_INSERT [dbo].[DONHANG] OFF
GO
SET IDENTITY_INSERT [dbo].[KHACHHANG] ON 

INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [GioiTinh], [Email], [SDT], [Username], [Password_KH], [TrangThai]) VALUES (1, N'Nguyễn Minh Hiếu', N'Nam', N'hieu.nm@gmail.com', N'0901234567', N'hieuminh', N'pass123', N'Hoạt động')
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [GioiTinh], [Email], [SDT], [Username], [Password_KH], [TrangThai]) VALUES (2, N'Chung Huệ Như', N'Nữ', N'tako@gmail.com', N'0912345678', N'tako', N'hnhuowo', N'Hoạt động')
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [GioiTinh], [Email], [SDT], [Username], [Password_KH], [TrangThai]) VALUES (3, N'Lê Hoàng Nam', N'Nam', N'hoangnam@gmail.com', N'0923456789', N'hoangnam', N'namhoang', N'Hoạt động')
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [GioiTinh], [Email], [SDT], [Username], [Password_KH], [TrangThai]) VALUES (4, N'Lê Thành Đạt', N'Nam', N'ltd@gmail.com', N'0934567890', N'thanhdat', N'dat12345', N'Hoạt động')
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [GioiTinh], [Email], [SDT], [Username], [Password_KH], [TrangThai]) VALUES (5, N'Nguyễn Thị Lan', N'Nữ', N'lannt@gmail.com', N'0945678901', N'nguyenlan', N'lanlan', N'Hoạt động')
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [GioiTinh], [Email], [SDT], [Username], [Password_KH], [TrangThai]) VALUES (6, N'Hoàng Anh Tuấn', N'Nam', N'tuanha@gmail.com', N'0956789012', N'anhtuan', N'tuan123', N'Hoạt động')
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [GioiTinh], [Email], [SDT], [Username], [Password_KH], [TrangThai]) VALUES (7, N'Võ Thị Mai', N'Nữ', N'maivt@gmail.com', N'0967890123', N'maimai', N'mai2024', N'Hoạt động')
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [GioiTinh], [Email], [SDT], [Username], [Password_KH], [TrangThai]) VALUES (8, N'Đặng Văn Phước', N'Nam', N'phuocdv@gmail.com', N'0978901234', N'phuocdv', N'phuoc2024', N'Hoạt động')
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [GioiTinh], [Email], [SDT], [Username], [Password_KH], [TrangThai]) VALUES (9, N'Hoàng Gia Huy', N'Nam', N'ghuy@gmail.com', N'0989012345', N'giahuy', N'huydapoet', N'Hoạt động')
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [GioiTinh], [Email], [SDT], [Username], [Password_KH], [TrangThai]) VALUES (10, N'Giang Kiên Huy', N'Nam', N'kienhuy@gmail.com', N'0990123456', N'kienhuy', N'huynek', N'Hoạt động')
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [GioiTinh], [Email], [SDT], [Username], [Password_KH], [TrangThai]) VALUES (12, N'Nguyễn Chung Tường Vi', N'Nữ', N'ttuonvi@gmail.com', N'0956789012', N'ttuonvi', N'test s?a kh', N'Không hoạt động')
SET IDENTITY_INSERT [dbo].[KHACHHANG] OFF
GO
INSERT [dbo].[KHUYENMAI] ([MaKM], [TenMa], [LoaiGiam], [MucGiam], [SoLuong], [LuotSuDung], [NgayBatDau], [NgayKetThuc], [TrangThai], [MaNV]) VALUES (N'DAT3K', N'Mã của đạt', N'fixed amount', CAST(100000 AS Decimal(18, 0)), 2, 0, CAST(N'2025-03-30T12:19:19.400' AS DateTime), CAST(N'2026-11-18T00:00:00.000' AS DateTime), N'Hoạt động', 2)
INSERT [dbo].[KHUYENMAI] ([MaKM], [TenMa], [LoaiGiam], [MucGiam], [SoLuong], [LuotSuDung], [NgayBatDau], [NgayKetThuc], [TrangThai], [MaNV]) VALUES (N'SALE10', N'Mã sale 10 phần trăm', N'percent', CAST(10 AS Decimal(18, 0)), 20, 0, CAST(N'2025-03-30T12:19:19.400' AS DateTime), CAST(N'2026-01-07T00:00:00.000' AS DateTime), N'Hoạt động', 1)
INSERT [dbo].[KHUYENMAI] ([MaKM], [TenMa], [LoaiGiam], [MucGiam], [SoLuong], [LuotSuDung], [NgayBatDau], [NgayKetThuc], [TrangThai], [MaNV]) VALUES (N'SALE100K', N'Mã sale 100k', N'fixed amount', CAST(100000 AS Decimal(18, 0)), 20, 0, CAST(N'2025-03-30T12:19:19.400' AS DateTime), CAST(N'2026-01-07T00:00:00.000' AS DateTime), N'Hoạt động', 1)
INSERT [dbo].[KHUYENMAI] ([MaKM], [TenMa], [LoaiGiam], [MucGiam], [SoLuong], [LuotSuDung], [NgayBatDau], [NgayKetThuc], [TrangThai], [MaNV]) VALUES (N'SALE10K', N'Mã sale 10k', N'fixed amount', CAST(10000 AS Decimal(18, 0)), 50, 0, CAST(N'2025-03-30T12:19:19.400' AS DateTime), CAST(N'2026-01-07T00:00:00.000' AS DateTime), N'Hoạt động', 1)
INSERT [dbo].[KHUYENMAI] ([MaKM], [TenMa], [LoaiGiam], [MucGiam], [SoLuong], [LuotSuDung], [NgayBatDau], [NgayKetThuc], [TrangThai], [MaNV]) VALUES (N'SALE20', N'Mã sale 20 phần trăm', N'percent', CAST(20 AS Decimal(18, 0)), 20, 0, CAST(N'2025-03-30T12:19:19.400' AS DateTime), CAST(N'2026-01-07T00:00:00.000' AS DateTime), N'Hoạt động', 2)
INSERT [dbo].[KHUYENMAI] ([MaKM], [TenMa], [LoaiGiam], [MucGiam], [SoLuong], [LuotSuDung], [NgayBatDau], [NgayKetThuc], [TrangThai], [MaNV]) VALUES (N'SALE30', N'Mã sale 30 phần trăm', N'percent', CAST(30 AS Decimal(18, 0)), 20, 0, CAST(N'2025-03-30T12:19:19.400' AS DateTime), CAST(N'2026-01-07T00:00:00.000' AS DateTime), N'Hoạt động', 1)
INSERT [dbo].[KHUYENMAI] ([MaKM], [TenMa], [LoaiGiam], [MucGiam], [SoLuong], [LuotSuDung], [NgayBatDau], [NgayKetThuc], [TrangThai], [MaNV]) VALUES (N'SALE40', N'Mã sale 40 phần trăm', N'percent', CAST(40 AS Decimal(18, 0)), 20, 0, CAST(N'2025-03-30T12:19:19.400' AS DateTime), CAST(N'2026-01-07T00:00:00.000' AS DateTime), N'Hoạt động', 1)
INSERT [dbo].[KHUYENMAI] ([MaKM], [TenMa], [LoaiGiam], [MucGiam], [SoLuong], [LuotSuDung], [NgayBatDau], [NgayKetThuc], [TrangThai], [MaNV]) VALUES (N'SALE50', N'Mã sale 50 phần trăm', N'percent', CAST(50 AS Decimal(18, 0)), 20, 0, CAST(N'2025-03-30T12:19:19.400' AS DateTime), CAST(N'2026-01-07T00:00:00.000' AS DateTime), N'Hoạt động', 1)
INSERT [dbo].[KHUYENMAI] ([MaKM], [TenMa], [LoaiGiam], [MucGiam], [SoLuong], [LuotSuDung], [NgayBatDau], [NgayKetThuc], [TrangThai], [MaNV]) VALUES (N'SALE50K', N'Mã sale 50k', N'fixed amount', CAST(50000 AS Decimal(18, 0)), 20, 0, CAST(N'2025-03-30T12:19:19.400' AS DateTime), CAST(N'2026-01-07T00:00:00.000' AS DateTime), N'Hoạt động', 1)
INSERT [dbo].[KHUYENMAI] ([MaKM], [TenMa], [LoaiGiam], [MucGiam], [SoLuong], [LuotSuDung], [NgayBatDau], [NgayKetThuc], [TrangThai], [MaNV]) VALUES (N'TAKO', N'Mã của tako', N'percent', CAST(90 AS Decimal(18, 0)), 2, 0, CAST(N'2025-03-30T12:19:19.400' AS DateTime), CAST(N'2026-01-07T00:00:00.000' AS DateTime), N'Hoạt động', 1)
GO
SET IDENTITY_INSERT [dbo].[NHANVIEN] ON 

INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [GioiTinh], [NgaySinh], [Email], [SDT], [DiaChi], [ChucVu], [NgayVaoLam], [Username], [Password_NV], [TrangThai]) VALUES (1, N'Chung Huệ Như', NULL, NULL, N'hnhu07012004@gmail.com', N'0327226371', NULL, N'Quản trị viên', NULL, N'tako0w0skw', N'takowatotemokawaii', N'Hoạt động')
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [GioiTinh], [NgaySinh], [Email], [SDT], [DiaChi], [ChucVu], [NgayVaoLam], [Username], [Password_NV], [TrangThai]) VALUES (2, N'Lê Thành Đạt', NULL, NULL, N'ltdat@gmail.com', N'0901234567', NULL, N'Quản trị viên', NULL, N'lethanhdat', N'datwabakajanaidesu', N'Hoạt động')
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [GioiTinh], [NgaySinh], [Email], [SDT], [DiaChi], [ChucVu], [NgayVaoLam], [Username], [Password_NV], [TrangThai]) VALUES (3, N'Phạm Ngọc Sơn', NULL, NULL, N'pnson@gmail.com', N'0912345678', NULL, N'Nhân viên', NULL, N'1', NULL, N'Hoạt động')
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [GioiTinh], [NgaySinh], [Email], [SDT], [DiaChi], [ChucVu], [NgayVaoLam], [Username], [Password_NV], [TrangThai]) VALUES (4, N'Lê Thị Mộng Kiều', NULL, NULL, N'ltmkieu@gmail.com', N'0912345679', NULL, N'Nhân viên', NULL, N'2', NULL, N'Hoạt động')
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [GioiTinh], [NgaySinh], [Email], [SDT], [DiaChi], [ChucVu], [NgayVaoLam], [Username], [Password_NV], [TrangThai]) VALUES (5, N'Nguyễn Thảo Nguyên', NULL, NULL, N'ntnguyen@gmail.com', N'0912345610', NULL, N'Nhân viên', NULL, N'3', NULL, N'Hoạt động')
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [GioiTinh], [NgaySinh], [Email], [SDT], [DiaChi], [ChucVu], [NgayVaoLam], [Username], [Password_NV], [TrangThai]) VALUES (6, N'Võ Quốc Nam', N'', NULL, N'vqnam@gmail.com', N'0912345611', N'', N'Nhân viên', NULL, N'4', N'', N'Hoạt động')
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [GioiTinh], [NgaySinh], [Email], [SDT], [DiaChi], [ChucVu], [NgayVaoLam], [Username], [Password_NV], [TrangThai]) VALUES (7, N'Lê Minh Phương', NULL, NULL, N'lmphuong@gmail.com', N'0912345612', NULL, N'Nhân viên', NULL, N'5', NULL, N'Hoạt động')
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [GioiTinh], [NgaySinh], [Email], [SDT], [DiaChi], [ChucVu], [NgayVaoLam], [Username], [Password_NV], [TrangThai]) VALUES (8, N'Cao Kiều Nhung', N'', NULL, N'cknhunz@gmail.com', N'0912345613', N'', N'Nhân viên', NULL, N'6', N'', N'Hoạt động')
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [GioiTinh], [NgaySinh], [Email], [SDT], [DiaChi], [ChucVu], [NgayVaoLam], [Username], [Password_NV], [TrangThai]) VALUES (9, N'Huỳnh Gia Huy', NULL, NULL, N'huyhuynh@gmail.com', N'0912345614', NULL, N'Nhân viên', NULL, N'7', NULL, N'Hoạt động')
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [GioiTinh], [NgaySinh], [Email], [SDT], [DiaChi], [ChucVu], [NgayVaoLam], [Username], [Password_NV], [TrangThai]) VALUES (10, N'Bùi Châu Nhã Uyên', NULL, NULL, N'uyenbui@gmail.com', N'0912345615', NULL, N'Nhân viên', NULL, N'8', NULL, N'Hoạt động')
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [GioiTinh], [NgaySinh], [Email], [SDT], [DiaChi], [ChucVu], [NgayVaoLam], [Username], [Password_NV], [TrangThai]) VALUES (11, N'Chung Huệ Như', NULL, NULL, N'hnhu07012004@gmail.com', N'0327226371', NULL, N'Quản trị viên', NULL, N'admin', N'123', N'Hoạt động')
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [GioiTinh], [NgaySinh], [Email], [SDT], [DiaChi], [ChucVu], [NgayVaoLam], [Username], [Password_NV], [TrangThai]) VALUES (23, N'Chung Huệ Như', NULL, NULL, N'hnhu07012004@gmail.com', N'0938089711', NULL, N'Nhân viên', NULL, N'staff01', N'123', N'Hoạt động')
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [GioiTinh], [NgaySinh], [Email], [SDT], [DiaChi], [ChucVu], [NgayVaoLam], [Username], [Password_NV], [TrangThai]) VALUES (25, N'test thêm nv', N'Nữ', CAST(N'2025-05-04T22:59:49.000' AS DateTime), N'cknhunz@gmail.com', N'0912345613', N'aaaaaaaaaaaa', N'Nhân viên', CAST(N'2025-05-04T22:59:49.000' AS DateTime), N'1212', N'123', N'Hoạt động')
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [GioiTinh], [NgaySinh], [Email], [SDT], [DiaChi], [ChucVu], [NgayVaoLam], [Username], [Password_NV], [TrangThai]) VALUES (26, N'test thêm nv 2', N'Nam', CAST(N'2025-05-04T22:59:49.000' AS DateTime), N'cknhunz@gmail.com', N'0912345613', N'fsdfsdggs', N'Nhân viên', CAST(N'2025-05-04T22:59:49.000' AS DateTime), N'21313', N'123', N'Hoạt động')
SET IDENTITY_INSERT [dbo].[NHANVIEN] OFF
GO
SET IDENTITY_INSERT [dbo].[SACH] ON 

INSERT [dbo].[SACH] ([MaSach], [HinhAnh], [TenSach], [Gia], [SoLuongTon], [NhaXuatBan], [MoTa], [SoTrang], [NgayPhatHanh], [DichGia], [MaKM], [TrangThai]) VALUES (1, N'nhagiakim.png', N'Nhà Giả Kim', CAST(120000 AS Decimal(18, 0)), 45, N'NXB Trẻ', N'Sách về hành trình tìm kiếm ước mơ', 250, CAST(N'2006-01-01' AS Date), N'', N'TAKO', N'Còn hàng')
INSERT [dbo].[SACH] ([MaSach], [HinhAnh], [TenSach], [Gia], [SoLuongTon], [NhaXuatBan], [MoTa], [SoTrang], [NgayPhatHanh], [DichGia], [MaKM], [TrangThai]) VALUES (2, N'dacnhantam.png', N'Đắc Nhân Tâm', CAST(150000 AS Decimal(18, 0)), 58, N'NXB Tổng Hợp', N'Cách để thành công trong giao tiếp', 300, CAST(N'2010-03-15' AS Date), N'', N'DAT3K', N'Còn hàng')
INSERT [dbo].[SACH] ([MaSach], [HinhAnh], [TenSach], [Gia], [SoLuongTon], [NhaXuatBan], [MoTa], [SoTrang], [NgayPhatHanh], [DichGia], [MaKM], [TrangThai]) VALUES (3, N'thientaibentraikedienbenphai.png', N'Thiên tài bên trái, kẻ điên bên phải', CAST(135000 AS Decimal(18, 0)), 40, N'NXB Lao Động', N'Sách về tâm lý học và tư duy sáng tạo', 280, CAST(N'2015-06-20' AS Date), N'', N'SALE10K', N'Còn hàng')
INSERT [dbo].[SACH] ([MaSach], [HinhAnh], [TenSach], [Gia], [SoLuongTon], [NhaXuatBan], [MoTa], [SoTrang], [NgayPhatHanh], [DichGia], [MaKM], [TrangThai]) VALUES (4, N'tuoitredanggiabaonhieu.png', N'Tuổi trẻ đáng giá bao nhiêu', CAST(98000 AS Decimal(18, 0)), 79, N'NXB Kim Đồng', N'Lời khuyên cho tuổi trẻ về cuộc sống và sự nghiệp', 200, CAST(N'2018-09-05' AS Date), N'', N'SALE50', N'Còn hàng')
INSERT [dbo].[SACH] ([MaSach], [HinhAnh], [TenSach], [Gia], [SoLuongTon], [NhaXuatBan], [MoTa], [SoTrang], [NgayPhatHanh], [DichGia], [MaKM], [TrangThai]) VALUES (5, N'khongdietkhongsinhdungsohai.png', N'Không diệt không sinh đừng sợ hãi', CAST(115000 AS Decimal(18, 0)), 39, N'NXB Phụ Nữ', N'Sách về triết lý sống theo đạo Phật', 220, CAST(N'2014-12-12' AS Date), N'', N'SALE10K', N'Còn hàng')
INSERT [dbo].[SACH] ([MaSach], [HinhAnh], [TenSach], [Gia], [SoLuongTon], [NhaXuatBan], [MoTa], [SoTrang], [NgayPhatHanh], [DichGia], [MaKM], [TrangThai]) VALUES (6, N'kheoannoisecoduocthienha.png', N'Khéo ăn nói sẽ có được thiên hạ', CAST(140000 AS Decimal(18, 0)), 50, N'NXB Thanh Niên', N'Bí quyết giao tiếp và đàm phán', 310, CAST(N'2017-05-25' AS Date), N'', N'SALE10', N'Còn hàng')
INSERT [dbo].[SACH] ([MaSach], [HinhAnh], [TenSach], [Gia], [SoLuongTon], [NhaXuatBan], [MoTa], [SoTrang], [NgayPhatHanh], [DichGia], [MaKM], [TrangThai]) VALUES (7, N'minhlacavieccuaminhlaboi.png', N'Mình là cá, việc của mình là bơi', CAST(99000 AS Decimal(18, 0)), 64, N'NXB Dân Trí', N'Sách phát triển bản thân giúp vượt qua áp lực', 180, CAST(N'2019-08-10' AS Date), N'', N'SALE20', N'Còn hàng')
INSERT [dbo].[SACH] ([MaSach], [HinhAnh], [TenSach], [Gia], [SoLuongTon], [NhaXuatBan], [MoTa], [SoTrang], [NgayPhatHanh], [DichGia], [MaKM], [TrangThai]) VALUES (8, N'nghethuattinhtecuaviecdechquantam.png', N'Nghệ thuật tinh tế của việc đếch quan tâm', CAST(165000 AS Decimal(18, 0)), 30, N'NXB Văn Hóa', N'Cuốn sách giúp sống thoải mái hơn', 270, CAST(N'2020-02-28' AS Date), N'', N'SALE20', N'Còn hàng')
INSERT [dbo].[SACH] ([MaSach], [HinhAnh], [TenSach], [Gia], [SoLuongTon], [NhaXuatBan], [MoTa], [SoTrang], [NgayPhatHanh], [DichGia], [MaKM], [TrangThai]) VALUES (9, N'chienbinhcauvong.png', N'Chiến binh cầu vồng', CAST(130000 AS Decimal(18, 0)), 68, N'NXB Thế Giới', N'Câu chuyện về những đứa trẻ ở Indonesia', 330, CAST(N'2012-11-14' AS Date), N'', N'SALE40', N'Còn hàng')
INSERT [dbo].[SACH] ([MaSach], [HinhAnh], [TenSach], [Gia], [SoLuongTon], [NhaXuatBan], [MoTa], [SoTrang], [NgayPhatHanh], [DichGia], [MaKM], [TrangThai]) VALUES (10, N'cafecungtony.png', N'Cafe cùng Tony', CAST(105000 AS Decimal(18, 0)), 90, N'NXB Văn Học', N'Những bài học kinh nghiệm từ thực tế cuộc sống', 250, CAST(N'2016-07-30' AS Date), N'', N'SALE10', N'Còn hàng')
INSERT [dbo].[SACH] ([MaSach], [HinhAnh], [TenSach], [Gia], [SoLuongTon], [NhaXuatBan], [MoTa], [SoTrang], [NgayPhatHanh], [DichGia], [MaKM], [TrangThai]) VALUES (11, N'nhagiakim.png', N'test cập nhật sách', CAST(1111111111 AS Decimal(18, 0)), 1111, N'NXB Kim Đồng', N'hhhhhhhhhhhh', 123, CAST(N'2025-05-03' AS Date), N'aaaaaaaaa', N'DAT3K', N'Còn hàng')
INSERT [dbo].[SACH] ([MaSach], [HinhAnh], [TenSach], [Gia], [SoLuongTon], [NhaXuatBan], [MoTa], [SoTrang], [NgayPhatHanh], [DichGia], [MaKM], [TrangThai]) VALUES (12, N'tuoitredanggiabaonhieu.png', N'test thêm sách', CAST(1111111111 AS Decimal(18, 0)), 1111, N'NXB Kim Đồng', N'hhhhhhhhhhhh', 123, CAST(N'2025-05-03' AS Date), N'aaaaaaaaa', N'DAT3K', N'Còn hàng')
INSERT [dbo].[SACH] ([MaSach], [HinhAnh], [TenSach], [Gia], [SoLuongTon], [NhaXuatBan], [MoTa], [SoTrang], [NgayPhatHanh], [DichGia], [MaKM], [TrangThai]) VALUES (13, N'Nguoiduadieu.png', N'Người Đua Diều', CAST(180000 AS Decimal(18, 0)), 70, N'NXB Thế Giới', N'Sách về hành trình tìm kiếm ước mơ', 250, CAST(N'2010-07-23' AS Date), N'', N'SALE10K', N'Còn hàng')
SET IDENTITY_INSERT [dbo].[SACH] OFF
GO
SET IDENTITY_INSERT [dbo].[TACGIA] ON 

INSERT [dbo].[TACGIA] ([MaTacGia], [TenTacGia], [TrangThai]) VALUES (1, N'Paulo Coelho', 1)
INSERT [dbo].[TACGIA] ([MaTacGia], [TenTacGia], [TrangThai]) VALUES (2, N'Dale Carnegie', 1)
INSERT [dbo].[TACGIA] ([MaTacGia], [TenTacGia], [TrangThai]) VALUES (3, N'Tony Buổi Sáng', 1)
INSERT [dbo].[TACGIA] ([MaTacGia], [TenTacGia], [TrangThai]) VALUES (4, N'Mark Manson', 1)
INSERT [dbo].[TACGIA] ([MaTacGia], [TenTacGia], [TrangThai]) VALUES (5, N'Ichiro Kishimi', 1)
INSERT [dbo].[TACGIA] ([MaTacGia], [TenTacGia], [TrangThai]) VALUES (6, N'Hector Garcia', 1)
INSERT [dbo].[TACGIA] ([MaTacGia], [TenTacGia], [TrangThai]) VALUES (7, N'Robin Sharma', 1)
INSERT [dbo].[TACGIA] ([MaTacGia], [TenTacGia], [TrangThai]) VALUES (8, N'Nguyễn Nhật Ánh', 1)
INSERT [dbo].[TACGIA] ([MaTacGia], [TenTacGia], [TrangThai]) VALUES (9, N'Haruki Murakami', 1)
INSERT [dbo].[TACGIA] ([MaTacGia], [TenTacGia], [TrangThai]) VALUES (10, N'Thích Nhất Hạnh', 1)
INSERT [dbo].[TACGIA] ([MaTacGia], [TenTacGia], [TrangThai]) VALUES (11, N'test sửa tác giả', 0)
SET IDENTITY_INSERT [dbo].[TACGIA] OFF
GO
INSERT [dbo].[TACGIA_SACH] ([MaSach], [MaTacGia]) VALUES (1, 1)
INSERT [dbo].[TACGIA_SACH] ([MaSach], [MaTacGia]) VALUES (2, 2)
INSERT [dbo].[TACGIA_SACH] ([MaSach], [MaTacGia]) VALUES (3, 5)
INSERT [dbo].[TACGIA_SACH] ([MaSach], [MaTacGia]) VALUES (4, 9)
INSERT [dbo].[TACGIA_SACH] ([MaSach], [MaTacGia]) VALUES (5, 10)
INSERT [dbo].[TACGIA_SACH] ([MaSach], [MaTacGia]) VALUES (6, 7)
INSERT [dbo].[TACGIA_SACH] ([MaSach], [MaTacGia]) VALUES (7, 6)
INSERT [dbo].[TACGIA_SACH] ([MaSach], [MaTacGia]) VALUES (8, 4)
INSERT [dbo].[TACGIA_SACH] ([MaSach], [MaTacGia]) VALUES (9, 8)
INSERT [dbo].[TACGIA_SACH] ([MaSach], [MaTacGia]) VALUES (10, 3)
INSERT [dbo].[TACGIA_SACH] ([MaSach], [MaTacGia]) VALUES (11, 5)
GO
SET IDENTITY_INSERT [dbo].[THELOAI] ON 

INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai], [TrangThai]) VALUES (1, N'Văn học', 1)
INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai], [TrangThai]) VALUES (2, N'Kinh tế', 1)
INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai], [TrangThai]) VALUES (3, N'Kỹ năng sống', 1)
INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai], [TrangThai]) VALUES (4, N'Tâm lý học', 1)
INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai], [TrangThai]) VALUES (5, N'Phát triển bản thân', 1)
INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai], [TrangThai]) VALUES (6, N'Lịch sử', 1)
INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai], [TrangThai]) VALUES (7, N'Khoa học', 1)
INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai], [TrangThai]) VALUES (8, N'Truyện thiếu nhi', 1)
INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai], [TrangThai]) VALUES (9, N'Tiểu thuyết', 1)
INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai], [TrangThai]) VALUES (10, N'Tôn giáo', 0)
INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai], [TrangThai]) VALUES (11, N'test thêm tl', 1)
INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai], [TrangThai]) VALUES (12, N'test cập nhật tl', 1)
INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai], [TrangThai]) VALUES (13, N'Văn học', 0)
SET IDENTITY_INSERT [dbo].[THELOAI] OFF
GO
INSERT [dbo].[THELOAI_SACH] ([MaSach], [MaTheLoai]) VALUES (1, 5)
INSERT [dbo].[THELOAI_SACH] ([MaSach], [MaTheLoai]) VALUES (2, 3)
INSERT [dbo].[THELOAI_SACH] ([MaSach], [MaTheLoai]) VALUES (3, 4)
INSERT [dbo].[THELOAI_SACH] ([MaSach], [MaTheLoai]) VALUES (4, 5)
INSERT [dbo].[THELOAI_SACH] ([MaSach], [MaTheLoai]) VALUES (5, 10)
INSERT [dbo].[THELOAI_SACH] ([MaSach], [MaTheLoai]) VALUES (6, 3)
INSERT [dbo].[THELOAI_SACH] ([MaSach], [MaTheLoai]) VALUES (7, 5)
INSERT [dbo].[THELOAI_SACH] ([MaSach], [MaTheLoai]) VALUES (8, 5)
INSERT [dbo].[THELOAI_SACH] ([MaSach], [MaTheLoai]) VALUES (9, 1)
INSERT [dbo].[THELOAI_SACH] ([MaSach], [MaTheLoai]) VALUES (10, 3)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_KH]    Script Date: 06/05/2025 4:27:07 CH ******/
ALTER TABLE [dbo].[KHACHHANG] ADD  CONSTRAINT [UQ_KH] UNIQUE NONCLUSTERED 
(
	[Email] ASC,
	[SDT] ASC,
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_NhanVien_Username]    Script Date: 06/05/2025 4:27:07 CH ******/
ALTER TABLE [dbo].[NHANVIEN] ADD  CONSTRAINT [UQ_NhanVien_Username] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_NV]    Script Date: 06/05/2025 4:27:07 CH ******/
ALTER TABLE [dbo].[NHANVIEN] ADD  CONSTRAINT [UQ_NV] UNIQUE NONCLUSTERED 
(
	[Email] ASC,
	[SDT] ASC,
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DONHANG] ADD  CONSTRAINT [DF_NgayLapHD]  DEFAULT (getdate()) FOR [NgayLapHD]
GO
ALTER TABLE [dbo].[KHUYENMAI] ADD  DEFAULT ((0)) FOR [LuotSuDung]
GO
ALTER TABLE [dbo].[KHUYENMAI] ADD  DEFAULT (getdate()) FOR [NgayBatDau]
GO
ALTER TABLE [dbo].[SACH] ADD  DEFAULT ((0)) FOR [Gia]
GO
ALTER TABLE [dbo].[SACH] ADD  DEFAULT ((0)) FOR [SoLuongTon]
GO
ALTER TABLE [dbo].[TACGIA] ADD  CONSTRAINT [DF_TACGIA_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[THELOAI] ADD  CONSTRAINT [DF_THELOAI_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD  CONSTRAINT [FK_CTHD_HD] FOREIGN KEY([MaHD])
REFERENCES [dbo].[DONHANG] ([MaHD])
GO
ALTER TABLE [dbo].[CHITIETHOADON] CHECK CONSTRAINT [FK_CTHD_HD]
GO
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD  CONSTRAINT [FK_CTHD_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[SACH] ([MaSach])
GO
ALTER TABLE [dbo].[CHITIETHOADON] CHECK CONSTRAINT [FK_CTHD_Sach]
GO
ALTER TABLE [dbo].[DIACHI_KH]  WITH CHECK ADD  CONSTRAINT [FK_DC_KH] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[DIACHI_KH] CHECK CONSTRAINT [FK_DC_KH]
GO
ALTER TABLE [dbo].[DONHANG]  WITH CHECK ADD  CONSTRAINT [FK_DH_NV] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[DONHANG] CHECK CONSTRAINT [FK_DH_NV]
GO
ALTER TABLE [dbo].[DONHANG]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[DONHANG] CHECK CONSTRAINT [FK_DonHang_KhachHang]
GO
ALTER TABLE [dbo].[DONHANG]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_KhuyenMai] FOREIGN KEY([MaKM])
REFERENCES [dbo].[KHUYENMAI] ([MaKM])
GO
ALTER TABLE [dbo].[DONHANG] CHECK CONSTRAINT [FK_DonHang_KhuyenMai]
GO
ALTER TABLE [dbo].[KHUYENMAI]  WITH CHECK ADD  CONSTRAINT [FK_KhuyenMai_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[KHUYENMAI] CHECK CONSTRAINT [FK_KhuyenMai_NhanVien]
GO
ALTER TABLE [dbo].[SACH]  WITH CHECK ADD  CONSTRAINT [FK_Sach_KhuyenMai] FOREIGN KEY([MaKM])
REFERENCES [dbo].[KHUYENMAI] ([MaKM])
GO
ALTER TABLE [dbo].[SACH] CHECK CONSTRAINT [FK_Sach_KhuyenMai]
GO
ALTER TABLE [dbo].[TACGIA_SACH]  WITH CHECK ADD  CONSTRAINT [FK_SACH_TACGIA] FOREIGN KEY([MaSach])
REFERENCES [dbo].[SACH] ([MaSach])
GO
ALTER TABLE [dbo].[TACGIA_SACH] CHECK CONSTRAINT [FK_SACH_TACGIA]
GO
ALTER TABLE [dbo].[TACGIA_SACH]  WITH CHECK ADD  CONSTRAINT [FK_TACGIA] FOREIGN KEY([MaTacGia])
REFERENCES [dbo].[TACGIA] ([MaTacGia])
GO
ALTER TABLE [dbo].[TACGIA_SACH] CHECK CONSTRAINT [FK_TACGIA]
GO
ALTER TABLE [dbo].[THELOAI_SACH]  WITH CHECK ADD  CONSTRAINT [FK_SACH_THELOAI] FOREIGN KEY([MaSach])
REFERENCES [dbo].[SACH] ([MaSach])
GO
ALTER TABLE [dbo].[THELOAI_SACH] CHECK CONSTRAINT [FK_SACH_THELOAI]
GO
ALTER TABLE [dbo].[THELOAI_SACH]  WITH CHECK ADD  CONSTRAINT [FK_THELOAI] FOREIGN KEY([MaTheLoai])
REFERENCES [dbo].[THELOAI] ([MaTheLoai])
GO
ALTER TABLE [dbo].[THELOAI_SACH] CHECK CONSTRAINT [FK_THELOAI]
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatKhachHang]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_CapNhatKhachHang]
	@MaKH int,
	@HoTen nvarchar(100),
	@GioiTinh nvarchar(10),
	@Email varchar(100),
	@SDT varchar(15),
	@Username varchar(50),
	@Password_KH varchar(255),
	@TrangThai nvarchar(50)
as
	update KHACHHANG set HoTen = @HoTen, GioiTinh = @GioiTinh, 
	Email = @Email, SDT = @SDT, Username = @Username, 
	Password_KH = @Password_KH, TrangThai = @TrangThai
	where MaKH = @MaKH
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatNhanVien]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_CapNhatNhanVien]
	@MaNV int,
	@HoTen	nvarchar(100),
	@GioiTinh nvarchar(10),
	@NgaySinh datetime,
	@Email varchar(100),
	@SDT varchar(15),
	@DiaChi	nvarchar(255),
	@ChucVu	nvarchar(50),
	@NgayVaoLam	datetime,
	@Username varchar(50),
	@Password_NV varchar(255),
	@TrangThai nvarchar(50)
as
	update NHANVIEN set HoTen = @HoTen, GioiTinh = @GioiTinh, 
	NgaySinh = @NgaySinh,Email = @Email, SDT = @SDT, 
	DiaChi = @DiaChi, ChucVu = @ChucVu, NgayVaoLam = @NgayVaoLam, 
	Username = @Username, Password_NV = @Password_NV, TrangThai = @TrangThai
	where MaNV = @MaNV
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatSach]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_CapNhatSach]
	@MaSach int, @HinhAnh nvarchar(255), @TenSach nvarchar(255), @Gia decimal(18, 0),
	@SoLuongTon	int, @NhaXuatBan nvarchar(100), @MoTa nvarchar(MAX), @SoTrang int,
	@NgayPhatHanh date,	@DichGia nvarchar(100),	@MaKM varchar(20), @TrangThai nvarchar(50)
as
	update SACH
	set HinhAnh = @HinhAnh,
		TenSach = @TenSach,
		Gia = @Gia,
		SoLuongTon = @SoLuongTon,
		NhaXuatBan = @NhaXuatBan,
		MoTa = @MoTa,
		SoTrang = @SoTrang,
		NgayPhatHanh = @NgayPhatHanh,
		DichGia = @DichGia,
		MaKM = @MaKM,
		TrangThai = @TrangThai
	where MaSach = @MaSach
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatSoLuongTon]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_CapNhatSoLuongTon]
	@MaSach int, @SoLuong int
as
	update SACH set SoLuongTon = SoLuongTon - @SoLuong where MaSach = @MaSach
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatTacGia]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_CapNhatTacGia]
	@MaTacGia int, @TenTacGia nvarchar(100)
as
	update TACGIA set TenTacGia = @TenTacGia where MaTacGia = @MaTacGia
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatTGSach]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_CapNhatTGSach]
	@MaSach int, @MaTacGia int
as
	update TACGIA_SACH set MaTacGia = @MaTacGia where MaSach = @MaSach
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatTheLoai]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_CapNhatTheLoai]
	@MaTheLoai int, @TenTheLoai nvarchar(100)
as
	update THELOAI set TenTheLoai = @TenTheLoai where MaTheLoai = @MaTheLoai
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatTheLoaiSach]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_CapNhatTheLoaiSach]
	@MaSach int, @MaTheLoai int
as
	update THELOAI_SACH set MaTheLoai = @MaTheLoai where MaSach = @MaSach
GO
/****** Object:  StoredProcedure [dbo].[sp_KiemTraDangNhap]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_KiemTraDangNhap]
	@Username varchar(50), @Password varchar(255)
as
	select COUNT(MaNV) from NHANVIEN
	where Username = @Username and Password_NV = @Password
	group by MaNV
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDanhSachChiTietHoaDon]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_LayDanhSachChiTietHoaDon]
	@MaHD int = null
as
	select * from CHITIETHOADON where MaHD = ISNULL(@MaHD,MaHD)
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDanhSachHoaDon]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LayDanhSachHoaDon]
	@MaHD int  = null, @MaNV int = null, @MaKH int = null
as
	begin
		if @MaHD is not null
			select * from DONHANG
			where 
			MaHD = ISNULL(@MaHD,MaHD)

		else if @MaNV is not null
			select * from DONHANG
			where 
			MaNV = ISNULL(@MaNV,MaNV)

		else if @MaKH is not null
			select * from DONHANG
			where 
			MaKH = ISNULL(@MaKH,MaKH)
		else
			select * from DONHANG
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDanhSachKhachHang]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_LayDanhSachKhachHang]
	@MaKH int = null
as
	select * from KHACHHANG where MaKH = ISNULL(@MaKH,MaKH) and TrangThai like N'%Hoạt động%'
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDanhSachKhuyenMai]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LayDanhSachKhuyenMai]
	@MaKM varchar(20) = null,
	@MaNV int = null,
	@LoaiGiam nvarchar(50) = null
as
begin
	select * from KHUYENMAI
	where 
		(MaKM like '%' + ISNULL(@MaKM,'') + '%') and
		(MaNV = ISNULL(@MaNV, MaNV)) and
		(LoaiGiam like N'%' + ISNULL(@LoaiGiam,'') + '%')
end
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDanhSachNhanVien]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LayDanhSachNhanVien]
	@MaNV int = null, @ChucVu nvarchar(50) = null, @TrangThai nvarchar(50) = null
as
begin
	if @ChucVu is not null or @TrangThai is not null
	begin
		if @ChucVu is null
		begin
			select * from NHANVIEN
			where 
			MaNV = ISNULL(@MaNV, MaNV) and 
			TrangThai like N'%'+ ISNULL(@TrangThai,'') +'%'
		end

		else
		begin
			select * from NHANVIEN
			where 
			MaNV = ISNULL(@MaNV, MaNV) and 
			ChucVu like N'%'+ ISNULL(@ChucVu,'') +'%'
		end
	end

	else
	begin
		select * from NHANVIEN
		where 
		MaNV = ISNULL(@MaNV, MaNV) and TrangThai = N'Hoạt động'
	end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDanhSachSach]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LayDanhSachSach]
	@MaSach int = null,
	@NXB nvarchar(100) = null,
	@TrangThai nvarchar(50) = null
as
begin
	select * from SACH
	where 
		(MaSach = ISNULL(@MaSach,MaSach)) and
		(NhaXuatBan like N'%' + ISNULL(@NXB,'') + '%') and
		(TrangThai like N'%' + ISNULL(@TrangThai,'') + '%')
end
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDanhSachTacGia]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LayDanhSachTacGia]
	@MaTacGia int = null
as
	select * from TACGIA
	where MaTacGia = ISNULL(@MaTacGia,MaTacGia) and TrangThai = 1
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDanhSachTGSach]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LayDanhSachTGSach]
	@MaSach int = null
as
	select s.MaSach, tg.MaTacGia, s.TenSach, tg.TenTacGia
	from TACGIA_SACH tgs join SACH s on tgs.MaSach = s.MaSach join TACGIA tg on tgs.MaTacGia = tg.MaTacGia
	where s.MaSach = ISNULL(@MaSach,s.MaSach)
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDanhSachTheLoai]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LayDanhSachTheLoai]
	@MaTheLoai int = null
as
	select * from THELOAI
	where MaTheLoai = ISNULL(@MaTheLoai,MaTheLoai) and TrangThai = 1
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDanhSachTheLoaiSach]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LayDanhSachTheLoaiSach]
	@MaSach int = null, @MaTheLoai int = null
as
	select tls.MaSach, tls.MaTheLoai, s.TenSach, tl.TenTheLoai
	from THELOAI_SACH tls join SACH s on tls.MaSach = s.MaSach join THELOAI tl on tl.MaTheLoai = tls.MaTheLoai
	where tls.MaSach = ISNULL(@MaSach, tls.MaSach) and tls.MaTheLoai = ISNULL(@MaTheLoai, tls.MaTheLoai)
GO
/****** Object:  StoredProcedure [dbo].[sp_LayHoaDonVuaTao]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LayHoaDonVuaTao]
as
	select top 1 MaHD from DONHANG order by NgayLapHD desc
GO
/****** Object:  StoredProcedure [dbo].[sp_LayThongTinUser]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_LayThongTinUser]
	@Username varchar(50), @Password varchar(255)
as
	select * from NHANVIEN where Username = @Username and Password_NV = @Password
GO
/****** Object:  StoredProcedure [dbo].[sp_ReseedIdentityKhachHang]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ReseedIdentityKhachHang]
as
begin
    declare @MaxID int;

    -- Tìm giá trị lớn nhất của cột MaSach
    select @MaxID = MAX(MaKH)
    from KHACHHANG;

    -- Nếu bảng rỗng, đặt giá trị IDENTITY về 0
    if @MaxID IS NULL
        SET @MaxID = 0;

    -- Đặt lại giá trị IDENTITY
    DBCC CHECKIDENT ('KHACHHANG', RESEED, @MaxID);
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ReseedIdentityNhanVien]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ReseedIdentityNhanVien]
as
begin
    declare @MaxID int;

    -- Tìm giá trị lớn nhất của cột MaSach
    select @MaxID = MAX(MaNV)
    from NHANVIEN;

    -- Nếu bảng rỗng, đặt giá trị IDENTITY về 0
    if @MaxID IS NULL
        SET @MaxID = 0;

    -- Đặt lại giá trị IDENTITY
    DBCC CHECKIDENT ('NHANVIEN', RESEED, @MaxID);
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ReseedIdentitySach]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ReseedIdentitySach]
as
begin
    declare @MaxID int;

    select @MaxID = MAX(MaSach)
    from Sach;

    if @MaxID IS NULL
        SET @MaxID = 0;

    DBCC CHECKIDENT ('SACH', RESEED, @MaxID);
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ReseedIdentityTacGia]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ReseedIdentityTacGia]
as
begin
    declare @MaxID int;

    select @MaxID = MAX(MaTacGia)
    from TACGIA;

    if @MaxID IS NULL
        SET @MaxID = 0;

    DBCC CHECKIDENT ('TACGIA', RESEED, @MaxID);
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ReseedIdentityTheLoai]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ReseedIdentityTheLoai]
as
begin
    declare @MaxID int;

    select @MaxID = MAX(MaTheLoai)
    from THELOAI;

    if @MaxID IS NULL
        SET @MaxID = 0;

    DBCC CHECKIDENT ('THELOAI', RESEED, @MaxID);
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemChiTietHoaDon]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ThemChiTietHoaDon]
	@MaHD int,
	@MaSach int,
	@TenSach nvarchar(255),
	@SoLuong int,
	@DonGia decimal(18, 0),
	@ThanhTien decimal(18, 0)
as
	insert into CHITIETHOADON values
	(@MaHD,@MaSach,@TenSach,@SoLuong,@DonGia,@ThanhTien)
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemHoaDon]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ThemHoaDon]
	@TamTinh decimal(18, 0),
	@PhiVanChuyen decimal(18, 0),
	@TongTien decimal(18, 0),
	@PT_ThanhToan nvarchar(50),
	@PT_GiaoHang nvarchar(50),
	@SDT varchar(15),
	@TrangThai nvarchar(50) = N'Đang xử lý',
	@MaKH int,
	@MaKM varchar(20),
	@MaNV int
as
	insert into DONHANG(TamTinh,PhiVanChuyen,TongTien,PT_ThanhToan,PT_GiaoHang,SDT,TrangThai,MaKH,MaKM,MaNV) values
	(@TamTinh,@PhiVanChuyen,@TongTien,@PT_ThanhToan,@PT_GiaoHang,@SDT,@TrangThai,@MaKH,@MaKM,@MaNV)
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemKhachHang]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ThemKhachHang]
	@HoTen nvarchar(100),
	@GioiTinh nvarchar(10),
	@Email varchar(100),
	@SDT varchar(15),
	@Username varchar(50),
	@Password_KH varchar(255),
	@TrangThai nvarchar(50)
as
	insert into KHACHHANG(HoTen,GioiTinh,Email,SDT,Username,Password_KH,TrangThai) values
	(@HoTen,@GioiTinh,@Email,@SDT,@Username,@Password_KH,@TrangThai)
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemNhanVien]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ThemNhanVien]
	@HoTen	nvarchar(100),
	@GioiTinh nvarchar(10),
	@NgaySinh datetime,
	@Email varchar(100),
	@SDT varchar(15),
	@DiaChi	nvarchar(255),
	@ChucVu	nvarchar(50),
	@NgayVaoLam	datetime,
	@Username varchar(50),
	@Password_NV varchar(255),
	@TrangThai nvarchar(50)
as
	insert into NHANVIEN(HoTen,GioiTinh,NgaySinh,Email,SDT,DiaChi,ChucVu,NgayVaoLam,Username,Password_NV,TrangThai) values
	(@HoTen,@GioiTinh,@NgaySinh,@Email,@SDT,@DiaChi,@ChucVu,@NgayVaoLam,@Username,@Password_NV,@TrangThai)
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemSach]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ThemSach]
	@HinhAnh nvarchar(255) = null, @TenSach nvarchar(255), @Gia decimal(18, 0),
	@SoLuongTon	int, @NhaXuatBan nvarchar(100), @MoTa nvarchar(MAX), @SoTrang int,
	@NgayPhatHanh date,	@DichGia nvarchar(100),	@MaKM varchar(20), @TrangThai nvarchar(50)
as
	insert into SACH(HinhAnh,TenSach,Gia,SoLuongTon,NhaXuatBan,MoTa,SoTrang,NgayPhatHanh,DichGia,MaKM,TrangThai) values
	(@HinhAnh,@TenSach,@Gia,@SoLuongTon,@NhaXuatBan,@MoTa,@SoTrang,@NgayPhatHanh,@DichGia,@MaKM,@TrangThai)
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemTacGia]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ThemTacGia]
	@TenTacGia nvarchar(100)
as
	insert into TACGIA values(@TenTacGia)
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemTGSach]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ThemTGSach]
	@MaSach int, @MaTacGia int
as
	insert into TACGIA_SACH values(@MaSach,@MaTacGia)
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemTheLoai]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_ThemTheLoai]
	 @TenTheLoai nvarchar(100)
as
	insert into THELOAI(TenTheLoai) values(@TenTheLoai)
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemTheLoaiSach]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ThemTheLoaiSach]
	@MaSach int, @MaTheLoai int
as
	insert into THELOAI_SACH values (@MaSach,@MaTheLoai)
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaKhachHang]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_XoaKhachHang]
	@MaKH int
as
	update KHACHHANG set TrangThai = N'Không hoạt động' where MaKH = @MaKH
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaNhanVien]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_XoaNhanVien]
	@MaNV int
as
	update NHANVIEN set TrangThai = N'Không hoạt động' where MaNV = @MaNV
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaSach]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_XoaSach]
	@MaSach int
as
begin
	delete from SACH where MaSach = @MaSach
end
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaTacGia]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_XoaTacGia]
	@MaTacGia int
as
	update TACGIA set TrangThai = 0 where MaTacGia = @MaTacGia
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaTGSach]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_XoaTGSach]
	@MaTacGia int, @MaSach int
as
	delete from TACGIA_SACH where MaSach = @MaSach and MaTacGia = @MaTacGia
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaTheLoai]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_XoaTheLoai]
	@MaTheLoai int
as
	update THELOAI set TrangThai = 0 where MaTheLoai = @MaTheLoai
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaTheLoaiSach]    Script Date: 06/05/2025 4:27:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_XoaTheLoaiSach]
		@MaSach int, @MaTheLoai int
as
	delete from THELOAI_SACH where MaSach = @MaSach and MaTheLoai = @MaTheLoai
GO
USE [master]
GO
ALTER DATABASE [QuanLyPMBanSach] SET  READ_WRITE 
GO
