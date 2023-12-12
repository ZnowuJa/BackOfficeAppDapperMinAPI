using BackOfficeApp_Domain.Entities.ITWarehouse;

namespace BackOfficeApp_Application.Interfaces.ITWarehouse;

public interface IWarehouseData
{
    Task DeleteWarehouse(int id);
    Task<WarehouseModel?> GetWarehouse(int id);
    Task<IEnumerable<WarehouseModel>> GetWarehouses();
    Task InsertWarehouse(WarehouseModel item);
    Task UpdateWarehouse(WarehouseModel item);
}
