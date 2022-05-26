CREATE PROCEDURE [dbo].[Room_Add]
	@Name nvarchar(255),
	@WorkPlaceNumber int
AS
BEGIN

	INSERT INTO dbo.Room 
	(
		[Name], 
		[WorkPlaceNumber]
	)

    VALUES 
	(
		@Name,
		@WorkPlaceNumber
	)

SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]	

END
