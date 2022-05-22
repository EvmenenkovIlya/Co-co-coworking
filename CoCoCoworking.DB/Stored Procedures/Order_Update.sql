CREATE PROCEDURE [dbo].[Order_Update]
	
	@Id int,
	@CustomerId int,
	@OrderCost decimal(18,2),
	@OrderStatus nvarchar(255),
	@PaidDate nvarchar(255)

AS
BEGIN
	
	UPDATE [dbo].[Order]

	SET CustomerId = @CustomerId,		
	    OrderCost = @OrderCost,
	    OrderStatus = @OrderStatus,
	    PaidDate = @PaidDate

	WHERE Id = @Id
END
