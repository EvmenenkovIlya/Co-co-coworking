CREATE PROCEDURE [dbo].[Order_GetByCustomerId]
	@Id int
AS
BEGIN
	SELECT *
	FROM [dbo].[Order]
	WHERE CustomerId = @Id
END
