
CREATE PROC dbo.usp_Items_Notes_Select
    @Id int
AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, ItemId, NoteId
        FROM   dbo.Items_Notes
        WHERE  Id = @Id 

    COMMIT
GO



CREATE PROC dbo.usp_Items_Notes_Select_All
    
AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, ItemId, NoteId
        FROM   dbo.Items_Notes

    COMMIT
GO

CREATE PROC dbo.usp_Items_Notes_Insert

    @ItemId int,
    @NoteId int
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        INSERT INTO dbo.Items_Notes ( ItemId, NoteId)
        SELECT  @ItemId, @NoteId
        SELECT SCOPE_IDENTITY()

        /*
        -- Begin Return row code block

        SELECT Id, ItemId, NoteId
        FROM   dbo.Items_Notes
        WHERE  Id = @Id AND ItemId = @ItemId AND NoteId = @NoteId

        -- End Return row code block

        */
    COMMIT
GO



CREATE PROC dbo.usp_Items_Notes_Update
@Id int,
@ItemId int,
@NoteId int
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        UPDATE dbo.Items_Notes
        SET    ItemId = @ItemId, NoteId = @NoteId
        WHERE  Id = @Id

        /*
        -- Begin Return row code block

        SELECT ItemId, NoteId
        FROM   dbo.Items_Notes
        WHERE  Id = @Id

        -- End Return row code block

        */
    COMMIT
GO



CREATE PROC dbo.usp_Items_Notes_Delete
@Id int
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        DELETE
        FROM   dbo.Items_Notes
        WHERE  Id = @Id

    COMMIT
GO
--endregion