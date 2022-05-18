CREATE TABLE [dbo].[Order] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [CustomerId]    INT            NOT NULL,
    [OrderCost]     DECIMAL (18)   NOT NULL,
    [OrderStatusId] INT            NOT NULL,
    [PaidDate]      NVARCHAR (255) NULL,
    CONSTRAINT [PK__Order__3214EC07F0E68909] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK__Order__CustomerI__48CFD27E] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id]),
    CONSTRAINT [FK__Order__OrderStat__49C3F6B7] FOREIGN KEY ([OrderStatusId]) REFERENCES [dbo].[OrderStatus] ([Id])
);

