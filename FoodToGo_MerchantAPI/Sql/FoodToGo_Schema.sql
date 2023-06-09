USE [master]
GO
/****** Object:  Database [FoodToGo]    Script Date: 7/2/2023 9:17:53 PM ******/
CREATE DATABASE [FoodToGo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FoodToGo', FILENAME = N'C:\SQL\FoodToGo.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FoodToGo_log', FILENAME = N'C:\SQL\FoodToGo_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [FoodToGo] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FoodToGo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FoodToGo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FoodToGo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FoodToGo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FoodToGo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FoodToGo] SET ARITHABORT OFF 
GO
ALTER DATABASE [FoodToGo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FoodToGo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FoodToGo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FoodToGo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FoodToGo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FoodToGo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FoodToGo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FoodToGo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FoodToGo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FoodToGo] SET  ENABLE_BROKER 
GO
ALTER DATABASE [FoodToGo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FoodToGo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FoodToGo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FoodToGo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FoodToGo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FoodToGo] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [FoodToGo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FoodToGo] SET RECOVERY FULL 
GO
ALTER DATABASE [FoodToGo] SET  MULTI_USER 
GO
ALTER DATABASE [FoodToGo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FoodToGo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FoodToGo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FoodToGo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FoodToGo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FoodToGo] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'FoodToGo', N'ON'
GO
ALTER DATABASE [FoodToGo] SET QUERY_STORE = ON
GO
ALTER DATABASE [FoodToGo] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [FoodToGo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/2/2023 9:17:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bans]    Script Date: 7/2/2023 9:17:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bans](
	[BanId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Reason] [nvarchar](max) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Bans] PRIMARY KEY CLUSTERED 
