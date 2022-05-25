CREATE PROCEDURE [dbo].[Order_Add]
	@CustomerId int,
	@OrderCost decimal(18,2),
	@OrderStatus nvarchar(255),
	@PaidDate nvarchar(255)
AS
BEGIN
	 INSERT INTO dbo.[Order]
	 (

	 CustomerId, 
	 OrderCost,
	 OrderStatus,
	 PaidDate

	 )

	 VALUES 
	 (
	 @CustomerId, 
	 @OrderCost, 
	 @OrderStatus,
	 @PaidDate
	 )

	 SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]
END


