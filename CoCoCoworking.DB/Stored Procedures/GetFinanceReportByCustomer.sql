CREATE PROCEDURE [dbo].[GetFinanceReportByCustomer]
	@StartDate DATE,
	@EndDate DATE
AS
BEGIN
	SELECT C.[Id], 
		C.[FirstName], 
		C.[LastName],
		C.[PhoneNumber], 
		C.[Email], 
		Count(O.[Id]) as OrderCount, 
		Sum(O.[OrderCost]) as OrderSum 
	FROM [dbo].[Customer] as C
	join  [dbo].[Order] as O on O.[CustomerId] = C.[Id]
	
	WHERE CAST(O.[PaidDate] AS DATE) >= @StartDate AND CAST(O.[PaidDate] AS DATE) <= @EndDate
	GROUP BY C.[Id], C.[FirstName], C.[LastName], C.[PhoneNumber], C.[Email]
END