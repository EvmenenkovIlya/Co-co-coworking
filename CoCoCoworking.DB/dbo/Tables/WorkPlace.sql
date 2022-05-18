CREATE TABLE [dbo].[WorkPlace] (
    [Id]      INT IDENTITY (1, 1) NOT NULL,
    [RoomId]  INT NOT NULL,
    [IsFixed] BIT NOT NULL,
    CONSTRAINT [PK_WorkPlace] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_WorkPlace_Room] FOREIGN KEY ([RoomId]) REFERENCES [dbo].[Room] ([Id])
);

