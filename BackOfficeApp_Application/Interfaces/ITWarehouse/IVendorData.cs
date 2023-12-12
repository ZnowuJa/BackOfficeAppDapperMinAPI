using BackOfficeApp_Domain.Entities.ITWarehouse;

namespace BackOfficeApp_Application.Interfaces.ITWarehouse;

public interface IVendorData
{
    Task DeleteVendor(int id);
    Task<VendorModel?> GetVendor(int id);
    Task<IEnumerable<VendorModel>> GetVendors();
    Task InsertVendor(VendorModel item);
    Task UpdateVendor(VendorModel item);
}
