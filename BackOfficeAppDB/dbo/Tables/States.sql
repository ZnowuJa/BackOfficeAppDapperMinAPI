CREATE TABLE [dbo].[States] (
    [Id]          INT    PRIMARY KEY     IDENTITY (1, 1) NOT NULL,
    [Name]        NCHAR (10)  NOT NULL,
    [Description] NCHAR (100) NOT NULL,
);
