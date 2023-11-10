IF NOT EXISTS (
		SELECT 1
		FROM sys.databases
		WHERE name = N'UserPlatformDB'
		)
BEGIN
	CREATE DATABASE UserPlatformDB
END
GO

USE [UserPlatformDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (
		SELECT 1
		FROM sys.tables
		WHERE name = N'UserDetails'
		)
BEGIN
	CREATE TABLE [dbo].[UserDetails] (
		[UserId] [uniqueidentifier] NOT NULL
		,[FirstName] [nvarchar](100) NOT NULL
		,[MiddleName] [nvarchar](100) NULL
		,[LastName] [nvarchar](100) NOT NULL
		,[UserName] [nvarchar](100) NOT NULL
		,[MobileNo] [bigint] NOT NULL
		,[Email] [nvarchar](255) NOT NULL
		,[Password] [nvarchar](255) NOT NULL
		,[CreatedOn] [datetime] NULL
		,[ModifiedOn] [datetime] NULL
		,[IsLocked] [bit] NULL
		,PRIMARY KEY CLUSTERED ([UserId] ASC) WITH (
			PAD_INDEX = OFF
			,STATISTICS_NORECOMPUTE = OFF
			,IGNORE_DUP_KEY = OFF
			,ALLOW_ROW_LOCKS = ON
			,ALLOW_PAGE_LOCKS = ON
			,OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF
			) ON [PRIMARY]
		) ON [PRIMARY]

	ALTER TABLE [dbo].[UserDetails] ADD DEFAULT(newid())
	FOR [UserId]

	ALTER TABLE [dbo].[UserDetails] ADD DEFAULT((0))
	FOR [IsLocked]
END
GO

-- maintain to write all alter query for [UserDetails] below.

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Salt'
          AND Object_ID = Object_ID(N'dbo.UserDetails'))

BEGIN
	ALTER TABLE [dbo].[UserDetails] 
	ADD Salt NVARCHAR(512) NOT NULL
END
IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'PasswordModifiedOn'
          AND Object_ID = Object_ID(N'dbo.UserDetails'))

BEGIN
	ALTER TABLE [dbo].[UserDetails] 
	ADD PasswordModifiedOn [datetime] NULL
END

