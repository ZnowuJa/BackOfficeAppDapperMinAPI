using BackOfficeApp_Application.Interfaces.ITWarehouse;
using BackOfficeApp_Domain.Entities.ITWarehouse;
using BackOfficeAPP_Infrastructure.DbAccess;
using BackOfficeAPP_Application;

namespace BackOfficeAPP_Infrastructure.Repositories.ITWarehouse;

public class Item_NoteData : IItem_NoteData
{
    private readonly ISqlDataAccess _db;
    public Item_NoteData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<Item_NoteModel>> GetItems_Notes() =>
    _db.LoadData<Item_NoteModel, dynamic>(storedProcedures: "dbo.usp_Items_Notes_Select_All", new { });

    public async Task<Item_NoteModel?> GetItem_Note(int id)
    {
        var results = await _db.LoadData<Item_NoteModel, dynamic>(
            storedProcedures: "dbo.usp_Items_Notes_Select",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertItem_Note(Item_NoteModel item_note) =>
        _db.SaveData(storedProcedures: "dbo.usp_Items_Notes_Insert", new { item_note.ItemId, item_note.NoteId });

    public Task UpdateItem_Note(Item_NoteModel item_note) =>
        _db.SaveData(storedProcedures: "dbo.usp_Items_Notes_Update", new { item_note.Id, item_note.ItemId, item_note.NoteId });

    public Task DeleteItem_Note(int id) =>
        _db.SaveData(storedProcedures: "dbo.usp_Items_Notes_Delete", new { Id = id });
}
