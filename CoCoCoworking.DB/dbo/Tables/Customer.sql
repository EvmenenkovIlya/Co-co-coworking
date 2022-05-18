CREATE TABLE [dbo].[Customer] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (255) NULL,
    [LastName]    NVARCHAR (255) NULL,
    [PhoneNumber] NVARCHAR (255) NOT NULL,
    [Email]       NVARCHAR (255) NULL,
    [IsRegular]   BIT            NOT NULL,
    [IsExtended]  BIT            NOT NULL,
    CONSTRAINT [PK__Customer__3214EC0793174563] PRIMARY KEY CLUSTERED ([Id] ASC)
);

