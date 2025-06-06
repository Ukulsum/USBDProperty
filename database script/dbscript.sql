USE [master]
GO
/****** Object:  Database [USBDRealEstate]    Script Date: 3/26/2024 1:51:35 PM ******/
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
ALTER DATABASE [USBDRealEstate] SET AUTO_CLOSE OFF 
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
ALTER DATABASE [USBDRealEstate] SET  ENABLE_BROKER 
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
ALTER DATABASE [USBDRealEstate] SET RECOVERY FULL 
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/26/2024 1:51:35 PM ******/
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
/****** Object:  Table [dbo].[Areas]    Script Date: 3/26/2024 1:51:36 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 3/26/2024 1:51:36 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 3/26/2024 1:51:36 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 3/26/2024 1:51:36 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 3/26/2024 1:51:36 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 3/26/2024 1:51:36 PM ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 3/26/2024 1:51:36 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 3/26/2024 1:51:36 PM ******/
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
/****** Object:  Table [dbo].[Citys]    Script Date: 3/26/2024 1:51:36 PM ******/
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
/****** Object:  Table [dbo].[ClientContacts]    Script Date: 3/26/2024 1:51:36 PM ******/
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
/****** Object:  Table [dbo].[ClientInterest]    Script Date: 3/26/2024 1:51:36 PM ******/
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
/****** Object:  Table [dbo].[Countries]    Script Date: 3/26/2024 1:51:36 PM ******/
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
/****** Object:  Table [dbo].[DevelopersorAgent]    Script Date: 3/26/2024 1:51:36 PM ******/
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
/****** Object:  Table [dbo].[Divisions]    Script Date: 3/26/2024 1:51:36 PM ******/
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
/****** Object:  Table [dbo].[FloorPlans]    Script Date: 3/26/2024 1:51:36 PM ******/
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
/****** Object:  Table [dbo].[MeasurementUnit]    Script Date: 3/26/2024 1:51:36 PM ******/
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
/****** Object:  Table [dbo].[Notices]    Script Date: 3/26/2024 1:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notices](
	[NoticeID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
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
/****** Object:  Table [dbo].[PrivacyPolicy]    Script Date: 3/26/2024 1:51:36 PM ******/
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
/****** Object:  Table [dbo].[ProjectImageGallery]    Script Date: 3/26/2024 1:51:36 PM ******/
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
/****** Object:  Table [dbo].[ProjectsInfo]    Script Date: 3/26/2024 1:51:36 PM ******/
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
/****** Object:  Table [dbo].[PropertyDetails]    Script Date: 3/26/2024 1:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyDetails](
	[PropertyInfoId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[PropertyName] [nvarchar](150) NULL,
	[Location] [nvarchar](100) NOT NULL,
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
	[LandArea] [int] NULL,
	[Price] [real] NULL,
	[Path] [nvarchar](max) NULL,
	[Comments] [nvarchar](255) NULL,
	[PropertyCondition] [int] NULL,
	[HandOverDate] [datetime2](7) NULL,
	[PropertyTypeId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[AreaId] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
	[UpdateBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[PropertyFor] [int] NULL,
	[ISFeatured] [bit] NOT NULL,
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
/****** Object:  Table [dbo].[PropertyFeatures]    Script Date: 3/26/2024 1:51:36 PM ******/
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
/****** Object:  Table [dbo].[PropertyImages]    Script Date: 3/26/2024 1:51:36 PM ******/
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
/****** Object:  Table [dbo].[PropertyTypes]    Script Date: 3/26/2024 1:51:36 PM ******/
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
/****** Object:  Table [dbo].[PropertyWithFeatures]    Script Date: 3/26/2024 1:51:36 PM ******/
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
/****** Object:  Table [dbo].[SocialIcons]    Script Date: 3/26/2024 1:51:36 PM ******/
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
/****** Object:  Table [dbo].[TermsConditions]    Script Date: 3/26/2024 1:51:36 PM ******/
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
/****** Object:  Table [dbo].[TransactionTypes]    Script Date: 3/26/2024 1:51:36 PM ******/
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
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240208042435_pp', N'6.0.24')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240210080957_land', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240212060901_IsLand1', N'6.0.24')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240212061704_Im', N'6.0.24')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240212072230_pd', N'6.0.24')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240213112424_d', N'6.0.24')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240213134808_das', N'6.0.24')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240214110038_m', N'6.0.24')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240214115648_m1', N'6.0.24')
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
GO
SET IDENTITY_INSERT [dbo].[Areas] ON 

