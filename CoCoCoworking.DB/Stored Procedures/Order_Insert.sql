CREATE PROCEDURE [dbo].[Order_Insert]
	@CustomerId int,
	@OrderCost decimal(18),
	@OrderStatusId int,
	@PaidDate nvarchar(255)
AS
BEGIN
	 INSERT INTO dbo.[Order](CustomerId, OrderCost,OrderStatusId,PaidDate)
	 VALUES (@CustomerId, @OrderCost, @OrderStatusId, @PaidDate)
END
