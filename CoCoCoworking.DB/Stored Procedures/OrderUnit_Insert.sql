CREATE PROCEDURE [dbo].[OrderUnit_Insert]
	@StartDate nvarchar(255),
	@EndDate nvarchar(255),
	@RoomId int,
	@WorkPlaceId int,
	@AdditionalServiceId int,
	@OrderUnitCost decimal(18,0),
	@OrderId int
AS
BEGIN
	 INSERT INTO dbo.[OrderUnit](StartDate, EndDate,RoomId,WorkPlaceId,AdditionalServiceId,OrderUnitCost,OrderId )
	 VALUES (@StartDate, @EndDate,@RoomId,@WorkPlaceId,@AdditionalServiceId,@OrderUnitCost,@OrderId)
END

