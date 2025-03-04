USE [Test]
GO
/****** Object:  Table [dbo].[ContestsDetails]    Script Date: 7/25/2020 5:38:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContestsDetails](
	[ContestId] [int] NOT NULL,
	[ContestName] [nvarchar](max) NOT NULL,
	[EntryAmount] [int] NULL,
 CONSTRAINT [PK_ContestsDetails] PRIMARY KEY CLUSTERED 
(
	[ContestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 7/25/2020 5:38:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NULL,
	[WalletId] [int] NOT NULL,
 CONSTRAINT [PK_UserDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserToContestMapper]    Script Date: 7/25/2020 5:38:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserToContestMapper](
	[TransactionId] [int] IDENTITY(1,1) NOT NULL,
	[ContestId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[DiscountApplied] [int] NULL,
	[DepositAmount] [int] NULL,
	[BonusAmount] [int] NULL,
	[WinningsAmount] [int] NULL,
 CONSTRAINT [PK_UserToContestMapper] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WalletsAccount]    Script Date: 7/25/2020 5:38:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WalletsAccount](
	[WalletId] [int] NOT NULL,
	[DepositBucket] [int] NULL,
	[BonusBucket] [int] NULL,
	[WinningsBucket] [int] NULL,
	[TotalWalletAmount] [int] NULL,
 CONSTRAINT [PK_WalletsAccount] PRIMARY KEY CLUSTERED 
(
	[WalletId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ContestsDetails] ADD  CONSTRAINT [DF_ContestsDetails_EntryAmount]  DEFAULT ((0)) FOR [EntryAmount]
GO
ALTER TABLE [dbo].[WalletsAccount] ADD  CONSTRAINT [DF_WalletsAccount_DepositBucket]  DEFAULT ((0)) FOR [DepositBucket]
GO
ALTER TABLE [dbo].[WalletsAccount] ADD  CONSTRAINT [DF_WalletsAccount_BonusBucket]  DEFAULT ((0)) FOR [BonusBucket]
GO
ALTER TABLE [dbo].[WalletsAccount] ADD  CONSTRAINT [DF_WalletsAccount_WinningsBucket]  DEFAULT ((0)) FOR [WinningsBucket]
GO
ALTER TABLE [dbo].[WalletsAccount] ADD  CONSTRAINT [DF_WalletsAccount_TotalWalletAmount]  DEFAULT ((0)) FOR [TotalWalletAmount]
GO
ALTER TABLE [dbo].[UserDetails]  WITH CHECK ADD  CONSTRAINT [FK_UserDetails_UserDetails] FOREIGN KEY([Id])
REFERENCES [dbo].[UserDetails] ([Id])
GO
ALTER TABLE [dbo].[UserDetails] CHECK CONSTRAINT [FK_UserDetails_UserDetails]
GO
ALTER TABLE [dbo].[UserToContestMapper]  WITH CHECK ADD  CONSTRAINT [FK_UserToContestMapper_UserToContestMapper] FOREIGN KEY([TransactionId])
REFERENCES [dbo].[UserToContestMapper] ([TransactionId])
GO
ALTER TABLE [dbo].[UserToContestMapper] CHECK CONSTRAINT [FK_UserToContestMapper_UserToContestMapper]
GO
