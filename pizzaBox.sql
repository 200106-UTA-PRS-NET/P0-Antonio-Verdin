USE [PizzaBox]
GO

/****** Object:  Table [Pizza].[Crust]    Script Date: 1/24/2020 10:21:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Pizza].[Crust](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[crust] [varchar](max) NULL,
	[price] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

USE [PizzaBox]
GO

/****** Object:  Table [Pizza].[Crust]    Script Date: 1/24/2020 10:21:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Pizza].[Crust](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[crust] [varchar](max) NULL,
	[price] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [PizzaBox]
GO

/****** Object:  Table [Pizza].[Orders]    Script Date: 1/24/2020 10:22:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Pizza].[Orders](
	[OrderNum] [int] NOT NULL,
	[Ordercount] [int] NULL,
	[Orderuid] [uniqueidentifier] NOT NULL,
	[dateordered] [datetime] NULL,
	[customerid] [int] NULL,
	[storeid] [int] NULL,
	[ordercost] [money] NULL,
	[crust] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Orderuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Pizza].[Orders] ADD  DEFAULT (newid()) FOR [Orderuid]
GO

ALTER TABLE [Pizza].[Orders]  WITH CHECK ADD FOREIGN KEY([crust])
REFERENCES [Pizza].[Crust] ([id])
GO

ALTER TABLE [Pizza].[Orders]  WITH CHECK ADD FOREIGN KEY([customerid])
REFERENCES [Pizza].[Customers] ([customerid])
GO

ALTER TABLE [Pizza].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Store] FOREIGN KEY([storeid])
REFERENCES [Pizza].[Store] ([id])
GO

ALTER TABLE [Pizza].[Orders] CHECK CONSTRAINT [FK_Orders_Store]
GO
USE [PizzaBox]
GO

/****** Object:  Table [Pizza].[Pizzas]    Script Date: 1/24/2020 10:22:30 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Pizza].[Pizzas](
	[Topping] [int] NULL,
	[Orderid] [uniqueidentifier] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Pizza].[Pizzas]  WITH CHECK ADD FOREIGN KEY([Orderid])
REFERENCES [Pizza].[Orders] ([Orderuid])
GO

ALTER TABLE [Pizza].[Pizzas]  WITH CHECK ADD FOREIGN KEY([Topping])
REFERENCES [Pizza].[Toppings] ([id])
GO
USE [PizzaBox]
GO

/****** Object:  Table [Pizza].[Store]    Script Date: 1/24/2020 10:22:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Pizza].[Store](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[loc] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [PizzaBox]
GO

/****** Object:  Table [Pizza].[Toppings]    Script Date: 1/24/2020 10:22:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Pizza].[Toppings](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[topping] [varchar](max) NULL,
	[price] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO







