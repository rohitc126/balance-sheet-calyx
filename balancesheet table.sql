USE [CALYX_Test]
GO

/****** Object:  Table [dbo].[Tbl_Balance_Sheet_Document]    Script Date: 7/24/2024 6:43:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tbl_Balance_Sheet_Document](
	[BSD_ID] [int] IDENTITY(1,1) NOT NULL,
	[Comp_Code] [varchar](10) NOT NULL,
	[Comp_Name] [varchar](50) NOT NULL,
	[FY] [varchar](15) NOT NULL,
	[Uploaded_by] [varchar](7) NOT NULL,
	[Uploaded_date] [datetime] NOT NULL,
	[File_Path] [varchar](100) NULL,
	[File_Name] [varchar](50) NULL,
	[Status] [char](1) NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Tbl_Balance_Sheet_Document] ADD  CONSTRAINT [DF_Tbl_Balance_Sheet_Document_Uploaded_date]  DEFAULT (getdate()) FOR [Uploaded_date]
GO

ALTER TABLE [dbo].[Tbl_Balance_Sheet_Document] ADD  CONSTRAINT [DF_Tbl_Balance_Sheet_Document_Status]  DEFAULT ('Y') FOR [Status]
GO

