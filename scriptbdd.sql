USE [master]
GO
/****** Object:  Database [Wdr_Tests]    Script Date: 22/01/2019 10:12:27 ******/
CREATE DATABASE [Wdr_Tests]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Wdr_Tests', FILENAME = N'F:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Wdr_Tests.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Wdr_Tests_log', FILENAME = N'L:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\Data\Wdr_Tests_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Wdr_Tests] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Wdr_Tests].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Wdr_Tests] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Wdr_Tests] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Wdr_Tests] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Wdr_Tests] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Wdr_Tests] SET ARITHABORT OFF 
GO
ALTER DATABASE [Wdr_Tests] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Wdr_Tests] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Wdr_Tests] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Wdr_Tests] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Wdr_Tests] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Wdr_Tests] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Wdr_Tests] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Wdr_Tests] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Wdr_Tests] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Wdr_Tests] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Wdr_Tests] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Wdr_Tests] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Wdr_Tests] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Wdr_Tests] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Wdr_Tests] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Wdr_Tests] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Wdr_Tests] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Wdr_Tests] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Wdr_Tests] SET RECOVERY FULL 
GO
ALTER DATABASE [Wdr_Tests] SET  MULTI_USER 
GO
ALTER DATABASE [Wdr_Tests] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Wdr_Tests] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Wdr_Tests] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Wdr_Tests] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Wdr_Tests', N'ON'
GO
USE [Wdr_Tests]
GO
/****** Object:  User [APHM\E014200]    Script Date: 22/01/2019 10:12:27 ******/
CREATE USER [APHM\E014200] FOR LOGIN [APHM\E014200] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [APHM\E014200]
GO
/****** Object:  Table [dbo].[Couleurs]    Script Date: 22/01/2019 10:12:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Couleurs](
	[co_id] [uniqueidentifier] NOT NULL,
	[co_lib] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Couleurs] PRIMARY KEY CLUSTERED 
(
	[co_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Marques]    Script Date: 22/01/2019 10:12:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Marques](
	[ma_id] [uniqueidentifier] NOT NULL,
	[ma_lib] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Marques] PRIMARY KEY CLUSTERED 
(
	[ma_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Modeles]    Script Date: 22/01/2019 10:12:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Modeles](
	[mo_id] [uniqueidentifier] NOT NULL,
	[mo_lib] [varchar](50) NOT NULL,
	[mo_cheveaux] [int] NOT NULL,
	[mo_portes] [tinyint] NOT NULL,
	[mo_ma_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Modeles] PRIMARY KEY CLUSTERED 
(
	[mo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Voitures]    Script Date: 22/01/2019 10:12:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Voitures](
	[vo_id] [uniqueidentifier] NOT NULL,
	[vo_km] [int] NOT NULL,
	[vo_immat] [varchar](50) NOT NULL,
	[vo_co_id] [uniqueidentifier] NOT NULL,
	[vo_mo_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Voitures] PRIMARY KEY CLUSTERED 
(
	[vo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Modeles]  WITH CHECK ADD  CONSTRAINT [FK_Modeles_Marques] FOREIGN KEY([mo_ma_id])
REFERENCES [dbo].[Marques] ([ma_id])
GO
ALTER TABLE [dbo].[Modeles] CHECK CONSTRAINT [FK_Modeles_Marques]
GO
ALTER TABLE [dbo].[Voitures]  WITH CHECK ADD  CONSTRAINT [FK_Voitures_Couleurs] FOREIGN KEY([vo_co_id])
REFERENCES [dbo].[Couleurs] ([co_id])
GO
ALTER TABLE [dbo].[Voitures] CHECK CONSTRAINT [FK_Voitures_Couleurs]
GO
ALTER TABLE [dbo].[Voitures]  WITH CHECK ADD  CONSTRAINT [FK_Voitures_Modeles] FOREIGN KEY([vo_mo_id])
REFERENCES [dbo].[Modeles] ([mo_id])
GO
ALTER TABLE [dbo].[Voitures] CHECK CONSTRAINT [FK_Voitures_Modeles]
GO
USE [master]
GO
ALTER DATABASE [Wdr_Tests] SET  READ_WRITE 
GO
