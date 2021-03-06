USE [Billing_Customized]
GO
/****** Object:  Table [dbo].[AdminDetails]    Script Date: 3/3/2021 7:56:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminDetails](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AdminName] [nvarchar](50) NOT NULL,
	[UserId] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Last LoggedIn Time] [datetime] NULL,
	[Last LoggedOut Time] [datetime] NULL,
 CONSTRAINT [PK_AdminDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductSalesDetails]    Script Date: 3/3/2021 7:56:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSalesDetails](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SoldDate] [datetime] NOT NULL,
	[BillNumber] [bigint] NULL,
	[ProductId] [bigint] NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[Quantity] [decimal](18, 0) NOT NULL,
	[BillAmount] [money] NOT NULL,
	[GstAmount] [money] NOT NULL,
 CONSTRAINT [PK_ProductSalesDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesDetails]    Script Date: 3/3/2021 7:56:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesDetails](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[BillNos] [bigint] NOT NULL,
	[BillAmount] [money] NOT NULL,
	[GstAmount] [money] NOT NULL,
	[SalesDate] [datetime] NOT NULL,
 CONSTRAINT [PK_SalesDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockDetails]    Script Date: 3/3/2021 7:56:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockDetails](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[BuyingPrice] [money] NOT NULL,
	[RetailPrice] [money] NOT NULL,
	[WholesalePrice] [money] NOT NULL,
	[CreditPrice] [money] NOT NULL,
	[GSTPercentage] [int] NOT NULL,
 CONSTRAINT [PK_StockDetails] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AdminDetails] ON 

INSERT [dbo].[AdminDetails] ([Id], [AdminName], [UserId], [Password], [Last LoggedIn Time], [Last LoggedOut Time]) VALUES (1, N'Azar', N'111', N'MTEx', CAST(N'2021-03-03T03:23:31.283' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[AdminDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[StockDetails] ON 

INSERT [dbo].[StockDetails] ([Id], [ProductId], [ProductName], [Quantity], [BuyingPrice], [RetailPrice], [WholesalePrice], [CreditPrice], [GSTPercentage]) VALUES (4, 2, N'Prd', CAST(34.00 AS Decimal(18, 2)), 35.5000, 34.5000, 24.5000, 23.5000, 0)
SET IDENTITY_INSERT [dbo].[StockDetails] OFF
GO
