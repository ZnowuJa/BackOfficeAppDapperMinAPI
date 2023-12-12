using BackOfficeApp_Application.Interfaces.ITWarehouse;
using BackOfficeApp_Domain.Entities.ITWarehouse;
using BackOfficeAPP_Application;

namespace BackOfficeAPP_Infrastructure.Repositories.ITWarehouse;

public class WarehouseData : IWarehouseData
{
    private readonly ISqlDataAccess _db;
    public WarehouseData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<WarehouseModel>> GetWarehouses() =>
        _db.LoadData<WarehouseModel,
            dynamic>(storedProcedures: "dbo.usp_Warehouses_Select_All",
                new { });

    public async Task<WarehouseModel?> GetWarehouse(int id)
    {
        var results = await _db.LoadData<WarehouseModel, dynamic>(
            storedProcedures: "dbo.usp_Warehouses_Select",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertWarehouse(WarehouseModel item) =>
        _db.SaveData(storedProcedures: "dbo.usp_Warehouses_Insert", new { item.Number });

    public Task UpdateWarehouse(WarehouseModel item) =>
        _db.SaveData(storedProcedures: "usp_Warehouses_Update", new { item.Id, item.Number });

    public Task DeleteWarehouse(int id) =>
        _db.SaveData(storedProcedures: "dbo.usp_Warehouses_Delete", new { Id = id });
}
