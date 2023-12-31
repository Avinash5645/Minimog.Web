USE [Minimog]
GO
/****** Object:  StoredProcedure [dbo].[procLoginCheck]    Script Date: 9/10/2023 9:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* History
Created By Avinash


*/
CREATE proc [dbo].[procLoginCheck](
@Email Nvarchar(60),
@password nvarchar(10)
)
As
Begin
	declare @IsValid bit =0,@Message nvarchar(100)

	--if(Select 1 From [User] where Email=@Email and [Password]=@password)
	--Begin
	--	set @IsValid=1
	--	set @Message=select Username From [User] where Email=@Email and [Password]=@password
	--End

	SELECT  @IsValid = 1, @Message = Username
    FROM    [User]
    WHERE	Email = @Email AND [Password] = @Password

	select @IsValid IsValid ,ISNULL(@Message, 'Email And Password Not Correct') [Message]
End