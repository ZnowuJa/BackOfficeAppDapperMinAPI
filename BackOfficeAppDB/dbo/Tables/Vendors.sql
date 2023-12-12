CREATE TABLE [dbo].[Vendors] (
    [Id]                INT     PRIMARY KEY      IDENTITY (1, 1) NOT NULL,
    [Name]              NCHAR (30)    NOT NULL,
    [isDeactivated]     bit           DEFAULT 'false' NOT NULL,
    [isDeactivatedDate] SMALLDATETIME DEFAULT ('1900-01-01 00:00:00') NOT NULL,

);

