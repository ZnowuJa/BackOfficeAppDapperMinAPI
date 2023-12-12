CREATE PROCEDURE [dbo].[spBankTransfersGetLastByAmount]
	@amount int 
AS 

BEGIN
    select top (@amount)
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