(
	[BanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 7/2/2023 9:17:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[MiddleName] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Rating] [float] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuItemImages]    Script Date: 7/2/2023 9:17:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuItemImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MenuItemId] [int] NOT NULL,
	[Path] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_MenuItemImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuItemRatings]    Script Date: 7/2/2023 9:17:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuItemRatings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MenuItemId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Rating] [float] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[OrderId] [int] NOT NULL,
 CONSTRAINT [PK_MenuItemRatings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuItems]    Script Date: 7/2/2023 9:17:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MerchantId] [int] NOT NULL,
	[ItemTypeId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[IsClosed] [bit] NOT NULL,
	[Rating] [float] NOT NULL,
 CONSTRAINT [PK_MenuItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuItemTypes]    Script Date: 7/2/2023 9:17:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuItemTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_MenuItemTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MerchantProfileImages]    Script Date: 7/2/2023 9:17:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MerchantProfileImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MerchantId] [int] NOT NULL,
	[Path] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_MerchantProfileImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MerchantRatings]    Script Date: 7/2/2023 9:17:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MerchantRatings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FromUserId] [int] NOT NULL,
	[FromUserType] [nvarchar](max) NOT NULL,
	[ToMerchantId] [int] NOT NULL,
	[Rating] [float] NOT NULL,
	[OrderId] [int] NOT NULL,
 CONSTRAINT [PK_MerchantRatings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Merchants]    Script Date: 7/2/2023 9:17:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Merchants](
	[MerchantId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[GeoLatitude] [float] NOT NULL,
	[GeoLongitude] [float] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Rating] [float] NOT NULL,
 CONSTRAINT [PK_Merchants] PRIMARY KEY CLUSTERED 
(
	[MerchantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NormalOpenHours]    Script Date: 7/2/2023 9:17:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NormalOpenHours](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MerchantId] [int] NOT NULL,
	[DayOfWeek] [int] NOT NULL,
	[SessionNo] [int] NOT NULL,
	[OpenTime] [datetime2](7) NOT NULL,
	[CloseTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_NormalOpenHours] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OnlineCustomerLocations]    Script Date: 7/2/2023 9:17:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OnlineCustomerLocations](
	[CustomerId] [int] NOT NULL,
	[GeoLatitude] [float] NOT NULL,
	[GeoLongitude] [float] NOT NULL,
 CONSTRAINT [PK_OnlineCustomerLocations] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OnlineShipperStatuses]    Script Date: 7/2/2023 9:17:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OnlineShipperStatuses](
	[ShipperId] [int] NOT NULL,
	[GeoLatitude] [float] NOT NULL,
	[GeoLongitude] [float] NOT NULL,
	[IsAvailable] [bit] NOT NULL,
 CONSTRAINT [PK_OnlineShipperStatuses] PRIMARY KEY CLUSTERED 
(
	[ShipperId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 7/2/2023 9:17:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderId] [int] NOT NULL,
	[MenuItemId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[SpecialInstruction] [nvarchar](max) NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 7/2/2023 9:17:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MerchantId] [int] NOT NULL,
	[ShipperId] [int] NULL,
	[CustomerId] [int] NOT NULL,
	[PromotionId] [int] NULL,
	[PlacedTime] [datetime2](7) NOT NULL,
	[ETA] [datetime2](7) NOT NULL,
	[DeliveryCompletionTime] [datetime2](7) NULL,
	[OrderPrice] [money] NOT NULL,
	[ShippingFee] [money] NOT NULL,
	[AppFee] [money] NOT NULL,
	[PromotionDiscount] [money] NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[CancellationReason] [nvarchar](max) NULL,
	[cancelledBy] [nvarchar](max) NULL,
	[DeliveryAddress] [nvarchar](max) NOT NULL,
	[DeliveryLatitude] [float] NOT NULL,
	[DeliveryLongitude] [float] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OverrideOpenHours]    Script Date: 7/2/2023 9:17:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OverrideOpenHours](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MerchantId] [int] NOT NULL,
	[OverrideStartDate] [datetime2](7) NOT NULL,
	[OverrideEndDate] [datetime2](7) NOT NULL,
	[DayOfWeek] [int] NOT NULL,
	[SessionNo] [int] NOT NULL,
	[AltOpenTime] [datetime2](7) NULL,
	[AltCloseTime] [datetime2](7) NULL,
	[IsClosed] [bit] NOT NULL,
 CONSTRAINT [PK_OverrideOpenHours] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promotions]    Script Date: 7/2/2023 9:17:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promotions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DiscountCreatorMerchantId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[DiscountPercentage] [int] NOT NULL,
	[DiscountAmount] [money] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[Quantity] [int] NOT NULL,
	[QuantityLeft] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Promotions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shippers]    Script Date: 7/2/2023 9:17:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shippers](
	[UserId] [int] NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[MiddleName] [nvarchar](max) NOT NULL,
	[VehicleType] [nvarchar](max) NOT NULL,
	[VehicleNumberPlate] [nvarchar](max) NOT NULL,
	[Rating] [float] NOT NULL,
 CONSTRAINT [PK_Shippers] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRatings]    Script Date: 7/2/2023 9:17:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRatings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FromUserId] [int] NOT NULL,
	[FromUserType] [nvarchar](max) NOT NULL,
	[ToUserId] [int] NOT NULL,
	[ToUserType] [nvarchar](max) NOT NULL,
	[Rating] [float] NOT NULL,
	[OrderId] [int] NOT NULL,
 CONSTRAINT [PK_UserRatings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 7/2/2023 9:17:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Salt] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Role] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Bans_UserId]    Script Date: 7/2/2023 9:17:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_Bans_UserId] ON [dbo].[Bans]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MenuItemImages_MenuItemId]    Script Date: 7/2/2023 9:17:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_MenuItemImages_MenuItemId] ON [dbo].[MenuItemImages]
(
	[MenuItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MenuItemRatings_CustomerId]    Script Date: 7/2/2023 9:17:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_MenuItemRatings_CustomerId] ON [dbo].[MenuItemRatings]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MenuItemRatings_MenuItemId]    Script Date: 7/2/2023 9:17:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_MenuItemRatings_MenuItemId] ON [dbo].[MenuItemRatings]
