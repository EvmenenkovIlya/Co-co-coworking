CREATE PROCEDURE [dbo].[Room_GetById]
	@Id int
AS
BEGIN
	SELECT *
	FROM [dbo].[Room]
	WHERE Id = @Id
END
