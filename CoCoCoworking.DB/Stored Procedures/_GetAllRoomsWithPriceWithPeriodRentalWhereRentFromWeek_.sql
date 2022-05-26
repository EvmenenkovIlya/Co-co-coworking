CREATE PROCEDURE [dbo].[GetAllRoomsWithPriceWithPeriodRental]

AS
BEGIN
	select distinct 
		OU.[Startdate], 
		OU.[EndDate], 
		R.[Name], 
		R.[WorkPlaceNumber], 
		RP.[RegularPrice], 
		RP.[ResidentPrice], 
		RP.[FixedPrice] 
	
	from dbo.[OrderUnit] as OU
	inner join dbo.[Room] as R on OU.RoomId = R.Id
	inner join dbo.[RentPrice] as RP  on R.Id = RP.RoomId  
	
	where RP.[PeriodType] = 'неделя' 
END