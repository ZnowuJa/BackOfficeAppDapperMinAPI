
CREATE PROC dbo.usp_Categories_Select
    @Id int
AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, Name, Prefix, CategoryTypeId, isDeactivated, isDeactivatedDate
        FROM   dbo.Categories
        WHERE  Id = @Id 

    COMMIT
GO




CREATE PROC dbo.usp_Categories_Select_All
    
AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, Name, Prefix, CategoryTypeId, isDeactivated, isDeactivatedDate
        FROM   dbo.Categories

    COMMIT
GO



CREATE PROC dbo.usp_Categories_Insert

    @Name nchar(20),
    @Prefix nchar(5),
    @CategoryTypeId int
    
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        INSERT INTO dbo.Categories (Name, Prefix, CategoryTypeId)
        SELECT  @Name, @Prefix, @CategoryTypeId
        SELECT SCOPE_IDENTITY()
        /*
        -- Begin Return row code block

        SELECT Id, Name, Prefix, CategoryTypeId, isDeactivated, isDeactivatedDate
        FROM   dbo.Categories
        WHERE  Id = @Id AND Name = @Name AND Prefix = @Prefix AND CategoryTypeId = @CategoryTypeId AND isDeactivated = @isDeactivated AND 
               isDeactivatedDate = @isDeactivatedDate

        -- End Return row code block

        */
    COMMIT
GO




CREATE PROC dbo.usp_Categories_Update
@Id int,
@Name nchar(20),
@Prefix nchar(5),
@CategoryTypeId int

AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        UPDATE dbo.Categories
        SET    Name = @Name, Prefix = @Prefix, CategoryTypeId = @CategoryTypeId
        WHERE  Id = @Id

        /*
        -- Begin Return row code block

        SELECT Name, Prefix, CategoryTypeId, isDeactivated, isDeactivatedDate
        FROM   dbo.Categories
        WHERE  Id = @Id

        -- End Return row code block

        */
        COMMIT
GO




CREATE PROC dbo.usp_Categories_Delete
@Id int
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

		update  dbo.Categories
		set isDeactivated = 'true', isDeactivatedDate = getdate()
		where Id = @Id;

    COMMIT
GO
--endregion

