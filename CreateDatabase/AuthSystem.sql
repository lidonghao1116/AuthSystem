USE [master]
GO
/****** Object:  Database [TestAuth]    Script Date: 2015/6/17 17:47:08 ******/
CREATE DATABASE [TestAuth]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TestAuth', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.ACSQL\MSSQL\DATA\TestAuth.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TestAuth_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.ACSQL\MSSQL\DATA\TestAuth_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TestAuth] SET COMPATIBILITY_LEVEL = 90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestAuth].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestAuth] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestAuth] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestAuth] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestAuth] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestAuth] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestAuth] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TestAuth] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [TestAuth] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestAuth] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestAuth] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestAuth] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestAuth] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestAuth] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestAuth] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestAuth] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestAuth] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TestAuth] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestAuth] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestAuth] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestAuth] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestAuth] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestAuth] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TestAuth] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestAuth] SET RECOVERY FULL 
GO
ALTER DATABASE [TestAuth] SET  MULTI_USER 
GO
ALTER DATABASE [TestAuth] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestAuth] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestAuth] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestAuth] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TestAuth', N'ON'
GO
USE [TestAuth]
GO
/****** Object:  Table [dbo].[AuthCangKu]    Script Date: 2015/6/17 17:47:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthCangKu](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CangKu_ID] [nvarchar](50) NOT NULL,
	[CangKu_Name] [nvarchar](50) NOT NULL,
	[CangKu_BeiZhu] [nvarchar](100) NULL,
 CONSTRAINT [PK_AuthCangKu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AuthGr2Ca]    Script Date: 2015/6/17 17:47:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthGr2Ca](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Group_CangKu_ID] [nvarchar](50) NULL,
	[CangKu_ID] [nvarchar](50) NULL,
 CONSTRAINT [PK_AuthGr2Ca] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AuthGr2Ru]    Script Date: 2015/6/17 17:47:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthGr2Ru](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Group_Rule_ID] [nvarchar](50) NULL,
	[Rule_ID] [nvarchar](50) NULL,
 CONSTRAINT [PK_AuthGr2Ru] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AuthGroups]    Script Date: 2015/6/17 17:47:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthGroups](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Group_ID] [nvarchar](50) NOT NULL,
	[Group_Name] [nvarchar](50) NOT NULL,
	[Group_Status] [bit] NOT NULL,
	[Group_Rule_ID] [nvarchar](50) NULL,
	[Group_CangKu_ID] [nvarchar](50) NULL,
	[Group_BeiZhu] [nvarchar](100) NULL,
 CONSTRAINT [PK_AuthGroups] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AuthItems]    Script Date: 2015/6/17 17:47:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthItems](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Item_ID] [nvarchar](50) NOT NULL,
	[Item_Name] [nvarchar](50) NOT NULL,
	[Item_NameSpace] [nvarchar](50) NOT NULL,
	[Item_BeiZhu] [nvarchar](100) NULL,
 CONSTRAINT [PK_AuthItems] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AuthRu2It]    Script Date: 2015/6/17 17:47:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthRu2It](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Rule_Item_ID] [nvarchar](50) NULL,
	[Item_ID] [nvarchar](50) NULL,
 CONSTRAINT [PK_AuthRu2It] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AuthRules]    Script Date: 2015/6/17 17:47:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthRules](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Rule_ID] [nvarchar](50) NOT NULL,
	[Rule_Name] [nvarchar](50) NOT NULL,
	[Rule_Item_ID] [nvarchar](50) NOT NULL,
	[Rule_BeiZhu] [nvarchar](100) NULL,
 CONSTRAINT [PK_AuthRules] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AuthUsers]    Script Date: 2015/6/17 17:47:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthUsers](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[User_ID] [nvarchar](50) NOT NULL,
	[User_Name] [nvarchar](50) NOT NULL,
	[User_Text] [nvarchar](50) NULL,
	[User_Pass] [nvarchar](50) NULL,
	[User_Tel] [nvarchar](50) NULL,
	[User_QQ] [nvarchar](50) NULL,
	[User_Email] [nvarchar](50) NULL,
	[User_Status] [bit] NOT NULL,
	[User_Group] [nvarchar](50) NULL,
	[User_CangKu] [nvarchar](50) NULL,
	[User_BeiZhu] [nvarchar](100) NULL
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[AuthAllData]    Script Date: 2015/6/17 17:47:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AuthAllData]
AS
SELECT   dbo.AuthGroups.Group_ID, dbo.AuthGroups.Group_Name, dbo.AuthGroups.Group_Status, dbo.AuthRules.Rule_Name, 
                dbo.AuthItems.Item_Name
FROM      dbo.AuthGroups INNER JOIN
                dbo.AuthGr2Ru ON dbo.AuthGroups.Group_Rule_ID = dbo.AuthGr2Ru.Group_Rule_ID INNER JOIN
                dbo.AuthRules ON dbo.AuthGr2Ru.Rule_ID = dbo.AuthRules.Rule_ID INNER JOIN
                dbo.AuthRu2It ON dbo.AuthRules.Rule_Item_ID = dbo.AuthRu2It.Rule_Item_ID INNER JOIN
                dbo.AuthItems ON dbo.AuthRu2It.Item_ID = dbo.AuthItems.Item_ID

GO
/****** Object:  View [dbo].[AuthGroupsItems]    Script Date: 2015/6/17 17:47:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AuthGroupsItems]
AS
SELECT   dbo.AuthGroups.Group_ID, dbo.AuthGroups.Group_Name, dbo.AuthGroups.Group_Status, dbo.AuthRules.Rule_Name, 
                dbo.AuthItems.Item_Name, dbo.AuthItems.Item_ID, dbo.AuthItems.Item_NameSpace, dbo.AuthItems.Item_BeiZhu
FROM      dbo.AuthGroups INNER JOIN
                dbo.AuthGr2Ru ON dbo.AuthGroups.Group_Rule_ID = dbo.AuthGr2Ru.Group_Rule_ID INNER JOIN
                dbo.AuthRules ON dbo.AuthGr2Ru.Rule_ID = dbo.AuthRules.Rule_ID INNER JOIN
                dbo.AuthRu2It ON dbo.AuthRules.Rule_Item_ID = dbo.AuthRu2It.Rule_Item_ID INNER JOIN
                dbo.AuthItems ON dbo.AuthRu2It.Item_ID = dbo.AuthItems.Item_ID

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[44] 4[17] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "AuthGroups"
            Begin Extent = 
               Top = 17
               Left = 110
               Bottom = 156
               Right = 304
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "AuthGr2Ru"
            Begin Extent = 
               Top = 6
               Left = 342
               Bottom = 181
               Right = 516
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AuthRules"
            Begin Extent = 
               Top = 6
               Left = 554
               Bottom = 187
               Right = 717
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AuthRu2It"
            Begin Extent = 
               Top = 6
               Left = 755
               Bottom = 126
               Right = 918
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AuthItems"
            Begin Extent = 
               Top = 6
               Left = 956
               Bottom = 169
               Right = 1146
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AuthAllData'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AuthAllData'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AuthAllData'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[44] 4[17] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "AuthGroups"
            Begin Extent = 
               Top = 17
               Left = 110
               Bottom = 156
               Right = 304
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "AuthGr2Ru"
            Begin Extent = 
               Top = 6
               Left = 342
               Bottom = 126
               Right = 516
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AuthRules"
            Begin Extent = 
               Top = 6
               Left = 554
               Bottom = 187
               Right = 717
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AuthRu2It"
            Begin Extent = 
               Top = 6
               Left = 755
               Bottom = 126
               Right = 918
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AuthItems"
            Begin Extent = 
               Top = 6
               Left = 956
               Bottom = 169
               Right = 1146
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AuthGroupsItems'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AuthGroupsItems'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AuthGroupsItems'
GO
USE [master]
GO
ALTER DATABASE [TestAuth] SET  READ_WRITE 
GO
