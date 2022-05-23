CREATE PROCEDURE [dbo].[AdditionalService_Update]
	@Id int,
	@Name nvarchar(255),
	@Count int,
	@IsDeleted bit
AS
	Begin
		update dbo.AdditionalService
		set 
		[Name] = @Name,
		[Count] = @Count,
		[IsDeleted] = 0	
		where Id = @Id
	End