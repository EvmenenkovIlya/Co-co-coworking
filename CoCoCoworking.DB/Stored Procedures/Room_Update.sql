﻿CREATE PROCEDURE [dbo].[Room_Update]
	
	@Id int,
	@Name nvarchar (255),
	@WorkPlaceNumber int,
	@Type nvarchar (255)

AS
BEGIN
	
	UPDATE [dbo].[Room]

	SET [Type] = @Type,
		[Name] = @Name,
		[WorkPlaceNumber] = @WorkPlaceNumber

	WHERE Id = @Id
END

