USE [master]
GO
/****** Object:  Database [ShopGiay]    Script Date: 11/10/2022 9:32:52 AM ******/
CREATE DATABASE [ShopGiay]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopGiay', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ShopGiay.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShopGiay_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ShopGiay_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ShopGiay] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopGiay].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopGiay] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopGiay] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopGiay] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopGiay] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopGiay] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopGiay] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ShopGiay] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopGiay] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopGiay] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopGiay] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopGiay] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopGiay] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopGiay] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopGiay] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopGiay] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ShopGiay] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopGiay] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopGiay] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopGiay] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopGiay] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopGiay] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShopGiay] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopGiay] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ShopGiay] SET  MULTI_USER 
GO
ALTER DATABASE [ShopGiay] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopGiay] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopGiay] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopGiay] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShopGiay] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ShopGiay] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ShopGiay] SET QUERY_STORE = OFF
GO
USE [ShopGiay]
GO
/****** Object:  Table [dbo].[admin]    Script Date: 11/10/2022 9:32:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin](
	[MaAdmin] [int] IDENTITY(1,1) NOT NULL,
	[HoTenAdmin] [nvarchar](50) NULL,
	[DiaChiAdmin] [nvarchar](50) NULL,
	[DienThoaiAdmin] [varchar](10) NULL,
	[TenDNAdmin] [varchar](15) NULL,
	[MatKhauAdmin] [varchar](15) NULL,
	[NgaySinhAdmin] [smalldatetime] NULL,
	[GioiTinhAdmin] [bit] NULL,
	[EmailAdmin] [varchar](50) NULL,
	[QuyenAdmin] [int] NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[MaAdmin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chude]    Script Date: 11/10/2022 9:32:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chude](
	[MaCD] [int] IDENTITY(1,1) NOT NULL,
	[TenChuDe] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ChuDe] PRIMARY KEY CLUSTERED 
(
	[MaCD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ctdathang]    Script Date: 11/10/2022 9:32:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ctdathang](
	[SoDH] [int] NOT NULL,
	[MaGiay] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [decimal](9, 2) NULL,
	[ThanhTien]  AS ([SoLuong]*[DonGia]),
 CONSTRAINT [PK_CTDatHang] PRIMARY KEY CLUSTERED 
(
	[SoDH] ASC,
	[MaGiay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ctthamdo]    Script Date: 11/10/2022 9:32:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ctthamdo](
	[MaCH] [int] NOT NULL,
	[STT] [int] NOT NULL,
	[NoiDungTraLoi] [nvarchar](255) NOT NULL,
	[SoLanBinhChon] [int] NULL,
 CONSTRAINT [PK_CTThamDo] PRIMARY KEY CLUSTERED 
(
	[MaCH] ASC,
	[STT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dondathang]    Script Date: 11/10/2022 9:32:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dondathang](
	[SoDH] [int] IDENTITY(1,1) NOT NULL,
	[MaKH] [int] NULL,
	[NgayDH] [smalldatetime] NULL,
	[TriGia] [money] NULL,
	[DaGiao] [bit] NULL,
	[NgayGiaoHang] [smalldatetime] NULL,
	[TenNguoiNhan] [varchar](50) NULL,
	[DiaChiNhan] [nvarchar](50) NULL,
	[DienThoaiNhan] [varchar](15) NULL,
	[HTThanhToan] [bit] NULL,
	[HTGiaoHang] [bit] NULL,
 CONSTRAINT [PK_DonDatHang] PRIMARY KEY CLUSTERED 
(
	[SoDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[giay]    Script Date: 11/10/2022 9:32:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[giay](
	[MaGiay] [int] IDENTITY(1,1) NOT NULL,
	[TenGiay] [nvarchar](100) NOT NULL,
	[DonViTinh] [nvarchar](50) NULL,
	[DonGia] [money] NULL,
	[MoTa] [ntext] NULL,
	[HinhMinhHoa] [varchar](50) NULL,
	[MaCD] [int] NULL,
	[MaNXB] [int] NULL,
	[NgayCapNhat] [smalldatetime] NULL,
	[SoLuongBan] [int] NULL,
	[SoLanXem] [int] NULL,
 CONSTRAINT [PK_Giay] PRIMARY KEY CLUSTERED 
(
	[MaGiay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[khachhang]    Script Date: 11/10/2022 9:32:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khachhang](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[HoTenKH] [nvarchar](50) NULL,
	[DiaChiKH] [nvarchar](50) NULL,
	[DienThoaiKH] [varchar](10) NULL,
	[TenDN] [varchar](15) NULL,
	[MatKhau] [varchar](15) NULL,
	[NgaySinh] [smalldatetime] NULL,
	[GioiTinh] [bit] NULL,
	[Email] [varchar](50) NULL,
	[DaDuyet] [bit] NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[menu]    Script Date: 11/10/2022 9:32:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[menu](
	[Id] [int] NOT NULL,
	[MenuName] [nvarchar](50) NULL,
	[MenuLink] [nvarchar](100) NULL,
	[ParentId] [int] NULL,
	[OrderNumber] [int] NULL,
 CONSTRAINT [PK_menu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nhaxuatban]    Script Date: 11/10/2022 9:32:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nhaxuatban](
	[MaNXB] [int] IDENTITY(1,1) NOT NULL,
	[TenNXB] [nvarchar](100) NOT NULL,
	[DiaChi] [nvarchar](150) NULL,
	[DienThoai] [nvarchar](15) NULL,
 CONSTRAINT [PK_NhaXuatBan] PRIMARY KEY CLUSTERED 
(
	[MaNXB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[quangcao]    Script Date: 11/10/2022 9:32:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[quangcao](
	[STT] [int] IDENTITY(1,1) NOT NULL,
	[TenCongTy] [nvarchar](200) NOT NULL,
	[HinhMinhHoa] [varchar](20) NULL,
	[Href] [varchar](100) NULL,
	[NgayBatDau] [smalldatetime] NULL,
	[NgayHetHan] [smalldatetime] NULL,
 CONSTRAINT [PK_QuangCao] PRIMARY KEY CLUSTERED 
(
	[STT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tacgia]    Script Date: 11/10/2022 9:32:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tacgia](
	[MaTG] [int] IDENTITY(1,1) NOT NULL,
	[TenTG] [nvarchar](50) NOT NULL,
	[DiaChiTG] [nvarchar](100) NULL,
	[DienThoaiTG] [varchar](15) NULL,
 CONSTRAINT [PK_TacGia] PRIMARY KEY CLUSTERED 
(
	[MaTG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[thamdo]    Script Date: 11/10/2022 9:32:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[thamdo](
	[MaCH] [int] IDENTITY(1,1) NOT NULL,
	[NgayDang] [smalldatetime] NULL,
	[NoiDungThamDo] [nvarchar](255) NOT NULL,
	[TongSoBinhChon] [int] NULL,
 CONSTRAINT [PK_ThamDo] PRIMARY KEY CLUSTERED 
(
	[MaCH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vietgiay]    Script Date: 11/10/2022 9:32:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vietgiay](
	[MaTG] [int] NOT NULL,
	[MaGiay] [int] NOT NULL,
	[VaiTro] [nvarchar](30) NULL,
 CONSTRAINT [PK_VietGiay] PRIMARY KEY CLUSTERED 
(
	[MaTG] ASC,
	[MaGiay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[admin] ADD  DEFAULT ((1)) FOR [GioiTinhAdmin]
GO
ALTER TABLE [dbo].[admin] ADD  DEFAULT ((1)) FOR [QuyenAdmin]
GO
ALTER TABLE [dbo].[ctthamdo] ADD  DEFAULT ((0)) FOR [SoLanBinhChon]
GO
ALTER TABLE [dbo].[dondathang] ADD  DEFAULT ((0)) FOR [DaGiao]
GO
ALTER TABLE [dbo].[dondathang] ADD  DEFAULT ((0)) FOR [HTThanhToan]
GO
ALTER TABLE [dbo].[dondathang] ADD  DEFAULT ((0)) FOR [HTGiaoHang]
GO
ALTER TABLE [dbo].[giay] ADD  DEFAULT ('cu?n') FOR [DonViTinh]
GO
ALTER TABLE [dbo].[giay] ADD  DEFAULT ((0)) FOR [SoLanXem]
GO
ALTER TABLE [dbo].[khachhang] ADD  DEFAULT ((1)) FOR [GioiTinh]
GO
ALTER TABLE [dbo].[khachhang] ADD  DEFAULT ((0)) FOR [DaDuyet]
GO
ALTER TABLE [dbo].[thamdo] ADD  DEFAULT ((0)) FOR [TongSoBinhChon]
GO
ALTER TABLE [dbo].[ctdathang]  WITH CHECK ADD  CONSTRAINT [FK_ctdathang_dondathang] FOREIGN KEY([SoDH])
REFERENCES [dbo].[dondathang] ([SoDH])
GO
ALTER TABLE [dbo].[ctdathang] CHECK CONSTRAINT [FK_ctdathang_dondathang]
GO
ALTER TABLE [dbo].[ctdathang]  WITH CHECK ADD  CONSTRAINT [FK_ctdathang_Giay] FOREIGN KEY([MaGiay])
REFERENCES [dbo].[giay] ([MaGiay])
GO
ALTER TABLE [dbo].[ctdathang] CHECK CONSTRAINT [FK_ctdathang_Giay]
GO
ALTER TABLE [dbo].[ctthamdo]  WITH CHECK ADD  CONSTRAINT [FK_ctthamdo_ThamDo] FOREIGN KEY([MaCH])
REFERENCES [dbo].[thamdo] ([MaCH])
GO
ALTER TABLE [dbo].[ctthamdo] CHECK CONSTRAINT [FK_ctthamdo_ThamDo]
GO
ALTER TABLE [dbo].[dondathang]  WITH CHECK ADD  CONSTRAINT [FK_dondathang_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[khachhang] ([MaKH])
GO
ALTER TABLE [dbo].[dondathang] CHECK CONSTRAINT [FK_dondathang_KhachHang]
GO
ALTER TABLE [dbo].[giay]  WITH CHECK ADD  CONSTRAINT [FK_giay_ChuDe] FOREIGN KEY([MaCD])
REFERENCES [dbo].[chude] ([MaCD])
GO
ALTER TABLE [dbo].[giay] CHECK CONSTRAINT [FK_giay_ChuDe]
GO
ALTER TABLE [dbo].[giay]  WITH CHECK ADD  CONSTRAINT [FK_giay_NhaXuatBan] FOREIGN KEY([MaNXB])
REFERENCES [dbo].[nhaxuatban] ([MaNXB])
GO
ALTER TABLE [dbo].[giay] CHECK CONSTRAINT [FK_giay_NhaXuatBan]
GO
ALTER TABLE [dbo].[vietgiay]  WITH CHECK ADD  CONSTRAINT [FK_vietgiay_Giay] FOREIGN KEY([MaGiay])
REFERENCES [dbo].[giay] ([MaGiay])
GO
ALTER TABLE [dbo].[vietgiay] CHECK CONSTRAINT [FK_vietgiay_Giay]
GO
ALTER TABLE [dbo].[vietgiay]  WITH CHECK ADD  CONSTRAINT [FK_vietgiay_TacGia] FOREIGN KEY([MaTG])
REFERENCES [dbo].[tacgia] ([MaTG])
GO
ALTER TABLE [dbo].[vietgiay] CHECK CONSTRAINT [FK_vietgiay_TacGia]
GO
ALTER TABLE [dbo].[ctdathang]  WITH CHECK ADD CHECK  (([DonGia]>=(0)))
GO
ALTER TABLE [dbo].[ctdathang]  WITH CHECK ADD CHECK  (([SoLuong]>(0)))
GO
ALTER TABLE [dbo].[dondathang]  WITH CHECK ADD CHECK  (([TriGia]>(0)))
GO
ALTER TABLE [dbo].[giay]  WITH CHECK ADD CHECK  (([DonGia]>=(0)))
GO
ALTER TABLE [dbo].[giay]  WITH CHECK ADD CHECK  (([SoLuongBan]>(0)))
GO
USE [master]
GO
ALTER DATABASE [ShopGiay] SET  READ_WRITE 
GO
