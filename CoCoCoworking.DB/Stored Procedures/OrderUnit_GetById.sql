CREATE PROCEDURE [dbo].[OrderUnit_GetById]
	@Id int
AS
BEGIN
	SELECT *
	FROM [dbo].[OrderUnit]
	WHERE Id = @Id
END
