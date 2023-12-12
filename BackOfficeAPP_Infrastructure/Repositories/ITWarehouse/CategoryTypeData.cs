using BackOfficeApp_Application.Interfaces.ITWarehouse;
using BackOfficeAPP_Application;
using BackOfficeApp_Domain.Entities.ITWarehouse;
using BackOfficeAPP_Infrastructure.DbAccess;


namespace BackOfficeAPP_Infrastructure.Repositories.ITWarehouse;

public class CategoryTypeData : ICategoryTypeData
{
    private readonly ISqlDataAccess _db;
    public CategoryTypeData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<CategoryTypeModel>> GetCategoryTypes() =>
        _db.LoadData<CategoryTypeModel,
            dynamic>(storedProcedures: "dbo.usp_CategoryTypes_Select_All",
                new { });

    public async Task<CategoryTypeModel?> GetCategoryType(int id)
    {
        var results = await _db.LoadData<CategoryTypeModel, dynamic>(
            storedProcedures: "dbo.usp_CategoryTypes_Select",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertCategoryType(CategoryTypeModel categoryType) =>
        _db.SaveData(storedProcedures: "dbo.usp_CategoryTypes_Insert", new { categoryType.Name });

    public Task UpdateCategoryType(CategoryTypeModel categoryType) =>
        _db.SaveData(storedProcedures: "usp_CategoryTypes_Update", new { categoryType.Id, categoryType.Name });

    public Task DeleteCategoryType(int id) =>
        _db.SaveData(storedProcedures: "dbo.usp_CategoryTypes_Delete", new { Id = id });
}