INSERT [dbo].[Areas] ([AreaId], [AreaName], [CityId]) VALUES (1, N'Mirpur', 1)
INSERT [dbo].[Areas] ([AreaId], [AreaName], [CityId]) VALUES (2, N'Mohammadpur', 1)
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
INSERT [dbo].[AspNetUsers] ([Id], [ProfilePic], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3f7022e5-3c9d-435a-bbd6-eaa88e318586', NULL, N'd@d.com', N'D@D.COM', N'd@d.com', N'D@D.COM', 0, N'AQAAAAEAACcQAAAAEGFa/DZrWUVjw1qq4HyJXcqEA8o1/810kmsHzveZy/4tbgc8uKl5ZwWFO19QTHDpuw==', N'73JRKV7ALIJ7KF42UOZV5GUZGQ742ZSG', N'5ff5ea93-4e97-41c4-9863-f147f1402242', N'014447784966', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [ProfilePic], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'60e960e4-edf1-44ec-a743-e33afcbca890', NULL, N'abul@g.com', N'ABUL@G.COM', N'abul@g.com', N'ABUL@G.COM', 1, N'AQAAAAEAACcQAAAAEKWDBq30zH30m0/ruNIx0wwVyyFTl1VcZA1CPB7sViJy/5nfS0xnT/OiceNAyz2/Sg==', N'JMMJBZVQRVVODULVGLMIMP6HX65DMW4V', N'99a2098e-c24c-4abd-b1be-493c96626890', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [ProfilePic], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'61497247-1b9f-4437-b6da-3fad0fa5e5f8', NULL, N'k@K.com', N'K@K.COM', N'k@K.com', N'K@K.COM', 0, N'AQAAAAEAACcQAAAAEKB2+MXs367vFGTx/j1IxoWIR37j0HNM0nFMsUmAxVxVWpODoWwsimJlO4J868j3RA==', N'CZ6RCBFOPDPPF7NTQYMBFCITDCR4QOCX', N'86095d34-a2e3-4b3b-ab5d-d701ff826f2f', N'014447784965', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [ProfilePic], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'9dc2ef9f-b822-45b6-94d2-427e593a3d6b', NULL, N'bd@d.com', N'BD@D.COM', N'bd@d.com', N'BD@D.COM', 0, N'AQAAAAEAACcQAAAAELr7Bqky/v7mNyQM4XAsFXl+0kVI37P1xR2WdAKeFBCeD2823LXhva4J1C1on9JN7g==', N'HOUZIOP674KQ3ATM3U5CTFGMHZK5U45Y', N'615acdb3-a368-4653-ac70-f214d111ae3d', N'014447784963', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [ProfilePic], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c69a9482-886a-4f4f-a68f-fa500f88c8dc', NULL, N'samu@gmail.com', N'SAMU@GMAIL.COM', N'samu@gmail.com', N'SAMU@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEMGzSIckVAnXwv3Z6CIaoznBGTJjrW75HR9aF4ltVMLvhZO5O0f3MWwJxyiyoLMKaw==', N'S3JCKDXCNJ6UBWP2RT2GCKXIJYTWD32K', N'a470b2e7-2636-4c06-8456-f0842b9754d7', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [ProfilePic], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd118e255-93be-445b-ba24-aa30a0674fbc', NULL, N'devshahanaj123@gmail.com', N'DEVSHAHANAJ123@GMAIL.COM', N'devshahanaj123@gmail.com', N'DEVSHAHANAJ123@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEFVIpwQzg6APfVRphs0RJi0NlK+HrxeOguc9Vqtk1De+yehtj26/DPFFz5e6BQfYcg==', N'QWSHPABKEDQBMHCWTX7OMZEM63WZEFCG', N'5a86cd07-a50f-4622-9aa6-22230a563da3', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Citys] ON 

INSERT [dbo].[Citys] ([CityId], [CityName], [DivisionId]) VALUES (1, N'Dhaka', 1)
INSERT [dbo].[Citys] ([CityId], [CityName], [DivisionId]) VALUES (2, N'Jursy', 3)
INSERT [dbo].[Citys] ([CityId], [CityName], [DivisionId]) VALUES (3, N'Mirpur', 1)
SET IDENTITY_INSERT [dbo].[Citys] OFF
GO
SET IDENTITY_INSERT [dbo].[ClientContacts] ON 

INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (1, N'sfsdf', N'01744852365', N'shahanaj89@gmail.com', CAST(N'2024-01-24T12:40:31.2649046' AS DateTime2), NULL, 1)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (12, N'wrwq', N'ewwerwe', N'shahanaj89@gmail.com', CAST(N'2024-01-29T12:50:44.8449147' AS DateTime2), N'll', 3)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (13, N'gdg', N'01747852', N'shahanaj89@gmail.com', CAST(N'2024-02-14T11:49:45.8702455' AS DateTime2), N'sadasdasdasdasd', 3)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (14, N'tyuty', N'01747852', N'shahanaj89@gmail.com', CAST(N'2024-02-14T11:50:27.3094750' AS DateTime2), N'asdasda', 3)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (15, N'Tomal', N'8888', N't@t.com', CAST(N'2024-02-14T12:16:44.9854189' AS DateTime2), N'ppppp', 3)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (19, N'tyuty', N'ewrew', N'shahanaj89@gmail.com', CAST(N'2024-02-14T14:16:46.5640341' AS DateTime2), N'asadsasd', 0)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (20, N'sfsdf', N'sdfs', N'shahanaj89@gmail.com', CAST(N'2024-02-14T14:19:29.9172187' AS DateTime2), N'dsdf', 0)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (21, N'etretr', N'01747852', N'shahanaj89@gmail.com', CAST(N'2024-02-14T15:23:51.5992700' AS DateTime2), N'trtretr', 0)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (22, N'nhfg', N'01744852365', N'shahanaj89@gmail.com', CAST(N'2024-02-14T15:28:09.7057648' AS DateTime2), N'jhfgjj', 0)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (23, N'tyuty', N'01744852365', N'shahanaj89@gmail.com', CAST(N'2024-02-14T15:29:56.9087034' AS DateTime2), N'fgdh', 0)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (24, N'hgfhgf', N'werw', N'ss@s.com', CAST(N'2024-02-14T15:34:46.6973947' AS DateTime2), N'rwerwerw', 1)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (25, N'tyuty', N'01744852365', N'shahanaj89@gmail.com', CAST(N'2024-02-14T15:53:56.1009207' AS DateTime2), N'dfdhfg', 1)
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate], [Message], [Interested]) VALUES (26, N'sdfsdfds', N'dsfsdfsdf', N'shahanaj89@gmail.com', CAST(N'2024-02-15T14:05:42.8810199' AS DateTime2), N'sdfsdf', 1)
SET IDENTITY_INSERT [dbo].[ClientContacts] OFF
GO
SET IDENTITY_INSERT [dbo].[ClientInterest] ON 

