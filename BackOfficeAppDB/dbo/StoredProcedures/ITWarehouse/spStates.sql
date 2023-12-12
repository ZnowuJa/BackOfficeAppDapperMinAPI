
CREATE PROC dbo.usp_States_Select
    @Id int
AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, Name, Description
        FROM   dbo.States
        WHERE  Id = @Id 

    COMMIT
GO



CREATE PROC dbo.usp_States_Select_All

AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, Name, Description
        FROM   dbo.States

    COMMIT
GO



CREATE PROC dbo.usp_States_Insert
    @Name nchar(10),
    @Description nchar(100)
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        INSERT INTO dbo.States (Name, Description)
        SELECT  @Name, @Description
        SELECT SCOPE_IDENTITY()
        /*
        -- Begin Return row code block

        SELECT Id, Name, Description
        FROM   dbo.States
        WHERE  Id = @Id AND Name = @Name AND Description = @Description

        -- End Return row code block

        */
    COMMIT
GO



CREATE PROC dbo.usp_States_Update
@Id int,
@Name nchar(10),
@Description nchar(100)
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        UPDATE dbo.States
        SET    Name = @Name, Description = @Description
        WHERE  Id = @Id

        /*
        -- Begin Return row code block

        SELECT Name, Description
        FROM   dbo.States
        WHERE  Id = @Id

        -- End Return row code block

        */
    COMMIT
GO



CREATE PROC dbo.usp_States_Delete
@Id int
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        DELETE
        FROM   dbo.States
        WHERE  Id = @Id

    COMMIT
GO
--endregion