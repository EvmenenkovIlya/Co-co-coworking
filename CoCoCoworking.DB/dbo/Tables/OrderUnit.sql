CREATE TABLE [dbo].[OrderUnit] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [StartDate]           NVARCHAR (255) NOT NULL,
    [EndDate]             NVARCHAR (255) NOT NULL,
    [RoomId]              INT            NULL,
    [WorkPlaceId]         INT            NULL,
    [WorkPlaceInRoomId]   INT            NULL,
    [AdditionalServiceId] INT            NULL,
    [OrderId]             INT            NOT NULL,
    [OrderUnitCost]       DECIMAL        NOT NULL,
    CONSTRAINT [PK__OrderUni__3214EC078C0B9961] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK__OrderUnit__Addit__5535A963] FOREIGN KEY ([AdditionalServiceId]) REFERENCES [dbo].[AdditionalService] ([Id]),
    CONSTRAINT [FK__OrderUnit__Order__5629CD9C] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id]),
    CONSTRAINT [FK__OrderUnit__RoomI__534D60F1] FOREIGN KEY ([RoomId]) REFERENCES [dbo].[Room] ([Id]),
    CONSTRAINT [FK__OrderUnit__WorkP__5441852A] FOREIGN KEY ([WorkPlaceId]) REFERENCES [dbo].[WorkPlace] ([Id])
);

