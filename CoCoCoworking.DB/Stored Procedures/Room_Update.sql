CREATE PROCEDURE [dbo].[Room_Update]
	
	@Id int,
	@Type nvarchar (255),
	@Name nvarchar (255),
	@WorkPlaceNumber int

AS
BEGIN
	
	UPDATE [dbo].[Room]

	SET [Type] = @Type,
		[Name] = @Name,
		[WorkPlaceNumber] = @WorkPlaceNumber

	WHERE Id = @Id
END

