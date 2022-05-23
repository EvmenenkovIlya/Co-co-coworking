CREATE PROCEDURE [dbo].[RentPrice_SoftDelete]
	@Id int	

AS
BEGIN
	
	UPDATE [dbo].RentPrice

	SET [IsDeleted] = 1

	WHERE Id = @Id
END