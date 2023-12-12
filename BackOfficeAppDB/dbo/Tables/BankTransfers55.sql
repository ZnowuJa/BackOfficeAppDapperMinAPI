CREATE TABLE [dbo].[BankTransfers55]
(
    [txid]      INT            NOT NULL,
    [instrid]   NVARCHAR (50)  NOT NULL,
    [data]      DATE           NOT NULL,
    [waluta]    NVARCHAR (50)  NOT NULL,
    [kwota]     FLOAT (53)     NULL,
    [cdtdbtind] NVARCHAR (50)  NOT NULL,
    [nazwa]     NVARCHAR (100) NOT NULL,
    [panstwo]   NVARCHAR (50)  NULL,
    [adres]     NVARCHAR (100) NULL,
    [iban]      NVARCHAR (50)  NOT NULL,
    [tytul]     NVARCHAR (150) NOT NULL
);

