using BackOfficeApp_Domain.Entities.ITWarehouse;

namespace BackOfficeApp_Application.Interfaces.ITWarehouse;

public interface IUnitData
{
    Task DeleteUnit(int id);
    Task<UnitModel?> GetUnit(int id);
    Task<IEnumerable<UnitModel>> GetUnits();
    Task InsertUnit(UnitModel dataModel);
    Task UpdateUnit(UnitModel dataModel);
}