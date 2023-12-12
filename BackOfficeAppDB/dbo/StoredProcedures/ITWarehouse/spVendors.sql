
CREATE PROC dbo.usp_Vendors_Select
    @Id int
AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, Name, isDeactivated, isDeactivatedDate
        FROM   dbo.Vendors
        WHERE  Id = @Id 

    COMMIT
GO


CREATE PROC dbo.usp_Vendors_Select_All

AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, Name, isDeactivated, isDeactivatedDate
        FROM   dbo.Vendors

    COMMIT
GO



CREATE PROC dbo.usp_Vendors_Insert
    @Id int,
    @Name nchar(30),
    @isDeactivated int,
    @isDeactivatedDate smalldatetime
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN
            
        INSERT INTO dbo.Vendors (Id, Name, isDeactivated, isDeactivatedDate)
        SELECT @Id, @Name, @isDeactivated, @isDeactivatedDate
        SELECT SCOPE_IDENTITY()
        /*
        -- Begin Return row code block

        SELECT Id, Name, isDeactivated, isDeactivatedDate
        FROM   dbo.Vendors
        WHERE  Id = @Id AND Name = @Name AND isDeactivated = @isDeactivated AND isDeactivatedDate = @isDeactivatedDate

        -- End Return row code block

        */
    COMMIT
GO



CREATE PROC dbo.usp_Vendors_Update
@Id int,
@Name nchar(30)


AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON
    

    BEGIN TRAN
        --DECLARE @isActive bit = SELECT isDeactivated from dbo.Vendors where id = @Id;
        --IF @isActive
        UPDATE dbo.Vendors
        SET    Name = @Name
        WHERE  Id = @Id

        /*
        -- Begin Return row code block

        SELECT Name, isDeactivated, isDeactivatedDate
        FROM   dbo.Vendors
        WHERE  Id = @Id

        -- End Return row code block

        */
    COMMIT
GO




CREATE PROC dbo.usp_Vendors_Delete
@Id int
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

       UPDATE dbo.Vendors
        SET   isDeactivated = 1, isDeactivatedDate = GETDATE()
        WHERE  Id = @Id

    COMMIT
GO
--endregion