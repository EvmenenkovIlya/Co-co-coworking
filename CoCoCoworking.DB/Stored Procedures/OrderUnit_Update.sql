CREATE PROCEDURE [dbo].[OrderUnit_Update]
	
	@Id int,
	@StartDate nvarchar(255),
	@EndDate nvarchar(255),
	@RoomId int,
	@WorkPlaceId int,
	@WorkPlaceInRoomId int,
	@AdditionalServiceId int,
	@OrderId int,
	@OrderUnitCost decimal

AS
BEGIN
	
	UPDATE [dbo].[OrderUnit]

	SET 
	StartDate= @StartDate,
	EndDate= @EndDate,
	RoomId= @RoomId,
	WorkPlaceId=@WorkPlaceId,
	WorkPlaceInRoomId=@WorkPlaceInRoomId,
	AdditionalServiceId=@AdditionalServiceId,
	OrderId=@OrderId,
	OrderUnitCost=@OrderUnitCost

	WHERE Id = @Id
END
