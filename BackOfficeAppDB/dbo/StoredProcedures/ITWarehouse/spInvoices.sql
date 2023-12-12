CREATE PROC dbo.usp_Invoices_Select
    @Id int
AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, Number, SupplierId, Date, TotalNet, CompanyId
        FROM   dbo.Invoices
        WHERE  Id = @Id 

    COMMIT
GO



CREATE PROC dbo.usp_Invoices_Select_All
    
AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, Number, SupplierId, Date, TotalNet, CompanyId
        FROM   dbo.Invoices

    COMMIT
GO

CREATE PROC dbo.usp_Invoices_Insert

    @Number nchar(30),
    @SupplierId int,
    @Date smalldatetime,
    @TotalNet decimal(10, 2),
    @CompanyId int
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        INSERT INTO dbo.Invoices (Number, SupplierId, Date, TotalNet, CompanyId)
        SELECT  @Number, @SupplierId, @Date, @TotalNet, @CompanyId
        SELECT SCOPE_IDENTITY()
        /*
        -- Begin Return row code block

        SELECT Id, Number, SupplierId, Date, TotalNet, Company
        FROM   dbo.Invoices
        WHERE  Id = @Id AND Number = @Number AND SupplierId = @SupplierId AND Date = @Date AND TotalNet = @TotalNet AND 
               Company = @Company

        -- End Return row code block

        */
    COMMIT
GO



CREATE PROC dbo.usp_Invoices_Update
@Id int,
@Number nchar(30),
@SupplierId int,
@Date smalldatetime,
@TotalNet decimal(10, 2),
@CompanyId int
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        UPDATE dbo.Invoices
        SET    Number = @Number, SupplierId = @SupplierId, Date = @Date, TotalNet = @TotalNet, CompanyId = @CompanyId
        WHERE  Id = @Id

    /*
    -- Begin Return row code block

    SELECT Number, SupplierId, Date, TotalNet, Company
    FROM   dbo.Invoices
    WHERE  Id = @Id

    -- End Return row code block

    */
    COMMIT
GO



CREATE PROC dbo.usp_Invoices_Delete
@Id int
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        DELETE
        FROM   dbo.Invoices
        WHERE  Id = @Id

    COMMIT
GO
