CREATE PROC dbo.usp_CategoryTypes_Select_All
   
AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, Name
        FROM   dbo.CategoryTypes

    COMMIT
GO



CREATE PROC dbo.usp_CategoryTypes_Select
    @Id int
AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, Name
        FROM   dbo.CategoryTypes
        WHERE  Id = @Id 

    COMMIT
GO



CREATE PROC dbo.usp_CategoryTypes_Insert
    @Name nchar(10)
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        INSERT INTO dbo.CategoryTypes ( Name)
        SELECT @Name
        SELECT SCOPE_IDENTITY()

        /*
        -- Begin Return row code block

        SELECT Id, Name
        FROM   dbo.CategoryTypes
        WHERE  Id = @Id AND Name = @Name

        -- End Return row code block

        */
    COMMIT
GO



CREATE PROC dbo.usp_CategoryTypes_Update
@Id int,
@Name nchar(10)
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        UPDATE dbo.CategoryTypes
        SET    Name = @Name
        WHERE  Id = @Id

        /*
        -- Begin Return row code block

        SELECT Name
        FROM   dbo.CategoryTypes
        WHERE  Id = @Id

        -- End Return row code block

        */
    COMMIT
GO



CREATE PROC dbo.usp_CategoryTypes_Delete
@Id int

AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN
    
        DELETE
        FROM   dbo.CategoryTypes
        WHERE  Id = @Id

    COMMIT
GO
