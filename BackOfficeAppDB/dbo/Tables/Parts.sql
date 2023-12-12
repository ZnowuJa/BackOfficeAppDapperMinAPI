CREATE TABLE [dbo].[Parts] (
    [Id]                   INT     PRIMARY KEY      IDENTITY (1, 1) NOT NULL,
    [Name]                 NCHAR (30)    NOT NULL,
    [CategoryID]           INT           NOT NULL,
    [VendorId]             INT           NOT NULL,
    [Description]          NCHAR (100)   NOT NULL,
    [Photo]                NCHAR (10)    NOT NULL,
    [WarrantyPeriod]       INT           NOT NULL,
    [isCurrentlyOrderable] BIT           NOT NULL DEFAULT 'false',
    [isDeactivated]        BIT           DEFAULT 'false' NOT NULL,
    [isDeactivatedDate]    SMALLDATETIME DEFAULT ('1900-01-01 00:00:00') NOT NULL,
    FOREIGN KEY ([VendorId]) REFERENCES [dbo].[Vendors] ([Id]),
    FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Categories] ([Id]),

);

