using BackOfficeApp_Domain.Entities.ITWarehouse;

namespace BackOfficeApp_Application.Interfaces.ITWarehouse;

public interface INoteData
{
    Task DeleteNote(int id);
    Task<NoteModel?> GetNote(int id);
    Task<IEnumerable<NoteModel>> GetNotes();
    Task InsertNote(NoteModel item);
    Task UpdateNote(NoteModel item);
}
