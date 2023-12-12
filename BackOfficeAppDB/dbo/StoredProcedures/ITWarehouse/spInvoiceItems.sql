
CREATE PROC dbo.usp_InvoiceItems_Select
    @Id int
AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, Name, Qty, UnitId, UnitShortName, InvoiceId, UnitNetPrice
        FROM   dbo.InvoiceItems
        WHERE  Id = @Id 

    COMMIT
GO



CREATE PROC dbo.usp_InvoiceItems_Select_All

AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, Name, Qty, UnitId, UnitShortName, InvoiceId, UnitNetPrice
        FROM   dbo.InvoiceItems


    COMMIT
GO




CREATE PROC dbo.usp_InvoiceItems_Insert
    @Name nchar(100),
    @Qty decimal(10, 4),
    @UnitId int,
    @UnitShortName  nchar(12),
    @InvoiceId int,
    @UnitNetPrice decimal (10,2)
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        INSERT INTO dbo.InvoiceItems ( Name, Qty, UnitId, UnitShortName, InvoiceId, UnitNetPrice)
        SELECT @Name, @Qty, @UnitId, @UnitShortName, @InvoiceId, @UnitNetPrice
        SELECT SCOPE_IDENTITY()

        /*
        -- Begin Return row code block

        SELECT Id, Name, Qty, UnitId, UnitShortName, InvoiceId
        FROM   dbo.InoviceItems
        WHERE  Id = @Id AND Name = @Name AND Qty = @Qty AND UnitId = @UnitId AND UnitShortName = @UnitShortName AND 
               InvoiceId = @InvoiceId

        -- End Return row code block

        */
    COMMIT
GO



CREATE PROC dbo.usp_InvoiceItems_Update
    @Id int,
    @Name nchar(100),
    @Qty decimal(10, 4),
    @UnitId int,
    @UnitShortName  nchar(12),
    @InvoiceId int,
    @UnitNetPrice decimal (10,2)
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        UPDATE dbo.InvoiceItems
        SET    Name = @Name, Qty = @Qty, UnitId = @UnitId, UnitShortName = @UnitShortName, InvoiceId = @InvoiceId, UnitNetPrice = @UnitNetPrice
        WHERE  Id = @Id

        /*
        -- Begin Return row code block

        SELECT Name, Qty, UnitId, UnitShortName, InvoiceId
        FROM   dbo.InoviceItems
        WHERE  Id = @Id

        -- End Return row code block

        */
    COMMIT
GO



CREATE PROC dbo.usp_InvoiceItems_Delete
@Id int
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        DELETE
        FROM   dbo.InvoiceItems
        WHERE  Id = @Id

    COMMIT
GO
--endregion