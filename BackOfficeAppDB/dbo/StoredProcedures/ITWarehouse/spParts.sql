
CREATE PROC dbo.usp_Parts_Select
    @Id int
AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, Name, CategoryID, VendorId, Description, Photo, WarrantyPeriod, isCurrentlyOrderable
        FROM   dbo.Parts
        WHERE  Id = @Id 

    COMMIT
GO

CREATE PROC dbo.usp_Parts_Select_All
   
AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, Name, CategoryID, VendorId, Description, Photo, WarrantyPeriod, isCurrentlyOrderable
        FROM   dbo.Parts

    COMMIT
GO



CREATE PROC dbo.usp_Parts_Insert

    @Name nchar(20),
    @CategoryID int,
    @VendorId int,
    @Description nchar(100),
    @Photo nchar(10),
    @WarrantyPeriod int,
    @isCurrentlyOrderable int

AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        INSERT INTO dbo.Parts ( Name, CategoryID, VendorId, Description, Photo, WarrantyPeriod, isCurrentlyOrderable)
        SELECT  @Name, @CategoryID, @VendorId, @Description, @Photo, @WarrantyPeriod, @isCurrentlyOrderable
        SELECT SCOPE_IDENTITY()   

        /*
        -- Begin Return row code block

        SELECT Id, Name, CategoryID, VendorId, Description, Photo, WarrantyPeriod, isCurrentlyOrderable, 
               isDeactivated, isDeactivatedDate
        FROM   dbo.Parts
        WHERE  Id = @Id AND Name = @Name AND CategoryID = @CategoryID AND VendorId = @VendorId AND Description = @Description AND 
               Photo = @Photo AND WarrantyPeriod = @WarrantyPeriod AND isCurrentlyOrderable = @isCurrentlyOrderable AND 
               isDeactivated = @isDeactivated AND isDeactivatedDate = @isDeactivatedDate

        -- End Return row code block

        */
    COMMIT
GO



CREATE PROC dbo.usp_Parts_Update
@Id int,
@Name nchar(20),
@CategoryID int,
@VendorId int,
@Description nchar(100),
@Photo nchar(10),
@WarrantyPeriod int,
@isCurrentlyOrderable int

AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        UPDATE dbo.Parts
        SET    Name = @Name, CategoryID = @CategoryID, VendorId = @VendorId, Description = @Description, 
               Photo = @Photo, WarrantyPeriod = @WarrantyPeriod, isCurrentlyOrderable = @isCurrentlyOrderable
               
        WHERE  Id = @Id

        /*
        -- Begin Return row code block

        SELECT Name, CategoryID, VendorId, Description, Photo, WarrantyPeriod, isCurrentlyOrderable
        FROM   dbo.Parts
        WHERE  Id = @Id

        -- End Return row code block

        */
    COMMIT
GO



CREATE PROC dbo.usp_Parts_Delete
@Id int
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        UPDATE dbo.Parts
        SET    isDeactivated = 1, isDeactivatedDate = GETDATE()
               
        WHERE  Id = @Id

    COMMIT
GO
