USE [master]
GO
/****** Object:  Database [M_ATM]    Script Date: 08-Jun-18 12:12:35 AM ******/
CREATE DATABASE [M_ATM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'M_ATM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\M_ATM.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'M_ATM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\M_ATM_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [M_ATM] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [M_ATM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [M_ATM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [M_ATM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [M_ATM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [M_ATM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [M_ATM] SET ARITHABORT OFF 
GO
ALTER DATABASE [M_ATM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [M_ATM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [M_ATM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [M_ATM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [M_ATM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [M_ATM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [M_ATM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [M_ATM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [M_ATM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [M_ATM] SET  ENABLE_BROKER 
GO
ALTER DATABASE [M_ATM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [M_ATM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [M_ATM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [M_ATM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [M_ATM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [M_ATM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [M_ATM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [M_ATM] SET RECOVERY FULL 
GO
ALTER DATABASE [M_ATM] SET  MULTI_USER 
GO
ALTER DATABASE [M_ATM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [M_ATM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [M_ATM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [M_ATM] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [M_ATM] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'M_ATM', N'ON'
GO
ALTER DATABASE [M_ATM] SET QUERY_STORE = OFF
GO
USE [M_ATM]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [M_ATM]
GO
/****** Object:  UserDefinedFunction [dbo].[FN_GetLog]    Script Date: 08-Jun-18 12:12:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create function [dbo].[FN_GetLog]()
returns varchar(10)
as
begin
	declare @Idx int
	declare @MaLog varchar(50) = 'BG001'
	set @Idx = 1;

	while(exists(select * from GhiGiaoDich where MaBanghiLog = @MaLog))
	begin
		set @Idx = @Idx + 1
		set @MaLog = 'BG'+REPLICATE('0', 3-LEN(cast(@Idx as varchar))) + CAST(@Idx as varchar)
	end
	return @MaLog
end
GO
/****** Object:  Table [dbo].[ATM]    Script Date: 08-Jun-18 12:12:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ATM](
	[MaATM] [nvarchar](20) NOT NULL,
	[TenChiNhanh] [nvarchar](30) NOT NULL,
	[ViTriATM] [nvarchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaATM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Config]    Script Date: 08-Jun-18 12:12:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Config](
	[MaConfig] [nvarchar](20) NOT NULL,
	[ngaycapnhap] [datetime] NULL,
	[SoTienRutToiThieu] [money] NULL,
	[SoTienRutTrongNgay] [money] NULL,
	[SoBanghi] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaConfig] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhsachKhachHang]    Script Date: 08-Jun-18 12:12:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhsachKhachHang](
	[Makhachhang] [nvarchar](25) NOT NULL,
	[Tenkhachhang] [nvarchar](30) NOT NULL,
	[Sodienthoai] [int] NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[DiaChi] [nvarchar](60) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Makhachhang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Danhsachtaikhoan]    Script Date: 08-Jun-18 12:12:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Danhsachtaikhoan](
	[Mataikhoan] [nvarchar](20) NOT NULL,
	[Makhachhang] [nvarchar](25) NOT NULL,
	[MaMucThauChi] [nvarchar](25) NOT NULL,
	[MaGioiHanRut] [nvarchar](25) NOT NULL,
	[SoTienConLaiTrongTK] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[Mataikhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhsachtheATM]    Script Date: 08-Jun-18 12:12:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhsachtheATM](
	[SoTheATM] [nvarchar](15) NOT NULL,
	[MaPin] [int] NOT NULL,
	[TrangThaiThe] [nvarchar](30) NOT NULL,
	[Mataikhoan] [nvarchar](20) NOT NULL,
	[NgayCapThe] [datetime] NULL,
	[NgayHetHan] [datetime] NULL,
	[SoLanNhapPin] [int] NOT NULL,
 CONSTRAINT [PK__Danhsach__D60A1B612C359EFF] PRIMARY KEY CLUSTERED 
(
	[SoTheATM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GhiGiaoDich]    Script Date: 08-Jun-18 12:12:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GhiGiaoDich](
	[MaBanghiLog] [nvarchar](25) NOT NULL,
	[Ngaygiaodich] [datetime] NULL,
	[KhoanTienGD] [int] NULL,
	[MoTaGD] [nvarchar](35) NOT NULL,
	[SotheATMnhanTien] [nvarchar](15) NULL,
	[SoTheATM] [nvarchar](15) NOT NULL,
	[Malog] [nvarchar](20) NOT NULL,
	[MaATM] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK__GhiGiaoD__E87CF4DFE84F7467] PRIMARY KEY CLUSTERED 
(
	[MaBanghiLog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiLog]    Script Date: 08-Jun-18 12:12:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiLog](
	[Malog] [nvarchar](20) NOT NULL,
	[TenLog] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Malog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiTien]    Script Date: 08-Jun-18 12:12:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiTien](
	[MaTien] [nvarchar](20) NOT NULL,
	[GiaTriTien] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiTienTrongATM]    Script Date: 08-Jun-18 12:12:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiTienTrongATM](
	[MacuabanghiStock] [nvarchar](25) NOT NULL,
	[SoLuongMoiLoaiTien] [int] NOT NULL,
	[MaATM] [nvarchar](20) NOT NULL,
	[MaTien] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MacuabanghiStock] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SoTienMaMotTaiKhoanCoTheChi]    Script Date: 08-Jun-18 12:12:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SoTienMaMotTaiKhoanCoTheChi](
	[MaMucThauChi] [nvarchar](25) NOT NULL,
	[SoTienMaMotTaiKhoanThauChi] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaMucThauChi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SoTienToiDaTKrutTrongNgay]    Script Date: 08-Jun-18 12:12:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SoTienToiDaTKrutTrongNgay](
	[MaGioiHanRut] [nvarchar](25) NOT NULL,
	[SoTienToiDa] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaGioiHanRut] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ATM] ([MaATM], [TenChiNhanh], [ViTriATM]) VALUES (N'ATM000001', N'Bắc Từ Liêm - Hà Nội', N'298 đường 32, Bắc Từ Liêm, Hà Nội')
INSERT [dbo].[Config] ([MaConfig], [ngaycapnhap], [SoTienRutToiThieu], [SoTienRutTrongNgay], [SoBanghi]) VALUES (N'A1', CAST(N'1900-01-01T00:00:00.000' AS DateTime), 50000.0000, 30000000.0000, 3)
INSERT [dbo].[DanhsachKhachHang] ([Makhachhang], [Tenkhachhang], [Sodienthoai], [Email], [DiaChi]) VALUES (N'KH00000001', N'Nguyen Van A', 977206532, N'nguyenvan@gmail.com', N'Hà Nội')
INSERT [dbo].[DanhsachKhachHang] ([Makhachhang], [Tenkhachhang], [Sodienthoai], [Email], [DiaChi]) VALUES (N'KH00000002', N'Triệu Thị B', 1666476533, N'trieuthib@gmail.com', N'Bắc Ninh')
INSERT [dbo].[Danhsachtaikhoan] ([Mataikhoan], [Makhachhang], [MaMucThauChi], [MaGioiHanRut], [SoTienConLaiTrongTK]) VALUES (N'TK000000001', N'KH00000001', N'TH001', N'GH001', 4499300.0000)
INSERT [dbo].[Danhsachtaikhoan] ([Mataikhoan], [Makhachhang], [MaMucThauChi], [MaGioiHanRut], [SoTienConLaiTrongTK]) VALUES (N'TK000000002', N'KH00000001', N'TH001', N'GH001', 1530000.0000)
INSERT [dbo].[Danhsachtaikhoan] ([Mataikhoan], [Makhachhang], [MaMucThauChi], [MaGioiHanRut], [SoTienConLaiTrongTK]) VALUES (N'TK000000003', N'KH00000002', N'TH001', N'GH001', 5000000.0000)
INSERT [dbo].[DanhsachtheATM] ([SoTheATM], [MaPin], [TrangThaiThe], [Mataikhoan], [NgayCapThe], [NgayHetHan], [SoLanNhapPin]) VALUES (N'970405076132', 1234, N'kich hoat', N'TK000000001', CAST(N'2013-03-25T00:00:00.000' AS DateTime), CAST(N'2019-04-20T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[DanhsachtheATM] ([SoTheATM], [MaPin], [TrangThaiThe], [Mataikhoan], [NgayCapThe], [NgayHetHan], [SoLanNhapPin]) VALUES (N'970405126355', 1234, N'kich hoat', N'TK000000002', CAST(N'2015-05-05T00:00:00.000' AS DateTime), CAST(N'2021-02-03T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[DanhsachtheATM] ([SoTheATM], [MaPin], [TrangThaiThe], [Mataikhoan], [NgayCapThe], [NgayHetHan], [SoLanNhapPin]) VALUES (N'970405127644', 1234, N'kich hoat', N'TK000000001', CAST(N'2014-10-05T00:00:00.000' AS DateTime), CAST(N'2020-10-04T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[DanhsachtheATM] ([SoTheATM], [MaPin], [TrangThaiThe], [Mataikhoan], [NgayCapThe], [NgayHetHan], [SoLanNhapPin]) VALUES (N'970405136463', 1234, N'kich hoat', N'TK000000003', CAST(N'2016-07-03T00:00:00.000' AS DateTime), CAST(N'2022-07-05T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[GhiGiaoDich] ([MaBanghiLog], [Ngaygiaodich], [KhoanTienGD], [MoTaGD], [SotheATMnhanTien], [SoTheATM], [Malog], [MaATM]) VALUES (N'BG001', CAST(N'2018-01-23T00:00:00.000' AS DateTime), 1000000, N'Rút tiền', NULL, N'970405076132', N'log01', N'ATM000001')
INSERT [dbo].[GhiGiaoDich] ([MaBanghiLog], [Ngaygiaodich], [KhoanTienGD], [MoTaGD], [SotheATMnhanTien], [SoTheATM], [Malog], [MaATM]) VALUES (N'BG002', CAST(N'2018-02-15T00:00:00.000' AS DateTime), 3500000, N'Chuyển khoản', N'970405127644', N'970405076132', N'Log02', N'ATM000001')
INSERT [dbo].[GhiGiaoDich] ([MaBanghiLog], [Ngaygiaodich], [KhoanTienGD], [MoTaGD], [SotheATMnhanTien], [SoTheATM], [Malog], [MaATM]) VALUES (N'BG003', CAST(N'2018-06-07T21:44:27.253' AS DateTime), 2000000, N'Rút ti?n', N'', N'970405127644', N'Log01', N'ATM000001')
INSERT [dbo].[GhiGiaoDich] ([MaBanghiLog], [Ngaygiaodich], [KhoanTienGD], [MoTaGD], [SotheATMnhanTien], [SoTheATM], [Malog], [MaATM]) VALUES (N'BG004', CAST(N'2018-06-07T22:36:23.030' AS DateTime), 0, N'Vấn tin tài khoản', N'', N'970405076132', N'Log03', N'ATM000001')
INSERT [dbo].[GhiGiaoDich] ([MaBanghiLog], [Ngaygiaodich], [KhoanTienGD], [MoTaGD], [SotheATMnhanTien], [SoTheATM], [Malog], [MaATM]) VALUES (N'BG005', CAST(N'2018-06-07T22:36:30.150' AS DateTime), 0, N'Xem lịch sử giao dịch', N'', N'970405076132', N'Log06', N'ATM000001')
INSERT [dbo].[GhiGiaoDich] ([MaBanghiLog], [Ngaygiaodich], [KhoanTienGD], [MoTaGD], [SotheATMnhanTien], [SoTheATM], [Malog], [MaATM]) VALUES (N'BG006', CAST(N'2018-06-07T22:37:57.463' AS DateTime), 0, N'Xem lịch sử giao dịch', N'', N'970405076132', N'Log06', N'ATM000001')
INSERT [dbo].[GhiGiaoDich] ([MaBanghiLog], [Ngaygiaodich], [KhoanTienGD], [MoTaGD], [SotheATMnhanTien], [SoTheATM], [Malog], [MaATM]) VALUES (N'BG007', CAST(N'2018-06-07T22:39:54.847' AS DateTime), 0, N'Xem lịch sử giao dịch', N'', N'970405076132', N'Log06', N'ATM000001')
INSERT [dbo].[GhiGiaoDich] ([MaBanghiLog], [Ngaygiaodich], [KhoanTienGD], [MoTaGD], [SotheATMnhanTien], [SoTheATM], [Malog], [MaATM]) VALUES (N'BG008', CAST(N'2018-06-07T22:41:24.990' AS DateTime), 0, N'Xem lịch sử giao dịch', N'', N'970405076132', N'Log06', N'ATM000001')
INSERT [dbo].[GhiGiaoDich] ([MaBanghiLog], [Ngaygiaodich], [KhoanTienGD], [MoTaGD], [SotheATMnhanTien], [SoTheATM], [Malog], [MaATM]) VALUES (N'BG009', CAST(N'2018-06-07T22:42:22.710' AS DateTime), 0, N'Xem lịch sử giao dịch', N'', N'970405076132', N'Log06', N'ATM000001')
INSERT [dbo].[GhiGiaoDich] ([MaBanghiLog], [Ngaygiaodich], [KhoanTienGD], [MoTaGD], [SotheATMnhanTien], [SoTheATM], [Malog], [MaATM]) VALUES (N'BG010', CAST(N'2018-06-07T22:45:00.180' AS DateTime), 1000000, N'Rút tiền', N'', N'970405076132', N'Log01', N'ATM000001')
INSERT [dbo].[GhiGiaoDich] ([MaBanghiLog], [Ngaygiaodich], [KhoanTienGD], [MoTaGD], [SotheATMnhanTien], [SoTheATM], [Malog], [MaATM]) VALUES (N'BG011', CAST(N'2018-06-07T22:45:05.850' AS DateTime), 0, N'Xem lịch sử giao dịch', N'', N'970405076132', N'Log06', N'ATM000001')
INSERT [dbo].[GhiGiaoDich] ([MaBanghiLog], [Ngaygiaodich], [KhoanTienGD], [MoTaGD], [SotheATMnhanTien], [SoTheATM], [Malog], [MaATM]) VALUES (N'BG012', CAST(N'2018-06-07T22:45:40.017' AS DateTime), 0, N'Vấn tin tài khoản', N'', N'970405076132', N'Log03', N'ATM000001')
INSERT [dbo].[GhiGiaoDich] ([MaBanghiLog], [Ngaygiaodich], [KhoanTienGD], [MoTaGD], [SotheATMnhanTien], [SoTheATM], [Malog], [MaATM]) VALUES (N'BG013', CAST(N'2018-06-07T22:45:51.740' AS DateTime), 1500000, N'Rút tiền', N'', N'970405076132', N'Log01', N'ATM000001')
INSERT [dbo].[GhiGiaoDich] ([MaBanghiLog], [Ngaygiaodich], [KhoanTienGD], [MoTaGD], [SotheATMnhanTien], [SoTheATM], [Malog], [MaATM]) VALUES (N'BG014', CAST(N'2018-06-07T22:47:12.420' AS DateTime), 1500000, N'Rút tiền', N'', N'970405076132', N'Log01', N'ATM000001')
INSERT [dbo].[GhiGiaoDich] ([MaBanghiLog], [Ngaygiaodich], [KhoanTienGD], [MoTaGD], [SotheATMnhanTien], [SoTheATM], [Malog], [MaATM]) VALUES (N'BG015', CAST(N'2018-06-07T22:53:19.243' AS DateTime), 0, N'Vấn tin tài khoản', N'', N'970405076132', N'Log03', N'ATM000001')
INSERT [dbo].[GhiGiaoDich] ([MaBanghiLog], [Ngaygiaodich], [KhoanTienGD], [MoTaGD], [SotheATMnhanTien], [SoTheATM], [Malog], [MaATM]) VALUES (N'BG016', CAST(N'2018-06-07T23:00:37.607' AS DateTime), 0, N'Đổi mã pin', N'', N'970405076132', N'Log05', N'ATM000001')
INSERT [dbo].[GhiGiaoDich] ([MaBanghiLog], [Ngaygiaodich], [KhoanTienGD], [MoTaGD], [SotheATMnhanTien], [SoTheATM], [Malog], [MaATM]) VALUES (N'BG017', CAST(N'2018-06-07T23:02:40.507' AS DateTime), 0, N'Đổi mã pin', N'', N'970405076132', N'Log05', N'ATM000001')
INSERT [dbo].[GhiGiaoDich] ([MaBanghiLog], [Ngaygiaodich], [KhoanTienGD], [MoTaGD], [SotheATMnhanTien], [SoTheATM], [Malog], [MaATM]) VALUES (N'BG018', CAST(N'2018-06-07T23:33:54.167' AS DateTime), 500000, N'Chuyển khoản', N'970405076132', N'970405127644', N'Log02', N'ATM000001')
INSERT [dbo].[GhiGiaoDich] ([MaBanghiLog], [Ngaygiaodich], [KhoanTienGD], [MoTaGD], [SotheATMnhanTien], [SoTheATM], [Malog], [MaATM]) VALUES (N'BG019', CAST(N'2018-06-07T23:36:57.937' AS DateTime), 0, N'Vấn tin tài khoản', N'', N'970405076132', N'Log03', N'ATM000001')
INSERT [dbo].[GhiGiaoDich] ([MaBanghiLog], [Ngaygiaodich], [KhoanTienGD], [MoTaGD], [SotheATMnhanTien], [SoTheATM], [Malog], [MaATM]) VALUES (N'BG020', CAST(N'2018-06-08T00:05:35.307' AS DateTime), 500000, N'Rút tiền', N'', N'970405126355', N'Log01', N'ATM000001')
INSERT [dbo].[LoaiLog] ([Malog], [TenLog]) VALUES (N'Log01', N'Rút tiền')
INSERT [dbo].[LoaiLog] ([Malog], [TenLog]) VALUES (N'Log02', N'Chuyển khoản')
INSERT [dbo].[LoaiLog] ([Malog], [TenLog]) VALUES (N'Log03', N'Vấn tin tài khoản')
INSERT [dbo].[LoaiLog] ([Malog], [TenLog]) VALUES (N'Log04', N'Chuyển khoản')
INSERT [dbo].[LoaiLog] ([Malog], [TenLog]) VALUES (N'Log05', N'Đổi mã pin')
INSERT [dbo].[LoaiLog] ([Malog], [TenLog]) VALUES (N'Log06', N'Xem lịch sử giao dịch')
INSERT [dbo].[LoaiTien] ([MaTien], [GiaTriTien]) VALUES (N'B001', 1000)
INSERT [dbo].[LoaiTien] ([MaTien], [GiaTriTien]) VALUES (N'B002', 2000)
INSERT [dbo].[LoaiTien] ([MaTien], [GiaTriTien]) VALUES (N'B003', 5000)
INSERT [dbo].[LoaiTien] ([MaTien], [GiaTriTien]) VALUES (N'B004', 10000)
INSERT [dbo].[LoaiTien] ([MaTien], [GiaTriTien]) VALUES (N'B005', 20000)
INSERT [dbo].[LoaiTien] ([MaTien], [GiaTriTien]) VALUES (N'B006', 50000)
INSERT [dbo].[LoaiTien] ([MaTien], [GiaTriTien]) VALUES (N'B007', 100000)
INSERT [dbo].[LoaiTien] ([MaTien], [GiaTriTien]) VALUES (N'B008', 200000)
INSERT [dbo].[LoaiTien] ([MaTien], [GiaTriTien]) VALUES (N'B009', 500000)
INSERT [dbo].[LoaiTienTrongATM] ([MacuabanghiStock], [SoLuongMoiLoaiTien], [MaATM], [MaTien]) VALUES (N'BG01', 120, N'ATM000001', N'B001')
INSERT [dbo].[LoaiTienTrongATM] ([MacuabanghiStock], [SoLuongMoiLoaiTien], [MaATM], [MaTien]) VALUES (N'BG02', 120, N'ATM000001', N'B002')
INSERT [dbo].[LoaiTienTrongATM] ([MacuabanghiStock], [SoLuongMoiLoaiTien], [MaATM], [MaTien]) VALUES (N'BG03', 120, N'ATM000001', N'B003')
INSERT [dbo].[LoaiTienTrongATM] ([MacuabanghiStock], [SoLuongMoiLoaiTien], [MaATM], [MaTien]) VALUES (N'BG04', 50, N'ATM000001', N'B004')
INSERT [dbo].[LoaiTienTrongATM] ([MacuabanghiStock], [SoLuongMoiLoaiTien], [MaATM], [MaTien]) VALUES (N'BG05', 50, N'ATM000001', N'B005')
INSERT [dbo].[LoaiTienTrongATM] ([MacuabanghiStock], [SoLuongMoiLoaiTien], [MaATM], [MaTien]) VALUES (N'BG06', 200, N'ATM000001', N'B006')
INSERT [dbo].[LoaiTienTrongATM] ([MacuabanghiStock], [SoLuongMoiLoaiTien], [MaATM], [MaTien]) VALUES (N'BG07', 250, N'ATM000001', N'B007')
INSERT [dbo].[LoaiTienTrongATM] ([MacuabanghiStock], [SoLuongMoiLoaiTien], [MaATM], [MaTien]) VALUES (N'BG08', 250, N'ATM000001', N'B008')
INSERT [dbo].[LoaiTienTrongATM] ([MacuabanghiStock], [SoLuongMoiLoaiTien], [MaATM], [MaTien]) VALUES (N'BG09', 250, N'ATM000001', N'B009')
INSERT [dbo].[SoTienMaMotTaiKhoanCoTheChi] ([MaMucThauChi], [SoTienMaMotTaiKhoanThauChi]) VALUES (N'TH001', 50000000)
INSERT [dbo].[SoTienToiDaTKrutTrongNgay] ([MaGioiHanRut], [SoTienToiDa]) VALUES (N'GH001', 50000000)
ALTER TABLE [dbo].[DanhsachtheATM] ADD  CONSTRAINT [DF_DanhsachtheATM_SoLanNhapPin]  DEFAULT ((0)) FOR [SoLanNhapPin]
GO
ALTER TABLE [dbo].[GhiGiaoDich] ADD  CONSTRAINT [DF_GhiGiaoDich_Ngaygiaodich]  DEFAULT (getdate()) FOR [Ngaygiaodich]
GO
ALTER TABLE [dbo].[Danhsachtaikhoan]  WITH CHECK ADD  CONSTRAINT [fk_MaGioiHanRut] FOREIGN KEY([MaGioiHanRut])
REFERENCES [dbo].[SoTienToiDaTKrutTrongNgay] ([MaGioiHanRut])
GO
ALTER TABLE [dbo].[Danhsachtaikhoan] CHECK CONSTRAINT [fk_MaGioiHanRut]
GO
ALTER TABLE [dbo].[Danhsachtaikhoan]  WITH CHECK ADD  CONSTRAINT [fk_Makhachhang] FOREIGN KEY([Makhachhang])
REFERENCES [dbo].[DanhsachKhachHang] ([Makhachhang])
GO
ALTER TABLE [dbo].[Danhsachtaikhoan] CHECK CONSTRAINT [fk_Makhachhang]
GO
ALTER TABLE [dbo].[Danhsachtaikhoan]  WITH CHECK ADD  CONSTRAINT [fk_MaMucThauChi] FOREIGN KEY([MaMucThauChi])
REFERENCES [dbo].[SoTienMaMotTaiKhoanCoTheChi] ([MaMucThauChi])
GO
ALTER TABLE [dbo].[Danhsachtaikhoan] CHECK CONSTRAINT [fk_MaMucThauChi]
GO
ALTER TABLE [dbo].[DanhsachtheATM]  WITH CHECK ADD  CONSTRAINT [fk_Mataikhoan] FOREIGN KEY([Mataikhoan])
REFERENCES [dbo].[Danhsachtaikhoan] ([Mataikhoan])
GO
ALTER TABLE [dbo].[DanhsachtheATM] CHECK CONSTRAINT [fk_Mataikhoan]
GO
ALTER TABLE [dbo].[GhiGiaoDich]  WITH CHECK ADD  CONSTRAINT [fk_MaATM] FOREIGN KEY([MaATM])
REFERENCES [dbo].[ATM] ([MaATM])
GO
ALTER TABLE [dbo].[GhiGiaoDich] CHECK CONSTRAINT [fk_MaATM]
GO
ALTER TABLE [dbo].[GhiGiaoDich]  WITH CHECK ADD  CONSTRAINT [fk_Malog] FOREIGN KEY([Malog])
REFERENCES [dbo].[LoaiLog] ([Malog])
GO
ALTER TABLE [dbo].[GhiGiaoDich] CHECK CONSTRAINT [fk_Malog]
GO
ALTER TABLE [dbo].[GhiGiaoDich]  WITH CHECK ADD  CONSTRAINT [fk_SoTheATM] FOREIGN KEY([SoTheATM])
REFERENCES [dbo].[DanhsachtheATM] ([SoTheATM])
GO
ALTER TABLE [dbo].[GhiGiaoDich] CHECK CONSTRAINT [fk_SoTheATM]
GO
ALTER TABLE [dbo].[LoaiTienTrongATM]  WITH CHECK ADD  CONSTRAINT [fk_MaATM1] FOREIGN KEY([MaATM])
REFERENCES [dbo].[ATM] ([MaATM])
GO
ALTER TABLE [dbo].[LoaiTienTrongATM] CHECK CONSTRAINT [fk_MaATM1]
GO
ALTER TABLE [dbo].[LoaiTienTrongATM]  WITH CHECK ADD  CONSTRAINT [fk_MaTien] FOREIGN KEY([MaTien])
REFERENCES [dbo].[LoaiTien] ([MaTien])
GO
ALTER TABLE [dbo].[LoaiTienTrongATM] CHECK CONSTRAINT [fk_MaTien]
GO
/****** Object:  StoredProcedure [dbo].[sb_UpdateMoney]    Script Date: 08-Jun-18 12:12:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE proc [dbo].[sb_UpdateMoney] @maTaiKhoan nvarchar(15), @slTien float
  as
  begin
	update Danhsachtaikhoan set SoTienConLaiTrongTK = SoTienConLaiTrongTK - @slTien
	where Mataikhoan = @maTaiKhoan
  end
GO
/****** Object:  StoredProcedure [dbo].[sb_UpdateMoneyTranfer]    Script Date: 08-Jun-18 12:12:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[sb_UpdateMoneyTranfer]
  @maTaiKhoanNhan nvarchar(15), @maTaiKhoanChuyen nvarchar(15), @slTien float
  as
  begin
	update Danhsachtaikhoan set SoTienConLaiTrongTK = SoTienConLaiTrongTK + @slTien
	where Mataikhoan = @maTaiKhoanNhan
	update Danhsachtaikhoan set SoTienConLaiTrongTK = SoTienConLaiTrongTK - @slTien
	where Mataikhoan = @maTaiKhoanChuyen
  end
GO
USE [master]
GO
ALTER DATABASE [M_ATM] SET  READ_WRITE 
GO
