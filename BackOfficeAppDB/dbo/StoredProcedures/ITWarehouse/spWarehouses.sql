
CREATE PROC dbo.usp_Warehouses_Select
    @Id int
AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, Number
        FROM   dbo.Warehouses
        WHERE  Id = @Id 

    COMMIT
GO


CREATE PROC dbo.usp_Warehouses_Select_All
    
AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, Number
        FROM   dbo.Warehouses
        
    COMMIT
GO



CREATE PROC dbo.usp_Warehouses_Insert

    @Number int
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        INSERT INTO dbo.Warehouses (Number)
        SELECT @Number
        SELECT SCOPE_IDENTITY()
        /*
        -- Begin Return row code block

        SELECT Id, Number
        FROM   dbo.Warehouses
        WHERE  Id = @Id AND Number = @Number

        -- End Return row code block

        */
    COMMIT
GO


CREATE PROC dbo.usp_Warehouses_Update
@Id int,
@Number int
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        UPDATE dbo.Warehouses
        SET    Number = @Number
        WHERE  Id = @Id

        /*
        -- Begin Return row code block

        SELECT Number
        FROM   dbo.Warehouses
        WHERE  Id = @Id

        -- End Return row code block

        */
    COMMIT
GO



CREATE PROC dbo.usp_Warehouses_Delete
@Id int
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        DELETE
        FROM   dbo.Warehouses
        WHERE  Id = @Id
    
    COMMIT
GO
--endregion