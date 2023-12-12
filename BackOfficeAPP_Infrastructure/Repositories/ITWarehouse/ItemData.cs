using BackOfficeApp_Application.Interfaces.ITWarehouse;
using BackOfficeApp_Domain.Entities.ITWarehouse;
using BackOfficeAPP_Infrastructure.DbAccess;
using BackOfficeAPP_Application;

namespace BackOfficeAPP_Infrastructure.Repositories.ITWarehouse;

public class ItemData : IItemData
{
    private readonly ISqlDataAccess _db;
    public ItemData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<ItemModel>> GetItems() =>
        _db.LoadData<ItemModel,
            dynamic>(storedProcedures: "dbo.usp_Items_Select_All",
                new { });

    public async Task<ItemModel?> GetItem(int id)
    {
        var results = await _db.LoadData<ItemModel, dynamic>(
            storedProcedures: "dbo.usp_Items_Select",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertItem(ItemModel item) =>
        _db.SaveData(storedProcedures: "dbo.usp_Items_Insert", new { item.PartId, item.StateId, item.AssetTagNumber, item.SerialNumber, item.LastSeen, item.InvoiceItemId, item.InvoiceId, item.UserId, item.WarehouseId, item.Price, item.Currency, item.PurchaseDate });

    public Task UpdateItem(ItemModel item) =>
        _db.SaveData(storedProcedures: "usp_Items_Update", new { item.Id, item.PartId, item.StateId, item.AssetTagNumber, item.SerialNumber, item.LastSeen, item.InvoiceItemId, item.InvoiceId, item.UserId, item.WarehouseId, item.Price, item.Currency, item.PurchaseDate });

    public Task DeleteItem(int id) =>
        _db.SaveData(storedProcedures: "dbo.usp_Items_Delete", new { Id = id });
}
