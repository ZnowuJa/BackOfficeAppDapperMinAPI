CREATE PROC dbo.usp_Companies_Select
    @Id int
AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

    SELECT Id, Name, VATID, Street, Building, City, PostalCode, Country, CountryCode, ContactPerson, ContactPersonMobile, ContactPersonEmail, CompanyTypeId
    FROM   dbo.Companies
    WHERE  Id = @Id 

    COMMIT
GO


CREATE PROC dbo.usp_Companies_Select_All
    
AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

    SELECT Id, Name, VATID, Street, Building, City, PostalCode, Country, CountryCode, ContactPerson, ContactPersonMobile, ContactPersonEmail, CompanyTypeId
    FROM   dbo.Companies


    COMMIT
GO



CREATE PROC dbo.usp_Companies_Insert

    @Name nchar(30),
    @VATID nchar(10),
    @Street nchar(30),
    @Building nchar(10),
    @City nchar(30),
    @PostalCode nchar(10),
    @Country nchar(20),
    @CountryCode nchar(3),
    @ContactPerson nchar(30),
    @ContactPersonMobile nchar(16),
    @ContactPersonEmail nchar(50),
    @CompanyTypeId int
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        INSERT INTO dbo.Companies (Name, VATID, Street, Building, City, PostalCode, Country, CountryCode, ContactPerson, ContactPersonMobile, ContactPersonEmail, CompanyTypeId)
        SELECT @Name, @VATID, @Street, @Building, @City, @PostalCode, @Country, @CountryCode, @ContactPerson, @ContactPersonMobile, @ContactPersonEmail, @CompanyTypeId
        SELECT SCOPE_IDENTITY()

    /*
    -- Begin Return row code block

    SELECT Id, Name, VATID, Street, Building, City, PostalCode, Country, CountryCode, ContactPerson, 
           ContactPersonMobile, ContactPersonEmail
    FROM   dbo.Companies
    WHERE  Id = @Id AND Name = @Name AND VATID = @VATID AND Street = @Street AND Building = @Building AND 
           City = @City AND PostalCode = @PostalCode AND Country = @Country AND CountryCode = @CountryCode AND 
           ContactPerson = @ContactPerson AND ContactPersonMobile = @ContactPersonMobile AND ContactPersonEmail = @ContactPersonEmail

    -- End Return row code block

    */
    COMMIT
GO




CREATE PROC dbo.usp_Companies_Update
@Id int,
@Name nchar(30),
@VATID nchar(10),
@Street nchar(30),
@Building nchar(10),
@City nchar(30),
@PostalCode nchar(10),
@Country nchar(20),
@CountryCode nchar(3),
@ContactPerson nchar(30),
@ContactPersonMobile nchar(16),
@ContactPersonEmail nchar(50),
@CompanyTypeId int
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

    UPDATE dbo.Companies
    SET    Name = @Name, VATID = @VATID, Street = @Street, Building = @Building, City = @City, PostalCode = @PostalCode, 
           Country = @Country, CountryCode = @CountryCode, ContactPerson = @ContactPerson, ContactPersonMobile = @ContactPersonMobile, 
           ContactPersonEmail = @ContactPersonEmail, CompanyTypeId = @CompanyTypeId
    WHERE  Id = @Id

    /*
    -- Begin Return row code block

    SELECT Name, VATID, Street, Building, City, PostalCode, Country, CountryCode, ContactPerson, ContactPersonMobile, 
           ContactPersonEmail
    FROM   dbo.Companies
    WHERE  Id = @Id

    -- End Return row code block

    */
    COMMIT
GO




CREATE PROC dbo.usp_Companies_Delete
@Id int
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

    DELETE
    FROM   dbo.Companies
    WHERE  Id = @Id

    COMMIT
GO
--endregion