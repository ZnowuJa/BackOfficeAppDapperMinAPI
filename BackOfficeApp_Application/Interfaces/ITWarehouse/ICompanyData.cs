using BackOfficeApp_Domain.Entities.ITWarehouse;

namespace BackOfficeApp_Application.Interfaces.ITWarehouse;

public interface ICompanyData
{
    Task DeleteCompany(int id);
    Task<IEnumerable<CompanyModel>> GetCompanies();
    Task<CompanyModel?> GetCompany(int id);
    Task InsertCompany(CompanyModel company);
    Task UpdateCompany(CompanyModel company);
}