CREATE PROCEDURE [dbo].[Customer_Add]
	@FirstName nvarchar(255),
	@LastName nvarchar(255),
	@PhoneNumber nvarchar(255),
	@Email nvarchar(255)
AS
BEGIN
	INSERT INTO dbo.Customer 
	(
		[FirstName],
		[LastName],
		[PhoneNumber],
		[Email]
	)

    VALUES 
	(
		@FirstName,
		@LastName,
		@PhoneNumber,
		@Email
	)

SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]	

END