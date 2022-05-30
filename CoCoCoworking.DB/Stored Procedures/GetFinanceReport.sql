CREATE PROCEDURE [dbo].[GetFinancialReport]
	--@Date DATE
AS
BEGIN
	SELECT OU.[RoomId], 
		COUNT(OU.[RoomId]) as RoomCount, 
		OU.[WorkPlaceId], 
		COUNT(OU.[WorkPlaceId]) as WorkPlaceCount, 
		OU.[AdditionalServiceId], 
		COUNT(OU.[AdditionalServiceId]) as AdditionalServiceCount, 
		SUM(OU.[OrderUnitCost]) as Summ 
		FROM [dbo].[Order] as O
	join [dbo].[OrderUnit] as OU on OU.[OrderId] = O.[Id]
	--WHERE MONTH(CAST(O.[PaidDate] AS DATE)) = MONTH(@Date)
	GROUP BY OU.[RoomId], OU.[WorkPlaceId], OU.[AdditionalServiceId]
	
END