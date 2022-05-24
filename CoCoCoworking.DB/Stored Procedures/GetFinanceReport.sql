CREATE PROCEDURE [dbo].[GetFinancialReport]
	@Date DATE
AS
BEGIN
	SELECT OU.[RoomId], OU.[WorkPlaceId], OU.[AdditionalServiceId], SUM(OU.[OrderUnitCost]) as Summ FROM [dbo].[Order] as O
	join [dbo].[OrderUnit] as OU on OU.[OrderId] = O.[Id]
	WHERE MONTH(CAST(O.[PaidDate] AS DATE)) = MONTH(@Date)
	GROUP BY OU.[RoomId], OU.[WorkPlaceId], OU.[AdditionalServiceId]
	
END