using BackOfficeApp_Domain.Entities.ITWarehouse;

namespace BackOfficeApp_Application.Interfaces.ITWarehouse;

public interface IItem_NoteData
{
    Task DeleteItem_Note(int id);
    Task<IEnumerable<Item_NoteModel>> GetItems_Notes();
    Task<Item_NoteModel?> GetItem_Note(int id);
    Task InsertItem_Note(Item_NoteModel item_note);
    Task UpdateItem_Note(Item_NoteModel item_note);
}
