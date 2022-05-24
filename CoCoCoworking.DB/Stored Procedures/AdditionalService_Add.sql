CREATE PROCEDURE [dbo].[AdditionalService_Add]
	@Name nvarchar(255),
	@Count int,
	@IsDeleted bit
AS
BEGIN
	INSERT INTO dbo.AdditionalService 
	(
	 [Name],
	 [Count],
	 [IsDeleted]
	)

    VALUES 
	(
	 @Name,
	 @Count,
	  0
	)

SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]
END