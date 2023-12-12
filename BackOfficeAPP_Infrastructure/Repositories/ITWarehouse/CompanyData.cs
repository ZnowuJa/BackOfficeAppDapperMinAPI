using BackOfficeApp_Application.Interfaces.ITWarehouse;
using BackOfficeAPP_Application;
using BackOfficeApp_Domain.Entities.ITWarehouse;
using BackOfficeAPP_Infrastructure.DbAccess;


namespace BackOfficeAPP_Infrastructure.Repositories.ITWarehouse;

public class CompanyData : ICompanyData
{
    private readonly ISqlDataAccess _db;
    public CompanyData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<CompanyModel>> GetCompanies() =>
    _db.LoadData<CompanyModel, dynamic>(storedProcedures: "dbo.usp_Companies_Select_All", new { });

    public async Task<CompanyModel?> GetCompany(int id)
    {
        var results = await _db.LoadData<CompanyModel, dynamic>(
            storedProcedures: "dbo.usp_Companies_Select",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertCompany(CompanyModel company) =>
        _db.SaveData(storedProcedures: "dbo.usp_Companies_Insert", new { company.Name, company.VATID, company.Street, company.Building, company.City, company.PostalCode, company.Country, company.CountryCode, company.ContactPerson, company.ContactPersonMobile, company.ContactPersonEmail, company.CompanyTypeId });

    public Task UpdateCompany(CompanyModel company) =>
        _db.SaveData(storedProcedures: "dbo.usp_Companies_Update", new { company.Id, company.Name, company.VATID, company.Street, company.Building, company.City, company.PostalCode, company.Country, company.CountryCode, company.ContactPerson, company.ContactPersonMobile, company.ContactPersonEmail, company.CompanyTypeId });

    public Task DeleteCompany(int id) =>
        _db.SaveData(storedProcedures: "dbo.usp_Companies_Delete", new { Id = id });

}
