CREATE PROCEDURE [dbo].[RentPrice_Add]
	@RoomId int,
	@WorkPlaceInRoomId int,
	@AdditionalServiceId int,
	@Hours int,
	@RegularPrice decimal(18,2),
	@ResidentPrice decimal(18,2),
	@FixedPrice decimal(18,2)
	
AS
BEGIN
	 INSERT INTO dbo.[RentPrice]
	 (
	  RoomId,
	  WorkPlaceInRoomId,
	  AdditionalServiceId,
 	  Hours,
	  RegularPrice,
	  ResidentPrice,
	  FixedPrice,
	  IsDeleted	 
	 )

	 VALUES 
	 (
	 @RoomId,
	 @WorkPlaceInRoomId,
	 @AdditionalServiceId,
 	 @Hours,
	 @RegularPrice,
	 @ResidentPrice,
	 @FixedPrice,
	 0
	 )

	 SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]
END


