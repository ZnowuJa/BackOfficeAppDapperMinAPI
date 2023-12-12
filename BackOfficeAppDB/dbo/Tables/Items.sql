CREATE TABLE [dbo].[Items] (
    [Id]                INT    PRIMARY KEY        IDENTITY (1, 1) NOT NULL,
    [PartId]            INT            NOT NULL,
    [StateId]           INT            NOT NULL,
    [AssetTagNumber]    NCHAR (15)     NULL,
    [SerialNumber]      NCHAR (30)     NULL,
    [LastSeen]          SMALLDATETIME  DEFAULT ('1900-01-01 00:00:00') NULL,
    [InvoiceItemId]     INT            NOT NULL,
    [InvoiceId]         INT            NOT NULL,
    [UserId]            INT            NULL,
    [WarehouseId]       INT            NULL,
    [isDeactivated]     BIT            DEFAULT 'false' NOT NULL,
    [isDeactivatedDate] SMALLDATETIME  DEFAULT ('1900-01-01 00:00:00') NOT NULL,
    [Price]             DECIMAL (8, 2) NULL,
    [Currency]          NCHAR (3)      DEFAULT ('PLN') NULL,
    [PurchaseDate]      SMALLDATETIME     NULL,
    
    FOREIGN KEY ([StateId]) REFERENCES [dbo].[States] ([Id]),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]),
    FOREIGN KEY ([WarehouseId]) REFERENCES [dbo].[Warehouses] ([Id]),
    FOREIGN KEY ([InvoiceItemId]) REFERENCES [dbo].[InvoiceItems] ([Id]),
    FOREIGN KEY ([PartId]) REFERENCES [dbo].[Parts] ([Id]),
    CHECK ([UserId] IS NOT NULL OR [WarehouseId] IS NOT NULL)
);

