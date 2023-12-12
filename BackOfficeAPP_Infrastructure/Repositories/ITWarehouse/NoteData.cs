using BackOfficeApp_Application.Interfaces.ITWarehouse;
using BackOfficeApp_Domain.Entities.ITWarehouse;
using BackOfficeAPP_Infrastructure.DbAccess;
using BackOfficeAPP_Application;

namespace BackOfficeAPP_Infrastructure.Repositories.ITWarehouse;

public class NoteData : INoteData
{
    private readonly ISqlDataAccess _db;
    public NoteData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<NoteModel>> GetNotes() =>
    _db.LoadData<NoteModel, dynamic>(storedProcedures: "dbo.usp_Notes_Select_All", new { });

    public async Task<NoteModel?> GetNote(int id)
    {
        var results = await _db.LoadData<NoteModel, dynamic>(
            storedProcedures: "dbo.usp_Notes_Select",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertNote(NoteModel item) =>
        _db.SaveData(storedProcedures: "dbo.usp_Notes_Insert", new { item.Text });

    public Task UpdateNote(NoteModel item) =>
        _db.SaveData(storedProcedures: "dbo.usp_Notes_Update", new { item.Id, item.Text });

    public Task DeleteNote(int id) =>
        _db.SaveData(storedProcedures: "dbo.usp_Notes_Delete", new { Id = id });

}
