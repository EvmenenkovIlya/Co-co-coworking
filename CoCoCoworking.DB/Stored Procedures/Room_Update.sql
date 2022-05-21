CREATE PROCEDURE [dbo].[Room_Update]
	
	@Id int,
	@Name nvarchar (255),
	@WorkPlaceNumber int

AS
BEGIN
	
	UPDATE [dbo].[Room]

	SET [Name] = @Name,
		WorkPlaceNumber = @WorkPlaceNumber

	WHERE Id = @Id
END

