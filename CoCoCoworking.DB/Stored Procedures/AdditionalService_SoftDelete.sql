CREATE PROCEDURE [dbo].[AdditionalService_SoftDelete]
	@Id int,
	@IsDeleted bit
AS
Begin
	Update dbo.AdditionalService 
	set IsDeleted = @IsDeleted
	where Id = @Id
End
	
