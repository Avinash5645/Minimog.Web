USE [Minimog]
GO
/****** Object:  StoredProcedure [dbo].[procSaveUser]    Script Date: 9/3/2023 7:26:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[procSaveUser]
(
    @Username nvarchar(50),
    @Email nvarchar(100),
    @Password nvarchar(50)
)
AS
BEGIN
    Declare @IsValid bit, @Message nvarchar(50)

    -- Check if the email already exists
    IF EXISTS (SELECT 1 FROM [User] WHERE Email = @Email)
    BEGIN
        SET @IsValid = 0
        SET @Message = 'User with this email already exists.'
    END
    ELSE
    BEGIN
        SET @IsValid = 1
        SET @Message = 'User inserted successfully.'
        
        -- Insert the new user
        INSERT INTO [User] (UserName, Email, [Password])
        VALUES (@Username, @Email, @Password)
    END
    
    -- Return validation result and message
    SELECT @IsValid AS IsValid, @Message AS Message
END
