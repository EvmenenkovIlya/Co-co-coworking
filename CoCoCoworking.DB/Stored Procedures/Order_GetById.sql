CREATE PROCEDURE [dbo].[Order_GetById]
	@Id int
AS
BEGIN
	SELECT *
	FROM [dbo].[Order]
	WHERE Id = @Id
END
