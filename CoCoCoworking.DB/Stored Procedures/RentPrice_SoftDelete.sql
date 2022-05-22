CREATE PROCEDURE [dbo].[RentPrice_SoftDelete]
	@Id int,	
	@IsDeleted bit

AS
BEGIN
	
	UPDATE [dbo].RentPrice

	SET [IsDeleted] = @IsDeleted

	WHERE Id = @Id
END