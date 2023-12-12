using BackOfficeApp_Domain.Entities.ITWarehouse;

namespace BackOfficeApp_Application.Interfaces.ITWarehouse;


public interface IItemData
{
    Task DeleteItem(int id);
    Task<ItemModel?> GetItem(int id);
    Task<IEnumerable<ItemModel>> GetItems();
    Task InsertItem(ItemModel item);
    Task UpdateItem(ItemModel item);
}

