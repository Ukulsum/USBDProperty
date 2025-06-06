USE [master]
GO
/****** Object:  Database [USBDRealEstate]    Script Date: 9/8/2024 5:20:06 PM ******/
CREATE DATABASE [USBDRealEstate]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'USBDRealEstate', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\USBDRealEstate.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'USBDRealEstate_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\USBDRealEstate_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [USBDRealEstate] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [USBDRealEstate].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [USBDRealEstate] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [USBDRealEstate] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [USBDRealEstate] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [USBDRealEstate] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [USBDRealEstate] SET ARITHABORT OFF 
GO
ALTER DATABASE [USBDRealEstate] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [USBDRealEstate] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [USBDRealEstate] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [USBDRealEstate] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [USBDRealEstate] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [USBDRealEstate] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [USBDRealEstate] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [USBDRealEstate] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [USBDRealEstate] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [USBDRealEstate] SET  DISABLE_BROKER 
GO
ALTER DATABASE [USBDRealEstate] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [USBDRealEstate] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [USBDRealEstate] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [USBDRealEstate] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [USBDRealEstate] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [USBDRealEstate] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [USBDRealEstate] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [USBDRealEstate] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [USBDRealEstate] SET  MULTI_USER 
GO
ALTER DATABASE [USBDRealEstate] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [USBDRealEstate] SET DB_CHAINING OFF 
GO
ALTER DATABASE [USBDRealEstate] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [USBDRealEstate] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [USBDRealEstate] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [USBDRealEstate] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'USBDRealEstate', N'ON'
GO
ALTER DATABASE [USBDRealEstate] SET QUERY_STORE = OFF
GO
USE [USBDRealEstate]
GO
/****** Object:  User [usbduser]    Script Date: 9/8/2024 5:20:07 PM ******/
CREATE USER [usbduser] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[usbduser]
GO
ALTER ROLE [db_owner] ADD MEMBER [usbduser]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [usbduser]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [usbduser]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [usbduser]
GO
ALTER ROLE [db_datareader] ADD MEMBER [usbduser]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [usbduser]
GO
/****** Object:  Schema [usbduser]    Script Date: 9/8/2024 5:20:07 PM ******/
CREATE SCHEMA [usbduser]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9/8/2024 5:20:07 PM ******/
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
/****** Object:  Table [dbo].[Areas]    Script Date: 9/8/2024 5:20:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Areas](
	[AreaId] [int] IDENTITY(1,1) NOT NULL,
	[AreaName] [nvarchar](100) NOT NULL,
	[CityId] [int] NOT NULL,
 CONSTRAINT [PK_Areas] PRIMARY KEY CLUSTERED 
(
	[AreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 9/8/2024 5:20:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 9/8/2024 5:20:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 9/8/2024 5:20:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 9/8/2024 5:20:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 9/8/2024 5:20:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 9/8/2024 5:20:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[ProfilePic] [nvarchar](max) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 9/8/2024 5:20:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AvailableFlatSizes]    Script Date: 9/8/2024 5:20:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AvailableFlatSizes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NOT NULL,
	[AvailableFSize] [nvarchar](max) NOT NULL,
	[UnitID] [int] NOT NULL,
 CONSTRAINT [PK_AvailableFlatSizes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Citys]    Script Date: 9/8/2024 5:20:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Citys](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](100) NOT NULL,
	[DivisionId] [int] NOT NULL,
 CONSTRAINT [PK_Citys] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientContacts]    Script Date: 9/8/2024 5:20:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientContacts](
	[ClientContactId] [int] IDENTITY(1,1) NOT NULL,
	[ClientName] [nvarchar](100) NOT NULL,
	[ContactNo] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[ContactDate] [datetime2](7) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[Interested] [int] NOT NULL,
 CONSTRAINT [PK_ClientContacts] PRIMARY KEY CLUSTERED 
(
	[ClientContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientInterest]    Script Date: 9/8/2024 5:20:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientInterest](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[PropertyID] [int] NOT NULL,
	[PropertyForId] [int] NOT NULL,
	[PropertyTypeId] [int] NOT NULL,
	[Message] [nvarchar](max) NULL,
	[PropertyFor] [int] NOT NULL,
 CONSTRAINT [PK_ClientInterest] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 9/8/2024 5:20:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DevelopersorAgent]    Script Date: 9/8/2024 5:20:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DevelopersorAgent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Logo] [nvarchar](max) NOT NULL,
	[Banner] [nvarchar](max) NOT NULL,
	[CompanyName] [nvarchar](100) NOT NULL,
	[ContactNo] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
	[UpdateBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[AreaID] [int] NOT NULL,
	[Membership] [int] NOT NULL,
	[AboutUs] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DevelopersorAgent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Divisions]    Script Date: 9/8/2024 5:20:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Divisions](
	[DivisionID] [int] IDENTITY(1,1) NOT NULL,
	[DivisionName] [nvarchar](100) NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Divisions] PRIMARY KEY CLUSTERED 
(
	[DivisionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FloorPlans]    Script Date: 9/8/2024 5:20:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FloorPlans](
	[FloorPlanId] [int] IDENTITY(1,1) NOT NULL,
	[FloorPlanName] [nvarchar](255) NOT NULL,
	[ImagePath] [nvarchar](max) NOT NULL,
	[PropertyInfoID] [int] NOT NULL,
 CONSTRAINT [PK_FloorPlans] PRIMARY KEY CLUSTERED 
(
	[FloorPlanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MeasurementUnit]    Script Date: 9/8/2024 5:20:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeasurementUnit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ShortName] [nvarchar](max) NULL,
 CONSTRAINT [PK_MeasurementUnit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notices]    Script Date: 9/8/2024 5:20:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notices](
	[NoticeID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NULL,
	[Description] [nvarchar](max) NULL,
	[Path] [nvarchar](max) NULL,
	[StartDate] [datetime2](7) NULL,
	[EndDate] [datetime2](7) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdateDate] [datetime2](7) NULL,
	[UpdateBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsFeatured] [bit] NOT NULL,
	[ImagePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_Notices] PRIMARY KEY CLUSTERED 
(
	[NoticeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PrivacyPolicy]    Script Date: 9/8/2024 5:20:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrivacyPolicy](
	[PpId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_PrivacyPolicy] PRIMARY KEY CLUSTERED 
(
	[PpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectImageGallery]    Script Date: 9/8/2024 5:20:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectImageGallery](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ImagePath] [nvarchar](max) NOT NULL,
	[ProjectID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectImageGallery] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectsInfo]    Script Date: 9/8/2024 5:20:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectsInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ProjectName] [nvarchar](150) NOT NULL,
	[Location] [nvarchar](100) NOT NULL,
	[LocationMap] [nvarchar](100) NULL,
	[AgentID] [int] NOT NULL,
	[AreaID] [int] NOT NULL,
	[ProjectVideo] [nvarchar](max) NULL,
 CONSTRAINT [PK_ProjectsInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropertyDetails]    Script Date: 9/8/2024 5:20:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyDetails](
	[PropertyInfoId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[PropertyName] [nvarchar](150) NULL,
	[Location] [nvarchar](100) NULL,
	[ConstructionStatus] [int] NULL,
	[PropertySize] [int] NULL,
	[NumberOfBedrooms] [int] NULL,
	[NumberOfBaths] [int] NULL,
	[NumberOfBalconies] [int] NULL,
	[NumberOfGarages] [int] NULL,
	[TotalFloor] [int] NULL,
	[FloorAvailableNo] [int] NULL,
	[Furnishing] [int] NULL,
	[Facing] [int] NULL,
	[LandArea] [real] NOT NULL,
	[Price] [real] NULL,
	[Path] [nvarchar](max) NULL,
	[Comments] [nvarchar](255) NULL,
	[PropertyCondition] [int] NULL,
	[HandOverDate] [datetime2](7) NULL,
	[PropertyTypeId] [int] NULL,
	[ProjectId] [int] NULL,
	[AreaId] [int] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdateDate] [datetime2](7) NULL,
	[UpdateBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[PropertyFor] [int] NULL,
	[ISFeatured] [bit] NULL,
	[MeasurementID] [int] NOT NULL,
	[FlatSize] [int] NULL,
	[LandPrice] [real] NULL,
	[ImagePath] [nvarchar](max) NULL,
	[IsLand] [bit] NULL,
	[IsSold] [bit] NOT NULL,
 CONSTRAINT [PK_PropertyDetails] PRIMARY KEY CLUSTERED 
(
	[PropertyInfoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropertyFeatures]    Script Date: 9/8/2024 5:20:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyFeatures](
	[PropertyFeatureId] [int] IDENTITY(1,1) NOT NULL,
	[PropertyFeatureName] [nvarchar](150) NOT NULL,
	[FeatureDescription] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_PropertyFeatures] PRIMARY KEY CLUSTERED 
(
	[PropertyFeatureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropertyImages]    Script Date: 9/8/2024 5:20:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyImages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[MultiImagePath] [nvarchar](max) NOT NULL,
	[propertyInfoId] [int] NOT NULL,
 CONSTRAINT [PK_PropertyImages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropertyTypes]    Script Date: 9/8/2024 5:20:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyTypes](
	[PropertyTypeId] [int] IDENTITY(1,1) NOT NULL,
	[PropertyTypeName] [nvarchar](255) NOT NULL,
	[ParentPropertyTypeId] [int] NULL,
	[IsLand] [bit] NOT NULL,
 CONSTRAINT [PK_PropertyTypes] PRIMARY KEY CLUSTERED 
(
	[PropertyTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropertyWithFeatures]    Script Date: 9/8/2024 5:20:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyWithFeatures](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NOT NULL,
	[FeatureId] [int] NOT NULL,
 CONSTRAINT [PK_PropertyWithFeatures] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SocialIcons]    Script Date: 9/8/2024 5:20:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SocialIcons](
	[IconId] [int] IDENTITY(1,1) NOT NULL,
	[Icon] [nvarchar](max) NOT NULL,
	[Link] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_SocialIcons] PRIMARY KEY CLUSTERED 
(
	[IconId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TermsConditions]    Script Date: 9/8/2024 5:20:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TermsConditions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TermsConditions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionTypes]    Script Date: 9/8/2024 5:20:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionTypes](
	[TransactionTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TransactionTypeName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_TransactionTypes] PRIMARY KEY CLUSTERED 
(
	[TransactionTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240109064013_pa12', N'6.0.24')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240109072438_prf', N'6.0.24')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240110043333_p', N'6.0.24')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240110043538_i', N'6.0.24')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240110065340_dev', N'6.0.24')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240111235307_dv', N'6.0.24')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240112012440_prj', N'6.0.24')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240112015119_prj1', N'6.0.24')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240112025527_prj13', N'6.0.24')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240112025908_prj133', N'6.0.24')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240112115551_munit', N'6.0.24')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240113050215_u', N'6.0.24')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240113075519_cs', N'6.0.24')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240113080703_cs1', N'6.0.24')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240117105203_df', N'6.0.24')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240123073445_mem', N'6.0.24')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240124045156_mes', N'6.0.24')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240128084924_sd', N'6.0.24')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240131053333_title', N'6.0.24')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240131074725_notice', N'6.0.24')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240208042435_pp', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240210080957_land', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240212060901_IsLand1', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240212061704_Im', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240212072230_pd', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240213112424_d', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240213134808_das', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240214110038_m', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240215135710_enumPro', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240217123533_mulimage', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240220061926_kd', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240227113629_sd', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240227125906_sdd', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240228075842_os', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240228092014_sdf', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240228092753_sdk', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240228105703_sdfs', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240229071221_jds', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240229072250_jdsd', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240229094634_mul', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240302062027_feature', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240302062929_feature1', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240310051122_p', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240310051908_p1', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240318045143_sold', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240421103327_df', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240422061925_ads', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240422084328_o', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240429080458_ds', N'6.0.33')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240827093809_uksd', N'6.0.33')
GO
SET IDENTITY_INSERT [dbo].[Areas] ON 

INSERT [dbo].[Areas] ([AreaId], [AreaName], [CityId]) VALUES (1, N'Mirpur', 1)
INSERT [dbo].[Areas] ([AreaId], [AreaName], [CityId]) VALUES (2, N'Mohammadpur', 1)
INSERT [dbo].[Areas] ([AreaId], [AreaName], [CityId]) VALUES (4, N'Highway', 5)
SET IDENTITY_INSERT [dbo].[Areas] OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'0b81452f-c6ce-46aa-b257-e6cb7d20cb06', N'Agent', N'AGENT', N'1b4be62f-6db4-4b04-9cb8-967f7f97952e')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'2b3a0971-0ce5-4ff3-9909-51d942396d33', N'Admin', N'ADMIN', N'a4cc4c46-3f2d-41bf-9ace-4720adb2c645')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'72d770aa-c8b3-464d-92a5-92a29cb18c05', N'Super Admin', N'SUPER ADMIN', N'109409a2-bca7-4af5-8688-7a32a5ca86c8')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c69a9482-886a-4f4f-a68f-fa500f88c8dc', N'0b81452f-c6ce-46aa-b257-e6cb7d20cb06')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd118e255-93be-445b-ba24-aa30a0674fbc', N'2b3a0971-0ce5-4ff3-9909-51d942396d33')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'60e960e4-edf1-44ec-a743-e33afcbca890', N'72d770aa-c8b3-464d-92a5-92a29cb18c05')
GO
INSERT [dbo].[AspNetUsers] ([Id], [ProfilePic], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3aefe9e5-3242-4832-bd70-2ce2b0b6bcd0', NULL, N'sdsa@gmail.com', N'SDSA@GMAIL.COM', N'sdsa@gmail.com', N'SDSA@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEHpEJqS1bEfOXAz2aAHUk/MmdD1HHjaPpQNf6gx8m+3TSW6Q75765te5XudoOVUahA==', N'UNFMYRSSSW7SR2E42NUW7JIJ7NGAIKI6', N'657ec5a9-8d89-4721-9e4c-d46e0cd2ff06', N'451', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [ProfilePic], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3f7022e5-3c9d-435a-bbd6-eaa88e318586', NULL, N'd@d.com', N'D@D.COM', N'd@d.com', N'D@D.COM', 0, N'AQAAAAEAACcQAAAAEGFa/DZrWUVjw1qq4HyJXcqEA8o1/810kmsHzveZy/4tbgc8uKl5ZwWFO19QTHDpuw==', N'73JRKV7ALIJ7KF42UOZV5GUZGQ742ZSG', N'5ff5ea93-4e97-41c4-9863-f147f1402242', N'014447784966', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [ProfilePic], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'60e960e4-edf1-44ec-a743-e33afcbca890', NULL, N'abul@g.com', N'ABUL@G.COM', N'abul@g.com', N'ABUL@G.COM', 1, N'AQAAAAEAACcQAAAAEKWDBq30zH30m0/ruNIx0wwVyyFTl1VcZA1CPB7sViJy/5nfS0xnT/OiceNAyz2/Sg==', N'JMMJBZVQRVVODULVGLMIMP6HX65DMW4V', N'99a2098e-c24c-4abd-b1be-493c96626890', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [ProfilePic], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'61497247-1b9f-4437-b6da-3fad0fa5e5f8', NULL, N'k@K.com', N'K@K.COM', N'k@K.com', N'K@K.COM', 0, N'AQAAAAEAACcQAAAAEKB2+MXs367vFGTx/j1IxoWIR37j0HNM0nFMsUmAxVxVWpODoWwsimJlO4J868j3RA==', N'CZ6RCBFOPDPPF7NTQYMBFCITDCR4QOCX', N'86095d34-a2e3-4b3b-ab5d-d701ff826f2f', N'014447784965', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [ProfilePic], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'9dc2ef9f-b822-45b6-94d2-427e593a3d6b', NULL, N'bd@d.com', N'BD@D.COM', N'bd@d.com', N'BD@D.COM', 0, N'AQAAAAEAACcQAAAAELr7Bqky/v7mNyQM4XAsFXl+0kVI37P1xR2WdAKeFBCeD2823LXhva4J1C1on9JN7g==', N'HOUZIOP674KQ3ATM3U5CTFGMHZK5U45Y', N'615acdb3-a368-4653-ac70-f214d111ae3d', N'014447784963', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [ProfilePic], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c69a9482-886a-4f4f-a68f-fa500f88c8dc', NULL, N'samu@gmail.com', N'SAMU@GMAIL.COM', N'samu@gmail.com', N'SAMU@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEMGzSIckVAnXwv3Z6CIaoznBGTJjrW75HR9aF4ltVMLvhZO5O0f3MWwJxyiyoLMKaw==', N'S3JCKDXCNJ6UBWP2RT2GCKXIJYTWD32K', N'a470b2e7-2636-4c06-8456-f0842b9754d7', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [ProfilePic], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd118e255-93be-445b-ba24-aa30a0674fbc', NULL, N'devshahanaj123@gmail.com', N'DEVSHAHANAJ123@GMAIL.COM', N'devshahanaj123@gmail.com', N'DEVSHAHANAJ123@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEFVIpwQzg6APfVRphs0RJi0NlK+HrxeOguc9Vqtk1De+yehtj26/DPFFz5e6BQfYcg==', N'QWSHPABKEDQBMHCWTX7OMZEM63WZEFCG', N'5a86cd07-a50f-4622-9aa6-22230a563da3', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [ProfilePic], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'e2166598-b3c9-43d2-bace-4103912f6fba', NULL, N'asd@gmail.com', N'ASD@GMAIL.COM', N'asd@gmail.com', N'ASD@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEAwUqYmewoFbtGtqgC+M0yXbjaurWtlvhdfDtqQAIMc6Ieq9t+r1v2lI0B5Ryq/GYA==', N'KJXZTSGJF5OL64VL37KANOPBQDXHHAGU', N'13156d13-deb8-4438-bee7-73775c1846cb', N'880 1881-660077', 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[AvailableFlatSizes] ON 

INSERT [dbo].[AvailableFlatSizes] ([ID], [PropertyId], [AvailableFSize], [UnitID]) VALUES (1, 10, N'2000', 1)
INSERT [dbo].[AvailableFlatSizes] ([ID], [PropertyId], [AvailableFSize], [UnitID]) VALUES (2, 11, N'2000', 1)
INSERT [dbo].[AvailableFlatSizes] ([ID], [PropertyId], [AvailableFSize], [UnitID]) VALUES (3, 11, N'2300', 1)
INSERT [dbo].[AvailableFlatSizes] ([ID], [PropertyId], [AvailableFSize], [UnitID]) VALUES (4, 14, N'2000', 1)
INSERT [dbo].[AvailableFlatSizes] ([ID], [PropertyId], [AvailableFSize], [UnitID]) VALUES (5, 14, N'2500', 1)
INSERT [dbo].[AvailableFlatSizes] ([ID], [PropertyId], [AvailableFSize], [UnitID]) VALUES (6, 14, N'2200', 1)
INSERT [dbo].[AvailableFlatSizes] ([ID], [PropertyId], [AvailableFSize], [UnitID]) VALUES (7, 15, N'1200', 1)
INSERT [dbo].[AvailableFlatSizes] ([ID], [PropertyId], [AvailableFSize], [UnitID]) VALUES (8, 15, N'1500', 1)
INSERT [dbo].[AvailableFlatSizes] ([ID], [PropertyId], [AvailableFSize], [UnitID]) VALUES (9, 15, N'2000', 1)
INSERT [dbo].[AvailableFlatSizes] ([ID], [PropertyId], [AvailableFSize], [UnitID]) VALUES (10, 16, N'2000', 1)
INSERT [dbo].[AvailableFlatSizes] ([ID], [PropertyId], [AvailableFSize], [UnitID]) VALUES (11, 16, N'2300', 1)
INSERT [dbo].[AvailableFlatSizes] ([ID], [PropertyId], [AvailableFSize], [UnitID]) VALUES (12, 17, N'2000', 1)
INSERT [dbo].[AvailableFlatSizes] ([ID], [PropertyId], [AvailableFSize], [UnitID]) VALUES (13, 18, N'2000', 1)
INSERT [dbo].[AvailableFlatSizes] ([ID], [PropertyId], [AvailableFSize], [UnitID]) VALUES (14, 18, N'2300', 1)
INSERT [dbo].[AvailableFlatSizes] ([ID], [PropertyId], [AvailableFSize], [UnitID]) VALUES (15, 19, N'2000', 1)
INSERT [dbo].[AvailableFlatSizes] ([ID], [PropertyId], [AvailableFSize], [UnitID]) VALUES (16, 20, N'2000', 1)
INSERT [dbo].[AvailableFlatSizes] ([ID], [PropertyId], [AvailableFSize], [UnitID]) VALUES (17, 21, N'2000', 1)
SET IDENTITY_INSERT [dbo].[AvailableFlatSizes] OFF
GO
SET IDENTITY_INSERT [dbo].[Citys] ON 

INSERT [dbo].[Citys] ([CityId], [CityName], [DivisionId]) VALUES (1, N'Dhaka', 1)
INSERT [dbo].[Citys] ([CityId], [CityName], [DivisionId]) VALUES (2, N'Jursy', 3)
INSERT [dbo].[Citys] ([CityId], [CityName], [DivisionId]) VALUES (3, N'Mirpur', 1)
INSERT [dbo].[Citys] ([CityId], [CityName], [DivisionId]) VALUES (5, N'Mawa', 1)
SET IDENTITY_INSERT [dbo].[Citys] OFF
GO
SET IDENTITY_INSERT [dbo].[ClientContacts] ON 

INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (1, N'umme', N'015244583632', N'ukfarhanaislam@gmail.com', CAST(N'2024-01-17T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (2, N'umme', N'665632054', N'ukfarhanaislam@gmail.com', CAST(N'2024-01-17T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (3, N'salim', N'88888', N's@s.com', CAST(N'2024-01-17T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (4, N'dsfd', N'33333', N'ukfarhanaislam@gmail.com', CAST(N'2024-01-17T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (6, N'fatu', N'012154561222', N'fatu21@gmail.com', CAST(N'2024-01-17T16:56:06.7354787' AS DateTime2), NULL, 0)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (7, N'fatu', N'01552145455', N'fatu125@gmail.com', CAST(N'2024-01-17T16:59:15.9529730' AS DateTime2), NULL, 0)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (8, N'eww', N'333', N'a@a.com', CAST(N'2024-01-17T17:01:25.0349543' AS DateTime2), NULL, 0)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (9, N'january', N'015224485', N'janu23@gmail.com', CAST(N'2024-01-17T17:05:52.6768835' AS DateTime2), NULL, 0)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (10, N'salim', N'4444', N'asd@gmail.com', CAST(N'2024-01-17T17:10:29.6779969' AS DateTime2), NULL, 0)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (11, N'salim', N'04511111', N'asd@gmail.com', CAST(N'2024-01-17T17:14:28.8717210' AS DateTime2), NULL, 0)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (12, N'salim', N'55555', N'ss@s.com', CAST(N'2024-01-17T17:21:28.6243914' AS DateTime2), NULL, 0)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (13, N'doyel', N'44444', N'd@d.com', CAST(N'2024-01-17T17:23:25.6537437' AS DateTime2), NULL, 0)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (14, N'e', N'6666', N'asd@gmail.com', CAST(N'2024-01-17T17:32:16.4231685' AS DateTime2), NULL, 0)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (15, N'rtyrt', N'3333', N's@s.com', CAST(N'2024-01-17T17:36:26.3235701' AS DateTime2), NULL, 0)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (16, N'Nitin Gagneja', N'+91 07982604575', N'flyingvertex@gmail.com', CAST(N'2024-02-08T00:59:33.2701965' AS DateTime2), N'Hi,

Greetings of the day!

Can we help you with 3D Rendering?


First 3D Rendering Is Absolutely FREE


Get your first 3D Architectural rendering for free! We''re offering this to show you what we can do.
If you like our work, you can keep going. If you don''t, no worries – you won''t have to pay anything.


Learn More - https://www.flyingvertexstudio.com', 0)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (17, N'Nitin Gagneja', N'+91 07982604575', N'flyingvertexstudio.info@gmail.com', CAST(N'2024-02-08T12:46:27.5433678' AS DateTime2), N'Hi,

Greetings of the day!

Can we help you with 3D Rendering?


First 3D Rendering Is Absolutely FREE


Get your first 3D Architectural rendering for free! We''re offering this to show you what we can do.
If you like our work, you can keep going. If you don''t, no worries – you won''t have to pay anything.


Learn More - https://www.flyingvertexstudio.com', 0)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (18, N'R', N'234567', N'er@gmail.com', CAST(N'2024-02-15T21:13:24.2390508' AS DateTime2), N'Cgyhh', 0)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (19, N'Casimira Sumsuma', N'0704-4417970', N'casimira.sumsuma@gmail.com', CAST(N'2024-02-29T19:22:31.5799823' AS DateTime2), N'This message showed up to you and I can make your message show up to millions of websites the same way. It''s awesome and low-cost.Contact me by email or skype below if you want to know more.

P. Stewart
Email: psruxs@gomail2.xyz
Skype: live:.cid.2bc4ed65aa40fb3b', 3)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (20, N'minimal', N'sugarwork78@gmail.com', N'sugarwork78@gmail.com', CAST(N'2024-03-06T13:12:51.4439857' AS DateTime2), N'Excited to enhance your online security with ease? Our independent services got you covered! From strengthening your website against bots to simplifying file sharing, we''ve got easy solutions for everyone.  https://array.surge.sh', 3)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (21, N'France Merry', N'0348 8474195', N'merry.france9@gmail.com', CAST(N'2024-03-14T14:38:35.5885260' AS DateTime2), N'Hi!

It is with sad regret to inform you that LeadsFly is shutting down!

We have made available all our consumer and business leads for the entire world on our way out.

We have the following available worldwide:

Consumer Records: 294,582,351
Business Records: 25,215,278

Visit us here: https://leadsfly.biz/usbdproperty.com/

Best regards,
France', 3)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (22, N'RaymondIdiom', N'no.reply.StevenMuller@gmail.com', N'no.reply.MartinPeeters@gmail.com', CAST(N'2024-03-16T04:08:13.5764902' AS DateTime2), N'Howdy-ho! usbdproperty.com 
 
Did you know that it is possible to send an appeal legally and without breaking any laws? We are providing a novel way of sending proposals through contact forms. 
Feedback Forms guarantee that messages won''t be marked as spam, since they are considered important. 
We offer you to try our service for free. 
We can transmit up to 50,000 messages in your behalf. 
 
The cost of sending one million messages is $59. 
 
This message was automatically generated. 
 
We only use chat for communication. 
 
Contact us. 
Telegram - https://t.me/FeedbackFormEU 
Skype  live:contactform_18 
WhatsApp - +375259112693 
WhatsApp  https://wa.me/+375259112693', 3)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (23, N'Phil Stewart', N'342-123-4456', N'noreplyhere@aol.com', CAST(N'2024-03-17T00:19:01.4105747' AS DateTime2), N'Want Your Ad Everywhere? Reach Millions Instantly! For less than $100 I can blast your message to website contact forms globally. Contact me via skype or email below for info

P. Stewart
Email: fal6da@gomail2.xyz
Skype: live:.cid.2bc4ed65aa40fb3b', 3)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (24, N'Mike Brooks
', N'mikedowTwivy@gmail.com', N'mikedowTwivy@gmail.com', CAST(N'2024-03-22T03:39:31.4088104' AS DateTime2), N'Hi there, 
 
I have reviewed your domain in MOZ and have observed that you may benefit from an increase in authority. 
 
Our solution guarantees you a high-quality domain authority score within a period of three months. This will increase your organic visibility and strengthen your website authority, thus making it stronger against Google updates. 
 
Check out our deals for more details. 
https://www.monkeydigital.co/domain-authority-plan/ 
 
NEW: Ahrefs Domain Rating 
https://www.monkeydigital.co/ahrefs-seo/ 
 
 
Thanks and regards 
Mike Brooks
', 3)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (25, N'Mike Babcock
', N'mikeCallyImmisusia@gmail.com', N'mikeCallyImmisusia@gmail.com', CAST(N'2024-03-22T07:43:46.1093955' AS DateTime2), N'This service is perfect for boosting your local business'' visibility on the map in a specific location. 
 
We provide Google Maps listing management, optimization, and promotion services that cover everything needed to rank in the Google 3-Pack. 
 
More info: 
https://www.speed-seo.net/ranking-in-the-maps-means-sales/ 
 
 
Thanks and Regards 
Mike Babcock
 
 
PS: Want a ONE-TIME comprehensive local plan that covers everything? 
https://www.speed-seo.net/product/local-seo-bundle/', 3)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (26, N'Merri Lindon', N'905-625-5299', N'merri.lindon@gmail.com', CAST(N'2024-03-25T18:26:41.0722976' AS DateTime2), N'Hi,

Want thousands of clients? We have compiled a list of all consumers and business''s across 149 countries for you.

We have a special that is running today and valid till the end of the day. Come check us out:

https://usbdproperty.leadsmax.biz/

Consumer Records: 294,582,351
Business Records: 25,215,278

Selling at $99 today only.', 3)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (27, N'Mike Black
', N'mikeAllowsscous@gmail.com', N'mikeAllowsscous@gmail.com', CAST(N'2024-03-25T18:52:06.9579028' AS DateTime2), N'Hi there 
 
Just checked your usbdproperty.com baclink profile, I noticed a moderate percentage of toxic links pointing to your website 
 
We will investigate each link for its toxicity and perform a professional clean up for you free of charge. 
 
Start recovering your ranks today: 
https://www.hilkom-digital.de/professional-linksprofile-clean-up-service/ 
 
Regards 
Mike Black
Hilkom Digital SEO Experts 
https://www.hilkom-digital.de/', 3)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (28, N'Foysal', N'0175820365', N'foysal12@gmail.com', CAST(N'2024-03-28T10:39:42.4627211' AS DateTime2), N'nddd', 1)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (29, N'Labonno', N'0125463156', N'labonno12@gmail.com', CAST(N'2024-03-28T10:40:45.3502205' AS DateTime2), N'daf', 3)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (30, N'ukfarhana', N'565232', N'ukfarhana23@gmail.com', CAST(N'2024-03-30T10:44:11.8044247' AS DateTime2), N'dsa', 0)
SET IDENTITY_INSERT [dbo].[ClientContacts] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (1, N'Bangladesh')
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (2, N'United States')
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[DevelopersorAgent] ON 

INSERT [dbo].[DevelopersorAgent] ([ID], [Logo], [Banner], [CompanyName], [ContactNo], [Email], [Name], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [Address], [AreaID], [Membership], [AboutUs]) VALUES (8, N'/Developer/Logo/ Dhorittree LTD logo .png', N'/Developer/Banner/ Dhorittree LTD banner .jpg', N'Dhorittree LTD', N'880 1881-660077', N'asd@gmail.com', N'Tipu', CAST(N'2024-02-23T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2024-02-23T00:00:00.0000000' AS DateTime2), N'devshahanaj123@gmail.com', 1, N'Kazipara', 1, 1, N'<p>Dhorittree Properties LTD</p>
')
SET IDENTITY_INSERT [dbo].[DevelopersorAgent] OFF
GO
SET IDENTITY_INSERT [dbo].[Divisions] ON 

INSERT [dbo].[Divisions] ([DivisionID], [DivisionName], [CountryId]) VALUES (1, N'Dhaka', 1)
INSERT [dbo].[Divisions] ([DivisionID], [DivisionName], [CountryId]) VALUES (2, N'Rangpur', 1)
INSERT [dbo].[Divisions] ([DivisionID], [DivisionName], [CountryId]) VALUES (3, N'Newyork', 2)
SET IDENTITY_INSERT [dbo].[Divisions] OFF
GO
SET IDENTITY_INSERT [dbo].[MeasurementUnit] ON 

INSERT [dbo].[MeasurementUnit] ([Id], [Name], [ShortName]) VALUES (1, N'Square Fit', N'SQFT')
INSERT [dbo].[MeasurementUnit] ([Id], [Name], [ShortName]) VALUES (2, N'Katha', N'katha')
INSERT [dbo].[MeasurementUnit] ([Id], [Name], [ShortName]) VALUES (3, N'shotok', N'shotok')
SET IDENTITY_INSERT [dbo].[MeasurementUnit] OFF
GO
SET IDENTITY_INSERT [dbo].[Notices] ON 

INSERT [dbo].[Notices] ([NoticeID], [Title], [Description], [Path], [StartDate], [EndDate], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [IsFeatured], [ImagePath]) VALUES (2, N'Offer', N'<p>Offer</p>
', N'/Content/Images/Offer.jpeg', CAST(N'2024-02-14T15:22:00.0000000' AS DateTime2), CAST(N'2024-04-03T15:22:00.0000000' AS DateTime2), CAST(N'2024-02-02T15:22:15.0069728' AS DateTime2), N'Umme', CAST(N'2024-03-30T10:09:51.8767950' AS DateTime2), N'devshahanaj123@gmail.com', 1, 1, N'/Content/Images/Offer.jpeg')
INSERT [dbo].[Notices] ([NoticeID], [Title], [Description], [Path], [StartDate], [EndDate], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [IsFeatured], [ImagePath]) VALUES (3, N'Share building', N'<p>Share building. For more infomation call at 01881660077.</p>
', N'', CAST(N'2024-02-01T16:25:00.0000000' AS DateTime2), CAST(N'2024-02-29T16:25:00.0000000' AS DateTime2), CAST(N'2024-02-23T00:00:00.0000000' AS DateTime2), N'p', CAST(N'2024-02-23T16:35:03.9412819' AS DateTime2), N'devshahanaj123@gmail.com', 1, 1, N'/Content/Images/Share building.jpg')
INSERT [dbo].[Notices] ([NoticeID], [Title], [Description], [Path], [StartDate], [EndDate], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [IsFeatured], [ImagePath]) VALUES (4, N'লিপইয়ার অফার', N'<p>লিপইয়ার অফার: বুকিং দিলেই ২০,০০০/-টাকা দামের মোবাইল উপহার।&nbsp;<br />
&nbsp;বুকিং মানি মাত্র ১লক্ষ টাকা&nbsp;<br />
৫০% সাশ্রয়ে ৩ বছরে হস্তান্তরযোগ্য ১০০০ ও ১৪৪০ বর্গফুটের ফ্ল্যাট;&nbsp;<br />
🙏নির্মাণ খরচ ৩ বছরের কিস্তিতে পরিশোধ করার সুবিধা;</p>

<p>ঢাকার জিরো পয়েন্ট থেকে মাত্র ২০/২৫ মিনিটের দূরত্বে শব্দদূষণ, বায়ুদূষণ ও কোলাহলমুক্ত সবুজের মাঝে পাখির কিচিরমিচির কলরবে সকাল হয় এমন এক নৈসর্গিক প্রাকৃতিক পরিবেশে আপনার ফ্ল্যাট। লিফটসহ অত্যাধুনিক বিল্ডিং।<br />
সুধী,&nbsp;<br />
পদ্মা সেতুকে কেন্দ্র করে উন্মোচিত হয়েছে অর্থ-বাণিজ্যের নব দিগন্ত, গড়ে উঠছে স্যাটেলাইট সিটি, অলিম্পিক ভিলেজ, আধুনিক শিল্পনগরী, বঙ্গবন্ধু ইন্টারন্যাশনাল এয়ারপোর্ট, হংকং-সিংগাপুরের মত ব্যস্ততম বাণিজ্যিক এলাকা এবং মালেশিয়ার পুত্রাজায়ার মত প্রশাসনিক রাজধানী এবং পর্যটন শিল্প নগরী।<br />
বাংলাদেশের শ্রেষ্ঠ রাস্তা ৪০০ ফুট প্রশস্ত ঢাকা মাওয়া &nbsp;মেইন রোড সংলগ্ন ধরিত্রী গার্ডেন সিটির &quot;এ&quot; ব্লকে সরকারের ৪০ ফুট প্রশস্ত রাস্তার সাথে রেডি প্লটে জমির মালিকানাসহ শেয়ার বিল্ডিং এ ফ্ল্যাট বিক্রয় চলছে।&nbsp;<br />
বিল্ডিং এর পাশেই হাইওয়ে পুলিশ থানা, বাংলা মিডিয়াম স্কুল, ইংলিশ মিডিয়াম স্কুল, বাজার ও মসজিদ ইত্যাদি নাগরিক সুবিধা বিদ্যমান। আমাদের ফেসবুক পেইজঃ<br />
https://www.facebook.com/dhorittreepropertiesltd&nbsp;<br />
👍 ১০০০ বর্গফুট ফ্ল্যাটের বিস্তারিত :&nbsp;<br />
জমির পরিমাণ: ৫.৫ কাঠা (জি+৯) প্রতি ফ্লোরে ৩টি করে ইউনিটে মোট ২৭টি ফ্ল্যাট<br />
শেয়ার মূল্যঃ ৪,৫০,০০০/-টাকা।<br />
(এই জমিটি আমাদের কোম্পানির অনেক আগে ক্রয় করা ছিল বিধায় জমির শেয়ার অনেক কম মূল্যে পাচ্ছেন। ২য় বিল্ডিং থেকে জমির শেয়ার মূল্য হবে ৬,০০,০০০+)<br />
সম্ভাব্য নির্মাণ খরচ &nbsp;২০ লক্ষ+-<br />
সম্ভাব্য মোট খরচ :<br />
২৪,৫০,০০০/- +- টাকা।</p>

<p>👍 ১৪৪০ বর্গফুট ফ্ল্যাটের বিস্তারিত :&nbsp;<br />
শেয়ার মূল্যঃ ৭,৫০,০০০০/-<br />
(এই জমিটি আমাদের কোম্পানির অনেক আগে ক্রয় করা ছিল বিধায় জমির শেয়ার অনেক কম মূল্যে পাচ্ছেন। পরবর্তী বিল্ডিং থেকে জমির শেয়ার মূল্য হবে ৯,০০,০০০+)<br />
&nbsp;জমির পরিমাণ: ৫.৫ কাঠা ( জি+৯) প্রতি ফ্লোরে ২টি করে ইউনিটে মোট ১৮ টি ফ্ল্যাট।&nbsp;<br />
সম্ভাব্য নির্মাণ খরচ: ২৯ লক্ষ+-</p>

<p>মোট খরচ: ৩৬,৫০,০০০/- +-</p>

<p>&nbsp;উভয় বিল্ডিং এ পার্কিং মূল্য ২,০০,০০০/- টাকা।&nbsp;<br />
১০ জন কনফার্ম করার পর পার্কিং সুযোগ থাকবে না। প্রথমে ৫০,০০০/- দিয়ে কনফার্মেশন করে জমি রেজিস্ট্রেশনের সময় পার্কিং এর বাকি মূল্য প্রদান করতে হবে।<br />
*প্রকল্পের লোকেশন ম্যাপ: https://goo.gl/maps/8Zu4ugBSaxgG9ehn9&nbsp;</p>

<p>🙏যেহেতু আপনার অংশের জমি এখনই আপনার নামে রেজিস্ট্রেশন হয়ে যাচ্ছে তাই আপনার বিনিয়োগ ১০০% সুরক্ষিত ইনশাআল্লাহ।&nbsp;<br />
👉এছাড়াও আমাদের প্রকল্পে রয়েছে আন্তর্জাতিক মানের মার্কেটের দোকান, ফাইভ &nbsp;স্টার হোটেলের শেয়ার এবং ৩,৫,১০ ও ২০ কাঠার প্লট বুকিং এর সুবর্ণ &nbsp;সুযোগ।<br />
&nbsp;প্রত্যেকটি জমির আমরা ক্রয়সূত্রে মালিক।&nbsp;<br />
বাংলাদেশ সরকারের জাতীয় গৃহায়ন কর্তৃক নিবন্ধিত। জাগৃক:১০।<br />
ধরিত্রী প্রপার্টিজ লি:<br />
অফিসের ঠিকানাঃ<br />
শামসুন্নাহার কমপ্লেক্স,<br />
6-A,31/C/1 তোপখানা রোড, সেগুন বাগিচা, শাহাবাগ,ঢাকা-১০০০। &nbsp;<br />
আমাদের ওয়েবসাইট লিংকঃ<br />
www.dhorittree.com</p>

<p>Mail: dhorittree@outlook.com<br />
প্রকল্প ভিজিট করতে বা বিস্তারিত জানতে যোগাযোগ করুন&nbsp;</p>
', N'', CAST(N'2024-02-25T11:15:00.0000000' AS DateTime2), CAST(N'2024-02-29T11:15:00.0000000' AS DateTime2), CAST(N'2024-02-25T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 1, 0, N'')
INSERT [dbo].[Notices] ([NoticeID], [Title], [Description], [Path], [StartDate], [EndDate], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [IsFeatured], [ImagePath]) VALUES (5, N'লিপইয়ার অফার', N'<p>লিপইয়ার অফার: বুকিং দিলেই ২০,০০০/-টাকা দামের মোবাইল উপহার।&nbsp;<br />
&nbsp;বুকিং মানি মাত্র ১লক্ষ টাকা&nbsp;<br />
৫০% সাশ্রয়ে ৩ বছরে হস্তান্তরযোগ্য ১০০০ ও ১৪৪০ বর্গফুটের ফ্ল্যাট;&nbsp;<br />
🙏নির্মাণ খরচ ৩ বছরের কিস্তিতে পরিশোধ করার সুবিধা;</p>

<p>ঢাকার জিরো পয়েন্ট থেকে মাত্র ২০/২৫ মিনিটের দূরত্বে শব্দদূষণ, বায়ুদূষণ ও কোলাহলমুক্ত সবুজের মাঝে পাখির কিচিরমিচির কলরবে সকাল হয় এমন এক নৈসর্গিক প্রাকৃতিক পরিবেশে আপনার ফ্ল্যাট। লিফটসহ অত্যাধুনিক বিল্ডিং।<br />
সুধী,&nbsp;<br />
পদ্মা সেতুকে কেন্দ্র করে উন্মোচিত হয়েছে অর্থ-বাণিজ্যের নব দিগন্ত, গড়ে উঠছে স্যাটেলাইট সিটি, অলিম্পিক ভিলেজ, আধুনিক শিল্পনগরী, বঙ্গবন্ধু ইন্টারন্যাশনাল এয়ারপোর্ট, হংকং-সিংগাপুরের মত ব্যস্ততম বাণিজ্যিক এলাকা এবং মালেশিয়ার পুত্রাজায়ার মত প্রশাসনিক রাজধানী এবং পর্যটন শিল্প নগরী।<br />
বাংলাদেশের শ্রেষ্ঠ রাস্তা ৪০০ ফুট প্রশস্ত ঢাকা মাওয়া &nbsp;মেইন রোড সংলগ্ন ধরিত্রী গার্ডেন সিটির &quot;এ&quot; ব্লকে সরকারের ৪০ ফুট প্রশস্ত রাস্তার সাথে রেডি প্লটে জমির মালিকানাসহ শেয়ার বিল্ডিং এ ফ্ল্যাট বিক্রয় চলছে।&nbsp;<br />
বিল্ডিং এর পাশেই হাইওয়ে পুলিশ থানা, বাংলা মিডিয়াম স্কুল, ইংলিশ মিডিয়াম স্কুল, বাজার ও মসজিদ ইত্যাদি নাগরিক সুবিধা বিদ্যমান। আমাদের ফেসবুক পেইজঃ<br />
https://www.facebook.com/dhorittreepropertiesltd&nbsp;<br />
👍 ১০০০ বর্গফুট ফ্ল্যাটের বিস্তারিত :&nbsp;<br />
জমির পরিমাণ: ৫.৫ কাঠা (জি+৯) প্রতি ফ্লোরে ৩টি করে ইউনিটে মোট ২৭টি ফ্ল্যাট<br />
শেয়ার মূল্যঃ ৪,৫০,০০০/-টাকা।<br />
(এই জমিটি আমাদের কোম্পানির অনেক আগে ক্রয় করা ছিল বিধায় জমির শেয়ার অনেক কম মূল্যে পাচ্ছেন। ২য় বিল্ডিং থেকে জমির শেয়ার মূল্য হবে ৬,০০,০০০+)<br />
সম্ভাব্য নির্মাণ খরচ &nbsp;২০ লক্ষ+-<br />
সম্ভাব্য মোট খরচ :<br />
২৪,৫০,০০০/- +- টাকা।</p>

<p>👍 ১৪৪০ বর্গফুট ফ্ল্যাটের বিস্তারিত :&nbsp;<br />
শেয়ার মূল্যঃ ৭,৫০,০০০০/-<br />
(এই জমিটি আমাদের কোম্পানির অনেক আগে ক্রয় করা ছিল বিধায় জমির শেয়ার অনেক কম মূল্যে পাচ্ছেন। পরবর্তী বিল্ডিং থেকে জমির শেয়ার মূল্য হবে ৯,০০,০০০+)<br />
&nbsp;জমির পরিমাণ: ৫.৫ কাঠা ( জি+৯) প্রতি ফ্লোরে ২টি করে ইউনিটে মোট ১৮ টি ফ্ল্যাট।&nbsp;<br />
সম্ভাব্য নির্মাণ খরচ: ২৯ লক্ষ+-</p>

<p>মোট খরচ: ৩৬,৫০,০০০/- +-</p>

<p>&nbsp;উভয় বিল্ডিং এ পার্কিং মূল্য ২,০০,০০০/- টাকা।&nbsp;<br />
১০ জন কনফার্ম করার পর পার্কিং সুযোগ থাকবে না। প্রথমে ৫০,০০০/- দিয়ে কনফার্মেশন করে জমি রেজিস্ট্রেশনের সময় পার্কিং এর বাকি মূল্য প্রদান করতে হবে।<br />
*প্রকল্পের লোকেশন ম্যাপ: https://goo.gl/maps/8Zu4ugBSaxgG9ehn9&nbsp;</p>

<p>🙏যেহেতু আপনার অংশের জমি এখনই আপনার নামে রেজিস্ট্রেশন হয়ে যাচ্ছে তাই আপনার বিনিয়োগ ১০০% সুরক্ষিত ইনশাআল্লাহ।&nbsp;<br />
👉এছাড়াও আমাদের প্রকল্পে রয়েছে আন্তর্জাতিক মানের মার্কেটের দোকান, ফাইভ &nbsp;স্টার হোটেলের শেয়ার এবং ৩,৫,১০ ও ২০ কাঠার প্লট বুকিং এর সুবর্ণ &nbsp;সুযোগ।<br />
&nbsp;প্রত্যেকটি জমির আমরা ক্রয়সূত্রে মালিক।&nbsp;<br />
বাংলাদেশ সরকারের জাতীয় গৃহায়ন কর্তৃক নিবন্ধিত। জাগৃক:১০।<br />
ধরিত্রী প্রপার্টিজ লি:<br />
অফিসের ঠিকানাঃ<br />
শামসুন্নাহার কমপ্লেক্স,<br />
6-A,31/C/1 তোপখানা রোড, সেগুন বাগিচা, শাহাবাগ,ঢাকা-১০০০। &nbsp;<br />
আমাদের ওয়েবসাইট লিংকঃ<br />
www.dhorittree.com</p>

<p>Mail: dhorittree@outlook.com<br />
প্রকল্প ভিজিট করতে বা বিস্তারিত জানতে যোগাযোগ করুন&nbsp;</p>
', N'/Content/Images/লিপইয়ার অফার.jpeg', CAST(N'2024-02-25T11:17:00.0000000' AS DateTime2), CAST(N'2024-02-29T11:17:00.0000000' AS DateTime2), CAST(N'2024-02-25T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 1, 1, N'/Content/Images/লিপইয়ার অফার.jpeg')
SET IDENTITY_INSERT [dbo].[Notices] OFF
GO
SET IDENTITY_INSERT [dbo].[ProjectsInfo] ON 

INSERT [dbo].[ProjectsInfo] ([Id], [Title], [Description], [ProjectName], [Location], [LocationMap], [AgentID], [AreaID], [ProjectVideo]) VALUES (4, N'DHORITTREE GARDEN CITY', N'<h2>Dhorittree Garden City</h2>
', N'DHORITTREE GARDEN CITY', N'Mohammadpur Salimullah Road', NULL, 8, 2, N'/Developer/Video/ DHORITTREE GARDEN CITY _video .mp4')
INSERT [dbo].[ProjectsInfo] ([Id], [Title], [Description], [ProjectName], [Location], [LocationMap], [AgentID], [AreaID], [ProjectVideo]) VALUES (5, N'DHORITTREE CONDOMINIUM FLAT​', N'<p>Dhorittree Condominium Flat</p>
', N'DHORITTREE CONDOMINIUM FLAT​', N'Mirpur Mina Bazar', NULL, 8, 1, N'/Developer/Video/ DHORITTREE CONDOMINIUM FLAT​ _video .mp4')
INSERT [dbo].[ProjectsInfo] ([Id], [Title], [Description], [ProjectName], [Location], [LocationMap], [AgentID], [AreaID], [ProjectVideo]) VALUES (6, N'SHOHOJ GRIHAYON PREMIUM', N'<p>Shohoj Grihayon Premium</p>
', N'SHOHOJ GRIHAYON PREMIUM', N'Mirpur-1', NULL, 8, 1, N'/Developer/Video/ SHOHOJ GRIHAYON PREMIUM _video .mp4')
INSERT [dbo].[ProjectsInfo] ([Id], [Title], [Description], [ProjectName], [Location], [LocationMap], [AgentID], [AreaID], [ProjectVideo]) VALUES (7, N'DHORITTREE GREEN ACRES', N'<h2>Dhorittree Green Acres</h2>
', N'DHORITTREE GREEN ACRES', N'Segun bagicha', NULL, 8, 1, N'/Developer/Video/ DHORITTREE GREEN ACRES _video .mp4')
INSERT [dbo].[ProjectsInfo] ([Id], [Title], [Description], [ProjectName], [Location], [LocationMap], [AgentID], [AreaID], [ProjectVideo]) VALUES (8, N'SHOHOJ GRIHAYON GOLDEN CHANCE-1200', N'<p>Shohoj Grihayon Golden Chance-1200</p>
', N'SHOHOJ GRIHAYON GOLDEN CHANCE-1200', N'Mirpur-12', NULL, 8, 1, N'/Developer/Video/ SHOHOJ GRIHAYON GOLDEN CHANCE-1200 _video .mp4')
INSERT [dbo].[ProjectsInfo] ([Id], [Title], [Description], [ProjectName], [Location], [LocationMap], [AgentID], [AreaID], [ProjectVideo]) VALUES (9, N'SHOHOJ GRIHAYON GOLDEN CHANCE', N'<h2>Shohoj Grihayon Golden Chance</h2>
', N'SHOHOJ GRIHAYON GOLDEN CHANCE', N'Mirpur-10', NULL, 8, 1, N'/Developer/Video/ SHOHOJ GRIHAYON GOLDEN CHANCE _video .mp4')
INSERT [dbo].[ProjectsInfo] ([Id], [Title], [Description], [ProjectName], [Location], [LocationMap], [AgentID], [AreaID], [ProjectVideo]) VALUES (10, N'SHOHOJ GRIHAYON LUXURY', N'<p>Shohoj Grihayon Luxury</p>
', N'SHOHOJ GRIHAYON LUXURY', N'Agargaon , Dhaka', NULL, 8, 1, N'/Developer/Video/ SHOHOJ GRIHAYON LUXURY _video .mp4')
INSERT [dbo].[ProjectsInfo] ([Id], [Title], [Description], [ProjectName], [Location], [LocationMap], [AgentID], [AreaID], [ProjectVideo]) VALUES (14, N'Share Building', N'<p>Share Building</p>
', N'Share Building', N'Dhaka Mawa Main Road', NULL, 8, 4, N'/Developer/Video/ Share Building _video .mp4')
SET IDENTITY_INSERT [dbo].[ProjectsInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[PropertyDetails] ON 

INSERT [dbo].[PropertyDetails] ([PropertyInfoId], [Title], [Description], [PropertyName], [Location], [ConstructionStatus], [PropertySize], [NumberOfBedrooms], [NumberOfBaths], [NumberOfBalconies], [NumberOfGarages], [TotalFloor], [FloorAvailableNo], [Furnishing], [Facing], [LandArea], [Price], [Path], [Comments], [PropertyCondition], [HandOverDate], [PropertyTypeId], [ProjectId], [AreaId], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [PropertyFor], [ISFeatured], [MeasurementID], [FlatSize], [LandPrice], [ImagePath], [IsLand], [IsSold]) VALUES (10, N'dsa', N'<p>fds</p>
', NULL, N'567(2nd floor), East Kazipara,Kazipara,Mirpur,Dhaka-1216', 2, NULL, 3, 2, 3, 1, 2, 2, 2, 1, 12, 5000, NULL, N'fgds', 2, CAST(N'2024-08-28T00:00:00.0000000' AS DateTime2), 5, 4, 1, CAST(N'2024-08-29T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2024-08-29T15:55:34.9156383' AS DateTime2), N'devshahanaj123@gmail.com', 1, 2, 1, 1, 1200, NULL, N'/Content/Images/dsa.jpg', 0, 0)
INSERT [dbo].[PropertyDetails] ([PropertyInfoId], [Title], [Description], [PropertyName], [Location], [ConstructionStatus], [PropertySize], [NumberOfBedrooms], [NumberOfBaths], [NumberOfBalconies], [NumberOfGarages], [TotalFloor], [FloorAvailableNo], [Furnishing], [Facing], [LandArea], [Price], [Path], [Comments], [PropertyCondition], [HandOverDate], [PropertyTypeId], [ProjectId], [AreaId], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [PropertyFor], [ISFeatured], [MeasurementID], [FlatSize], [LandPrice], [ImagePath], [IsLand], [IsSold]) VALUES (11, N'gs', N'<p>fg fds</p>
', NULL, N'567(2nd floor), East Kazipara,Kazipara,Mirpur,Dhaka-1216', 2, NULL, 3, 3, 2, 1, 10, 7, 2, 2, 12, 300, NULL, N'fdg', 1, CAST(N'2024-08-28T00:00:00.0000000' AS DateTime2), 5, 5, 1, CAST(N'2024-08-29T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2024-08-29T15:57:22.9238200' AS DateTime2), N'devshahanaj123@gmail.com', 1, 2, 1, 1, 0, NULL, N'/Content/Images/gs.jpg', 0, 0)
INSERT [dbo].[PropertyDetails] ([PropertyInfoId], [Title], [Description], [PropertyName], [Location], [ConstructionStatus], [PropertySize], [NumberOfBedrooms], [NumberOfBaths], [NumberOfBalconies], [NumberOfGarages], [TotalFloor], [FloorAvailableNo], [Furnishing], [Facing], [LandArea], [Price], [Path], [Comments], [PropertyCondition], [HandOverDate], [PropertyTypeId], [ProjectId], [AreaId], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [PropertyFor], [ISFeatured], [MeasurementID], [FlatSize], [LandPrice], [ImagePath], [IsLand], [IsSold]) VALUES (12, N'Dhorittree Land', N'<p>sads ds</p>
', NULL, N'567(2nd floor), East Kazipara,Kazipara,Mirpur,Dhak', 0, NULL, 0, 0, 0, 0, 0, 0, NULL, 0, 5, 0, NULL, N'asd', 0, CAST(N'2024-08-29T00:00:00.0000000' AS DateTime2), 9, 4, 2, CAST(N'2024-08-31T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2024-08-31T11:37:08.1748056' AS DateTime2), N'devshahanaj123@gmail.com', 1, 2, 1, 2, 0, 700, N'/Content/Images/Dhorittree Land.jpg', 0, 0)
INSERT [dbo].[PropertyDetails] ([PropertyInfoId], [Title], [Description], [PropertyName], [Location], [ConstructionStatus], [PropertySize], [NumberOfBedrooms], [NumberOfBaths], [NumberOfBalconies], [NumberOfGarages], [TotalFloor], [FloorAvailableNo], [Furnishing], [Facing], [LandArea], [Price], [Path], [Comments], [PropertyCondition], [HandOverDate], [PropertyTypeId], [ProjectId], [AreaId], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [PropertyFor], [ISFeatured], [MeasurementID], [FlatSize], [LandPrice], [ImagePath], [IsLand], [IsSold]) VALUES (13, N'Dhorittree  Commercial Land', N'<p>বুকিং মানি মাত্র ১লক্ষ টাকা</p>

<p>৫০% সাশ্রয়ে ৩ বছরে হস্তান্তরযোগ্য ১০০০ ও ১৪৪০ বর্গফুটের ফ্ল্যাট;</p>

<p>🙏নির্মাণ খরচ ৩ বছরের কিস্তিতে পরিশোধ করার সুবিধা;</p>

<p>&nbsp;</p>

<p>ঢাকার জিরো পয়েন্ট থেকে মাত্র ২০/২৫ মিনিটের দূরত্বে শব্দদূষণ, বায়ুদূষণ ও কোলাহলমুক্ত সবুজের মাঝে পাখির কিচিরমিচির কলরবে সকাল হয় এমন এক নৈসর্গিক প্রাকৃতিক পরিবেশে আপনার ফ্ল্যাট। লিফটসহ অত্যাধুনিক বিল্ডিং।</p>

<p>সুধী,</p>

<p>পদ্মা সেতুকে কেন্দ্র করে উন্মোচিত হয়েছে অর্থ-বাণিজ্যের নব দিগন্ত, গড়ে উঠছে স্যাটেলাইট সিটি, অলিম্পিক ভিলেজ, আধুনিক শিল্পনগরী, বঙ্গবন্ধু ইন্টারন্যাশনাল এয়ারপোর্ট, হংকং-সিংগাপুরের মত ব্যস্ততম বাণিজ্যিক এলাকা এবং মালেশিয়ার পুত্রাজায়ার মত প্রশাসনিক রাজধানী এবং পর্যটন শিল্প নগরী।</p>

<p>বাংলাদেশের শ্রেষ্ঠ রাস্তা ৪০০ ফুট প্রশস্ত ঢাকা মাওয়া&nbsp; মেইন রোড সংলগ্ন ধরিত্রী গার্ডেন সিটির &quot;এ&quot; ব্লকে সরকারের ৪০ ফুট প্রশস্ত রাস্তার সাথে রেডি প্লটে জমির মালিকানাসহ শেয়ার বিল্ডিং এ ফ্ল্যাট বিক্রয় চলছে।</p>

<p>বিল্ডিং এর পাশেই হাইওয়ে পুলিশ থানা, বাংলা মিডিয়াম স্কুল, ইংলিশ মিডিয়াম স্কুল, বাজার ও মসজিদ ইত্যাদি নাগরিক সুবিধা বিদ্যমান। আমাদের ফেসবুক পেইজঃ</p>

<p>https://www.facebook.com/dhorittreepropertiesltd</p>

<p>👍 ১০০০ বর্গফুট ফ্ল্যাটের বিস্তারিত :</p>

<p>জমির পরিমাণ: ৫.৫ কাঠা (জি+৯) প্রতি ফ্লোরে ৩টি করে ইউনিটে মোট ২৭টি ফ্ল্যাট</p>

<p>শেয়ার মূল্যঃ ৫,০০,০০০/-টাকা।</p>

<p>(এই জমিটি আমাদের কোম্পানির অনেক আগে ক্রয় করা ছিল বিধায় জমির শেয়ার অনেক কম মূল্যে পাচ্ছেন। ২য় বিল্ডিং থেকে জমির শেয়ার মূল্য হবে ৬,০০,০০০+)</p>

<p>সম্ভাব্য নির্মাণ খরচ&nbsp; ২০ লক্ষ+-</p>

<p>সম্ভাব্য মোট খরচ :</p>

<p>২৫,০০,০০০/- +- টাকা।</p>

<p>&nbsp;</p>

<p>👍 ১৪৪০ বর্গফুট ফ্ল্যাটের বিস্তারিত :</p>

<p>শেয়ার মূল্যঃ ৮,০০,০০০/-</p>

<p>(এই জমিটি আমাদের কোম্পানির অনেক আগে ক্রয় করা ছিল বিধায় জমির শেয়ার অনেক কম মূল্যে পাচ্ছেন। পরবর্তী বিল্ডিং থেকে জমির শেয়ার মূল্য হবে ৯,০০,০০০+)</p>

<p>&nbsp;জমির পরিমাণ: ৫.৫ কাঠা ( জি+৯) প্রতি ফ্লোরে ২টি করে ইউনিটে মোট ১৮ টি ফ্ল্যাট।</p>

<p>সম্ভাব্য নির্মাণ খরচ: ২৯ লক্ষ+-</p>

<p>&nbsp;</p>

<p>মোট খরচ: ৩৭,০০,০০০/- +-</p>

<p>&nbsp;</p>

<p>&nbsp;উভয় বিল্ডিং এ পার্কিং মূল্য ২,০০,০০০/- টাকা।</p>

<p>১০ জন কনফার্ম করার পর পার্কিং সুযোগ থাকবে না। প্রথমে ৫০,০০০/- দিয়ে কনফার্মেশন করে জমি রেজিস্ট্রেশনের সময় পার্কিং এর বাকি মূল্য প্রদান করতে হবে।</p>

<p>*প্রকল্পের লোকেশন ম্যাপ: https://goo.gl/maps/8Zu4ugBSaxgG9ehn9</p>

<p>&nbsp;</p>

<p>🙏যেহেতু আপনার অংশের জমি এখনই আপনার নামে রেজিস্ট্রেশন হয়ে যাচ্ছে তাই আপনার বিনিয়োগ ১০০% সুরক্ষিত ইনশাআল্লাহ।</p>

<p>👉এছাড়াও আমাদের প্রকল্পে রয়েছে আন্তর্জাতিক মানের মার্কেটের দোকান, ফাইভ&nbsp; স্টার হোটেলের শেয়ার এবং ৩,৫,১০ ও ২০ কাঠার প্লট বুকিং এর সুবর্ণ&nbsp; সুযোগ।</p>

<p>&nbsp;প্রত্যেকটি জমির আমরা ক্রয়সূত্রে মালিক।</p>

<p>বাংলাদেশ সরকারের জাতীয় গৃহায়ন কর্তৃক নিবন্ধিত। জাগৃক:১০।</p>

<p>ধরিত্রী প্রপার্টিজ লি:</p>

<p>অফিসের ঠিকানাঃ</p>

<p>শামসুন্নাহার কমপ্লেক্স,</p>

<p>6-A,31/C/1 তোপখানা রোড, সেগুন বাগিচা, শাহাবাগ,ঢাকা-১০০০।&nbsp;</p>

<p>আমাদের ওয়েবসাইট লিংকঃ</p>

<p>www.dhorittree.com</p>

<p>&nbsp;</p>

<p>Mail: ashrafzaman008@gmail.com</p>

<p>Mobile number: Ashraf 01881660077(WhatsApp)</p>

<p>প্রকল্প ভিজিট করতে বা বিস্তারিত জানতে যোগাযোগ করুন 🤳</p>
', NULL, N'567(2nd floor), East Kazipara,Kazipara,Mirpur,Dhak', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 5, NULL, NULL, N'dsf', 0, CAST(N'2024-08-29T00:00:00.0000000' AS DateTime2), 9, 5, 4, CAST(N'2024-08-29T17:24:01.2006729' AS DateTime2), N'devshahanaj123@gmail.com', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 1, 2, 1, 3, 0, 1000, N'/Content/Images/Dhorittree  Commercial Land.jpeg', 0, 0)
INSERT [dbo].[PropertyDetails] ([PropertyInfoId], [Title], [Description], [PropertyName], [Location], [ConstructionStatus], [PropertySize], [NumberOfBedrooms], [NumberOfBaths], [NumberOfBalconies], [NumberOfGarages], [TotalFloor], [FloorAvailableNo], [Furnishing], [Facing], [LandArea], [Price], [Path], [Comments], [PropertyCondition], [HandOverDate], [PropertyTypeId], [ProjectId], [AreaId], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [PropertyFor], [ISFeatured], [MeasurementID], [FlatSize], [LandPrice], [ImagePath], [IsLand], [IsSold]) VALUES (14, N'Dhorittree Project', N'<p>dffg dsg fds</p>
', NULL, N'567(2nd floor), East Kazipara,Kazipara,Mirpur,Dhak', 3, NULL, 3, 3, 3, 1, 12, 10, 1, 3, 10, 700, NULL, N'dsf', 1, CAST(N'2024-08-31T00:00:00.0000000' AS DateTime2), 5, 9, 4, CAST(N'2024-08-31T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2024-08-31T11:36:39.3473325' AS DateTime2), N'devshahanaj123@gmail.com', 1, 2, 1, 2, 0, NULL, N'/Content/Images/Dhorittree Project.jpg', 0, 0)
INSERT [dbo].[PropertyDetails] ([PropertyInfoId], [Title], [Description], [PropertyName], [Location], [ConstructionStatus], [PropertySize], [NumberOfBedrooms], [NumberOfBaths], [NumberOfBalconies], [NumberOfGarages], [TotalFloor], [FloorAvailableNo], [Furnishing], [Facing], [LandArea], [Price], [Path], [Comments], [PropertyCondition], [HandOverDate], [PropertyTypeId], [ProjectId], [AreaId], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [PropertyFor], [ISFeatured], [MeasurementID], [FlatSize], [LandPrice], [ImagePath], [IsLand], [IsSold]) VALUES (15, N'SHARE BUILDING', N'<p>gfh</p>
', NULL, N'567(2nd floor), East Kazipara,Kazipara,Mirpur,Dhak', 4, NULL, 4, 3, 2, 1, 15, 12, 2, 4, 10, 1200, NULL, N'cxb', 2, CAST(N'2024-08-31T00:00:00.0000000' AS DateTime2), 5, 9, 1, CAST(N'2024-08-31T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2024-08-31T11:40:06.7202848' AS DateTime2), N'devshahanaj123@gmail.com', 1, 2, 1, 2, 0, NULL, N'/Content/Images/SHARE BUILDING.jpg', 0, 0)
INSERT [dbo].[PropertyDetails] ([PropertyInfoId], [Title], [Description], [PropertyName], [Location], [ConstructionStatus], [PropertySize], [NumberOfBedrooms], [NumberOfBaths], [NumberOfBalconies], [NumberOfGarages], [TotalFloor], [FloorAvailableNo], [Furnishing], [Facing], [LandArea], [Price], [Path], [Comments], [PropertyCondition], [HandOverDate], [PropertyTypeId], [ProjectId], [AreaId], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [PropertyFor], [ISFeatured], [MeasurementID], [FlatSize], [LandPrice], [ImagePath], [IsLand], [IsSold]) VALUES (16, N'SHARE BUILDING 20', N'<p>dfsgfgd</p>
', NULL, N'567(2nd floor), East Kazipara,Kazipara,Mirpur,Dhak', 2, NULL, 3, 3, 3, 1, 12, 10, 2, 2, 5, 3000, NULL, N'sd', 1, CAST(N'2024-08-31T00:00:00.0000000' AS DateTime2), 5, 9, 1, CAST(N'2024-08-31T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2024-08-31T11:39:41.3892097' AS DateTime2), N'devshahanaj123@gmail.com', 1, 2, 1, 2, 0, NULL, N'/Content/Images/SHARE BUILDING 20.jpg', 0, 0)
INSERT [dbo].[PropertyDetails] ([PropertyInfoId], [Title], [Description], [PropertyName], [Location], [ConstructionStatus], [PropertySize], [NumberOfBedrooms], [NumberOfBaths], [NumberOfBalconies], [NumberOfGarages], [TotalFloor], [FloorAvailableNo], [Furnishing], [Facing], [LandArea], [Price], [Path], [Comments], [PropertyCondition], [HandOverDate], [PropertyTypeId], [ProjectId], [AreaId], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [PropertyFor], [ISFeatured], [MeasurementID], [FlatSize], [LandPrice], [ImagePath], [IsLand], [IsSold]) VALUES (17, N'SHARE BUILDING 3', N'<p>ds</p>
', NULL, N'567(2nd floor), East Kazipara,Kazipara,Mirpur,Dhak', 3, NULL, 3, 3, 3, 1, 12, 10, 1, 2, 12, 3000, NULL, N'gh', 1, CAST(N'2024-08-31T00:00:00.0000000' AS DateTime2), 4, 6, 4, CAST(N'2024-08-31T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2024-08-31T11:38:16.1555775' AS DateTime2), N'devshahanaj123@gmail.com', 1, 2, 1, 2, 0, NULL, N'/Content/Images/SHARE BUILDING 3.jpg', 0, 0)
INSERT [dbo].[PropertyDetails] ([PropertyInfoId], [Title], [Description], [PropertyName], [Location], [ConstructionStatus], [PropertySize], [NumberOfBedrooms], [NumberOfBaths], [NumberOfBalconies], [NumberOfGarages], [TotalFloor], [FloorAvailableNo], [Furnishing], [Facing], [LandArea], [Price], [Path], [Comments], [PropertyCondition], [HandOverDate], [PropertyTypeId], [ProjectId], [AreaId], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [PropertyFor], [ISFeatured], [MeasurementID], [FlatSize], [LandPrice], [ImagePath], [IsLand], [IsSold]) VALUES (18, N'SHARE BUILDING 3', N'<p>fggd&nbsp;</p>
', NULL, N'567(2nd floor), East Kazipara,Kazipara,Mirpur,Dhak', 3, NULL, 3, 3, 3, 1, 12, 10, 2, 2, 10, 5000, NULL, N'fgdg', 1, CAST(N'2024-08-31T00:00:00.0000000' AS DateTime2), 4, 5, 2, CAST(N'2024-08-31T11:34:02.4750902' AS DateTime2), N'devshahanaj123@gmail.com', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 1, 2, 1, 2, 0, NULL, N'/Content/Images/SHARE BUILDING 3.jpg', 0, 0)
INSERT [dbo].[PropertyDetails] ([PropertyInfoId], [Title], [Description], [PropertyName], [Location], [ConstructionStatus], [PropertySize], [NumberOfBedrooms], [NumberOfBaths], [NumberOfBalconies], [NumberOfGarages], [TotalFloor], [FloorAvailableNo], [Furnishing], [Facing], [LandArea], [Price], [Path], [Comments], [PropertyCondition], [HandOverDate], [PropertyTypeId], [ProjectId], [AreaId], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [PropertyFor], [ISFeatured], [MeasurementID], [FlatSize], [LandPrice], [ImagePath], [IsLand], [IsSold]) VALUES (19, N'fggggd', N'<p>fdddg</p>
', NULL, N'567(2nd floor), East Kazipara,Kazipara,Mirpur,Dhak', 4, NULL, 3, 2, NULL, NULL, NULL, 2, 2, 2, 12, 3000, NULL, N'bvc', 1, CAST(N'2024-08-31T00:00:00.0000000' AS DateTime2), 5, 7, 4, CAST(N'2024-08-31T12:28:38.8764058' AS DateTime2), N'devshahanaj123@gmail.com', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 1, 2, 1, 2, 0, NULL, N'/Content/Images/fggggd.jpg', 0, 0)
INSERT [dbo].[PropertyDetails] ([PropertyInfoId], [Title], [Description], [PropertyName], [Location], [ConstructionStatus], [PropertySize], [NumberOfBedrooms], [NumberOfBaths], [NumberOfBalconies], [NumberOfGarages], [TotalFloor], [FloorAvailableNo], [Furnishing], [Facing], [LandArea], [Price], [Path], [Comments], [PropertyCondition], [HandOverDate], [PropertyTypeId], [ProjectId], [AreaId], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [PropertyFor], [ISFeatured], [MeasurementID], [FlatSize], [LandPrice], [ImagePath], [IsLand], [IsSold]) VALUES (20, N'Share Building Dhorittree project', N'<p>ghfjh&nbsp;</p>
', NULL, N'567(2nd floor), East Kazipara,Kazipara,Mirpur,Dhak', 2, NULL, 3, 3, 3, 1, 10, 7, 1, 1, 10, 3000, NULL, N'gh', 2, CAST(N'2024-08-31T00:00:00.0000000' AS DateTime2), 5, 9, 4, CAST(N'2024-08-31T12:31:04.4721247' AS DateTime2), N'devshahanaj123@gmail.com', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 1, 2, 1, 3, 0, NULL, N'/Content/Images/Share Building Dhorittree project.jpg', 0, 0)
INSERT [dbo].[PropertyDetails] ([PropertyInfoId], [Title], [Description], [PropertyName], [Location], [ConstructionStatus], [PropertySize], [NumberOfBedrooms], [NumberOfBaths], [NumberOfBalconies], [NumberOfGarages], [TotalFloor], [FloorAvailableNo], [Furnishing], [Facing], [LandArea], [Price], [Path], [Comments], [PropertyCondition], [HandOverDate], [PropertyTypeId], [ProjectId], [AreaId], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [PropertyFor], [ISFeatured], [MeasurementID], [FlatSize], [LandPrice], [ImagePath], [IsLand], [IsSold]) VALUES (21, N'Dhorrittree Project', N'<p>fdsg</p>
', NULL, N'567(2nd floor), East Kazipara,Kazipara,Mirpur,Dhaka-1216', 2, NULL, 3, 3, 2, 1, 12, 11, 1, 3, 2, 111, NULL, N'dff', 1, CAST(N'2024-09-14T00:00:00.0000000' AS DateTime2), 5, 9, 1, CAST(N'2024-09-07T12:14:47.9991425' AS DateTime2), N'devshahanaj123@gmail.com', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 1, 2, 1, 2, 0, NULL, N'/Content/Images/Dhorrittree Project.jpg', 0, 0)
SET IDENTITY_INSERT [dbo].[PropertyDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[PropertyFeatures] ON 

INSERT [dbo].[PropertyFeatures] ([PropertyFeatureId], [PropertyFeatureName], [FeatureDescription]) VALUES (1, N'Security', N'Security')
INSERT [dbo].[PropertyFeatures] ([PropertyFeatureId], [PropertyFeatureName], [FeatureDescription]) VALUES (2, N'Lift', N'Lift')
SET IDENTITY_INSERT [dbo].[PropertyFeatures] OFF
GO
SET IDENTITY_INSERT [dbo].[PropertyTypes] ON 

INSERT [dbo].[PropertyTypes] ([PropertyTypeId], [PropertyTypeName], [ParentPropertyTypeId], [IsLand]) VALUES (1, N'Apartment', 0, 0)
INSERT [dbo].[PropertyTypes] ([PropertyTypeId], [PropertyTypeName], [ParentPropertyTypeId], [IsLand]) VALUES (2, N'Land/Plot', 0, 0)
INSERT [dbo].[PropertyTypes] ([PropertyTypeId], [PropertyTypeName], [ParentPropertyTypeId], [IsLand]) VALUES (4, N'Residencial', 1, 0)
INSERT [dbo].[PropertyTypes] ([PropertyTypeId], [PropertyTypeName], [ParentPropertyTypeId], [IsLand]) VALUES (5, N'Commercial', 1, 0)
INSERT [dbo].[PropertyTypes] ([PropertyTypeId], [PropertyTypeName], [ParentPropertyTypeId], [IsLand]) VALUES (9, N'Commertial', 2, 1)
INSERT [dbo].[PropertyTypes] ([PropertyTypeId], [PropertyTypeName], [ParentPropertyTypeId], [IsLand]) VALUES (10, N'Residencial', 2, 1)
INSERT [dbo].[PropertyTypes] ([PropertyTypeId], [PropertyTypeName], [ParentPropertyTypeId], [IsLand]) VALUES (11, N'df', 4, 0)
SET IDENTITY_INSERT [dbo].[PropertyTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[PropertyWithFeatures] ON 

INSERT [dbo].[PropertyWithFeatures] ([ID], [PropertyId], [FeatureId]) VALUES (1, 13, 1)
INSERT [dbo].[PropertyWithFeatures] ([ID], [PropertyId], [FeatureId]) VALUES (2, 13, 2)
SET IDENTITY_INSERT [dbo].[PropertyWithFeatures] OFF
GO
SET IDENTITY_INSERT [dbo].[TermsConditions] ON 

INSERT [dbo].[TermsConditions] ([ID], [Title], [Description]) VALUES (2, N'cxfds', N'<p>dsa</p>
')
SET IDENTITY_INSERT [dbo].[TermsConditions] OFF
GO
/****** Object:  Index [IX_Areas_CityId]    Script Date: 9/8/2024 5:20:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_Areas_CityId] ON [dbo].[Areas]
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 9/8/2024 5:20:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 9/8/2024 5:20:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 9/8/2024 5:20:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 9/8/2024 5:20:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 9/8/2024 5:20:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 9/8/2024 5:20:09 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 9/8/2024 5:20:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AvailableFlatSizes_PropertyId]    Script Date: 9/8/2024 5:20:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_AvailableFlatSizes_PropertyId] ON [dbo].[AvailableFlatSizes]
(
	[PropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AvailableFlatSizes_UnitID]    Script Date: 9/8/2024 5:20:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_AvailableFlatSizes_UnitID] ON [dbo].[AvailableFlatSizes]
(
	[UnitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Citys_DivisionId]    Script Date: 9/8/2024 5:20:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_Citys_DivisionId] ON [dbo].[Citys]
(
	[DivisionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientInterest_ClientID]    Script Date: 9/8/2024 5:20:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_ClientInterest_ClientID] ON [dbo].[ClientInterest]
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientInterest_PropertyID]    Script Date: 9/8/2024 5:20:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_ClientInterest_PropertyID] ON [dbo].[ClientInterest]
(
	[PropertyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientInterest_PropertyTypeId]    Script Date: 9/8/2024 5:20:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_ClientInterest_PropertyTypeId] ON [dbo].[ClientInterest]
(
	[PropertyTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DevelopersorAgent_AreaID]    Script Date: 9/8/2024 5:20:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_DevelopersorAgent_AreaID] ON [dbo].[DevelopersorAgent]
(
	[AreaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Divisions_CountryId]    Script Date: 9/8/2024 5:20:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_Divisions_CountryId] ON [dbo].[Divisions]
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FloorPlans_PropertyInfoID]    Script Date: 9/8/2024 5:20:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_FloorPlans_PropertyInfoID] ON [dbo].[FloorPlans]
(
	[PropertyInfoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProjectImageGallery_ProjectID]    Script Date: 9/8/2024 5:20:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProjectImageGallery_ProjectID] ON [dbo].[ProjectImageGallery]
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProjectsInfo_AgentID]    Script Date: 9/8/2024 5:20:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProjectsInfo_AgentID] ON [dbo].[ProjectsInfo]
(
	[AgentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProjectsInfo_AreaID]    Script Date: 9/8/2024 5:20:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProjectsInfo_AreaID] ON [dbo].[ProjectsInfo]
(
	[AreaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyDetails_AreaId]    Script Date: 9/8/2024 5:20:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyDetails_AreaId] ON [dbo].[PropertyDetails]
(
	[AreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyDetails_MeasurementID]    Script Date: 9/8/2024 5:20:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyDetails_MeasurementID] ON [dbo].[PropertyDetails]
(
	[MeasurementID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyDetails_ProjectId]    Script Date: 9/8/2024 5:20:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyDetails_ProjectId] ON [dbo].[PropertyDetails]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyDetails_PropertyTypeId]    Script Date: 9/8/2024 5:20:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyDetails_PropertyTypeId] ON [dbo].[PropertyDetails]
(
	[PropertyTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyImages_propertyInfoId]    Script Date: 9/8/2024 5:20:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyImages_propertyInfoId] ON [dbo].[PropertyImages]
(
	[propertyInfoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyWithFeatures_FeatureId]    Script Date: 9/8/2024 5:20:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyWithFeatures_FeatureId] ON [dbo].[PropertyWithFeatures]
(
	[FeatureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyWithFeatures_PropertyId]    Script Date: 9/8/2024 5:20:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyWithFeatures_PropertyId] ON [dbo].[PropertyWithFeatures]
(
	[PropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ClientContacts] ADD  DEFAULT ((0)) FOR [Interested]
GO
ALTER TABLE [dbo].[DevelopersorAgent] ADD  DEFAULT (N'') FOR [Address]
GO
ALTER TABLE [dbo].[DevelopersorAgent] ADD  DEFAULT ((0)) FOR [AreaID]
GO
ALTER TABLE [dbo].[DevelopersorAgent] ADD  DEFAULT ((0)) FOR [Membership]
GO
ALTER TABLE [dbo].[DevelopersorAgent] ADD  DEFAULT (N'') FOR [AboutUs]
GO
ALTER TABLE [dbo].[Notices] ADD  CONSTRAINT [DF_Notices_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Notices] ADD  CONSTRAINT [DF__Notices__IsFeatu__2739D489]  DEFAULT (CONVERT([bit],(0))) FOR [IsFeatured]
GO
ALTER TABLE [dbo].[Notices] ADD  CONSTRAINT [DF__Notices__ImagePa__3B40CD36]  DEFAULT (N'') FOR [ImagePath]
GO
ALTER TABLE [dbo].[ProjectsInfo] ADD  DEFAULT ((0)) FOR [AreaID]
GO
ALTER TABLE [dbo].[PropertyDetails] ADD  CONSTRAINT [DF_PropertyDetails_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[PropertyDetails] ADD  CONSTRAINT [DF__PropertyD__ISFea__6EF57B66]  DEFAULT (CONVERT([bit],(0))) FOR [ISFeatured]
GO
ALTER TABLE [dbo].[PropertyDetails] ADD  CONSTRAINT [DF__PropertyD__Measu__6FE99F9F]  DEFAULT ((0)) FOR [MeasurementID]
GO
ALTER TABLE [dbo].[PropertyDetails] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsLand]
GO
ALTER TABLE [dbo].[PropertyDetails] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsSold]
GO
ALTER TABLE [dbo].[PropertyTypes] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsLand]
GO
ALTER TABLE [dbo].[Areas]  WITH CHECK ADD  CONSTRAINT [FK_Areas_Citys_CityId] FOREIGN KEY([CityId])
REFERENCES [dbo].[Citys] ([CityId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Areas] CHECK CONSTRAINT [FK_Areas_Citys_CityId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AvailableFlatSizes]  WITH CHECK ADD  CONSTRAINT [FK_AvailableFlatSizes_MeasurementUnit_UnitID] FOREIGN KEY([UnitID])
REFERENCES [dbo].[MeasurementUnit] ([Id])
GO
ALTER TABLE [dbo].[AvailableFlatSizes] CHECK CONSTRAINT [FK_AvailableFlatSizes_MeasurementUnit_UnitID]
GO
ALTER TABLE [dbo].[AvailableFlatSizes]  WITH CHECK ADD  CONSTRAINT [FK_AvailableFlatSizes_PropertyDetails_PropertyId] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[PropertyDetails] ([PropertyInfoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AvailableFlatSizes] CHECK CONSTRAINT [FK_AvailableFlatSizes_PropertyDetails_PropertyId]
GO
ALTER TABLE [dbo].[Citys]  WITH CHECK ADD  CONSTRAINT [FK_Citys_Divisions_DivisionId] FOREIGN KEY([DivisionId])
REFERENCES [dbo].[Divisions] ([DivisionID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Citys] CHECK CONSTRAINT [FK_Citys_Divisions_DivisionId]
GO
ALTER TABLE [dbo].[ClientInterest]  WITH CHECK ADD  CONSTRAINT [FK_ClientInterest_ClientContacts_ClientID] FOREIGN KEY([ClientID])
REFERENCES [dbo].[ClientContacts] ([ClientContactId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClientInterest] CHECK CONSTRAINT [FK_ClientInterest_ClientContacts_ClientID]
GO
ALTER TABLE [dbo].[ClientInterest]  WITH CHECK ADD  CONSTRAINT [FK_ClientInterest_PropertyDetails_PropertyID] FOREIGN KEY([PropertyID])
REFERENCES [dbo].[PropertyDetails] ([PropertyInfoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClientInterest] CHECK CONSTRAINT [FK_ClientInterest_PropertyDetails_PropertyID]
GO
ALTER TABLE [dbo].[ClientInterest]  WITH CHECK ADD  CONSTRAINT [FK_ClientInterest_PropertyTypes_PropertyTypeId] FOREIGN KEY([PropertyTypeId])
REFERENCES [dbo].[PropertyTypes] ([PropertyTypeId])
GO
ALTER TABLE [dbo].[ClientInterest] CHECK CONSTRAINT [FK_ClientInterest_PropertyTypes_PropertyTypeId]
GO
ALTER TABLE [dbo].[DevelopersorAgent]  WITH CHECK ADD  CONSTRAINT [FK_DevelopersorAgent_Areas_AreaID] FOREIGN KEY([AreaID])
REFERENCES [dbo].[Areas] ([AreaId])
GO
ALTER TABLE [dbo].[DevelopersorAgent] CHECK CONSTRAINT [FK_DevelopersorAgent_Areas_AreaID]
GO
ALTER TABLE [dbo].[Divisions]  WITH CHECK ADD  CONSTRAINT [FK_Divisions_Countries_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([CountryID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Divisions] CHECK CONSTRAINT [FK_Divisions_Countries_CountryId]
GO
ALTER TABLE [dbo].[FloorPlans]  WITH CHECK ADD  CONSTRAINT [FK_FloorPlans_PropertyDetails_PropertyInfoID] FOREIGN KEY([PropertyInfoID])
REFERENCES [dbo].[PropertyDetails] ([PropertyInfoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FloorPlans] CHECK CONSTRAINT [FK_FloorPlans_PropertyDetails_PropertyInfoID]
GO
ALTER TABLE [dbo].[ProjectImageGallery]  WITH CHECK ADD  CONSTRAINT [FK_ProjectImageGallery_ProjectsInfo_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[ProjectsInfo] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjectImageGallery] CHECK CONSTRAINT [FK_ProjectImageGallery_ProjectsInfo_ProjectID]
GO
ALTER TABLE [dbo].[ProjectsInfo]  WITH CHECK ADD  CONSTRAINT [FK_ProjectsInfo_Areas_AreaID] FOREIGN KEY([AreaID])
REFERENCES [dbo].[Areas] ([AreaId])
GO
ALTER TABLE [dbo].[ProjectsInfo] CHECK CONSTRAINT [FK_ProjectsInfo_Areas_AreaID]
GO
ALTER TABLE [dbo].[ProjectsInfo]  WITH CHECK ADD  CONSTRAINT [FK_ProjectsInfo_DevelopersorAgent_AgentID] FOREIGN KEY([AgentID])
REFERENCES [dbo].[DevelopersorAgent] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjectsInfo] CHECK CONSTRAINT [FK_ProjectsInfo_DevelopersorAgent_AgentID]
GO
ALTER TABLE [dbo].[PropertyDetails]  WITH CHECK ADD  CONSTRAINT [FK_PropertyDetails_Areas_AreaId] FOREIGN KEY([AreaId])
REFERENCES [dbo].[Areas] ([AreaId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PropertyDetails] CHECK CONSTRAINT [FK_PropertyDetails_Areas_AreaId]
GO
ALTER TABLE [dbo].[PropertyDetails]  WITH CHECK ADD  CONSTRAINT [FK_PropertyDetails_MeasurementUnit_MeasurementID] FOREIGN KEY([MeasurementID])
REFERENCES [dbo].[MeasurementUnit] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PropertyDetails] CHECK CONSTRAINT [FK_PropertyDetails_MeasurementUnit_MeasurementID]
GO
ALTER TABLE [dbo].[PropertyDetails]  WITH CHECK ADD  CONSTRAINT [FK_PropertyDetails_ProjectsInfo_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[ProjectsInfo] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PropertyDetails] CHECK CONSTRAINT [FK_PropertyDetails_ProjectsInfo_ProjectId]
GO
ALTER TABLE [dbo].[PropertyDetails]  WITH CHECK ADD  CONSTRAINT [FK_PropertyDetails_PropertyTypes_PropertyTypeId] FOREIGN KEY([PropertyTypeId])
REFERENCES [dbo].[PropertyTypes] ([PropertyTypeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PropertyDetails] CHECK CONSTRAINT [FK_PropertyDetails_PropertyTypes_PropertyTypeId]
GO
ALTER TABLE [dbo].[PropertyImages]  WITH CHECK ADD  CONSTRAINT [FK_PropertyImages_PropertyDetails_propertyInfoId] FOREIGN KEY([propertyInfoId])
REFERENCES [dbo].[PropertyDetails] ([PropertyInfoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PropertyImages] CHECK CONSTRAINT [FK_PropertyImages_PropertyDetails_propertyInfoId]
GO
ALTER TABLE [dbo].[PropertyWithFeatures]  WITH CHECK ADD  CONSTRAINT [FK_PropertyWithFeatures_PropertyDetails_PropertyId] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[PropertyDetails] ([PropertyInfoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PropertyWithFeatures] CHECK CONSTRAINT [FK_PropertyWithFeatures_PropertyDetails_PropertyId]
GO
ALTER TABLE [dbo].[PropertyWithFeatures]  WITH CHECK ADD  CONSTRAINT [FK_PropertyWithFeatures_PropertyFeatures_FeatureId] FOREIGN KEY([FeatureId])
REFERENCES [dbo].[PropertyFeatures] ([PropertyFeatureId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PropertyWithFeatures] CHECK CONSTRAINT [FK_PropertyWithFeatures_PropertyFeatures_FeatureId]
GO
USE [master]
GO
ALTER DATABASE [USBDRealEstate] SET  READ_WRITE 
GO
