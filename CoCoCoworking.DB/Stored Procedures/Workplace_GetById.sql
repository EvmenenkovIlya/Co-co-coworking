CREATE PROCEDURE [dbo].[Workplace_GetById]
	@Id int
AS
BEGIN
	SELECT *
	FROM [dbo].[WorkPlace]
	WHERE Id = @Id
END