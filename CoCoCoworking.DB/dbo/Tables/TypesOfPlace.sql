CREATE TABLE [dbo].[TypesOfPlace] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Type] NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_TypesOfPlace] PRIMARY KEY CLUSTERED ([Id] ASC)
);

