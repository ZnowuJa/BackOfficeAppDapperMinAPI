using BackOfficeApp_Domain.Entities.ITWarehouse;

namespace BackOfficeApp_Application.Interfaces.ITWarehouse;

public interface ICategoryTypeData
{
    Task DeleteCategoryType(int id);
    Task<CategoryTypeModel?> GetCategoryType(int id);
    Task<IEnumerable<CategoryTypeModel>> GetCategoryTypes();
    Task InsertCategoryType(CategoryTypeModel categoryType);
    Task UpdateCategoryType(CategoryTypeModel categoryType);
}