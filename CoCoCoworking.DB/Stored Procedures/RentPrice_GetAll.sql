CREATE PROCEDURE [dbo].[RentPrice_GetAll]
	
AS
BEGIN
	SELECT *
	FROM [dbo].[RentPrice]
	WHERE IsDeleted = 0
END	