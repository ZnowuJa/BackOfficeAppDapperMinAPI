
CREATE PROC dbo.usp_CompanyTypes_Select
    @Id int
AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, Name
        FROM   dbo.CompanyTypes
        WHERE  Id = @Id 

    COMMIT
GO


CREATE PROC dbo.usp_CompanyTypes_Select_All
    
AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, Name
        FROM   dbo.CompanyTypes


    COMMIT
GO


CREATE PROC dbo.usp_CompanyTypes_Insert
    @Name nchar(10)
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        INSERT INTO dbo.CompanyTypes ( Name)
        SELECT  @Name
        SELECT SCOPE_IDENTITY()

    /*
    -- Begin Return row code block

    SELECT Id, Name
    FROM   dbo.CompanyTypes
    WHERE  Id = @Id AND Name = @Name

    -- End Return row code block

    */
    COMMIT
GO

CREATE PROC dbo.usp_CompanyTypes_Update
@Id int,
@Name nchar(10)
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        UPDATE dbo.CompanyTypes
        SET    Name = @Name
        WHERE  Id = @Id

    /*
    -- Begin Return row code block

    SELECT Name
    FROM   dbo.CompanyTypes
    WHERE  Id = @Id

    -- End Return row code block

    */
    COMMIT
GO

CREATE PROC dbo.usp_CompanyTypes_Delete
@Id int
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        DELETE
        FROM   dbo.CompanyTypes
        WHERE  Id = @Id

    COMMIT
GO