INSERT [dbo].[ClientInterest] ([ID], [ClientID], [PropertyID], [PropertyForId], [PropertyTypeId], [Message], [PropertyFor]) VALUES (1, 1, 1, 2, 4, N'fsdfsdfsd', 0)
SET IDENTITY_INSERT [dbo].[ClientInterest] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (1, N'Bangladesh')
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (2, N'United States')
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[DevelopersorAgent] ON 

INSERT [dbo].[DevelopersorAgent] ([ID], [Logo], [Banner], [CompanyName], [ContactNo], [Email], [Name], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [Address], [AreaID], [Membership], [AboutUs]) VALUES (2, N'/Developer/Logo/Krishibid group.jpg', N'/Developer/Banner/Krishibid group.jpg', N'Krishibid group', N'014447784965', N'k@K.com', N'Shahanaj', CAST(N'2024-01-12T00:00:00.0000000' AS DateTime2), N'devshahanaj123@gmail.com', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 1, N'Kazzipara', 1, 1, N'Krishibid group')
INSERT [dbo].[DevelopersorAgent] ([ID], [Logo], [Banner], [CompanyName], [ContactNo], [Email], [Name], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [Address], [AreaID], [Membership], [AboutUs]) VALUES (3, N'/Developer/Logo/Dhorittree Properties Ltd..png', N'/Developer/Banner/Dhorittree Properties Ltd..jpg', N'Dhorittree Properties Ltd.', N'014447784966', N'd@d.com', N'Samu', CAST(N'2024-01-12T00:00:00.0000000' AS DateTime2), N'devshahanaj123@gmail.com', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 1, N'Shewrapara', 1, 1, N'Dhorittree Properties Ltd.')
INSERT [dbo].[DevelopersorAgent] ([ID], [Logo], [Banner], [CompanyName], [ContactNo], [Email], [Name], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [Address], [AreaID], [Membership], [AboutUs]) VALUES (4, N'/Developer/Logo/ BD Properties logo .png', N'/Developer/Banner/ BD Properties _banner .jpg', N'BD Properties', N'014447784963', N'bd@d.com', N'Babu', CAST(N'2024-01-12T00:00:00.0000000' AS DateTime2), N'devshahanaj123@gmail.com', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 1, N'Mirpur-10', 1, 1, N'BD Properties')
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

