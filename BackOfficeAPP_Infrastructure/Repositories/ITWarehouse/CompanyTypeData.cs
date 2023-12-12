using BackOfficeApp_Application.Interfaces.ITWarehouse;
using BackOfficeAPP_Application;
using BackOfficeApp_Domain.Entities.ITWarehouse;
using BackOfficeAPP_Infrastructure.DbAccess;


namespace BackOfficeAPP_Infrastructure.Repositories.ITWarehouse;

public class CompanyTypeData : ICompanyTypeData
{
    private readonly ISqlDataAccess _db;
    public CompanyTypeData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<CompanyTypeModel>> GetCompanyTypes() =>
        _db.LoadData<CompanyTypeModel,
            dynamic>(storedProcedures: "dbo.usp_CompanyTypes_Select_All",
                new { });

    public async Task<CompanyTypeModel?> GetCompanyType(int id)
    {
        var results = await _db.LoadData<CompanyTypeModel, dynamic>(
            storedProcedures: "dbo.usp_CompanyTypes_Select",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertCompanyType(CompanyTypeModel companyType) =>
        _db.SaveData(storedProcedures: "dbo.usp_CompanyTypes_Insert", new { companyType.Name });

    public Task UpdateCompanyType(CompanyTypeModel companyType) =>
        _db.SaveData(storedProcedures: "usp_CompanyTypes_Update", new { companyType.Id, companyType.Name });

    public Task DeleteCompanyType(int id) =>
        _db.SaveData(storedProcedures: "dbo.usp_CompanyTypes_Delete", new { Id = id });
}
