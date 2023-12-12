CREATE TABLE [dbo].[Units] (
    [Id]            INT    PRIMARY KEY     IDENTITY (1, 1) NOT NULL,
    [Name]          NCHAR (20) NOT NULL,
    [UnitShortName] NCHAR (5)  NOT NULL,
);