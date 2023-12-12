CREATE TABLE [dbo].[Categories] (
    [Id]                INT          PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    [Name]              NCHAR (20)    NOT NULL,
    [Prefix]            NCHAR (5)     NOT NULL,
    [CategoryTypeId]    INT           NOT NULL,
    [isDeactivated]     bit           DEFAULT 'false' NOT NULL,
    [isDeactivatedDate] SMALLDATETIME DEFAULT ('1900-01-01 00:00:00') NOT NULL,
    FOREIGN KEY ([CategoryTypeId]) REFERENCES [dbo].[CategoryTypes] ([Id])
);

