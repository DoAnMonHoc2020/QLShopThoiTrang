USE [master]
GO
/****** Object:  Database [QL_ShopQuanAo]    Script Date: 16/08/2020 1:32:31 CH ******/
CREATE DATABASE [QL_ShopQuanAo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QL_ShopQuanAo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QL_ShopQuanAo.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QL_ShopQuanAo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QL_ShopQuanAo_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QL_ShopQuanAo] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QL_ShopQuanAo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QL_ShopQuanAo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QL_ShopQuanAo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QL_ShopQuanAo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QL_ShopQuanAo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QL_ShopQuanAo] SET ARITHABORT OFF 
GO
ALTER DATABASE [QL_ShopQuanAo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QL_ShopQuanAo] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QL_ShopQuanAo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QL_ShopQuanAo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QL_ShopQuanAo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QL_ShopQuanAo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QL_ShopQuanAo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QL_ShopQuanAo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QL_ShopQuanAo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QL_ShopQuanAo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QL_ShopQuanAo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QL_ShopQuanAo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QL_ShopQuanAo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QL_ShopQuanAo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QL_ShopQuanAo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QL_ShopQuanAo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QL_ShopQuanAo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QL_ShopQuanAo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QL_ShopQuanAo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QL_ShopQuanAo] SET  MULTI_USER 
GO
ALTER DATABASE [QL_ShopQuanAo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QL_ShopQuanAo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QL_ShopQuanAo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QL_ShopQuanAo] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QL_ShopQuanAo]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 16/08/2020 1:32:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[maHD] [nchar](10) NOT NULL,
	[maMH] [nchar](10) NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [float] NULL,
	[ThanhTien] [float] NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[maHD] ASC,
	[maMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietPhieuNhapHang]    Script Date: 16/08/2020 1:32:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhapHang](
	[maPN] [nchar](10) NOT NULL,
	[maMH] [nchar](10) NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [float] NULL,
 CONSTRAINT [PK_ChiTietPhieuNhapHang] PRIMARY KEY CLUSTERED 
(
	[maPN] ASC,
	[maMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HangHoa]    Script Date: 16/08/2020 1:32:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HangHoa](
	[maMH] [nchar](10) NOT NULL,
	[tenMH] [nvarchar](50) NULL,
	[DonGia] [float] NULL,
	[maLoaiHH] [nchar](10) NULL,
	[SoLuongTon] [int] NULL,
	[maNCC] [nchar](10) NULL,
 CONSTRAINT [PK_HangHoa] PRIMARY KEY CLUSTERED 
(
	[maMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 16/08/2020 1:32:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[maHD] [nchar](10) NOT NULL,
	[NgayLapHD] [date] NULL,
	[TongTien] [float] NULL,
	[maNV] [nchar](10) NULL,
	[maThe] [nchar](10) NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[maHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 16/08/2020 1:32:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[maThe] [nchar](10) NOT NULL,
	[tenKH] [nvarchar](30) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[DienThoai] [nchar](10) NULL,
	[DiemTL] [int] NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[maThe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiHangHoa]    Script Date: 16/08/2020 1:32:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiHangHoa](
	[maLoaiHH] [nchar](10) NOT NULL,
	[tenLoaiHH] [nvarchar](40) NULL,
 CONSTRAINT [PK_LoaiHangHoa] PRIMARY KEY CLUSTERED 
(
	[maLoaiHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 16/08/2020 1:32:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[maNCC] [nchar](10) NOT NULL,
	[tenNCC] [nvarchar](30) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[DienThoai] [nchar](12) NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[maNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 16/08/2020 1:32:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[maNV] [nchar](10) NOT NULL,
	[tenNV] [nvarchar](30) NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](50) NULL,
	[DienThoai] [nchar](10) NULL,
	[TenTK] [varchar](15) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[maNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhieuNhapHang]    Script Date: 16/08/2020 1:32:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhapHang](
	[maPN] [nchar](10) NOT NULL,
	[NgayNhap] [date] NULL,
	[maNV] [nchar](10) NULL,
 CONSTRAINT [PK_PhieuNhapHang] PRIMARY KEY CLUSTERED 
(
	[maPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 16/08/2020 1:32:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TenTK] [varchar](15) NOT NULL,
	[MatKhau] [varchar](15) NULL,
	[Quyen] [varchar](10) NULL,
	[maNV] [nchar](10) NULL,
	[HoatDong] [bit] NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[TenTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[ChiTietHoaDon] ([maHD], [maMH], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD00001   ', N'MHH001    ', 2, 300000, 600000)
INSERT [dbo].[ChiTietHoaDon] ([maHD], [maMH], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD00001   ', N'MHH002    ', 2, 350000, 700000)
INSERT [dbo].[ChiTietPhieuNhapHang] ([maPN], [maMH], [SoLuong], [DonGia]) VALUES (N'PN001     ', N'MHH001    ', 100, 300000)
INSERT [dbo].[ChiTietPhieuNhapHang] ([maPN], [maMH], [SoLuong], [DonGia]) VALUES (N'PN001     ', N'MHH006    ', 50, 400000)
INSERT [dbo].[ChiTietPhieuNhapHang] ([maPN], [maMH], [SoLuong], [DonGia]) VALUES (N'PN002     ', N'MHH002    ', 100, 350000)
INSERT [dbo].[ChiTietPhieuNhapHang] ([maPN], [maMH], [SoLuong], [DonGia]) VALUES (N'PN003     ', N'MHH006    ', 50, 400000)
INSERT [dbo].[ChiTietPhieuNhapHang] ([maPN], [maMH], [SoLuong], [DonGia]) VALUES (N'PN004     ', N'MHH007    ', 100, 150000)
INSERT [dbo].[ChiTietPhieuNhapHang] ([maPN], [maMH], [SoLuong], [DonGia]) VALUES (N'PN005     ', N'MHH005    ', 100, 300000)
INSERT [dbo].[ChiTietPhieuNhapHang] ([maPN], [maMH], [SoLuong], [DonGia]) VALUES (N'PN007     ', N'MHH001    ', 10, 300000)
INSERT [dbo].[ChiTietPhieuNhapHang] ([maPN], [maMH], [SoLuong], [DonGia]) VALUES (N'PN007     ', N'MHH003    ', 10, 400000)
INSERT [dbo].[ChiTietPhieuNhapHang] ([maPN], [maMH], [SoLuong], [DonGia]) VALUES (N'PN008     ', N'MHH003    ', 90, 400000)
INSERT [dbo].[ChiTietPhieuNhapHang] ([maPN], [maMH], [SoLuong], [DonGia]) VALUES (N'PN008     ', N'MHH004    ', 50, 500000)
INSERT [dbo].[HangHoa] ([maMH], [tenMH], [DonGia], [maLoaiHH], [SoLuongTon], [maNCC]) VALUES (N'MHH001    ', N'Quần tây cụt 1 chân 1', 300000, N'MH001     ', 105, N'NCC001    ')
INSERT [dbo].[HangHoa] ([maMH], [tenMH], [DonGia], [maLoaiHH], [SoLuongTon], [maNCC]) VALUES (N'MHH002    ', N'Quần tây cụt 1 chân ', 350000, N'MH001     ', 94, N'NCC001    ')
INSERT [dbo].[HangHoa] ([maMH], [tenMH], [DonGia], [maLoaiHH], [SoLuongTon], [maNCC]) VALUES (N'MHH003    ', N'Quần Jean ống so le', 400000, N'MH001     ', 100, N'NCC001    ')
INSERT [dbo].[HangHoa] ([maMH], [tenMH], [DonGia], [maLoaiHH], [SoLuongTon], [maNCC]) VALUES (N'MHH004    ', N'Quần Jean ống sole', 500000, N'MH001     ', 50, N'NCC001    ')
INSERT [dbo].[HangHoa] ([maMH], [tenMH], [DonGia], [maLoaiHH], [SoLuongTon], [maNCC]) VALUES (N'MHH005    ', N'Quần Short ống dài ống ngắn', 300000, N'MH001     ', 100, N'NCC002    ')
INSERT [dbo].[HangHoa] ([maMH], [tenMH], [DonGia], [maLoaiHH], [SoLuongTon], [maNCC]) VALUES (N'MHH006    ', N'Quần Short cụt 1 ống', 400000, N'MH001     ', 100, N'NCC002    ')
INSERT [dbo].[HangHoa] ([maMH], [tenMH], [DonGia], [maLoaiHH], [SoLuongTon], [maNCC]) VALUES (N'MHH007    ', N'Quần Short rách 2 chân', 150000, N'MH001     ', 100, N'NCC001    ')
INSERT [dbo].[HoaDon] ([maHD], [NgayLapHD], [TongTien], [maNV], [maThe]) VALUES (N'HD00001   ', CAST(0x74410B00 AS Date), 650000, N'NV001     ', NULL)
INSERT [dbo].[KhachHang] ([maThe], [tenKH], [DiaChi], [DienThoai], [DiemTL]) VALUES (N'KH0001    ', N'Nguyễn Tấn Sỹ', N'456 Lê Trọng Tấn , Quận 1, Thành phố Hồ Chí Minh', N'0765422998', 0)
INSERT [dbo].[KhachHang] ([maThe], [tenKH], [DiaChi], [DienThoai], [DiemTL]) VALUES (N'KH0002    ', N'Nguyễn Bảo Sang', N'305 Hậu Giang, Quận 3, Thành phố Hồ Chí Minh', N'0764277662', 90)
INSERT [dbo].[KhachHang] ([maThe], [tenKH], [DiaChi], [DienThoai], [DiemTL]) VALUES (N'KH0003    ', N'Huỳnh Ngọc Trí', N'713 Lũy Bán Bích, Quận 6, Thành phố Hồ Chí Minh', N'0764236699', 40)
INSERT [dbo].[KhachHang] ([maThe], [tenKH], [DiaChi], [DienThoai], [DiemTL]) VALUES (N'KH0004    ', N'Trần Xuân Lực', N'481 Nguyễn Thị Minh Khai, Thành phố Hồ Chí Minh', N'0754975561', 20)
INSERT [dbo].[KhachHang] ([maThe], [tenKH], [DiaChi], [DienThoai], [DiemTL]) VALUES (N'KH0005    ', N'Nguyễn Thị Nhựt Quỳnh', N'444 Tấn Long, Quận 1, Thành phố Hồ Chí Minh', N'0456782156', 80)
INSERT [dbo].[KhachHang] ([maThe], [tenKH], [DiaChi], [DienThoai], [DiemTL]) VALUES (N'KH0006    ', N'Nguyễn Hữu Trọng', N'315 Tân Sơn Nhì, Quận 1, Thành phố Hồ Chí Minh', N'0678154658', 50)
INSERT [dbo].[LoaiHangHoa] ([maLoaiHH], [tenLoaiHH]) VALUES (N'MH001     ', N'Quần')
INSERT [dbo].[LoaiHangHoa] ([maLoaiHH], [tenLoaiHH]) VALUES (N'MH002     ', N'Áo')
INSERT [dbo].[LoaiHangHoa] ([maLoaiHH], [tenLoaiHH]) VALUES (N'MH003     ', N'Giày ')
INSERT [dbo].[LoaiHangHoa] ([maLoaiHH], [tenLoaiHH]) VALUES (N'MH004     ', N'Mũ')
INSERT [dbo].[NhaCungCap] ([maNCC], [tenNCC], [DiaChi], [DienThoai]) VALUES (N'NCC001    ', N'Louis Vuitton', N'Opera View Building, 161 Đồng Khởi, Street,, Street, Quận 1, Thành phố Hồ Chí Minh', N'02838276318 ')
INSERT [dbo].[NhaCungCap] ([maNCC], [tenNCC], [DiaChi], [DienThoai]) VALUES (N'NCC002    ', N'Gucci', N'245 Lê Trọng Tấn, Quận 3, Thành phố Hồ Chí Minh', N'02838234566 ')
INSERT [dbo].[NhaCungCap] ([maNCC], [tenNCC], [DiaChi], [DienThoai]) VALUES (N'NCC003    ', N'Chanel', N'123 Hậu Giang, Quận 4, Thành phố Hồ Chí Minh', N'02838785318 ')
INSERT [dbo].[NhaCungCap] ([maNCC], [tenNCC], [DiaChi], [DienThoai]) VALUES (N'NCC004    ', N'Dior', N'455 Nguyễn Hữu Thọ, Quận 5, Thành phố Hồ Chí Minh', N'02838753317 ')
INSERT [dbo].[NhaCungCap] ([maNCC], [tenNCC], [DiaChi], [DienThoai]) VALUES (N'NCC005    ', N'Hermes', N'135 Nguyễn Thị Minh Khai, Quận 6, Thành phố Hồ Chí Minh', N'02812376319 ')
INSERT [dbo].[NhaCungCap] ([maNCC], [tenNCC], [DiaChi], [DienThoai]) VALUES (N'NCC006    ', N'Balenciaga', N'483 Phạm Đình Hổ, Quận 8, Thành phố Hồ Chí Minh', N'07838456318 ')
INSERT [dbo].[NhaCungCap] ([maNCC], [tenNCC], [DiaChi], [DienThoai]) VALUES (N'NCC007    ', N'Fendi', N'751 Lũy Bán Bích, Quận 4, Thành phố Hồ Chí Minh', N'02128276315 ')
INSERT [dbo].[NhaCungCap] ([maNCC], [tenNCC], [DiaChi], [DienThoai]) VALUES (N'NCC008    ', N'Prada', N'491 Tân Sơn Nhì, Quận 6, Thành phố Hồ Chí Minh', N'01214576318 ')
INSERT [dbo].[NhaCungCap] ([maNCC], [tenNCC], [DiaChi], [DienThoai]) VALUES (N'NCC009    ', N'Burberry', N'154 Bến Lức, Quận 1, Thành phố Hồ Chí Minh', N'02838245666 ')
INSERT [dbo].[NhanVien] ([maNV], [tenNV], [NgaySinh], [DiaChi], [DienThoai], [TenTK]) VALUES (N'NV001     ', N'Nguyễn Hữu Trí', CAST(0x9A220B00 AS Date), N'123 Hậu Giang', N'0765412391', N'TK001')
INSERT [dbo].[NhanVien] ([maNV], [tenNV], [NgaySinh], [DiaChi], [DienThoai], [TenTK]) VALUES (N'NV002     ', N'Huỳnh Tấn Lực', CAST(0xBA220B00 AS Date), N'147 Lê Trọng Tấn', N'0754236875', N'TK002')
INSERT [dbo].[NhanVien] ([maNV], [tenNV], [NgaySinh], [DiaChi], [DienThoai], [TenTK]) VALUES (N'NV003     ', N'Nguyễn Bảo Sỹ', CAST(0xD7220B00 AS Date), N'344 Tấn Long', N'0784521542', N'TK003')
INSERT [dbo].[NhanVien] ([maNV], [tenNV], [NgaySinh], [DiaChi], [DienThoai], [TenTK]) VALUES (N'NV004     ', N'Huỳnh Xuân Trọng', CAST(0xF7220B00 AS Date), N'711 Nguyễn Thị Minh Khai', N'0784216543', N'TK004')
INSERT [dbo].[NhanVien] ([maNV], [tenNV], [NgaySinh], [DiaChi], [DienThoai], [TenTK]) VALUES (N'NV005     ', N'Trần Ngọc Sang', CAST(0x16230B00 AS Date), N'481 Phạm Đình Hổ', N'0764277552', N'TK005')
INSERT [dbo].[PhieuNhapHang] ([maPN], [NgayNhap], [maNV]) VALUES (N'PN001     ', CAST(0x0D410B00 AS Date), N'NV001     ')
INSERT [dbo].[PhieuNhapHang] ([maPN], [NgayNhap], [maNV]) VALUES (N'PN002     ', CAST(0x0E410B00 AS Date), N'NV001     ')
INSERT [dbo].[PhieuNhapHang] ([maPN], [NgayNhap], [maNV]) VALUES (N'PN003     ', CAST(0x0F410B00 AS Date), N'NV001     ')
INSERT [dbo].[PhieuNhapHang] ([maPN], [NgayNhap], [maNV]) VALUES (N'PN004     ', CAST(0x10410B00 AS Date), N'NV001     ')
INSERT [dbo].[PhieuNhapHang] ([maPN], [NgayNhap], [maNV]) VALUES (N'PN005     ', CAST(0x11410B00 AS Date), N'NV001     ')
INSERT [dbo].[PhieuNhapHang] ([maPN], [NgayNhap], [maNV]) VALUES (N'PN006     ', CAST(0x12410B00 AS Date), N'NV001     ')
INSERT [dbo].[PhieuNhapHang] ([maPN], [NgayNhap], [maNV]) VALUES (N'PN007     ', CAST(0x74410B00 AS Date), N'NV001     ')
INSERT [dbo].[PhieuNhapHang] ([maPN], [NgayNhap], [maNV]) VALUES (N'PN008     ', CAST(0x74410B00 AS Date), N'NV001     ')
INSERT [dbo].[PhieuNhapHang] ([maPN], [NgayNhap], [maNV]) VALUES (N'PN009     ', CAST(0x74410B00 AS Date), N'NV001     ')
INSERT [dbo].[TaiKhoan] ([TenTK], [MatKhau], [Quyen], [maNV], [HoatDong]) VALUES (N'TK001', N'TK001', N'Admin', N'NV001     ', 1)
INSERT [dbo].[TaiKhoan] ([TenTK], [MatKhau], [Quyen], [maNV], [HoatDong]) VALUES (N'TK002', N'TK002', N'Admin', N'NV002     ', 1)
INSERT [dbo].[TaiKhoan] ([TenTK], [MatKhau], [Quyen], [maNV], [HoatDong]) VALUES (N'TK003', N'TK003', N'User', N'NV003     ', 0)
INSERT [dbo].[TaiKhoan] ([TenTK], [MatKhau], [Quyen], [maNV], [HoatDong]) VALUES (N'TK004', N'TK004', N'User', N'NV004     ', 1)
INSERT [dbo].[TaiKhoan] ([TenTK], [MatKhau], [Quyen], [maNV], [HoatDong]) VALUES (N'TK005', N'TK005', N'User', N'NV005     ', 1)
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HangHoa] FOREIGN KEY([maMH])
REFERENCES [dbo].[HangHoa] ([maMH])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HangHoa]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([maHD])
REFERENCES [dbo].[HoaDon] ([maHD])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhapHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhapHang_HangHoa] FOREIGN KEY([maMH])
REFERENCES [dbo].[HangHoa] ([maMH])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhapHang] CHECK CONSTRAINT [FK_ChiTietPhieuNhapHang_HangHoa]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhapHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhapHang_PhieuNhapHang] FOREIGN KEY([maPN])
REFERENCES [dbo].[PhieuNhapHang] ([maPN])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhapHang] CHECK CONSTRAINT [FK_ChiTietPhieuNhapHang_PhieuNhapHang]
GO
ALTER TABLE [dbo].[HangHoa]  WITH CHECK ADD  CONSTRAINT [FK_HangHoa_LoaiHangHoa] FOREIGN KEY([maLoaiHH])
REFERENCES [dbo].[LoaiHangHoa] ([maLoaiHH])
GO
ALTER TABLE [dbo].[HangHoa] CHECK CONSTRAINT [FK_HangHoa_LoaiHangHoa]
GO
ALTER TABLE [dbo].[HangHoa]  WITH CHECK ADD  CONSTRAINT [FK_HangHoa_NhaCungCap] FOREIGN KEY([maNCC])
REFERENCES [dbo].[NhaCungCap] ([maNCC])
GO
ALTER TABLE [dbo].[HangHoa] CHECK CONSTRAINT [FK_HangHoa_NhaCungCap]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([maThe])
REFERENCES [dbo].[KhachHang] ([maThe])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([maNV])
REFERENCES [dbo].[NhanVien] ([maNV])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_TaiKhoan] FOREIGN KEY([TenTK])
REFERENCES [dbo].[TaiKhoan] ([TenTK])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_TaiKhoan]
GO
ALTER TABLE [dbo].[PhieuNhapHang]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhapHang_NhanVien] FOREIGN KEY([maNV])
REFERENCES [dbo].[NhanVien] ([maNV])
GO
ALTER TABLE [dbo].[PhieuNhapHang] CHECK CONSTRAINT [FK_PhieuNhapHang_NhanVien]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_NhanVien] FOREIGN KEY([maNV])
REFERENCES [dbo].[NhanVien] ([maNV])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_NhanVien]
GO
USE [master]
GO
ALTER DATABASE [QL_ShopQuanAo] SET  READ_WRITE 
GO
