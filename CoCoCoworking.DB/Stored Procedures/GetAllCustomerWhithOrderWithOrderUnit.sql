CREATE PROCEDURE [dbo].[GetAllCustomerWhithOrderWithOrderUnit]

AS
BEGIN
	SELECT * FROM [dbo].[Customer] as C
	
	left join  [dbo].[Order] as O on O.[CustomerId] = C.[Id]
	left Join  [dbo].[OrderUnit] as OU on OU.[OrderId] = O.[Id]

	ORDER BY C.[PhoneNumber], OU.[EndDate] DESC
END