CREATE PROCEDURE [dbo].[Customer_Update]
	@Id int,
	@FirstName nvarchar(255),
	@LastName nvarchar(255),
	@PhoneNumber nvarchar(255),
	@Email nvarchar(255)
AS

BEGIN
	UPDATE [dbo].[Customer]
	SET [FirstName] = @FirstName,
		[LastName] = @LastName,
		[PhoneNumber] = @PhoneNumber,
		[Email] = @Email
	WHERE Id = @Id
END
