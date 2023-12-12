CREATE PROC dbo.usp_Notes_Select
    @Id int
AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, Text
        FROM   dbo.Notes
        WHERE  Id = @Id 

    COMMIT
GO

CREATE PROC dbo.usp_Notes_Select_All
 
AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, Text
        FROM   dbo.Notes

    COMMIT
GO


CREATE PROC dbo.usp_Notes_Insert
    @Id int,
    @Text nchar(500)
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        INSERT INTO dbo.Notes (Id, Text)
        SELECT @Id, @Text
        SELECT SCOPE_IDENTITY()

        /*
        -- Begin Return row code block

        SELECT Id, Text
        FROM   dbo.Notes
        WHERE  Id = @Id AND Text = @Text

        -- End Return row code block

        */
    COMMIT
GO



CREATE PROC dbo.usp_Notes_Update
@Id int,
@Text nchar(500)
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        UPDATE dbo.Notes
        SET    Text = @Text
        WHERE  Id = @Id

        /*
        -- Begin Return row code block

        SELECT Text
        FROM   dbo.Notes
        WHERE  Id = @Id

        -- End Return row code block

        */
    COMMIT
GO



CREATE PROC dbo.usp_Notes_Delete
@Id int
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        DELETE
        FROM   dbo.Notes
        WHERE  Id = @Id

    COMMIT
GO
--endregion