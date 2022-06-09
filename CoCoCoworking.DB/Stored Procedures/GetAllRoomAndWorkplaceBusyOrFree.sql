CREATE PROCEDURE [dbo].[GetAllRoomAndWorkPlaceBusyOrFree]

AS
BEGIN
	SELECT * FROM  [dbo].[Room]

		left Join [dbo].[WorkPlace] on [WorkPlace].[RoomId] = [Room].[Id]
		left Join [dbo].[RentPrice] on [WorkPlace].[Id] = [RentPrice].[WorkPlaceInRoomId]
		left Join [dbo].[OrderUnit] as O on O.[WorkPlaceId] = [WorkPlace].[Id]

END
