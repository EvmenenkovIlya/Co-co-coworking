CREATE PROCEDURE [dbo].[RentPrice_Update]
	@Id int,
	@RoomId int,
	@WorkPlaceInRoomId int,
	@AdditionalServiceId int,
	@Hours int,
	@RegularPrice decimal(18,2),
	@ResidentPrice decimal(18,2),
	@FixedPrice decimal(18,2)
AS
BEGIN
	
	UPDATE [dbo].RentPrice

	SET [RoomId] = @RoomId,
		WorkPlaceInRoomId = @WorkPlaceInRoomId,
	    AdditionalServiceId = @AdditionalServiceId,
	    Hours = @Hours,
		RegularPrice = @RegularPrice,
		ResidentPrice = @ResidentPrice,
		FixedPrice = @FixedPrice,
		IsDeleted = 0
	WHERE Id = @Id
END