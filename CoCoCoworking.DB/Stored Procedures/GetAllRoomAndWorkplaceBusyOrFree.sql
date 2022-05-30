CREATE PROCEDURE [dbo].[GetAllRoomAndWorkPlaceBusyOrFree]
	--@bool bit
AS
BEGIN
	SELECT * FROM  [dbo].[Room]

		left Join [dbo].[WorkPlace] on [WorkPlace].[RoomId] = [Room].[Id]
		left Join [dbo].[RentPrice] on [WorkPlace].[Id] = [RentPrice].[WorkPlaceInRoomId]
		left Join [dbo].[OrderUnit] as O on O.[WorkPlaceId] = [WorkPlace].[Id]

 
--	--WHERE ((O.EndDate IS NULL or o.EndDate < CAST(GETDATE() AS DATE)) and @bool = 0  ) OR
--	--		(NOT (O.EndDate IS NULL or o.EndDate < CAST(GETDATE() AS DATE)) and @bool = 1 )
END
