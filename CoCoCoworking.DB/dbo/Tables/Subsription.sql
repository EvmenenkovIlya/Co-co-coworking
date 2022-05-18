CREATE TABLE [dbo].[Subsription] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [CustomerId] INT            NOT NULL,
    [StartDate]  NVARCHAR (255) NOT NULL,
    [EndDate]    NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK__Subsript__3214EC073D2AB421] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK__Subsripti__Custo__440B1D61] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id])
);

