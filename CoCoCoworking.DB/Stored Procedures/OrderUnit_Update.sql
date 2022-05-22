CREATE PROCEDURE [dbo].[OrderUnit_Update]
	
	@Id int,
	@StartDate nvarchar(255),
	@EndDate nvarchar(255),
	@RoomId int,
	@WorkPlaceId int,
	@WorkPlaceInRoomId int,
	@AdditionalServiceId int,
	@OrderId int

AS
BEGIN
	
	UPDATE [dbo].[OrderUnit]

	SET Id= @Id,
	StartDate= @StartDate,
	EndDate= @EndDate,
	RoomId= @RoomId,
	WorkPlaceId=@WorkPlaceId,
	WorkPlaceInRoomId=@WorkPlaceInRoomId,
	AdditionalServiceId=@AdditionalServiceId,
	OrderId=@OrderId

	WHERE Id = @Id
END
