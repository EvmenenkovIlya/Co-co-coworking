CREATE PROCEDURE [dbo].[GetFinanceReport]
	@StartDate DATE,
	@EndDate DATE
AS
BEGIN
	SELECT OU.[RoomId], 
	R.[Name] as RoomName,
	COUNT(OU.[RoomId]) as RoomCount, 
	COUNT(OU.[WorkPlaceId]) as WorkPlaceCount, 
	OU.[AdditionalServiceId],
	AdS.[Name] as AdditionalServiceName,
	COUNT(OU.[AdditionalServiceId]) as AdditionalServiceCount, 
	SUM(OU.[OrderUnitCost]) as Summ 
	FROM [dbo].[Order] as O
	
	join [dbo].[OrderUnit] as OU on OU.[OrderId] = O.[Id]
	left join [dbo].[Room] as R on OU.[RoomId] = R.[Id]
	left join [dbo].[AdditionalService] as AdS on OU.[AdditionalServiceId] = AdS.[Id]

WHERE CAST(O.[PaidDate] AS DATE) >= @StartDate AND CAST(O.[PaidDate] AS DATE) <= @EndDate
GROUP BY OU.[RoomId], R.[Name], OU.[AdditionalServiceId],AdS.[Name]
	
END