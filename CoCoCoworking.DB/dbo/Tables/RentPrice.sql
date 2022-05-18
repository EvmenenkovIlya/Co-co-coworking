CREATE TABLE [dbo].[RentPrice] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [TypesOfPlaceId]      INT            NULL,
    [AdditionalServiceId] INT            NULL,
    [RegularPrice]        DECIMAL (18)   NULL,
    [ResidentPrice]       DECIMAL (18)   NULL,
    [MinimalRentDuration] NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK__RentPric__3214EC070F3AC686] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK__RentPrice__Addit__3F466844] FOREIGN KEY ([AdditionalServiceId]) REFERENCES [dbo].[AdditionalService] ([Id]),
    CONSTRAINT [FK__RentPrice__Types__3E52440B] FOREIGN KEY ([TypesOfPlaceId]) REFERENCES [dbo].[TypesOfPlace] ([Id])
);

