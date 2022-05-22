﻿CREATE PROCEDURE [dbo].[Workplace_Add]
	@RoomId int,
	@Number int
AS
BEGIN

	INSERT INTO [dbo].[Workplace]
	(
		RoomId,
		Number
	)

    VALUES 
	(
		@RoomId,
		@Number
	)

SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]	

END
