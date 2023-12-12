using BackOfficeApp_Domain.Entities.ITWarehouse;

namespace BackOfficeApp_Application.Interfaces.ITWarehouse;

public interface ICategoryData
{
    Task DeleteCategory(int id);
    Task<IEnumerable<CategoryModel>> GetCategories();
    Task<CategoryModel?> GetCategory(int id);
    Task InsertCategory(CategoryModel category);
    Task UpdateCategory(CategoryModel category);
}