
GO
/****** Object:  Table [dbo].[Books]    Script Date: 7/8/2024 2:32:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[price] [float] NOT NULL,
	[Author] [nvarchar](max) NOT NULL,
	[Stock] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 7/8/2024 2:32:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([BookId], [Name], [Description], [price], [Author], [Stock], [CategoryId]) VALUES (1, N'book 1 updated', N'Description 1', 100, N'ali', 200, 2)
INSERT [dbo].[Books] ([BookId], [Name], [Description], [price], [Author], [Stock], [CategoryId]) VALUES (2, N'Book 2', N'Description 2', 200, N'mai', 100, 1)
INSERT [dbo].[Books] ([BookId], [Name], [Description], [price], [Author], [Stock], [CategoryId]) VALUES (3, N'Book 3', N'Description 3', 200, N'mai', 100, 2)
INSERT [dbo].[Books] ([BookId], [Name], [Description], [price], [Author], [Stock], [CategoryId]) VALUES (4, N'Book 4', N'Description 4', 200, N'mai', 100, 2)
INSERT [dbo].[Books] ([BookId], [Name], [Description], [price], [Author], [Stock], [CategoryId]) VALUES (5, N'Book 5', N'Description 5', 200, N'mai', 100, 3)
INSERT [dbo].[Books] ([BookId], [Name], [Description], [price], [Author], [Stock], [CategoryId]) VALUES (6, N'Book 6', N'Description 6', 200, N'mai', 100, 3)
INSERT [dbo].[Books] ([BookId], [Name], [Description], [price], [Author], [Stock], [CategoryId]) VALUES (7, N'book 7', N'Description 7', 100, N'roqaia', 20, 4)
INSERT [dbo].[Books] ([BookId], [Name], [Description], [price], [Author], [Stock], [CategoryId]) VALUES (8, N'book 8', N'Description 8', 100, N'roqaia', 20, 4)
INSERT [dbo].[Books] ([BookId], [Name], [Description], [price], [Author], [Stock], [CategoryId]) VALUES (9, N'book 9', N'Description 9', 100, N'lolo', 20, 4)
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (1, N'Category 1 updated', N'Description 1 updated')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (2, N'Category 2', N'Description 2')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (3, N'Category 3', N'Description 3')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (4, N'Category 4', N'Description 4')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (5, N'Category 5', N'Description 5')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [CK_price_non-negative] CHECK  (([price]>(0)))
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [CK_price_non-negative]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [CK_Stock_non-negative] CHECK  (([Stock]>(0)))
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [CK_Stock_non-negative]
GO
