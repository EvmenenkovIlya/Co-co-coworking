CREATE PROCEDURE [dbo].[Workplace_GetById]
	@Id int
AS
BEGIN
	SELECT *
	FROM [dbo].[Workplace]
	WHERE Id = @Id
END