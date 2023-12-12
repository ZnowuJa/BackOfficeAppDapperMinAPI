CREATE TABLE [dbo].[InvoiceItems] (
    [Id]            INT     PRIMARY KEY        IDENTITY (1, 1) NOT NULL,
    [Name]          NCHAR (100)     NOT NULL,
    [Qty]           DECIMAL (10, 4) NOT NULL,
    [UnitId]        INT             NOT NULL,
    [UnitShortName] NCHAR(12) NOT NULL,
    [InvoiceId]     INT             NOT NULL,
    
    [UnitNetPrice] DECIMAL(10, 2) NOT NULL, 
    FOREIGN KEY ([UnitId]) REFERENCES [dbo].[Units] ([Id]),
    FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoices] ([Id])
);

