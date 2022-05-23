CREATE PROCEDURE [dbo].[RentPrice_GelAll]
	
AS
BEGIN
	SELECT *
	FROM [dbo].[RentPrice]
	WHERE IsDeleted = 0
END	