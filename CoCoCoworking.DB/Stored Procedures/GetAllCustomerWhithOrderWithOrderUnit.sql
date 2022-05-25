CREATE PROCEDURE [dbo].[GetAllCustomerWhithOrderWithOrderUnit]

AS
BEGIN
	SELECT * FROM [dbo].[Customer] as C
	
	join  [dbo].[Order] as O on O.[CustomerId] = C.[Id]
	Join  [dbo].[OrderUnit] as OU on OU.[OrderId] = O.[Id]

	ORDER BY C.[PhoneNumber], OU.[EndDate] DESC
END