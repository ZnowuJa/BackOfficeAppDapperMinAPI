using BackOfficeApp_Application.Interfaces.ITWarehouse;
using BackOfficeApp_Domain.Entities.ITWarehouse;
using BackOfficeAPP_Application;

namespace BackOfficeAPP_Infrastructure.Repositories.ITWarehouse;

public class VendorData : IVendorData
{
    private readonly ISqlDataAccess _db;
    public VendorData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<VendorModel>> GetVendors() =>
        _db.LoadData<VendorModel,
            dynamic>(storedProcedures: "dbo.usp_Vendors_Select_All",
                new { });

    public async Task<VendorModel?> GetVendor(int id)
    {
        var results = await _db.LoadData<VendorModel, dynamic>(
            storedProcedures: "dbo.usp_Vendors_Select",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertVendor(VendorModel item) =>
        _db.SaveData(storedProcedures: "dbo.usp_Vendors_Insert", new { item.Name });

    public Task UpdateVendor(VendorModel item) =>
        _db.SaveData(storedProcedures: "usp_Vendors_Update", new { item.Id, item.Name });

    public Task DeleteVendor(int id) =>
        _db.SaveData(storedProcedures: "dbo.usp_Vendors_Delete", new { Id = id });
}
