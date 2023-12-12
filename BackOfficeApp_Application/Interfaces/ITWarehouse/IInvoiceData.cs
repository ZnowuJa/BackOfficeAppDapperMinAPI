using BackOfficeApp_Domain.Entities.ITWarehouse;

namespace BackOfficeApp_Application.Interfaces.ITWarehouse;

public interface IInvoiceData
{
    Task DeleteInvoice(int id);
    Task<InvoiceModel?> GetInvoice(int id);
    Task<IEnumerable<InvoiceModel>> GetInvoices();
    Task InsertInvoice(InvoiceModel data);
    Task UpdateInvoice(InvoiceModel data);
}
