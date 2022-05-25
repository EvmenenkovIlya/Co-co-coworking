CREATE PROCEDURE [dbo].[AdditionalService_GetById]
@Id int
AS
Begin
Select *from dbo.AdditionalService 
where Id = @Id
End