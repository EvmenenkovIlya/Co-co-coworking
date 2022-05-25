CREATE PROCEDURE [dbo].[OrderUnit_Add]
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
	 INSERT INTO dbo.[OrderUnit]
	 (
	 StartDate,
	 EndDate,
	 RoomId,
	 WorkPlaceId,
	 WorkPlaceInRoomId,
	 AdditionalServiceId,
	 OrderId,
	 OrderUnitCost
	 )
	 VALUES 
	 (
	 @StartDate,
	 @EndDate,
	 @RoomId,
	 @WorkPlaceId,
	 @WorkPlaceInRoomId,
	 @AdditionalServiceId,
	 @OrderId,
	 @OrderUnitCost
	 )
	  SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]
END

