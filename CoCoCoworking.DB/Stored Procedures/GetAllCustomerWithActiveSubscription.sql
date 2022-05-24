CREATE PROCEDURE [dbo].[GetAllCustomerWithActiveSubscription]

AS
BEGIN
	SELECT C.[Id], C.[FirstName], C.[LastName], C.[PhoneNumber], O.[Id], OU.[Id], OU.[AdditionalServiceId], OU.[StartDate], OU.[EndDate] FROM [dbo].[Customer] as C
	join [dbo].[Order] as O on O.[CustomerId] = C.[Id]
	join [dbo].[OrderUnit] as OU on OU.[OrderId] = O.[Id]
	WHERE CAST(OU.[EndDate] AS DATE) >= GETDATE()
END