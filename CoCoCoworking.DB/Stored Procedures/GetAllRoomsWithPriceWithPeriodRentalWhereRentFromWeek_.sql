CREATE PROCEDURE [dbo].[GetAllRoomsWithPriceWithPeriodRentalWhereRentFromWeek]

AS
BEGIN
	select distinct 
		OU.[StartDate], 
		OU.[EndDate], 
		R.[Name], 
		R.[WorkPlaceNumber], 
		RP.[RegularPrice], 
		RP.[ResidentPrice], 
		RP.[FixedPrice] 
	
	from dbo.[OrderUnit] as OU
	inner join dbo.[Room] as R on OU.RoomId = R.Id
	inner join dbo.[RentPrice] as RP  on R.Id = RP.RoomId  
	
	where RP.[Hours] = 168
END