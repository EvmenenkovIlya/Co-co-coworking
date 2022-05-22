CREATE PROCEDURE [dbo].[Customer_GetById]
	@Id int
AS
BEGIN
	SELECT *
	FROM [dbo].[Customer]
	WHERE Id = @Id
END
