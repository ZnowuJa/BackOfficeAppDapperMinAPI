

if not exists (select 1 from dbo.Users)
    begin
        insert into dbo.Users (FirstName,LastName,ADLogonName,ThirdPartyId,Email,MobileNumber,PhoneNumber)
		values ('Marcin','Jarco','Marcin.Jarco','none','marcin.jarco@porscheinterauto.pl','+48512557420',''), ('Daniel','Maliszewski','Daniel.Maliszewski','none','daniel.maliszewski@porscheinterauto.pl','+48608574518',''),('Robert','Bogucki','Robert.Bogucki','none','Robert.Bogucki@porscheinterauto.pl','+48884204797','');
    end

--if not exists (select 1 from dbo.BankTransfers55)
--    begin
--        insert into dbo.BBankTransfers55(txid,instrid,data,waluta,kwota,cdtdbtind,nazwa,panstwo,adres,iban,tytul)
--		values 
--        (1000047640,'CEN2011130377851',2020-11-13,'PLN',89370.00,'CRDT','VOLKSWAGEN FINANCIAL SERVICES POLSK|A SP\xd3ŁKA Z OGRANICZONĄ ODPOWIEDZIAL','PL','RONDO ONZ I|00-124 WARSZAWA','46213000042001000000990003  ','/VAT/16711,46/IDC/6461002655/INV/FA|F/0016320PS/TXT/8800385-5420-04754||');
--    end

        
        
--if not exists (select 1 from dbo.Users)
--    begin
        


--    end

    