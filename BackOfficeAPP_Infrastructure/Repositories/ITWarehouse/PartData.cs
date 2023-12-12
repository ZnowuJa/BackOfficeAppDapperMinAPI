using BackOfficeApp_Application.Interfaces.ITWarehouse;
using BackOfficeApp_Domain.Entities.ITWarehouse;
using BackOfficeAPP_Application;


namespace BackOfficeAPP_Infrastructure.Repositories.ITWarehouse;

public class PartData : IPartData
{
    private readonly ISqlDataAccess _db;
    public PartData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<PartModel>> GetParts() =>
        _db.LoadData<PartModel,
            dynamic>(storedProcedures: "dbo.usp_Parts_Select_All",
                new { });

    public async Task<PartModel?> GetPart(int id)
    {
        var results = await _db.LoadData<PartModel, dynamic>(
            storedProcedures: "dbo.usp_Parts_Select",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertPart(PartModel item) =>
        _db.SaveData(storedProcedures: "dbo.usp_Parts_Insert", new { item.Name, item.CategoryID, item.VendorId, item.Description, item.Photo, item.WarrantyPeriod, item.isCurrentlyOrderable });

    public Task UpdatePart(PartModel item) =>
        _db.SaveData(storedProcedures: "usp_Parts_Update", new { item.Id, item.Name, item.CategoryID, item.VendorId, item.Description, item.Photo, item.WarrantyPeriod, item.isCurrentlyOrderable });

    public Task DeletePart(int id) =>
        _db.SaveData(storedProcedures: "dbo.usp_Parts_Delete", new { Id = id });
}
