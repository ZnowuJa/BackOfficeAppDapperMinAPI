
CREATE PROC dbo.usp_Items_Select
    @Id int
AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

    SELECT Id, PartId, StateId, AssetTagNumber, SerialNumber, LastSeen, InvoiceItemId, InvoiceId, UserId, WarehouseId, isDeactivated, isDeactivatedDate, Price, Currency, PurchaseDate
    FROM   dbo.Items
    WHERE  Id = @Id 

    COMMIT
GO



CREATE PROC dbo.usp_Items_Select_All
    
AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, PartId, StateId, AssetTagNumber, SerialNumber, LastSeen, InvoiceItemId, InvoiceId, UserId, WarehouseId, isDeactivated, isDeactivatedDate, Price, Currency, PurchaseDate
        FROM   dbo.Items

    COMMIT
GO

CREATE PROC dbo.usp_Items_Insert
    @PartId int,
    @StateId int,
    @AssetTagNumber nchar(15),
    @SerialNumber nchar(30),
    @LastSeen smalldatetime,
    @InvoiceItemId int,
    @InvoiceId int,
    @UserId int,
    @WarehouseId int,
    @Price decimal(8, 2),
    @Currency nchar(3),
    @PurchaseDate nchar(10)
   
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        INSERT INTO dbo.Items (PartId, StateId, AssetTagNumber, SerialNumber, LastSeen, InvoiceItemId, 
                               InvoiceId, UserId, WarehouseId, Price, 
                               Currency, PurchaseDate)
        SELECT  @PartId, @StateId, @AssetTagNumber, @SerialNumber, @LastSeen, @InvoiceItemId, @InvoiceId, 
               @UserId, @WarehouseId,  @Price, @Currency, @PurchaseDate
        SELECT SCOPE_IDENTITY()

    /*
    -- Begin Return row code block

    SELECT Id, PartId, StateId, AssetTagNumber, SerialNumber, LastSeen, InvoiceItemId, InvoiceId, UserId, 
           WarehouseId, isDeactivated, isDeactivatedDate, Price, Currency, PurchaseDate, dupa
    FROM   dbo.Items
    WHERE  Id = @Id AND PartId = @PartId AND StateId = @StateId AND AssetTagNumber = @AssetTagNumber AND 
           SerialNumber = @SerialNumber AND LastSeen = @LastSeen AND InvoiceItemId = @InvoiceItemId AND 
           InvoiceId = @InvoiceId AND UserId = @UserId AND WarehouseId = @WarehouseId AND isDeactivated = @isDeactivated AND 
           isDeactivatedDate = @isDeactivatedDate AND Price = @Price AND Currency = @Currency AND PurchaseDate = @PurchaseDate AND 
           dupa = @dupa

    -- End Return row code block

    */
    COMMIT
GO



CREATE PROC dbo.usp_Items_Update
@Id int,
@PartId int,
@StateId int,
@AssetTagNumber nchar(15),
@SerialNumber nchar(30),
@LastSeen smalldatetime,
@InvoiceItemId int,
@InvoiceId int,
@UserId int,
@WarehouseId int,
@Price decimal(8, 2),
@Currency nchar(3),
@PurchaseDate nchar(10)

AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        UPDATE dbo.Items
        SET    PartId = @PartId, StateId = @StateId, AssetTagNumber = @AssetTagNumber, SerialNumber = @SerialNumber, 
               LastSeen = @LastSeen, InvoiceItemId = @InvoiceItemId, InvoiceId = @InvoiceId, UserId = @UserId, 
               WarehouseId = @WarehouseId,Price = @Price, Currency = @Currency, PurchaseDate = @PurchaseDate
        WHERE  Id = @Id

        /*
        -- Begin Return row code block

        SELECT PartId, StateId, AssetTagNumber, SerialNumber, LastSeen, InvoiceItemId, InvoiceId, UserId, 
               WarehouseId, isDeactivated, isDeactivatedDate, Price, Currency, PurchaseDate, dupa
        FROM   dbo.Items
        WHERE  Id = @Id

        -- End Return row code block

        */
    COMMIT
GO



CREATE PROC dbo.usp_Items_Delete
@Id int,
@isDeactivated int

AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        UPDATE dbo.Items
        SET    isDeactivated = @isDeactivated, isDeactivatedDate = getdate()
        WHERE  Id = @Id

    COMMIT
GO
