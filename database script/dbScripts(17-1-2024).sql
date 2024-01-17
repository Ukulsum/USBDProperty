USE [master]
GO
/****** Object:  Database [USBDRealEstate]    Script Date: 1/17/2024 7:32:22 PM ******/
CREATE DATABASE [USBDRealEstate]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'USBDRealEstate', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\USBDRealEstate.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'USBDRealEstate_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\USBDRealEstate_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [USBDRealEstate] SET COMPATIBILITY_LEVEL = 160
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
ALTER DATABASE [USBDRealEstate] SET QUERY_STORE = ON
GO
ALTER DATABASE [USBDRealEstate] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [USBDRealEstate]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/17/2024 7:32:22 PM ******/
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
/****** Object:  Table [dbo].[Areas]    Script Date: 1/17/2024 7:32:22 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 1/17/2024 7:32:22 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 1/17/2024 7:32:22 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 1/17/2024 7:32:22 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 1/17/2024 7:32:22 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 1/17/2024 7:32:22 PM ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 1/17/2024 7:32:22 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 1/17/2024 7:32:22 PM ******/
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
/****** Object:  Table [dbo].[Citys]    Script Date: 1/17/2024 7:32:22 PM ******/
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
/****** Object:  Table [dbo].[ClientContacts]    Script Date: 1/17/2024 7:32:22 PM ******/
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
 CONSTRAINT [PK_ClientContacts] PRIMARY KEY CLUSTERED 
