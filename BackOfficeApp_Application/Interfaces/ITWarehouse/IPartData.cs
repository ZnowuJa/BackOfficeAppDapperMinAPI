using BackOfficeApp_Domain.Entities.ITWarehouse;

namespace BackOfficeApp_Application.Interfaces.ITWarehouse;

public interface IPartData
{
    Task DeletePart(int id);
    Task<PartModel?> GetPart(int id);
    Task<IEnumerable<PartModel>> GetParts();
    Task InsertPart(PartModel item);
    Task UpdatePart(PartModel item);
}
