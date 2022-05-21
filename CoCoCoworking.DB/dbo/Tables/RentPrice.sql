CREATE TABLE [dbo].[RentPrice] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [RoomId]              INT NULL,
    [WorkPlaceInRoomId]   INT NULL,
    [AdditionalServiceId] INT            NULL,
    [PeriodType]          NVARCHAR(255)   NOT NULL,
    [RegularPrice]        DECIMAL (18, 2)   NULL,
    [ResidentPrice]       DECIMAL (18, 2)   NULL,
    [FixedPrice]          DECIMAL (18, 2)   NULL,
    [IsDeleted]           BIT NOT NULL
    CONSTRAINT [PK__RentPric__3214EC070F3AC686] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK__RentPrice__Addit__3F466844] FOREIGN KEY ([AdditionalServiceId]) REFERENCES [dbo].[AdditionalService] ([Id]),
);

