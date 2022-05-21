CREATE PROCEDURE [dbo].[Workplace_Update]
	@Id int,
	@RoomId int,
	@Number int

AS
BEGIN
	
	UPDATE [dbo].Workplace

	SET [RoomId] = @RoomId,
		Number = @Number

	WHERE Id = @Id
END