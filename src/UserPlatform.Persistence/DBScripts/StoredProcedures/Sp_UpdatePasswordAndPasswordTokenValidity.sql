USE [UserPlatformDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE Sp_UpdatePasswordAndPasswordTokenValidity(
	@password NVARCHAR(512),
	@salt NVARCHAR(512),
	@userId UNIQUEIDENTIFIER,
	@isValid BIT,
	@changePasswordId INT
)
AS
BEGIN
	BEGIN TRANSACTION
		BEGIN TRY
			UPDATE	dbo.UserDetails
			SET		[Password]	=	@password,
					Salt		=	@salt
			WHERE	UserId		=	@userId

			UPDATE	dbo.ChangePassword
			SET		IsValid		=	@isValid
			WHERE	Id			=	@changePasswordId
		END TRY
		BEGIN CATCH
			IF @@TRANCOUNT > 0
				BEGIN
					ROLLBACK TRANSACTION
				END
		END CATCH
		COMMIT TRANSACTION
END
GO