using BackOfficeApp_Domain.Entities.ITWarehouse;

namespace BackOfficeApp_Application.Interfaces.ITWarehouse;

public interface ICompanyTypeData
{
    Task DeleteCompanyType(int id);
    Task<CompanyTypeModel?> GetCompanyType(int id);
    Task<IEnumerable<CompanyTypeModel>> GetCompanyTypes();
    Task InsertCompanyType(CompanyTypeModel companyType);
    Task UpdateCompanyType(CompanyTypeModel companyType);
}