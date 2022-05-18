CREATE TABLE [dbo].[OrderStatus] (
    [Id]     INT            IDENTITY (1, 1) NOT NULL,
    [Status] NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK__OrderSta__3214EC07AF4BEC14] PRIMARY KEY CLUSTERED ([Id] ASC)
);

