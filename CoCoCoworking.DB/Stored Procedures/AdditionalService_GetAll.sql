CREATE PROCEDURE [dbo].[AdditionalService_GetAll]

AS
Begin
Select *From dbo.AdditionalService
where IsDeleted = 0
End