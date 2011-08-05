USE [TestTracker]
GO
/****** Object:  Table [dbo].[TestStatuses]    Script Date: 08/05/2011 16:24:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestStatuses](
	[TestStatusID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TestStatuses] PRIMARY KEY CLUSTERED 
(
	[TestStatusID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Features]    Script Date: 08/05/2011 16:24:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Features](
	[FeatureID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Features] PRIMARY KEY CLUSTERED 
(
	[FeatureID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 08/05/2011 16:24:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestCases]    Script Date: 08/05/2011 16:24:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestCases](
	[TestCaseID] [int] IDENTITY(1,1) NOT NULL,
	[TestComponentID] [int] NOT NULL,
	[TestPlanID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_TestCases] PRIMARY KEY CLUSTERED 
(
	[TestCaseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActiveTestPlans]    Script Date: 08/05/2011 16:24:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActiveTestPlans](
	[ActiveTestPlanID] [int] IDENTITY(1,1) NOT NULL,
	[TestPlanID] [int] NOT NULL,
	[RequestTicketNumber] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ActiveTestPlans] PRIMARY KEY CLUSTERED 
(
	[ActiveTestPlanID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestSteps]    Script Date: 08/05/2011 16:24:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestSteps](
	[TestStepID] [int] IDENTITY(1,1) NOT NULL,
	[TestCaseID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_TestSteps] PRIMARY KEY CLUSTERED 
(
	[TestStepID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActiveTestCases]    Script Date: 08/05/2011 16:24:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActiveTestCases](
	[ActiveTestCaseID] [int] IDENTITY(1,1) NOT NULL,
	[ActiveTestPlanID] [int] NOT NULL,
	[TestCaseID] [int] NOT NULL,
 CONSTRAINT [PK_ActiveTestCases] PRIMARY KEY CLUSTERED 
(
	[ActiveTestCaseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActiveTestSteps]    Script Date: 08/05/2011 16:24:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActiveTestSteps](
	[ActiveTestStepID] [int] IDENTITY(1,1) NOT NULL,
	[ActiveTestCaseID] [int] NOT NULL,
	[TestStepID] [int] NOT NULL,
	[TestStatusID] [int] NOT NULL,
	[RequestTicketNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_ActiveTestSteps] PRIMARY KEY CLUSTERED 
(
	[ActiveTestStepID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Builds]    Script Date: 08/05/2011 16:24:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Builds](
	[BuildID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[ActiveTestPlanID] [int] NOT NULL,
	[BuildNumber] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Builds] PRIMARY KEY CLUSTERED 
(
	[BuildID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestPlans]    Script Date: 08/05/2011 16:24:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestPlans](
	[TestPlanID] [int] IDENTITY(1,1) NOT NULL,
	[FeatureID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_TestPlans] PRIMARY KEY CLUSTERED 
(
	[TestPlanID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestComponents]    Script Date: 08/05/2011 16:24:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestComponents](
	[TestComponentID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TestComponents] PRIMARY KEY CLUSTERED 
(
	[TestComponentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_ActiveTestCases_ActiveTestPlans]    Script Date: 08/05/2011 16:24:06 ******/
