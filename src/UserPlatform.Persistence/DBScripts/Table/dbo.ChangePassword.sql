

USE [UserPlatformDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (
		SELECT 1
		FROM sys.tables
		WHERE name = N'ChangePassword'
		)
BEGIN
	CREATE TABLE [dbo].[ChangePassword] (
		[Id]				[INT]				IDENTITY(1,1)	NOT NULL
		,[UserId]			[uniqueidentifier]					NOT NULL
		,[TempPassword]		[nvarchar]			(16)			NOT NULL
		,[ExpireOn]			[datetime]							NOT NULL
		,[Token]			[nvarchar]			(512)			NOT NULL
		,PRIMARY KEY CLUSTERED ([Id] ASC) WITH (
			PAD_INDEX = OFF
			,STATISTICS_NORECOMPUTE = OFF
			,IGNORE_DUP_KEY = OFF
			,ALLOW_ROW_LOCKS = ON
			,ALLOW_PAGE_LOCKS = ON
			,OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF
			) ON [PRIMARY]
		,CONSTRAINT FK_UserId FOREIGN KEY (UserId)
			REFERENCES [dbo].[UserDetails] (UserId)
		,
		) ON [PRIMARY]
END
GO

-- maintain to write all alter query for [UserDetails] below.
GO    
IF NOT EXISTS (SELECT name FROM sys.indexes  
            WHERE name = N'IX_ChangePassword_Token_TempPassword')     
BEGIN     
	CREATE NONCLUSTERED INDEX IX_ChangePassword_Token_TempPassword   
		ON dbo.ChangePassword (Token, TempPassword)
END
GO  
IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'IsValid'
          AND Object_ID = Object_ID(N'dbo.ChangePassword'))

BEGIN
	ALTER TABLE [dbo].ChangePassword 
	ADD IsValid BIT DEFAULT 0 NOT NULL
END



