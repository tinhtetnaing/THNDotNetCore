USE [master]
GO
/****** Object:  Database [MyDB]    Script Date: 14/05/2024 13:44:01 ******/
CREATE DATABASE [MyDB] ON  PRIMARY 
( NAME = N'MyDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MyDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MyDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyDB] SET RECOVERY FULL 
GO
ALTER DATABASE [MyDB] SET  MULTI_USER 
GO
ALTER DATABASE [MyDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyDB] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MyDB', N'ON'
GO
USE [MyDB]
GO
/****** Object:  Table [dbo].[TBL_BLOG]    Script Date: 14/05/2024 13:44:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_BLOG](
	[BlogId] [int] IDENTITY(1,1) NOT NULL,
	[BlogTitle] [varchar](50) NULL,
	[BlogAuthor] [varchar](50) NULL,
	[BlogContent] [varchar](50) NULL,
 CONSTRAINT [PK_TBL_BLOG] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TBL_BLOG] ON 

INSERT [dbo].[TBL_BLOG] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (8, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[TBL_BLOG] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (9, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[TBL_BLOG] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (10, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[TBL_BLOG] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (11, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[TBL_BLOG] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (12, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[TBL_BLOG] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (13, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[TBL_BLOG] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (14, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[TBL_BLOG] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (15, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[TBL_BLOG] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (16, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[TBL_BLOG] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (17, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[TBL_BLOG] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (18, N'title', N'author', N'content')
INSERT [dbo].[TBL_BLOG] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (19, N'UpdatedTitle', N'UpdatedAuthor', N'UpdatedContent')
INSERT [dbo].[TBL_BLOG] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (23, N'title', N'author', N'content')
INSERT [dbo].[TBL_BLOG] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (24, N'title', N'author', N'content')
SET IDENTITY_INSERT [dbo].[TBL_BLOG] OFF
GO
USE [master]
GO
ALTER DATABASE [MyDB] SET  READ_WRITE 
GO
