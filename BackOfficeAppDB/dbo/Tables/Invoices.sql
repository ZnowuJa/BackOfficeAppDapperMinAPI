CREATE TABLE [dbo].[Invoices] (
    [Id]         INT        PRIMARY KEY     IDENTITY (1, 1) NOT NULL,
    [Number]     NCHAR (30)      NOT NULL,
    [SupplierId] INT             NOT NULL,
    [Date]       SMALLDATETIME   NOT NULL,
    [TotalNet]   DECIMAL (10, 2) NOT NULL,
    [CompanyId]  INT             NOT NULL,

    FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([Id]),
    FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Companies] ([Id])

);