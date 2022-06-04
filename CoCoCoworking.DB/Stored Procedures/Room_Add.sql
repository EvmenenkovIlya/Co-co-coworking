CREATE PROCEDURE [dbo].[Room_Add]
	@Type nvarchar(255),
	@Name nvarchar(255),
	@WorkPlaceNumber int
AS
BEGIN

	INSERT INTO dbo.Room 
	(
		[Type],
		[Name], 
		[WorkPlaceNumber]
	)

    VALUES 
	(
		@Type,
		@Name,
		@WorkPlaceNumber
	)

SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]	

END
