USE [master]
GO
/****** Object:  Database [Biblioteca]    Script Date: 17/04/2022 10:51:52 a. m. ******/
CREATE DATABASE [Biblioteca]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Biblioteca', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Biblioteca.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Biblioteca_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Biblioteca_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Biblioteca] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Biblioteca].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Biblioteca] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Biblioteca] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Biblioteca] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Biblioteca] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Biblioteca] SET ARITHABORT OFF 
GO
ALTER DATABASE [Biblioteca] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Biblioteca] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Biblioteca] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Biblioteca] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Biblioteca] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Biblioteca] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Biblioteca] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Biblioteca] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Biblioteca] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Biblioteca] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Biblioteca] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Biblioteca] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Biblioteca] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Biblioteca] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Biblioteca] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Biblioteca] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Biblioteca] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Biblioteca] SET RECOVERY FULL 
GO
ALTER DATABASE [Biblioteca] SET  MULTI_USER 
GO
ALTER DATABASE [Biblioteca] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Biblioteca] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Biblioteca] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Biblioteca] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Biblioteca] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Biblioteca] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Biblioteca', N'ON'
GO
ALTER DATABASE [Biblioteca] SET QUERY_STORE = OFF
GO
USE [Biblioteca]
GO
/****** Object:  Table [dbo].[t01_libro]    Script Date: 17/04/2022 10:51:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t01_libro](
	[f01_rowid] [int] IDENTITY(1,1) NOT NULL,
	[f01_titulo] [nvarchar](100) NOT NULL,
	[f01_fecha] [date] NOT NULL,
	[f01_genero] [nvarchar](50) NOT NULL,
	[f01_num_paginas] [int] NULL,
	[f01_autor] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_t01_libro_1] PRIMARY KEY CLUSTERED 
(
	[f01_rowid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t02_autor]    Script Date: 17/04/2022 10:51:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t02_autor](
	[f02_rowid] [int] IDENTITY(1,1) NOT NULL,
	[f02_nombre] [nvarchar](80) NOT NULL,
	[f02_fecha_nacimiento] [date] NOT NULL,
	[f02_ciudad] [nvarchar](50) NULL,
	[f02_correo] [nvarchar](50) NULL,
 CONSTRAINT [PK_t02_autor_1] PRIMARY KEY CLUSTERED 
(
	[f02_rowid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[t01_libro] ON 
GO
INSERT [dbo].[t01_libro] ([f01_rowid], [f01_titulo], [f01_fecha], [f01_genero], [f01_num_paginas], [f01_autor]) VALUES (1, N'Romero y Julieta', CAST(N'1595-01-01' AS Date), N'Drama', 165, N'William Shakespeare')
GO
INSERT [dbo].[t01_libro] ([f01_rowid], [f01_titulo], [f01_fecha], [f01_genero], [f01_num_paginas], [f01_autor]) VALUES (2, N'Harry Potter', CAST(N'2001-01-01' AS Date), N'Aventura', 600, N'J.K. Rowling')
GO
INSERT [dbo].[t01_libro] ([f01_rowid], [f01_titulo], [f01_fecha], [f01_genero], [f01_num_paginas], [f01_autor]) VALUES (3, N'Harry Potter - Las reliquias de la muerte', CAST(N'2011-01-01' AS Date), N'Aventura', 900, N'J.K. Rowling')
GO
INSERT [dbo].[t01_libro] ([f01_rowid], [f01_titulo], [f01_fecha], [f01_genero], [f01_num_paginas], [f01_autor]) VALUES (8, N'Sun And Moon', CAST(N'2008-04-13' AS Date), N'Ficcion', 170, N'Cristian Paz')
GO
INSERT [dbo].[t01_libro] ([f01_rowid], [f01_titulo], [f01_fecha], [f01_genero], [f01_num_paginas], [f01_autor]) VALUES (12, N'Tails', CAST(N'2008-04-13' AS Date), N'Ficcion', 170, N'Cristian Paz')
GO
INSERT [dbo].[t01_libro] ([f01_rowid], [f01_titulo], [f01_fecha], [f01_genero], [f01_num_paginas], [f01_autor]) VALUES (13, N'Elder Ring', CAST(N'2022-04-14' AS Date), N'Ficcion', 170, N'Cristian Paz')
GO
INSERT [dbo].[t01_libro] ([f01_rowid], [f01_titulo], [f01_fecha], [f01_genero], [f01_num_paginas], [f01_autor]) VALUES (15, N'Halo', CAST(N'2022-04-14' AS Date), N'Accion', 150, N'J.K. Rowling')
GO
INSERT [dbo].[t01_libro] ([f01_rowid], [f01_titulo], [f01_fecha], [f01_genero], [f01_num_paginas], [f01_autor]) VALUES (22, N'Romero y Julieta3', CAST(N'2022-04-17' AS Date), N'Drama', 165, N'William Shakespeare')
GO
INSERT [dbo].[t01_libro] ([f01_rowid], [f01_titulo], [f01_fecha], [f01_genero], [f01_num_paginas], [f01_autor]) VALUES (23, N'Romero y Julieta3', CAST(N'2022-04-17' AS Date), N'Drama', 165, N'William Shakespeare')
GO
INSERT [dbo].[t01_libro] ([f01_rowid], [f01_titulo], [f01_fecha], [f01_genero], [f01_num_paginas], [f01_autor]) VALUES (24, N'HaloCe', CAST(N'0001-01-01' AS Date), N'accion', 124, N'Cristian Paz')
GO
INSERT [dbo].[t01_libro] ([f01_rowid], [f01_titulo], [f01_fecha], [f01_genero], [f01_num_paginas], [f01_autor]) VALUES (25, N'HaloCe', CAST(N'2022-04-16' AS Date), N'accion', 124, N'Cristian Paz')
GO
INSERT [dbo].[t01_libro] ([f01_rowid], [f01_titulo], [f01_fecha], [f01_genero], [f01_num_paginas], [f01_autor]) VALUES (26, N'Mario', CAST(N'2022-04-16' AS Date), N'Aventura', 8, N'Cristian Paz')
GO
INSERT [dbo].[t01_libro] ([f01_rowid], [f01_titulo], [f01_fecha], [f01_genero], [f01_num_paginas], [f01_autor]) VALUES (27, N'Halo 2', CAST(N'2022-04-18' AS Date), N'Accion', 14, N'Cristian Paz')
GO
INSERT [dbo].[t01_libro] ([f01_rowid], [f01_titulo], [f01_fecha], [f01_genero], [f01_num_paginas], [f01_autor]) VALUES (28, N'Harry Potter 10', CAST(N'2022-04-23' AS Date), N'Magia', 158, N'Cristian Paz')
GO
SET IDENTITY_INSERT [dbo].[t01_libro] OFF
GO
SET IDENTITY_INSERT [dbo].[t02_autor] ON 
GO
INSERT [dbo].[t02_autor] ([f02_rowid], [f02_nombre], [f02_fecha_nacimiento], [f02_ciudad], [f02_correo]) VALUES (1, N'William Shakespeare', CAST(N'1564-04-26' AS Date), N'Reino unido', N'')
GO
INSERT [dbo].[t02_autor] ([f02_rowid], [f02_nombre], [f02_fecha_nacimiento], [f02_ciudad], [f02_correo]) VALUES (3, N'Gabriel Garcia Marquez', CAST(N'1985-08-05' AS Date), N'Colombiano', N'N/A')
GO
INSERT [dbo].[t02_autor] ([f02_rowid], [f02_nombre], [f02_fecha_nacimiento], [f02_ciudad], [f02_correo]) VALUES (4, N'Edgar Allan Poe', CAST(N'1585-08-05' AS Date), N'Estados unidos', N'N/A')
GO
INSERT [dbo].[t02_autor] ([f02_rowid], [f02_nombre], [f02_fecha_nacimiento], [f02_ciudad], [f02_correo]) VALUES (7, N'J.K. Rowling', CAST(N'1564-04-26' AS Date), N'Reino unido', N'rowling@harry.com')
GO
INSERT [dbo].[t02_autor] ([f02_rowid], [f02_nombre], [f02_fecha_nacimiento], [f02_ciudad], [f02_correo]) VALUES (12, N'Jorge Luis Borges', CAST(N'1889-01-01' AS Date), N'n/a', N'n/a')
GO
INSERT [dbo].[t02_autor] ([f02_rowid], [f02_nombre], [f02_fecha_nacimiento], [f02_ciudad], [f02_correo]) VALUES (13, N'Luis Garcia Moreno', CAST(N'2001-01-01' AS Date), N'n/a', N'N/a')
GO
SET IDENTITY_INSERT [dbo].[t02_autor] OFF
GO
USE [master]
GO
ALTER DATABASE [Biblioteca] SET  READ_WRITE 
GO
