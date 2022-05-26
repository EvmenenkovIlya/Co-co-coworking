CREATE PROCEDURE [dbo].[AdditionalService_SoftDelete]
	@Id int
AS
Begin
	Update dbo.AdditionalService 
	SET [IsDeleted] = 1
	WHERE Id = @Id
End