CREATE PROCEDURE [dbo].[spBankTransfersGetAll]

AS

BEGIN
    select
	    [txid],
        [instrid],
        [data],
        [waluta],
        [kwota],
        [cdtdbtind],
        [nazwa],
        [panstwo],
        [adres],
        [iban],
        [tytul]
    from dbo.BankTransfers55
END