INSERT [dbo].[Notices] ([NoticeID], [Title], [Description], [StartDate], [EndDate], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [IsFeatured], [ImagePath]) VALUES (1, N'Big sale dhamaka', N'<p>Big sale dhamaka</p>
', CAST(N'2024-01-31T11:09:00.0000000' AS DateTime2), CAST(N'2024-03-15T11:09:00.0000000' AS DateTime2), CAST(N'2024-01-31T11:09:42.8051090' AS DateTime2), N'Umme', CAST(N'2024-03-10T12:20:38.0489644' AS DateTime2), N'devshahanaj123@gmail.com', 1, 1, N'/Content/Images/Big sale dhamaka.png')
INSERT [dbo].[Notices] ([NoticeID], [Title], [Description], [StartDate], [EndDate], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [IsFeatured], [ImagePath]) VALUES (5, N'weqwe', N'<p>qwe</p>
', CAST(N'2024-03-01T11:25:00.0000000' AS DateTime2), CAST(N'2024-03-09T11:25:00.0000000' AS DateTime2), CAST(N'2024-03-10T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2024-03-10T12:21:18.8649562' AS DateTime2), N'devshahanaj123@gmail.com', 1, 1, N'/Content/Images/weqwe.png')
INSERT [dbo].[Notices] ([NoticeID], [Title], [Description], [StartDate], [EndDate], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [IsFeatured], [ImagePath]) VALUES (6, N'erewrwerew', N'<p>ewrwe</p>
', CAST(N'2024-02-26T11:26:00.0000000' AS DateTime2), CAST(N'2024-03-11T11:26:00.0000000' AS DateTime2), CAST(N'2024-03-10T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 1, 1, N'/Content/Images/erewrwerew.png')
SET IDENTITY_INSERT [dbo].[Notices] OFF
GO
SET IDENTITY_INSERT [dbo].[ProjectsInfo] ON 

INSERT [dbo].[ProjectsInfo] ([Id], [Title], [Description], [ProjectName], [Location], [LocationMap], [AgentID], [AreaID], [ProjectVideo]) VALUES (3, N'Dharitree Garden city', N'Dharitree Garden city', N'Dharitree Garden city', N'dssadasda', NULL, 3, 1, NULL)
SET IDENTITY_INSERT [dbo].[ProjectsInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[PropertyDetails] ON 

INSERT [dbo].[PropertyDetails] ([PropertyInfoId], [Title], [Description], [PropertyName], [Location], [ConstructionStatus], [PropertySize], [NumberOfBedrooms], [NumberOfBaths], [NumberOfBalconies], [NumberOfGarages], [TotalFloor], [FloorAvailableNo], [Furnishing], [Facing], [LandArea], [Price], [Path], [Comments], [PropertyCondition], [HandOverDate], [PropertyTypeId], [ProjectId], [AreaId], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [PropertyFor], [ISFeatured], [MeasurementID], [FlatSize], [LandPrice], [ImagePath], [IsLand], [IsSold]) VALUES (1, N'Dharitree Garden City', N'<p>dfdsfsdf</p>
', N'Dharitree Garden City', N'ffghfg', 1, 3336, 3, 3, 3, 1, 25, 25, 1, 1, 0, 5000, N'/Content/Images/Dharitree GArden city.png', N'asdasdas', 0, CAST(N'2024-02-10T00:00:00.0000000' AS DateTime2), 4, 3, 1, CAST(N'2024-01-14T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 1, 2, 1, 2, NULL, NULL, N'/Content/Images/Dharitree GArden city.png', 0, 0)
INSERT [dbo].[PropertyDetails] ([PropertyInfoId], [Title], [Description], [PropertyName], [Location], [ConstructionStatus], [PropertySize], [NumberOfBedrooms], [NumberOfBaths], [NumberOfBalconies], [NumberOfGarages], [TotalFloor], [FloorAvailableNo], [Furnishing], [Facing], [LandArea], [Price], [Path], [Comments], [PropertyCondition], [HandOverDate], [PropertyTypeId], [ProjectId], [AreaId], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [PropertyFor], [ISFeatured], [MeasurementID], [FlatSize], [LandPrice], [ImagePath], [IsLand], [IsSold]) VALUES (2, N'Dharitree Condonium City', N'<p>Dharitree Condonium CityDharitree Condonium CityDharitree Condonium CityDharitree Condonium CityDharitree Condonium City</p>
', N'Dharitree Condonium City', N'567(2nd floor), East Kazipara,Kazipara,Mirpur,Dhaka-1216', 1, 3336, 3, 2, 3, 1, 25, 25, 1, 2, 0, 5000, N'/Content/Images/Dharitree Condonium City.png', N'uyiyuiyu', 0, CAST(N'2024-02-10T00:00:00.0000000' AS DateTime2), 5, 3, 1, CAST(N'2024-01-14T11:42:25.4471625' AS DateTime2), N'samu@gmail.com', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 1, 2, 1, 1, NULL, NULL, N'/Content/Images/Dharitree Condonium City.png', 0, 0)
INSERT [dbo].[PropertyDetails] ([PropertyInfoId], [Title], [Description], [PropertyName], [Location], [ConstructionStatus], [PropertySize], [NumberOfBedrooms], [NumberOfBaths], [NumberOfBalconies], [NumberOfGarages], [TotalFloor], [FloorAvailableNo], [Furnishing], [Facing], [LandArea], [Price], [Path], [Comments], [PropertyCondition], [HandOverDate], [PropertyTypeId], [ProjectId], [AreaId], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [PropertyFor], [ISFeatured], [MeasurementID], [FlatSize], [LandPrice], [ImagePath], [IsLand], [IsSold]) VALUES (3, N'PPPP', N'<p>JHJHVVJHV</p>
', NULL, N'567(2nd floor), East Kazipara,Kazipara,Mirpur,Dhaka-1216', 2, 3336, 3, 6, 2, 2, 3, 33, 2, 1, 9999, 963, N'/Content/Images/PPPP.png', N'PPPP', 1, CAST(N'2024-02-10T00:00:00.0000000' AS DateTime2), 4, 3, 1, CAST(N'2024-02-14T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2024-02-14T17:53:21.5479871' AS DateTime2), N'devshahanaj123@gmail.com', 1, 2, 1, 2, NULL, NULL, N'/Content/Images/PPPP.png', 0, 0)
INSERT [dbo].[PropertyDetails] ([PropertyInfoId], [Title], [Description], [PropertyName], [Location], [ConstructionStatus], [PropertySize], [NumberOfBedrooms], [NumberOfBaths], [NumberOfBalconies], [NumberOfGarages], [TotalFloor], [FloorAvailableNo], [Furnishing], [Facing], [LandArea], [Price], [Path], [Comments], [PropertyCondition], [HandOverDate], [PropertyTypeId], [ProjectId], [AreaId], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [PropertyFor], [ISFeatured], [MeasurementID], [FlatSize], [LandPrice], [ImagePath], [IsLand], [IsSold]) VALUES (4, N'adsaasdas', N'<p>cxzczxcz</p>
', NULL, N'567(2nd floor), East Kazipara,Kazipara,Mirpur,Dhaka-1216', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 6, NULL, NULL, N'asdasdas', 0, CAST(N'2024-03-07T00:00:00.0000000' AS DateTime2), 7, 3, 1, CAST(N'2024-02-15T12:52:41.1279746' AS DateTime2), N'devshahanaj123@gmail.com', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 1, 2, 1, 2, NULL, 50000, N'/Content/Images/adsaasdas.png', 1, 0)
INSERT [dbo].[PropertyDetails] ([PropertyInfoId], [Title], [Description], [PropertyName], [Location], [ConstructionStatus], [PropertySize], [NumberOfBedrooms], [NumberOfBaths], [NumberOfBalconies], [NumberOfGarages], [TotalFloor], [FloorAvailableNo], [Furnishing], [Facing], [LandArea], [Price], [Path], [Comments], [PropertyCondition], [HandOverDate], [PropertyTypeId], [ProjectId], [AreaId], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [PropertyFor], [ISFeatured], [MeasurementID], [FlatSize], [LandPrice], [ImagePath], [IsLand], [IsSold]) VALUES (5, N'dsfsdfsdf', N'<p>nlnnkn</p>
', NULL, N'567(2nd floor), East Kazipara,Kazipara,Mirpur,Dhaka-1216', 2, NULL, 3, 2, 1, 1, 20, 25, 1, 1, 10, 3000, NULL, N'bjhbjhb', 1, CAST(N'2024-02-15T00:00:00.0000000' AS DateTime2), 4, 3, 1, CAST(N'2024-02-15T13:42:58.5790579' AS DateTime2), N'devshahanaj123@gmail.com', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 1, 2, 1, 3, 1300, NULL, N'/Content/Images/dsfsdfsdf.png', 0, 0)
INSERT [dbo].[PropertyDetails] ([PropertyInfoId], [Title], [Description], [PropertyName], [Location], [ConstructionStatus], [PropertySize], [NumberOfBedrooms], [NumberOfBaths], [NumberOfBalconies], [NumberOfGarages], [TotalFloor], [FloorAvailableNo], [Furnishing], [Facing], [LandArea], [Price], [Path], [Comments], [PropertyCondition], [HandOverDate], [PropertyTypeId], [ProjectId], [AreaId], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [PropertyFor], [ISFeatured], [MeasurementID], [FlatSize], [LandPrice], [ImagePath], [IsLand], [IsSold]) VALUES (6, N'retyert', N'<p>dfsdfsdf</p>
', NULL, N'567(2nd floor), East Kazipara,Kazipara,Mirpur,Dhaka-1216', 2, NULL, 3, 2, 2, 1, 20, 22, 1, 1, 5, 3000, NULL, N'sdfsdfs', 1, CAST(N'2024-03-07T00:00:00.0000000' AS DateTime2), 4, 3, 1, CAST(N'2024-02-15T14:09:04.1810418' AS DateTime2), N'devshahanaj123@gmail.com', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 1, 2, 1, 2, 1300, NULL, N'/Content/Images/retyert.png', 0, 0)
INSERT [dbo].[PropertyDetails] ([PropertyInfoId], [Title], [Description], [PropertyName], [Location], [ConstructionStatus], [PropertySize], [NumberOfBedrooms], [NumberOfBaths], [NumberOfBalconies], [NumberOfGarages], [TotalFloor], [FloorAvailableNo], [Furnishing], [Facing], [LandArea], [Price], [Path], [Comments], [PropertyCondition], [HandOverDate], [PropertyTypeId], [ProjectId], [AreaId], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [PropertyFor], [ISFeatured], [MeasurementID], [FlatSize], [LandPrice], [ImagePath], [IsLand], [IsSold]) VALUES (7, N'sdaff', N'<p>sdfdsfsdfsd</p>
', NULL, N'567(2nd floor), East Kazipara,Kazipara,Mirpur,Dhaka-1216', 2, NULL, 3, 2, 2, 2, 22, 24, 1, 2, 20, 3000, NULL, N'dfsdf', 1, CAST(N'2024-02-27T00:00:00.0000000' AS DateTime2), 4, 3, 1, CAST(N'2024-02-15T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2024-02-15T14:16:14.9313142' AS DateTime2), N'devshahanaj123@gmail.com', 1, 2, 1, 3, 1300, NULL, N'/Content/Images/retyert.png', 0, 0)
SET IDENTITY_INSERT [dbo].[PropertyDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[PropertyFeatures] ON 

INSERT [dbo].[PropertyFeatures] ([PropertyFeatureId], [PropertyFeatureName], [FeatureDescription]) VALUES (1, N'Security', N'Security')
INSERT [dbo].[PropertyFeatures] ([PropertyFeatureId], [PropertyFeatureName], [FeatureDescription]) VALUES (2, N'Lift', N'Lift')
INSERT [dbo].[PropertyFeatures] ([PropertyFeatureId], [PropertyFeatureName], [FeatureDescription]) VALUES (5, N'tailor', N'<p>oii</p>
')
INSERT [dbo].[PropertyFeatures] ([PropertyFeatureId], [PropertyFeatureName], [FeatureDescription]) VALUES (6, N'gtr', N'<p>ytr</p>
')
INSERT [dbo].[PropertyFeatures] ([PropertyFeatureId], [PropertyFeatureName], [FeatureDescription]) VALUES (7, N'tryrt', N'<p>ytrytr</p>
')
INSERT [dbo].[PropertyFeatures] ([PropertyFeatureId], [PropertyFeatureName], [FeatureDescription]) VALUES (8, N'pp', N'<p>pp</p>
')
SET IDENTITY_INSERT [dbo].[PropertyFeatures] OFF
GO
SET IDENTITY_INSERT [dbo].[PropertyImages] ON 

INSERT [dbo].[PropertyImages] ([ID], [Title], [MultiImagePath], [propertyInfoId]) VALUES (1, N'city', N'/Content/Images/2_01.png', 2)
INSERT [dbo].[PropertyImages] ([ID], [Title], [MultiImagePath], [propertyInfoId]) VALUES (2, N'city', N'/Content/Images/2_11.png', 2)
INSERT [dbo].[PropertyImages] ([ID], [Title], [MultiImagePath], [propertyInfoId]) VALUES (3, N'city', N'/Content/Images/2_21.jpg', 2)
INSERT [dbo].[PropertyImages] ([ID], [Title], [MultiImagePath], [propertyInfoId]) VALUES (4, N'city', N'/Content/Images/2_31.png', 2)
INSERT [dbo].[PropertyImages] ([ID], [Title], [MultiImagePath], [propertyInfoId]) VALUES (5, N'city', N'/Content/Images/2_41.jpg', 2)
INSERT [dbo].[PropertyImages] ([ID], [Title], [MultiImagePath], [propertyInfoId]) VALUES (6, N'city', N'/Content/Images/2_51.jpeg', 2)
INSERT [dbo].[PropertyImages] ([ID], [Title], [MultiImagePath], [propertyInfoId]) VALUES (7, N'city', N'/Content/Images/2_61.jpeg', 2)
INSERT [dbo].[PropertyImages] ([ID], [Title], [MultiImagePath], [propertyInfoId]) VALUES (8, N'city', N'/Content/Images/2_71.jpeg', 2)
INSERT [dbo].[PropertyImages] ([ID], [Title], [MultiImagePath], [propertyInfoId]) VALUES (9, N'city', N'/Content/Images/2_81.jpeg', 2)
INSERT [dbo].[PropertyImages] ([ID], [Title], [MultiImagePath], [propertyInfoId]) VALUES (10, N'Front side', N'/Content/Images/1_01.jpeg', 1)
INSERT [dbo].[PropertyImages] ([ID], [Title], [MultiImagePath], [propertyInfoId]) VALUES (11, N'Front side', N'/Content/Images/1_11.jpeg', 1)
INSERT [dbo].[PropertyImages] ([ID], [Title], [MultiImagePath], [propertyInfoId]) VALUES (12, N'Front side', N'/Content/Images/1_21.jpeg', 1)
INSERT [dbo].[PropertyImages] ([ID], [Title], [MultiImagePath], [propertyInfoId]) VALUES (13, N'Front side', N'/Content/Images/1_31.jpeg', 1)
INSERT [dbo].[PropertyImages] ([ID], [Title], [MultiImagePath], [propertyInfoId]) VALUES (14, N'Front side', N'/Content/Images/1_41.jpeg', 1)
INSERT [dbo].[PropertyImages] ([ID], [Title], [MultiImagePath], [propertyInfoId]) VALUES (15, N'Front side', N'/Content/Images/1_51.jpeg', 1)
INSERT [dbo].[PropertyImages] ([ID], [Title], [MultiImagePath], [propertyInfoId]) VALUES (16, N'Front side', N'/Content/Images/1_61.jpeg', 1)
INSERT [dbo].[PropertyImages] ([ID], [Title], [MultiImagePath], [propertyInfoId]) VALUES (17, N'Front side', N'/Content/Images/1_71.jpeg', 1)
INSERT [dbo].[PropertyImages] ([ID], [Title], [MultiImagePath], [propertyInfoId]) VALUES (18, N'Front side', N'/Content/Images/1_81.jpeg', 1)
INSERT [dbo].[PropertyImages] ([ID], [Title], [MultiImagePath], [propertyInfoId]) VALUES (19, N'Front side', N'/Content/Images/1_91.jpeg', 1)
INSERT [dbo].[PropertyImages] ([ID], [Title], [MultiImagePath], [propertyInfoId]) VALUES (20, N'Front side', N'/Content/Images/1_101.jpeg', 1)
INSERT [dbo].[PropertyImages] ([ID], [Title], [MultiImagePath], [propertyInfoId]) VALUES (21, N'Front side', N'/Content/Images/1_111.jpeg', 1)
INSERT [dbo].[PropertyImages] ([ID], [Title], [MultiImagePath], [propertyInfoId]) VALUES (22, N'Front side', N'/Content/Images/1_121.jpeg', 1)
INSERT [dbo].[PropertyImages] ([ID], [Title], [MultiImagePath], [propertyInfoId]) VALUES (23, N'Test slider', N'/Content/Images/7_01.png', 7)
INSERT [dbo].[PropertyImages] ([ID], [Title], [MultiImagePath], [propertyInfoId]) VALUES (24, N'Test slider', N'/Content/Images/7_11.png', 7)
INSERT [dbo].[PropertyImages] ([ID], [Title], [MultiImagePath], [propertyInfoId]) VALUES (25, N'Test slider', N'/Content/Images/7_21.png', 7)
INSERT [dbo].[PropertyImages] ([ID], [Title], [MultiImagePath], [propertyInfoId]) VALUES (26, N'Test slider', N'/Content/Images/7_31.png', 7)
SET IDENTITY_INSERT [dbo].[PropertyImages] OFF
GO
SET IDENTITY_INSERT [dbo].[PropertyTypes] ON 

INSERT [dbo].[PropertyTypes] ([PropertyTypeId], [PropertyTypeName], [ParentPropertyTypeId], [IsLand]) VALUES (1, N'Commercial', 0, 0)
INSERT [dbo].[PropertyTypes] ([PropertyTypeId], [PropertyTypeName], [ParentPropertyTypeId], [IsLand]) VALUES (2, N'Residencial', 0, 0)
INSERT [dbo].[PropertyTypes] ([PropertyTypeId], [PropertyTypeName], [ParentPropertyTypeId], [IsLand]) VALUES (3, N'Land/Plot', 0, 0)
INSERT [dbo].[PropertyTypes] ([PropertyTypeId], [PropertyTypeName], [ParentPropertyTypeId], [IsLand]) VALUES (4, N'Apartment', 1, 0)
INSERT [dbo].[PropertyTypes] ([PropertyTypeId], [PropertyTypeName], [ParentPropertyTypeId], [IsLand]) VALUES (5, N'Office space', 1, 0)
INSERT [dbo].[PropertyTypes] ([PropertyTypeId], [PropertyTypeName], [ParentPropertyTypeId], [IsLand]) VALUES (6, N'Apartment', 2, 0)
INSERT [dbo].[PropertyTypes] ([PropertyTypeId], [PropertyTypeName], [ParentPropertyTypeId], [IsLand]) VALUES (7, N'Land/Plot', 3, 1)
SET IDENTITY_INSERT [dbo].[PropertyTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[PropertyWithFeatures] ON 

INSERT [dbo].[PropertyWithFeatures] ([ID], [PropertyId], [FeatureId]) VALUES (3, 6, 2)
INSERT [dbo].[PropertyWithFeatures] ([ID], [PropertyId], [FeatureId]) VALUES (4, 5, 1)
INSERT [dbo].[PropertyWithFeatures] ([ID], [PropertyId], [FeatureId]) VALUES (5, 5, 2)
INSERT [dbo].[PropertyWithFeatures] ([ID], [PropertyId], [FeatureId]) VALUES (6, 7, 6)
INSERT [dbo].[PropertyWithFeatures] ([ID], [PropertyId], [FeatureId]) VALUES (7, 7, 7)
SET IDENTITY_INSERT [dbo].[PropertyWithFeatures] OFF
GO
/****** Object:  Index [IX_Areas_CityId]    Script Date: 3/26/2024 1:51:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Areas_CityId] ON [dbo].[Areas]
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 3/26/2024 1:51:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 3/26/2024 1:51:36 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 3/26/2024 1:51:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 3/26/2024 1:51:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 3/26/2024 1:51:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 3/26/2024 1:51:36 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 3/26/2024 1:51:36 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Citys_DivisionId]    Script Date: 3/26/2024 1:51:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Citys_DivisionId] ON [dbo].[Citys]
(
	[DivisionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientInterest_ClientID]    Script Date: 3/26/2024 1:51:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_ClientInterest_ClientID] ON [dbo].[ClientInterest]
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientInterest_PropertyID]    Script Date: 3/26/2024 1:51:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_ClientInterest_PropertyID] ON [dbo].[ClientInterest]
(
	[PropertyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientInterest_PropertyTypeId]    Script Date: 3/26/2024 1:51:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_ClientInterest_PropertyTypeId] ON [dbo].[ClientInterest]
(
	[PropertyTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DevelopersorAgent_AreaID]    Script Date: 3/26/2024 1:51:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_DevelopersorAgent_AreaID] ON [dbo].[DevelopersorAgent]
(
	[AreaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Divisions_CountryId]    Script Date: 3/26/2024 1:51:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Divisions_CountryId] ON [dbo].[Divisions]
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FloorPlans_PropertyInfoID]    Script Date: 3/26/2024 1:51:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_FloorPlans_PropertyInfoID] ON [dbo].[FloorPlans]
(
	[PropertyInfoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProjectImageGallery_ProjectID]    Script Date: 3/26/2024 1:51:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProjectImageGallery_ProjectID] ON [dbo].[ProjectImageGallery]
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProjectsInfo_AgentID]    Script Date: 3/26/2024 1:51:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProjectsInfo_AgentID] ON [dbo].[ProjectsInfo]
(
	[AgentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProjectsInfo_AreaID]    Script Date: 3/26/2024 1:51:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProjectsInfo_AreaID] ON [dbo].[ProjectsInfo]
(
	[AreaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyDetails_AreaId]    Script Date: 3/26/2024 1:51:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyDetails_AreaId] ON [dbo].[PropertyDetails]
(
	[AreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyDetails_MeasurementID]    Script Date: 3/26/2024 1:51:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyDetails_MeasurementID] ON [dbo].[PropertyDetails]
(
	[MeasurementID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyDetails_ProjectId]    Script Date: 3/26/2024 1:51:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyDetails_ProjectId] ON [dbo].[PropertyDetails]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyDetails_PropertyTypeId]    Script Date: 3/26/2024 1:51:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyDetails_PropertyTypeId] ON [dbo].[PropertyDetails]
(
	[PropertyTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyImages_propertyInfoId]    Script Date: 3/26/2024 1:51:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyImages_propertyInfoId] ON [dbo].[PropertyImages]
(
	[propertyInfoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyWithFeatures_FeatureId]    Script Date: 3/26/2024 1:51:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyWithFeatures_FeatureId] ON [dbo].[PropertyWithFeatures]
(
	[FeatureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyWithFeatures_PropertyId]    Script Date: 3/26/2024 1:51:36 PM ******/
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
ALTER TABLE [dbo].[Notices] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsFeatured]
GO
ALTER TABLE [dbo].[Notices] ADD  DEFAULT (N'') FOR [ImagePath]
GO
ALTER TABLE [dbo].[ProjectsInfo] ADD  DEFAULT ((0)) FOR [AreaID]
GO
ALTER TABLE [dbo].[PropertyDetails] ADD  CONSTRAINT [DF__PropertyD__ISFea__5AEE82B9]  DEFAULT (CONVERT([bit],(0))) FOR [ISFeatured]
GO
ALTER TABLE [dbo].[PropertyDetails] ADD  CONSTRAINT [DF__PropertyD__Measu__5BE2A6F2]  DEFAULT ((0)) FOR [MeasurementID]
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
ALTER TABLE [dbo].[Citys]  WITH CHECK ADD  CONSTRAINT [FK_Citys_Divisions_DivisionId] FOREIGN KEY([DivisionId])
REFERENCES [dbo].[Divisions] ([DivisionID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Citys] CHECK CONSTRAINT [FK_Citys_Divisions_DivisionId]
GO
ALTER TABLE [dbo].[ClientInterest]  WITH CHECK ADD  CONSTRAINT [FK_ClientInterest_ClientContacts_ClientID] FOREIGN KEY([ClientID])
REFERENCES [dbo].[ClientContacts] ([ClientContactId])
GO
ALTER TABLE [dbo].[ClientInterest] CHECK CONSTRAINT [FK_ClientInterest_ClientContacts_ClientID]
GO
ALTER TABLE [dbo].[ClientInterest]  WITH CHECK ADD  CONSTRAINT [FK_ClientInterest_PropertyDetails_PropertyID] FOREIGN KEY([PropertyID])
REFERENCES [dbo].[PropertyDetails] ([PropertyInfoId])
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