ALTER TABLE [dbo].[ActiveTestCases]  WITH CHECK ADD  CONSTRAINT [FK_ActiveTestCases_ActiveTestPlans] FOREIGN KEY([ActiveTestPlanID])
REFERENCES [dbo].[ActiveTestPlans] ([ActiveTestPlanID])
GO
ALTER TABLE [dbo].[ActiveTestCases] CHECK CONSTRAINT [FK_ActiveTestCases_ActiveTestPlans]
GO
/****** Object:  ForeignKey [FK_ActiveTestCases_TestCases]    Script Date: 08/05/2011 16:24:06 ******/
ALTER TABLE [dbo].[ActiveTestCases]  WITH CHECK ADD  CONSTRAINT [FK_ActiveTestCases_TestCases] FOREIGN KEY([ActiveTestCaseID])
REFERENCES [dbo].[TestCases] ([TestCaseID])
GO
ALTER TABLE [dbo].[ActiveTestCases] CHECK CONSTRAINT [FK_ActiveTestCases_TestCases]
GO
/****** Object:  ForeignKey [FK_ActiveTestPlans_TestPlans]    Script Date: 08/05/2011 16:24:06 ******/
ALTER TABLE [dbo].[ActiveTestPlans]  WITH CHECK ADD  CONSTRAINT [FK_ActiveTestPlans_TestPlans] FOREIGN KEY([TestPlanID])
REFERENCES [dbo].[TestPlans] ([TestPlanID])
GO
ALTER TABLE [dbo].[ActiveTestPlans] CHECK CONSTRAINT [FK_ActiveTestPlans_TestPlans]
GO
/****** Object:  ForeignKey [FK_ActiveTestSteps_ActiveTestCases]    Script Date: 08/05/2011 16:24:06 ******/
ALTER TABLE [dbo].[ActiveTestSteps]  WITH CHECK ADD  CONSTRAINT [FK_ActiveTestSteps_ActiveTestCases] FOREIGN KEY([ActiveTestCaseID])
REFERENCES [dbo].[ActiveTestCases] ([ActiveTestCaseID])
GO
ALTER TABLE [dbo].[ActiveTestSteps] CHECK CONSTRAINT [FK_ActiveTestSteps_ActiveTestCases]
GO
/****** Object:  ForeignKey [FK_ActiveTestSteps_TestStatuses]    Script Date: 08/05/2011 16:24:06 ******/
ALTER TABLE [dbo].[ActiveTestSteps]  WITH CHECK ADD  CONSTRAINT [FK_ActiveTestSteps_TestStatuses] FOREIGN KEY([TestStatusID])
REFERENCES [dbo].[TestStatuses] ([TestStatusID])
GO
ALTER TABLE [dbo].[ActiveTestSteps] CHECK CONSTRAINT [FK_ActiveTestSteps_TestStatuses]
GO
/****** Object:  ForeignKey [FK_ActiveTestSteps_TestSteps]    Script Date: 08/05/2011 16:24:06 ******/
ALTER TABLE [dbo].[ActiveTestSteps]  WITH CHECK ADD  CONSTRAINT [FK_ActiveTestSteps_TestSteps] FOREIGN KEY([TestStepID])
REFERENCES [dbo].[TestSteps] ([TestStepID])
GO
ALTER TABLE [dbo].[ActiveTestSteps] CHECK CONSTRAINT [FK_ActiveTestSteps_TestSteps]
GO
/****** Object:  ForeignKey [FK_Builds_ActiveTestPlans]    Script Date: 08/05/2011 16:24:06 ******/
ALTER TABLE [dbo].[Builds]  WITH CHECK ADD  CONSTRAINT [FK_Builds_ActiveTestPlans] FOREIGN KEY([ActiveTestPlanID])
REFERENCES [dbo].[ActiveTestPlans] ([ActiveTestPlanID])
GO
ALTER TABLE [dbo].[Builds] CHECK CONSTRAINT [FK_Builds_ActiveTestPlans]
GO
/****** Object:  ForeignKey [FK_Builds_Products]    Script Date: 08/05/2011 16:24:06 ******/
ALTER TABLE [dbo].[Builds]  WITH CHECK ADD  CONSTRAINT [FK_Builds_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Builds] CHECK CONSTRAINT [FK_Builds_Products]
GO
/****** Object:  ForeignKey [FK_TestCases_TestComponents]    Script Date: 08/05/2011 16:24:06 ******/
ALTER TABLE [dbo].[TestCases]  WITH CHECK ADD  CONSTRAINT [FK_TestCases_TestComponents] FOREIGN KEY([TestComponentID])
REFERENCES [dbo].[TestComponents] ([TestComponentID])
GO
ALTER TABLE [dbo].[TestCases] CHECK CONSTRAINT [FK_TestCases_TestComponents]
GO
/****** Object:  ForeignKey [FK_TestCases_TestPlans]    Script Date: 08/05/2011 16:24:06 ******/
ALTER TABLE [dbo].[TestCases]  WITH CHECK ADD  CONSTRAINT [FK_TestCases_TestPlans] FOREIGN KEY([TestPlanID])
REFERENCES [dbo].[TestPlans] ([TestPlanID])
GO
ALTER TABLE [dbo].[TestCases] CHECK CONSTRAINT [FK_TestCases_TestPlans]
GO
/****** Object:  ForeignKey [FK_TestComponents_Products]    Script Date: 08/05/2011 16:24:06 ******/
ALTER TABLE [dbo].[TestComponents]  WITH CHECK ADD  CONSTRAINT [FK_TestComponents_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[TestComponents] CHECK CONSTRAINT [FK_TestComponents_Products]
GO
/****** Object:  ForeignKey [FK_TestPlans_Features]    Script Date: 08/05/2011 16:24:06 ******/
ALTER TABLE [dbo].[TestPlans]  WITH CHECK ADD  CONSTRAINT [FK_TestPlans_Features] FOREIGN KEY([FeatureID])
REFERENCES [dbo].[Features] ([FeatureID])
GO
ALTER TABLE [dbo].[TestPlans] CHECK CONSTRAINT [FK_TestPlans_Features]
GO
/****** Object:  ForeignKey [FK_TestSteps_TestCases]    Script Date: 08/05/2011 16:24:06 ******/
ALTER TABLE [dbo].[TestSteps]  WITH CHECK ADD  CONSTRAINT [FK_TestSteps_TestCases] FOREIGN KEY([TestCaseID])
REFERENCES [dbo].[TestCases] ([TestCaseID])
GO
ALTER TABLE [dbo].[TestSteps] CHECK CONSTRAINT [FK_TestSteps_TestCases]
GO
