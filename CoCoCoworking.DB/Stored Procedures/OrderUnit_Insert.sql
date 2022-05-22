CREATE PROCEDURE [dbo].[OrderUnit_Insert]
	@StartDate nvarchar(255),
	@EndDate nvarchar(255),
	@RoomId int,
	@WorkPlaceId int,
	@WorkPlaceInRoomId int,
	@AdditionalServiceId int,
	@OrderId int
AS
BEGIN
	 INSERT INTO dbo.[OrderUnit]
	 (
	 StartDate,
	 EndDate,
	 RoomId,
	 WorkPlaceId,
	 WorkPlaceInRoomId,
	 AdditionalServiceId,
	 OrderId
	 )
	 VALUES 
	 (
	 @StartDate,
	 @EndDate,
	 @RoomId,
	 @WorkPlaceId,
	 @WorkPlaceInRoomId,
	 @AdditionalServiceId,
	 @OrderId
	 )
	  SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]
END

