USE [master]
GO
/****** Object:  Database [Tp2.Truco]    Script Date: 20/11/2022 20:30:30 ******/
CREATE DATABASE [Tp2.Truco]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Tp2,Truco', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Tp2,Truco.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Tp2,Truco_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Tp2,Truco_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Tp2.Truco] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Tp2.Truco].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Tp2.Truco] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Tp2.Truco] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Tp2.Truco] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Tp2.Truco] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Tp2.Truco] SET ARITHABORT OFF 
GO
ALTER DATABASE [Tp2.Truco] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Tp2.Truco] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Tp2.Truco] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Tp2.Truco] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Tp2.Truco] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Tp2.Truco] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Tp2.Truco] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Tp2.Truco] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Tp2.Truco] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Tp2.Truco] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Tp2.Truco] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Tp2.Truco] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Tp2.Truco] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Tp2.Truco] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Tp2.Truco] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Tp2.Truco] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Tp2.Truco] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Tp2.Truco] SET RECOVERY FULL 
GO
ALTER DATABASE [Tp2.Truco] SET  MULTI_USER 
GO
ALTER DATABASE [Tp2.Truco] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Tp2.Truco] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Tp2.Truco] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Tp2.Truco] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Tp2.Truco] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Tp2.Truco] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Tp2.Truco', N'ON'
GO
ALTER DATABASE [Tp2.Truco] SET QUERY_STORE = OFF
GO
USE [Tp2.Truco]
GO
/****** Object:  Table [dbo].[Jugadores]    Script Date: 20/11/2022 20:30:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jugadores](
	[id] [int] NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[partidosGanados] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Jugadores] ([id], [nombre], [partidosGanados]) VALUES (1, N'Hernan', 3072)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidosGanados]) VALUES (2, N'Juanse', 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidosGanados]) VALUES (3, N'Jaco', 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidosGanados]) VALUES (4, N'Max', 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidosGanados]) VALUES (5, N'Octavio', 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidosGanados]) VALUES (6, N'Ornela', 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidosGanados]) VALUES (7, N'Peposo', 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidosGanados]) VALUES (8, N'Lucas', 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidosGanados]) VALUES (9, N'Esteban', 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidosGanados]) VALUES (10, N'Perugia', 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidosGanados]) VALUES (11, N'Juan', 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidosGanados]) VALUES (12, N'Ugo', 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidosGanados]) VALUES (13, N'Inessa', 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidosGanados]) VALUES (14, N'Averil', 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidosGanados]) VALUES (15, N'Nessie', 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidosGanados]) VALUES (16, N'Teressa', 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidosGanados]) VALUES (17, N'Byram', 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidosGanados]) VALUES (18, N'Ivie', 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidosGanados]) VALUES (19, N'Arte', 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidosGanados]) VALUES (20, N'Goldina', 0)
GO
USE [master]
GO
ALTER DATABASE [Tp2.Truco] SET  READ_WRITE 
GO
