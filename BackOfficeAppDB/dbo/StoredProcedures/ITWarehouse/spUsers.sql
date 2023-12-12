CREATE PROC dbo.usp_Users_Select_All
    
AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, FirstName, LastName, ADLogonName, ThirdPartyId, Email, MobileNumber, PhoneNumber, isDeactivated, isDeactivatedDate
        FROM   dbo.Users
 
    COMMIT
GO

CREATE PROC dbo.usp_Users_Select
    @Id int
AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, FirstName, LastName, ADLogonName, ThirdPartyId, Email, MobileNumber, PhoneNumber, isDeactivated, isDeactivatedDate
        FROM   dbo.Users
        WHERE  Id = @Id 

    COMMIT
GO



CREATE PROC dbo.usp_Users_Insert
    @FirstName nchar(50),
    @LastName nchar(50),
    @ADLogonName nchar(50),
    @ThirdPartyId nchar(50),
    @Email nchar(50),
    @MobileNumber nchar(20),
    @PhoneNumber nchar(20)

AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        INSERT INTO dbo.Users ( FirstName, LastName, ADLogonName, ThirdPartyId, Email, MobileNumber, PhoneNumber)
        SELECT @FirstName, @LastName, @ADLogonName, @ThirdPartyId, @Email, @MobileNumber, @PhoneNumber
        SELECT SCOPE_IDENTITY()
        /*
        -- Begin Return row code block

        SELECT Id, FirstName, LastName, ADLogonName, ThirdPartyId, Email, MobileNumber, PhoneNumber, isDeactivated, 
               isDeactivatedDate
        FROM   dbo.Users
        WHERE  Id = @Id AND FirstName = @FirstName AND LastName = @LastName AND ADLogonName = @ADLogonName AND 
               ThirdPartyId = @ThirdPartyId AND Email = @Email AND MobileNumber = @MobileNumber AND PhoneNumber = @PhoneNumber AND 
               isDeactivated = @isDeactivated AND isDeactivatedDate = @isDeactivatedDate

        -- End Return row code block

        */
    COMMIT
GO



CREATE PROC dbo.usp_Users_Update
@Id int,
@FirstName nchar(50),
@LastName nchar(50),
@ADLogonName nchar(50),
@ThirdPartyId nchar(50),
@Email nchar(50),
@MobileNumber nchar(20),
@PhoneNumber nchar(20)


AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        UPDATE dbo.Users
        SET    FirstName = @FirstName, LastName = @LastName, ADLogonName = @ADLogonName, ThirdPartyId = @ThirdPartyId, 
               Email = @Email, MobileNumber = @MobileNumber, PhoneNumber = @PhoneNumber
        WHERE  Id = @Id

        /*
        -- Begin Return row code block

        SELECT FirstName, LastName, ADLogonName, ThirdPartyId, Email, MobileNumber, PhoneNumber, isDeactivated, 
               isDeactivatedDate
        FROM   dbo.Users
        WHERE  Id = @Id

        -- End Return row code block

        */
    COMMIT
GO



CREATE PROC dbo.usp_Users_Delete
@Id int


AS 

    BEGIN TRAN

        update  [Users]
		set isDeactivated = 'true', isDeactivatedDate = getdate()
		where Id = @Id;

    COMMIT
GO
