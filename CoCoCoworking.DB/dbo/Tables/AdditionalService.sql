CREATE TABLE [dbo].[AdditionalService] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (255) NOT NULL,
    [Count] INT NOT NULL,
    [IsDeleted] BIT NOT NULL,
    CONSTRAINT [PK__Addition__3214EC07470C41FB] PRIMARY KEY CLUSTERED ([Id] ASC)
);

