CREATE TABLE [dbo].[Room] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Type]            NVARCHAR (255) NOT NULL,
    [Name]            NVARCHAR (255) NOT NULL,
    [WorkPlaceNumber] INT            NULL,
    CONSTRAINT [PK__Room__3214EC0712F1083D] PRIMARY KEY CLUSTERED ([Id] ASC),
);

