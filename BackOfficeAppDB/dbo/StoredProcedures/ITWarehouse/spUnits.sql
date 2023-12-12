
CREATE PROC dbo.usp_Units_Select
    @Id int
AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, Name, UnitShortName
        FROM   dbo.Units
        WHERE  Id = @Id 

    COMMIT
GO



CREATE PROC dbo.usp_Units_Select_All

AS
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        SELECT Id, Name, UnitShortName
        FROM   dbo.Units


    COMMIT
GO



CREATE PROC dbo.usp_Units_Insert
    @Name nchar(20),
    @UnitShortName nchar(5)
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        INSERT INTO dbo.Units (Name, UnitShortName)
        SELECT  @Name, @UnitShortName
        SELECT SCOPE_IDENTITY()
        /*
        -- Begin Return row code block

        SELECT Id, Name, UnitShortName
        FROM   dbo.Units
        WHERE  Id = @Id AND Name = @Name AND UnitShortName = @UnitShortName

        -- End Return row code block

        */
    COMMIT
GO



CREATE PROC dbo.usp_Units_Update
@Id int,
@Name nchar(20),
@UnitShortName nchar(5)
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        UPDATE dbo.Units
        SET    Name = @Name, UnitShortName = @UnitShortName
        WHERE  Id = @Id

        /*
        -- Begin Return row code block

        SELECT Name, UnitShortName
        FROM   dbo.Units
        WHERE  Id = @Id

        -- End Return row code block

        */
    COMMIT
GO




CREATE PROC dbo.usp_Units_Delete
@Id int
AS 
    SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRAN

        DELETE
        FROM   dbo.Units
        WHERE  Id = @Id

    COMMIT
GO
--endregion