(
	[MenuItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MenuItemRatings_OrderId]    Script Date: 7/2/2023 9:17:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_MenuItemRatings_OrderId] ON [dbo].[MenuItemRatings]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MenuItems_ItemTypeId]    Script Date: 7/2/2023 9:17:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_MenuItems_ItemTypeId] ON [dbo].[MenuItems]
(
	[ItemTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MenuItems_MerchantId]    Script Date: 7/2/2023 9:17:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_MenuItems_MerchantId] ON [dbo].[MenuItems]
(
	[MerchantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MerchantProfileImages_MerchantId]    Script Date: 7/2/2023 9:17:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_MerchantProfileImages_MerchantId] ON [dbo].[MerchantProfileImages]
(
	[MerchantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MerchantRatings_FromUserId]    Script Date: 7/2/2023 9:17:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_MerchantRatings_FromUserId] ON [dbo].[MerchantRatings]
(
	[FromUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MerchantRatings_OrderId]    Script Date: 7/2/2023 9:17:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_MerchantRatings_OrderId] ON [dbo].[MerchantRatings]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MerchantRatings_ToMerchantId]    Script Date: 7/2/2023 9:17:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_MerchantRatings_ToMerchantId] ON [dbo].[MerchantRatings]
(
	[ToMerchantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Merchants_UserId]    Script Date: 7/2/2023 9:17:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_Merchants_UserId] ON [dbo].[Merchants]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_NormalOpenHours_MerchantId]    Script Date: 7/2/2023 9:17:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_NormalOpenHours_MerchantId] ON [dbo].[NormalOpenHours]
(
	[MerchantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_MenuItemId]    Script Date: 7/2/2023 9:17:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_MenuItemId] ON [dbo].[OrderDetails]
(
	[MenuItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_OrderId]    Script Date: 7/2/2023 9:17:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_OrderId] ON [dbo].[OrderDetails]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_CustomerId]    Script Date: 7/2/2023 9:17:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_CustomerId] ON [dbo].[Orders]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_MerchantId]    Script Date: 7/2/2023 9:17:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_MerchantId] ON [dbo].[Orders]
(
	[MerchantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_PromotionId]    Script Date: 7/2/2023 9:17:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_PromotionId] ON [dbo].[Orders]
(
	[PromotionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_ShipperId]    Script Date: 7/2/2023 9:17:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_ShipperId] ON [dbo].[Orders]
(
	[ShipperId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OverrideOpenHours_MerchantId]    Script Date: 7/2/2023 9:17:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_OverrideOpenHours_MerchantId] ON [dbo].[OverrideOpenHours]
(
	[MerchantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Promotions_DiscountCreatorMerchantId]    Script Date: 7/2/2023 9:17:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_Promotions_DiscountCreatorMerchantId] ON [dbo].[Promotions]
(
	[DiscountCreatorMerchantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRatings_FromUserId]    Script Date: 7/2/2023 9:17:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserRatings_FromUserId] ON [dbo].[UserRatings]
(
	[FromUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRatings_OrderId]    Script Date: 7/2/2023 9:17:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserRatings_OrderId] ON [dbo].[UserRatings]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRatings_ToUserId]    Script Date: 7/2/2023 9:17:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserRatings_ToUserId] ON [dbo].[UserRatings]
