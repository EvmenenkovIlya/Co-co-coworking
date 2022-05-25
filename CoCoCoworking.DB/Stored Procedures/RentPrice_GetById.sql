CREATE PROCEDURE [dbo].[RentPrice_GetById]
	@Id int
AS
BEGIN
	SELECT *
	FROM [dbo].[RentPrice]
	WHERE Id = @Id and IsDeleted = 0
END
