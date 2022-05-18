CREATE TABLE [dbo].[Room] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (255) NOT NULL,
    [TypesOfPlaceId]  INT            NOT NULL,
    [WorkPlaceNumber] INT            NULL,
    CONSTRAINT [PK__Room__3214EC0712F1083D] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK__Room__TypesOfPla__2C3393D0] FOREIGN KEY ([TypesOfPlaceId]) REFERENCES [dbo].[TypesOfPlace] ([Id])
);