(
	[ToUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Rating]
GO
ALTER TABLE [dbo].[MenuItemRatings] ADD  DEFAULT ((0)) FOR [OrderId]
GO
ALTER TABLE [dbo].[MenuItems] ADD  DEFAULT (N'') FOR [Description]
GO
ALTER TABLE [dbo].[MenuItems] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsClosed]
GO
ALTER TABLE [dbo].[MenuItems] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Rating]
GO
ALTER TABLE [dbo].[MerchantRatings] ADD  DEFAULT ((0)) FOR [OrderId]
GO
ALTER TABLE [dbo].[Merchants] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Merchants] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Rating]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (N'') FOR [DeliveryAddress]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [DeliveryLatitude]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [DeliveryLongitude]
GO
ALTER TABLE [dbo].[Promotions] ADD  DEFAULT (N'') FOR [Description]
GO
ALTER TABLE [dbo].[Shippers] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Rating]
GO
ALTER TABLE [dbo].[UserRatings] ADD  DEFAULT ((0)) FOR [OrderId]
GO
ALTER TABLE [dbo].[Bans]  WITH CHECK ADD  CONSTRAINT [FK_Bans_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bans] CHECK CONSTRAINT [FK_Bans_Users_UserId]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Users_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Users_CustomerId]
GO
ALTER TABLE [dbo].[MenuItemImages]  WITH CHECK ADD  CONSTRAINT [FK_MenuItemImages_MenuItems_MenuItemId] FOREIGN KEY([MenuItemId])
REFERENCES [dbo].[MenuItems] ([Id])
GO
ALTER TABLE [dbo].[MenuItemImages] CHECK CONSTRAINT [FK_MenuItemImages_MenuItems_MenuItemId]
GO
ALTER TABLE [dbo].[MenuItemRatings]  WITH CHECK ADD  CONSTRAINT [FK_MenuItemRatings_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[MenuItemRatings] CHECK CONSTRAINT [FK_MenuItemRatings_Customers_CustomerId]
GO
ALTER TABLE [dbo].[MenuItemRatings]  WITH CHECK ADD  CONSTRAINT [FK_MenuItemRatings_MenuItems_MenuItemId] FOREIGN KEY([MenuItemId])
REFERENCES [dbo].[MenuItems] ([Id])
GO
ALTER TABLE [dbo].[MenuItemRatings] CHECK CONSTRAINT [FK_MenuItemRatings_MenuItems_MenuItemId]
GO
ALTER TABLE [dbo].[MenuItemRatings]  WITH CHECK ADD  CONSTRAINT [FK_MenuItemRatings_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[MenuItemRatings] CHECK CONSTRAINT [FK_MenuItemRatings_Orders_OrderId]
GO
ALTER TABLE [dbo].[MenuItems]  WITH CHECK ADD  CONSTRAINT [FK_MenuItems_MenuItemTypes_ItemTypeId] FOREIGN KEY([ItemTypeId])
REFERENCES [dbo].[MenuItemTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MenuItems] CHECK CONSTRAINT [FK_MenuItems_MenuItemTypes_ItemTypeId]
GO
ALTER TABLE [dbo].[MenuItems]  WITH CHECK ADD  CONSTRAINT [FK_MenuItems_Merchants_MerchantId] FOREIGN KEY([MerchantId])
REFERENCES [dbo].[Merchants] ([MerchantId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MenuItems] CHECK CONSTRAINT [FK_MenuItems_Merchants_MerchantId]
GO
ALTER TABLE [dbo].[MerchantProfileImages]  WITH CHECK ADD  CONSTRAINT [FK_MerchantProfileImages_Merchants_MerchantId] FOREIGN KEY([MerchantId])
REFERENCES [dbo].[Merchants] ([MerchantId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MerchantProfileImages] CHECK CONSTRAINT [FK_MerchantProfileImages_Merchants_MerchantId]
GO
ALTER TABLE [dbo].[MerchantRatings]  WITH CHECK ADD  CONSTRAINT [FK_MerchantRatings_Merchants_ToMerchantId] FOREIGN KEY([ToMerchantId])
REFERENCES [dbo].[Merchants] ([MerchantId])
GO
ALTER TABLE [dbo].[MerchantRatings] CHECK CONSTRAINT [FK_MerchantRatings_Merchants_ToMerchantId]
GO
ALTER TABLE [dbo].[MerchantRatings]  WITH CHECK ADD  CONSTRAINT [FK_MerchantRatings_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[MerchantRatings] CHECK CONSTRAINT [FK_MerchantRatings_Orders_OrderId]
GO
ALTER TABLE [dbo].[MerchantRatings]  WITH CHECK ADD  CONSTRAINT [FK_MerchantRatings_Users_FromUserId] FOREIGN KEY([FromUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[MerchantRatings] CHECK CONSTRAINT [FK_MerchantRatings_Users_FromUserId]
GO
ALTER TABLE [dbo].[Merchants]  WITH CHECK ADD  CONSTRAINT [FK_Merchants_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Merchants] CHECK CONSTRAINT [FK_Merchants_Users_UserId]
GO
ALTER TABLE [dbo].[NormalOpenHours]  WITH CHECK ADD  CONSTRAINT [FK_NormalOpenHours_Merchants_MerchantId] FOREIGN KEY([MerchantId])
REFERENCES [dbo].[Merchants] ([MerchantId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NormalOpenHours] CHECK CONSTRAINT [FK_NormalOpenHours_Merchants_MerchantId]
GO
ALTER TABLE [dbo].[OnlineCustomerLocations]  WITH CHECK ADD  CONSTRAINT [FK_OnlineCustomerLocations_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OnlineCustomerLocations] CHECK CONSTRAINT [FK_OnlineCustomerLocations_Customers_CustomerId]
GO
ALTER TABLE [dbo].[OnlineShipperStatuses]  WITH CHECK ADD  CONSTRAINT [FK_OnlineShipperStatuses_Shippers_ShipperId] FOREIGN KEY([ShipperId])
REFERENCES [dbo].[Shippers] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OnlineShipperStatuses] CHECK CONSTRAINT [FK_OnlineShipperStatuses_Shippers_ShipperId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_MenuItems_MenuItemId] FOREIGN KEY([MenuItemId])
REFERENCES [dbo].[MenuItems] ([Id])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_MenuItems_MenuItemId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders_OrderId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers_CustomerId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Merchants_MerchantId] FOREIGN KEY([MerchantId])
REFERENCES [dbo].[Merchants] ([MerchantId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Merchants_MerchantId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Promotions_PromotionId] FOREIGN KEY([PromotionId])
REFERENCES [dbo].[Promotions] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Promotions_PromotionId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Shippers_ShipperId] FOREIGN KEY([ShipperId])
REFERENCES [dbo].[Shippers] ([UserId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Shippers_ShipperId]
GO
ALTER TABLE [dbo].[OverrideOpenHours]  WITH CHECK ADD  CONSTRAINT [FK_OverrideOpenHours_Merchants_MerchantId] FOREIGN KEY([MerchantId])
REFERENCES [dbo].[Merchants] ([MerchantId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OverrideOpenHours] CHECK CONSTRAINT [FK_OverrideOpenHours_Merchants_MerchantId]
GO
ALTER TABLE [dbo].[Promotions]  WITH CHECK ADD  CONSTRAINT [FK_Promotions_Merchants_DiscountCreatorMerchantId] FOREIGN KEY([DiscountCreatorMerchantId])
REFERENCES [dbo].[Merchants] ([MerchantId])
GO
ALTER TABLE [dbo].[Promotions] CHECK CONSTRAINT [FK_Promotions_Merchants_DiscountCreatorMerchantId]
GO
ALTER TABLE [dbo].[Shippers]  WITH CHECK ADD  CONSTRAINT [FK_Shippers_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Shippers] CHECK CONSTRAINT [FK_Shippers_Users_UserId]
GO
ALTER TABLE [dbo].[UserRatings]  WITH CHECK ADD  CONSTRAINT [FK_UserRatings_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[UserRatings] CHECK CONSTRAINT [FK_UserRatings_Orders_OrderId]
GO
ALTER TABLE [dbo].[UserRatings]  WITH CHECK ADD  CONSTRAINT [FK_UserRatings_Users_FromUserId] FOREIGN KEY([FromUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserRatings] CHECK CONSTRAINT [FK_UserRatings_Users_FromUserId]
GO
ALTER TABLE [dbo].[UserRatings]  WITH CHECK ADD  CONSTRAINT [FK_UserRatings_Users_ToUserId] FOREIGN KEY([ToUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserRatings] CHECK CONSTRAINT [FK_UserRatings_Users_ToUserId]
GO
/****** Object:  Trigger [dbo].[updateMenuItemRating]    Script Date: 7/2/2023 9:17:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[updateMenuItemRating] on [dbo].[MenuItemRatings]
for update, delete, insert
as
begin
	if exists (select top 1 1 from deleted)
	begin
		declare @deleteMenuItemId int = (select top 1 MenuItemId from deleted);
		declare @deleteAvgRating float = (select AVG(Rating) from MenuItemRatings where MenuItemId = @deleteMenuItemId);
		update MenuItems set Rating = @deleteAvgRating where Id = @deleteMenuItemId;
	end

	if exists (select top 1 1 from inserted)
	begin
		declare @insertMenuItemId int = (select top 1 MenuItemId from inserted)
		declare @insertAvgRating float = (select AVG(Rating) from MenuItemRatings where MenuItemId = @insertMenuItemId);
		update MenuItems set Rating = @insertAvgRating where Id = @insertMenuItemId;
	end
end
GO
ALTER TABLE [dbo].[MenuItemRatings] ENABLE TRIGGER [updateMenuItemRating]
GO
/****** Object:  Trigger [dbo].[updateMerchantRating]    Script Date: 7/2/2023 9:17:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[updateMerchantRating] on [dbo].[MerchantRatings]
for update, delete, insert
as
begin
	if exists (select top 1 1 from deleted)
	begin
		declare @deleteMerchantId int = (select top 1 ToMerchantId from deleted);
		declare @deleteAvgRating float = (select avg(Rating) from MerchantRatings where ToMerchantId = @deleteMerchantId);
		update Merchants set Rating = @deleteAvgRating where MerchantId = @deleteMerchantId;
	end
	
	if exists (select top 1 1 from inserted)
	begin
		declare @insertMerchantId int = (select top 1 ToMerchantId from inserted);
		declare @insertAvgRating float = (select avg(Rating) from MerchantRatings where ToMerchantId = @insertMerchantId);
		update Merchants set Rating = @insertAvgRating where MerchantId = @insertMerchantId;
	end
end
GO
ALTER TABLE [dbo].[MerchantRatings] ENABLE TRIGGER [updateMerchantRating]
GO
/****** Object:  Trigger [dbo].[updateUserRating]    Script Date: 7/2/2023 9:17:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[updateUserRating] on [dbo].[UserRatings]
for update, delete, insert
as
begin
	if exists (select top 1 1 from deleted)
	begin
		declare @deleteToUserId int = (select top 1 ToUserId from deleted);
		declare @deleteToUserType nvarchar(max) = (select top 1 ToUserType from deleted);
		declare @deleteAvgRating float = (select AVG(Rating) from UserRatings where ToUserId = @deleteToUserId and ToUserType like @deleteToUserType);
		
		if(@deleteToUserType like 'Customer')
		begin
			update Customers set Rating = @deleteAvgRating where CustomerId = @deleteToUserId
		end

		if(@deleteToUserType like 'Shipper')
		begin
			update Shippers set Rating = @deleteAvgRating where UserId = @deleteToUserId
		end

	end
	
	if exists (select top 1 1 from inserted)
	begin
		declare @insertToUserId int = (select top 1 ToUserId from inserted);
		declare @insertToUserType nvarchar(max) = (select top 1 ToUserType from inserted);
		declare @insertAvgRating float = (select AVG(Rating) from UserRatings where ToUserId = @insertToUserId and ToUserType like @insertToUserType);
		
		if(@insertToUserType like 'Customer')
		begin
			update Customers set Rating = @insertAvgRating where CustomerId = @insertToUserId
		end

		if(@insertToUserType like 'Shipper')
		begin
			update Shippers set Rating = @insertAvgRating where UserId = @insertToUserId
		end
	end
end
GO
ALTER TABLE [dbo].[UserRatings] ENABLE TRIGGER [updateUserRating]
GO
USE [master]
GO
ALTER DATABASE [FoodToGo] SET  READ_WRITE 
GO
