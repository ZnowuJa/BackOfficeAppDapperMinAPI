CREATE PROCEDURE [dbo].[spBankTransfersGetLastByDays]
	@days int 
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
    where data >= dateadd(DAY, -1 * @days, GETDATE())
END