(
	[ClientContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientInterest]    Script Date: 1/17/2024 7:32:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientInterest](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[PropertyID] [int] NOT NULL,
	[PropertyForId] [nvarchar](max) NOT NULL,
	[PropertyTypeId] [int] NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[PropertyFor] [int] NOT NULL,
 CONSTRAINT [PK_ClientInterest] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 1/17/2024 7:32:22 PM ******/
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
/****** Object:  Table [dbo].[DevelopersorAgent]    Script Date: 1/17/2024 7:32:22 PM ******/
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
 CONSTRAINT [PK_DevelopersorAgent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Divisions]    Script Date: 1/17/2024 7:32:22 PM ******/
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
/****** Object:  Table [dbo].[FloorPlans]    Script Date: 1/17/2024 7:32:22 PM ******/
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
/****** Object:  Table [dbo].[MeasurementUnit]    Script Date: 1/17/2024 7:32:22 PM ******/
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
/****** Object:  Table [dbo].[Notices]    Script Date: 1/17/2024 7:32:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notices](
	[NoticeID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Path] [nvarchar](max) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
	[UpdateBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Notices] PRIMARY KEY CLUSTERED 
(
	[NoticeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PrivacyPolicy]    Script Date: 1/17/2024 7:32:22 PM ******/
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
/****** Object:  Table [dbo].[ProjectImageGallery]    Script Date: 1/17/2024 7:32:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectImageGallery](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ImagePath] [nvarchar](100) NOT NULL,
	[ProjectID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectImageGallery] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectsInfo]    Script Date: 1/17/2024 7:32:22 PM ******/
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
/****** Object:  Table [dbo].[PropertyDetails]    Script Date: 1/17/2024 7:32:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyDetails](
	[PropertyInfoId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[PropertyName] [nvarchar](150) NOT NULL,
	[Location] [nvarchar](100) NOT NULL,
	[ConstructionStatus] [int] NOT NULL,
	[PropertySize] [int] NOT NULL,
	[NumberOfBedrooms] [int] NOT NULL,
	[NumberOfBaths] [int] NOT NULL,
	[NumberOfBalconies] [int] NOT NULL,
	[NumberOfGarages] [int] NOT NULL,
	[TotalFloor] [int] NOT NULL,
	[FloorAvailableNo] [int] NOT NULL,
	[Furnishing] [int] NOT NULL,
	[Facing] [int] NOT NULL,
	[LandArea] [int] NOT NULL,
	[Price] [real] NOT NULL,
	[Path] [nvarchar](max) NULL,
	[Comments] [nvarchar](255) NOT NULL,
	[PropertyCondition] [int] NOT NULL,
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
 CONSTRAINT [PK_PropertyDetails] PRIMARY KEY CLUSTERED 
(
	[PropertyInfoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropertyFeatures]    Script Date: 1/17/2024 7:32:22 PM ******/
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
/****** Object:  Table [dbo].[PropertyImages]    Script Date: 1/17/2024 7:32:22 PM ******/
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
/****** Object:  Table [dbo].[PropertyTypes]    Script Date: 1/17/2024 7:32:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyTypes](
	[PropertyTypeId] [int] IDENTITY(1,1) NOT NULL,
	[PropertyTypeName] [nvarchar](255) NOT NULL,
	[ParentPropertyTypeId] [int] NULL,
 CONSTRAINT [PK_PropertyTypes] PRIMARY KEY CLUSTERED 
(
	[PropertyTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropertyWithFeatures]    Script Date: 1/17/2024 7:32:22 PM ******/
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
/****** Object:  Table [dbo].[SocialIcons]    Script Date: 1/17/2024 7:32:22 PM ******/
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
/****** Object:  Table [dbo].[TermsConditions]    Script Date: 1/17/2024 7:32:22 PM ******/
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
/****** Object:  Table [dbo].[TransactionTypes]    Script Date: 1/17/2024 7:32:22 PM ******/
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
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240109072438_prf', N'6.0.24')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240110043333_p', N'6.0.24')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240110043538_i', N'6.0.24')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240110065340_dev', N'6.0.24')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240111235307_dv', N'6.0.24')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240112012440_prj', N'6.0.24')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240112015119_prj1', N'6.0.24')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240112025527_prj13', N'6.0.24')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240112025908_prj133', N'6.0.24')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240112115551_munit', N'6.0.24')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240113050215_u', N'6.0.24')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240113075519_cs', N'6.0.24')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240113080703_cs1', N'6.0.24')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240117105203_df', N'6.0.24')
GO
SET IDENTITY_INSERT [dbo].[Areas] ON 
GO
INSERT [dbo].[Areas] ([AreaId], [AreaName], [CityId]) VALUES (1, N'Mirpur', 1)
GO
INSERT [dbo].[Areas] ([AreaId], [AreaName], [CityId]) VALUES (2, N'Mohammadpur', 1)
GO
SET IDENTITY_INSERT [dbo].[Areas] OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'0b81452f-c6ce-46aa-b257-e6cb7d20cb06', N'Agent', N'AGENT', N'1b4be62f-6db4-4b04-9cb8-967f7f97952e')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'2b3a0971-0ce5-4ff3-9909-51d942396d33', N'Admin', N'ADMIN', N'a4cc4c46-3f2d-41bf-9ace-4720adb2c645')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'72d770aa-c8b3-464d-92a5-92a29cb18c05', N'Super Admin', N'SUPER ADMIN', N'109409a2-bca7-4af5-8688-7a32a5ca86c8')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c69a9482-886a-4f4f-a68f-fa500f88c8dc', N'0b81452f-c6ce-46aa-b257-e6cb7d20cb06')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd118e255-93be-445b-ba24-aa30a0674fbc', N'2b3a0971-0ce5-4ff3-9909-51d942396d33')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'60e960e4-edf1-44ec-a743-e33afcbca890', N'72d770aa-c8b3-464d-92a5-92a29cb18c05')
GO
INSERT [dbo].[AspNetUsers] ([Id], [ProfilePic], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3f7022e5-3c9d-435a-bbd6-eaa88e318586', NULL, N'd@d.com', N'D@D.COM', N'd@d.com', N'D@D.COM', 0, N'AQAAAAEAACcQAAAAEGFa/DZrWUVjw1qq4HyJXcqEA8o1/810kmsHzveZy/4tbgc8uKl5ZwWFO19QTHDpuw==', N'73JRKV7ALIJ7KF42UOZV5GUZGQ742ZSG', N'5ff5ea93-4e97-41c4-9863-f147f1402242', N'014447784966', 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [ProfilePic], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'60e960e4-edf1-44ec-a743-e33afcbca890', NULL, N'abul@g.com', N'ABUL@G.COM', N'abul@g.com', N'ABUL@G.COM', 1, N'AQAAAAEAACcQAAAAEKWDBq30zH30m0/ruNIx0wwVyyFTl1VcZA1CPB7sViJy/5nfS0xnT/OiceNAyz2/Sg==', N'JMMJBZVQRVVODULVGLMIMP6HX65DMW4V', N'99a2098e-c24c-4abd-b1be-493c96626890', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [ProfilePic], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'61497247-1b9f-4437-b6da-3fad0fa5e5f8', NULL, N'k@K.com', N'K@K.COM', N'k@K.com', N'K@K.COM', 0, N'AQAAAAEAACcQAAAAEKB2+MXs367vFGTx/j1IxoWIR37j0HNM0nFMsUmAxVxVWpODoWwsimJlO4J868j3RA==', N'CZ6RCBFOPDPPF7NTQYMBFCITDCR4QOCX', N'86095d34-a2e3-4b3b-ab5d-d701ff826f2f', N'014447784965', 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [ProfilePic], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'9dc2ef9f-b822-45b6-94d2-427e593a3d6b', NULL, N'bd@d.com', N'BD@D.COM', N'bd@d.com', N'BD@D.COM', 0, N'AQAAAAEAACcQAAAAELr7Bqky/v7mNyQM4XAsFXl+0kVI37P1xR2WdAKeFBCeD2823LXhva4J1C1on9JN7g==', N'HOUZIOP674KQ3ATM3U5CTFGMHZK5U45Y', N'615acdb3-a368-4653-ac70-f214d111ae3d', N'014447784963', 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [ProfilePic], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c69a9482-886a-4f4f-a68f-fa500f88c8dc', NULL, N'samu@gmail.com', N'SAMU@GMAIL.COM', N'samu@gmail.com', N'SAMU@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEMGzSIckVAnXwv3Z6CIaoznBGTJjrW75HR9aF4ltVMLvhZO5O0f3MWwJxyiyoLMKaw==', N'S3JCKDXCNJ6UBWP2RT2GCKXIJYTWD32K', N'a470b2e7-2636-4c06-8456-f0842b9754d7', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [ProfilePic], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd118e255-93be-445b-ba24-aa30a0674fbc', NULL, N'devshahanaj123@gmail.com', N'DEVSHAHANAJ123@GMAIL.COM', N'devshahanaj123@gmail.com', N'DEVSHAHANAJ123@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEFVIpwQzg6APfVRphs0RJi0NlK+HrxeOguc9Vqtk1De+yehtj26/DPFFz5e6BQfYcg==', N'QWSHPABKEDQBMHCWTX7OMZEM63WZEFCG', N'5a86cd07-a50f-4622-9aa6-22230a563da3', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Citys] ON 
GO
INSERT [dbo].[Citys] ([CityId], [CityName], [DivisionId]) VALUES (1, N'Dhaka', 1)
GO
INSERT [dbo].[Citys] ([CityId], [CityName], [DivisionId]) VALUES (2, N'Jursy', 3)
GO
INSERT [dbo].[Citys] ([CityId], [CityName], [DivisionId]) VALUES (3, N'Mirpur', 1)
GO
SET IDENTITY_INSERT [dbo].[Citys] OFF
GO
SET IDENTITY_INSERT [dbo].[ClientContacts] ON 
GO
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate]) VALUES (1, N'umme', N'015244583632', N'ukfarhanaislam@gmail.com', CAST(N'2024-01-17T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate]) VALUES (2, N'umme', N'665632054', N'ukfarhanaislam@gmail.com', CAST(N'2024-01-17T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate]) VALUES (3, N'salim', N'88888', N's@s.com', CAST(N'2024-01-17T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate]) VALUES (4, N'dsfd', N'33333', N'ukfarhanaislam@gmail.com', CAST(N'2024-01-17T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate]) VALUES (6, N'fatu', N'012154561222', N'fatu21@gmail.com', CAST(N'2024-01-17T16:56:06.7354787' AS DateTime2))
GO
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate]) VALUES (7, N'fatu', N'01552145455', N'fatu125@gmail.com', CAST(N'2024-01-17T16:59:15.9529730' AS DateTime2))
GO
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate]) VALUES (8, N'eww', N'333', N'a@a.com', CAST(N'2024-01-17T17:01:25.0349543' AS DateTime2))
GO
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate]) VALUES (9, N'january', N'015224485', N'janu23@gmail.com', CAST(N'2024-01-17T17:05:52.6768835' AS DateTime2))
GO
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate]) VALUES (10, N'salim', N'4444', N'asd@gmail.com', CAST(N'2024-01-17T17:10:29.6779969' AS DateTime2))
GO
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate]) VALUES (11, N'salim', N'04511111', N'asd@gmail.com', CAST(N'2024-01-17T17:14:28.8717210' AS DateTime2))
GO
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate]) VALUES (12, N'salim', N'55555', N'ss@s.com', CAST(N'2024-01-17T17:21:28.6243914' AS DateTime2))
GO
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate]) VALUES (13, N'doyel', N'44444', N'd@d.com', CAST(N'2024-01-17T17:23:25.6537437' AS DateTime2))
GO
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate]) VALUES (14, N'e', N'6666', N'asd@gmail.com', CAST(N'2024-01-17T17:32:16.4231685' AS DateTime2))
GO
INSERT [dbo].[ClientContacts] ([ClientContactId], [ClientName], [ContactNo], [Email], [ContactDate]) VALUES (15, N'rtyrt', N'3333', N's@s.com', CAST(N'2024-01-17T17:36:26.3235701' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[ClientContacts] OFF
GO
SET IDENTITY_INSERT [dbo].[ClientInterest] ON 
GO
INSERT [dbo].[ClientInterest] ([ID], [ClientID], [PropertyID], [PropertyForId], [PropertyTypeId], [Message], [PropertyFor]) VALUES (4, 9, 2, N'1', 6, N'dfs', 0)
GO
INSERT [dbo].[ClientInterest] ([ID], [ClientID], [PropertyID], [PropertyForId], [PropertyTypeId], [Message], [PropertyFor]) VALUES (5, 10, 2, N'1', 6, N'hkj', 0)
GO
INSERT [dbo].[ClientInterest] ([ID], [ClientID], [PropertyID], [PropertyForId], [PropertyTypeId], [Message], [PropertyFor]) VALUES (6, 11, 2, N'1', 6, N'dfssf', 0)
GO
INSERT [dbo].[ClientInterest] ([ID], [ClientID], [PropertyID], [PropertyForId], [PropertyTypeId], [Message], [PropertyFor]) VALUES (7, 12, 2, N'1', 6, N'saasdasdasd', 0)
GO
INSERT [dbo].[ClientInterest] ([ID], [ClientID], [PropertyID], [PropertyForId], [PropertyTypeId], [Message], [PropertyFor]) VALUES (8, 13, 2, N'1', 6, N'aaasdadas', 0)
GO
INSERT [dbo].[ClientInterest] ([ID], [ClientID], [PropertyID], [PropertyForId], [PropertyTypeId], [Message], [PropertyFor]) VALUES (9, 14, 2, N'1', 6, N'edsfsdfdsfdsds', 0)
GO
INSERT [dbo].[ClientInterest] ([ID], [ClientID], [PropertyID], [PropertyForId], [PropertyTypeId], [Message], [PropertyFor]) VALUES (10, 15, 2, N'1', 6, N'trytryrty', 0)
GO
SET IDENTITY_INSERT [dbo].[ClientInterest] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 
GO
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (1, N'Bangladesh')
GO
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (2, N'United States')
GO
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[DevelopersorAgent] ON 
GO
INSERT [dbo].[DevelopersorAgent] ([ID], [Logo], [Banner], [CompanyName], [ContactNo], [Email], [Name], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [Address], [AreaID]) VALUES (2, N'~/Developer/Logo/Krishibid group.jpg', N'~/Developer/Banner/Krishibid group.jpg', N'Krishibid group', N'014447784965', N'k@K.com', N'Shahanaj', CAST(N'2024-01-12T00:00:00.0000000' AS DateTime2), N'devshahanaj123@gmail.com', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 1, N'Kazzipara', 1)
GO
INSERT [dbo].[DevelopersorAgent] ([ID], [Logo], [Banner], [CompanyName], [ContactNo], [Email], [Name], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [Address], [AreaID]) VALUES (3, N'~/Developer/Logo/Dhorittree Properties Ltd..png', N'~/Developer/Banner/Dhorittree Properties Ltd..jpg', N'Dhorittree Properties Ltd.', N'014447784966', N'd@d.com', N'Samu', CAST(N'2024-01-12T00:00:00.0000000' AS DateTime2), N'devshahanaj123@gmail.com', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 1, N'Shewrapara', 1)
GO
INSERT [dbo].[DevelopersorAgent] ([ID], [Logo], [Banner], [CompanyName], [ContactNo], [Email], [Name], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [Address], [AreaID]) VALUES (4, N'~/Developer/Logo/ BD Properties logo .png', N'~/Developer/Banner/ BD Properties _banner .jpg', N'BD Properties', N'014447784963', N'bd@d.com', N'Babu', CAST(N'2024-01-12T00:00:00.0000000' AS DateTime2), N'devshahanaj123@gmail.com', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 1, N'Mirpur-10', 1)
GO
SET IDENTITY_INSERT [dbo].[DevelopersorAgent] OFF
GO
SET IDENTITY_INSERT [dbo].[Divisions] ON 
GO
INSERT [dbo].[Divisions] ([DivisionID], [DivisionName], [CountryId]) VALUES (1, N'Dhaka', 1)
GO
INSERT [dbo].[Divisions] ([DivisionID], [DivisionName], [CountryId]) VALUES (2, N'Rangpur', 1)
GO
INSERT [dbo].[Divisions] ([DivisionID], [DivisionName], [CountryId]) VALUES (3, N'Newyork', 2)
GO
SET IDENTITY_INSERT [dbo].[Divisions] OFF
GO
SET IDENTITY_INSERT [dbo].[MeasurementUnit] ON 
GO
INSERT [dbo].[MeasurementUnit] ([Id], [Name], [ShortName]) VALUES (1, N'Square Fit', N'SQFT')
GO
INSERT [dbo].[MeasurementUnit] ([Id], [Name], [ShortName]) VALUES (2, N'Katha', N'katha')
GO
INSERT [dbo].[MeasurementUnit] ([Id], [Name], [ShortName]) VALUES (3, N'shotok', N'shotok')
GO
SET IDENTITY_INSERT [dbo].[MeasurementUnit] OFF
GO
SET IDENTITY_INSERT [dbo].[ProjectsInfo] ON 
GO
INSERT [dbo].[ProjectsInfo] ([Id], [Title], [Description], [ProjectName], [Location], [LocationMap], [AgentID], [AreaID], [ProjectVideo]) VALUES (3, N'Dharitree Garden city', NULL, N'Dharitree Garden city', N'dssadasda', NULL, 2, 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[ProjectsInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[PropertyDetails] ON 
GO
INSERT [dbo].[PropertyDetails] ([PropertyInfoId], [Title], [Description], [PropertyName], [Location], [ConstructionStatus], [PropertySize], [NumberOfBedrooms], [NumberOfBaths], [NumberOfBalconies], [NumberOfGarages], [TotalFloor], [FloorAvailableNo], [Furnishing], [Facing], [LandArea], [Price], [Path], [Comments], [PropertyCondition], [HandOverDate], [PropertyTypeId], [ProjectId], [AreaId], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [PropertyFor], [ISFeatured], [MeasurementID]) VALUES (2, N'Zahora Garden', N'<p>2210sft 6floor GYM,Swimming Pul at Bashundhara</p>

<p>4Bed, 4Bath, Living, Dining, Kitchen, Veranda, Swimming Pul, Gym,Community Hall, Kids Play Ground, Roof Top Garden.</p>

<p>More Detail Please Contact</p>

<p>Soyeb</p>
', N'Zahora Garden', N'Mina Bazar house no-05', 1, 1522, 3, 3, 2, 1, 15, 0, 1, 2, 0, 1522, N'/Content/Images/Zahora Garden.jpg', N'safdfsa', 0, CAST(N'2024-01-17T00:00:00.0000000' AS DateTime2), 6, 3, 2, CAST(N'2024-01-15T13:00:57.6871735' AS DateTime2), N'umme', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 1, 1, 0, 2)
GO
INSERT [dbo].[PropertyDetails] ([PropertyInfoId], [Title], [Description], [PropertyName], [Location], [ConstructionStatus], [PropertySize], [NumberOfBedrooms], [NumberOfBaths], [NumberOfBalconies], [NumberOfGarages], [TotalFloor], [FloorAvailableNo], [Furnishing], [Facing], [LandArea], [Price], [Path], [Comments], [PropertyCondition], [HandOverDate], [PropertyTypeId], [ProjectId], [AreaId], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [PropertyFor], [ISFeatured], [MeasurementID]) VALUES (9, N'hf', N'<p>jhkjgh ghfhj ghj&nbsp;</p>
', N'n', N'Senpara Porbota, near Rupayan', 2, 1548, 3, 2, 2, 1, 15, 5, 1, 4, 12, 15264, N'/Content/Images/hf.jpg', N'dsa', 0, CAST(N'2024-01-11T00:00:00.0000000' AS DateTime2), 5, 3, 1, CAST(N'2024-01-15T14:22:34.6660494' AS DateTime2), N'umme', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 1, 1, 0, 2)
GO
INSERT [dbo].[PropertyDetails] ([PropertyInfoId], [Title], [Description], [PropertyName], [Location], [ConstructionStatus], [PropertySize], [NumberOfBedrooms], [NumberOfBaths], [NumberOfBalconies], [NumberOfGarages], [TotalFloor], [FloorAvailableNo], [Furnishing], [Facing], [LandArea], [Price], [Path], [Comments], [PropertyCondition], [HandOverDate], [PropertyTypeId], [ProjectId], [AreaId], [CreatedDate], [CreatedBy], [UpdateDate], [UpdateBy], [IsActive], [PropertyFor], [ISFeatured], [MeasurementID]) VALUES (10, N'Runner Story House', N'<p>dfsa fdga</p>
', N'Runner Story House', N'Agargaon , Dhaka', 2, 1524, 2, 1, 2, 1, 9, 5, 1, 2, 5, 125, N'/Content/Images/Runner Story House.jpg', N'das', 0, CAST(N'2024-01-18T00:00:00.0000000' AS DateTime2), 4, 3, 2, CAST(N'2024-01-15T17:49:55.1860913' AS DateTime2), N'umme', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 1, 1, 0, 2)
GO
SET IDENTITY_INSERT [dbo].[PropertyDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[PropertyFeatures] ON 
GO
INSERT [dbo].[PropertyFeatures] ([PropertyFeatureId], [PropertyFeatureName], [FeatureDescription]) VALUES (1, N'Security', N'Security')
GO
INSERT [dbo].[PropertyFeatures] ([PropertyFeatureId], [PropertyFeatureName], [FeatureDescription]) VALUES (2, N'Lift', N'Lift')
GO
SET IDENTITY_INSERT [dbo].[PropertyFeatures] OFF
GO
SET IDENTITY_INSERT [dbo].[PropertyTypes] ON 
GO
INSERT [dbo].[PropertyTypes] ([PropertyTypeId], [PropertyTypeName], [ParentPropertyTypeId]) VALUES (1, N'Commercial', 0)
GO
INSERT [dbo].[PropertyTypes] ([PropertyTypeId], [PropertyTypeName], [ParentPropertyTypeId]) VALUES (2, N'Residencial', 0)
GO
INSERT [dbo].[PropertyTypes] ([PropertyTypeId], [PropertyTypeName], [ParentPropertyTypeId]) VALUES (3, N'Land/Plot', 0)
GO
INSERT [dbo].[PropertyTypes] ([PropertyTypeId], [PropertyTypeName], [ParentPropertyTypeId]) VALUES (4, N'Apartment', 1)
GO
INSERT [dbo].[PropertyTypes] ([PropertyTypeId], [PropertyTypeName], [ParentPropertyTypeId]) VALUES (5, N'Office space', 1)
GO
INSERT [dbo].[PropertyTypes] ([PropertyTypeId], [PropertyTypeName], [ParentPropertyTypeId]) VALUES (6, N'Apartment', 2)
GO
SET IDENTITY_INSERT [dbo].[PropertyTypes] OFF
GO
/****** Object:  Index [IX_Areas_CityId]    Script Date: 1/17/2024 7:32:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_Areas_CityId] ON [dbo].[Areas]
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 1/17/2024 7:32:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 1/17/2024 7:32:23 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 1/17/2024 7:32:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 1/17/2024 7:32:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 1/17/2024 7:32:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 1/17/2024 7:32:23 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 1/17/2024 7:32:23 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Citys_DivisionId]    Script Date: 1/17/2024 7:32:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_Citys_DivisionId] ON [dbo].[Citys]
(
	[DivisionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientInterest_ClientID]    Script Date: 1/17/2024 7:32:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_ClientInterest_ClientID] ON [dbo].[ClientInterest]
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientInterest_PropertyID]    Script Date: 1/17/2024 7:32:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_ClientInterest_PropertyID] ON [dbo].[ClientInterest]
(
	[PropertyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientInterest_PropertyTypeId]    Script Date: 1/17/2024 7:32:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_ClientInterest_PropertyTypeId] ON [dbo].[ClientInterest]
(
	[PropertyTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DevelopersorAgent_AreaID]    Script Date: 1/17/2024 7:32:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_DevelopersorAgent_AreaID] ON [dbo].[DevelopersorAgent]
(
	[AreaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Divisions_CountryId]    Script Date: 1/17/2024 7:32:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_Divisions_CountryId] ON [dbo].[Divisions]
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FloorPlans_PropertyInfoID]    Script Date: 1/17/2024 7:32:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_FloorPlans_PropertyInfoID] ON [dbo].[FloorPlans]
(
	[PropertyInfoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProjectImageGallery_ProjectID]    Script Date: 1/17/2024 7:32:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProjectImageGallery_ProjectID] ON [dbo].[ProjectImageGallery]
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProjectsInfo_AgentID]    Script Date: 1/17/2024 7:32:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProjectsInfo_AgentID] ON [dbo].[ProjectsInfo]
(
	[AgentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProjectsInfo_AreaID]    Script Date: 1/17/2024 7:32:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProjectsInfo_AreaID] ON [dbo].[ProjectsInfo]
(
	[AreaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyDetails_AreaId]    Script Date: 1/17/2024 7:32:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyDetails_AreaId] ON [dbo].[PropertyDetails]
(
	[AreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyDetails_MeasurementID]    Script Date: 1/17/2024 7:32:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyDetails_MeasurementID] ON [dbo].[PropertyDetails]
(
	[MeasurementID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyDetails_ProjectId]    Script Date: 1/17/2024 7:32:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyDetails_ProjectId] ON [dbo].[PropertyDetails]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyDetails_PropertyTypeId]    Script Date: 1/17/2024 7:32:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyDetails_PropertyTypeId] ON [dbo].[PropertyDetails]
(
	[PropertyTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyImages_propertyInfoId]    Script Date: 1/17/2024 7:32:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyImages_propertyInfoId] ON [dbo].[PropertyImages]
(
	[propertyInfoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyWithFeatures_FeatureId]    Script Date: 1/17/2024 7:32:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyWithFeatures_FeatureId] ON [dbo].[PropertyWithFeatures]
(
	[FeatureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyWithFeatures_PropertyId]    Script Date: 1/17/2024 7:32:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyWithFeatures_PropertyId] ON [dbo].[PropertyWithFeatures]
(
	[PropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DevelopersorAgent] ADD  DEFAULT (N'') FOR [Address]
GO
ALTER TABLE [dbo].[DevelopersorAgent] ADD  DEFAULT ((0)) FOR [AreaID]
GO
ALTER TABLE [dbo].[ProjectsInfo] ADD  DEFAULT ((0)) FOR [AreaID]
GO
ALTER TABLE [dbo].[PropertyDetails] ADD  DEFAULT (CONVERT([bit],(0))) FOR [ISFeatured]
GO
ALTER TABLE [dbo].[PropertyDetails] ADD  DEFAULT ((0)) FOR [MeasurementID]
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
