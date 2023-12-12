
CREATE PROC dbo.usp_Currencies_Select
    @Id int
AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, Name
        FROM   dbo.Currencies
        WHERE  Id = @Id 

    COMMIT
GO

CREATE PROC dbo.usp_Currencies_Select_All

AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, Name
        FROM   dbo.Currencies

    COMMIT
GO



CREATE PROC dbo.usp_Currencies_Insert

    @Name nchar(3)
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        INSERT INTO dbo.Currencies ( Name)
        SELECT @Name
        SELECT SCOPE_IDENTITY()

    /*
    -- Begin Return row code block

    SELECT Id, Name
    FROM   dbo.Currencies
    WHERE  Id = @Id AND Name = @Name

    -- End Return row code block

    */
    COMMIT
GO



CREATE PROC dbo.usp_Currencies_Update
@Id int,
@Name nchar(3)
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        UPDATE dbo.Currencies
        SET    Name = @Name
        WHERE  Id = @Id

        /*
        -- Begin Return row code block

        SELECT Name
        FROM   dbo.Currencies
        WHERE  Id = @Id

        -- End Return row code block

        */
    COMMIT
GO



CREATE PROC dbo.usp_Currencies_Delete
@Id int
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        DELETE
        FROM   dbo.Currencies
        WHERE  Id = @Id

    COMMIT
GO
--endregion