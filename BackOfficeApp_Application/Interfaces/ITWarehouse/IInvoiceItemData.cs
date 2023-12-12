using BackOfficeApp_Domain.Entities.ITWarehouse;

namespace BackOfficeApp_Application.Interfaces.ITWarehouse;

public interface IInvoiceItemData
{
    Task DeleteInvoiceItem(int id);
    Task<InvoiceItemModel?> GetInvoiceItem(int id);
    Task<IEnumerable<InvoiceItemModel>> GetInvoiceItems();
    Task InsertInvoiceItem(InvoiceItemModel dataModel);
    Task UpdateInvoiceItem(InvoiceItemModel dataModel);
}