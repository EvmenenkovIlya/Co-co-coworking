CREATE PROCEDURE [dbo].[GetAllAdditionalService]
@bool bit
AS
BEGIN

  SELECT A.[Id],A.[Name],A.[Count],OU.[StartDate], OU.[EndDate], RP.[PeriodType], RP.[RegularPrice],RP.[ResidentPrice], RP.[FixedPrice] FROM [dbo].[AdditionalService] as A

left Join [dbo].[OrderUnit] as OU on OU.[AdditionalServiceId] = A.[Id]
left Join [dbo].[RentPrice] as RP on RP.[AdditionalServiceId]=A.[Id]

  WHERE ((OU.EndDate IS NULL or OU.EndDate < CAST(GETDATE() AS DATE)) and @bool = 0  ) OR
      (NOT (OU.EndDate IS NULL or OU.EndDate < CAST(GETDATE() AS DATE)) and @bool = 1 )
END