CREATE PROCEDURE [dbo].[AdditionalService_SoftDelete]
	@Id int,
	@IsDeleted bit
AS
Begin
	Update dbo.AdditionalService 
	SET [IsDeleted] = @IsDeleted
	WHERE Id = @Id
End
	
