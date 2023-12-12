using BackOfficeApp_Application.Interfaces.ITWarehouse;
using BackOfficeAPP_Application;
using BackOfficeApp_Domain.Entities.ITWarehouse;
using BackOfficeAPP_Infrastructure.DbAccess;


namespace BackOfficeAPP_Infrastructure.Repositories.ITWarehouse;

public class InvoiceData : IInvoiceData
{
    private readonly ISqlDataAccess _db;
    public InvoiceData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<InvoiceModel>> GetInvoices() =>
        _db.LoadData<InvoiceModel,
            dynamic>(storedProcedures: "dbo.usp_Invoices_Select_All",
                new { });

    public async Task<InvoiceModel?> GetInvoice(int id)
    {
        var results = await _db.LoadData<InvoiceModel, dynamic>(
            storedProcedures: "dbo.usp_Invoices_Select",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertInvoice(InvoiceModel data) =>
        _db.SaveData(storedProcedures: "dbo.usp_Invoices_Insert", new { data.TotalNet, data.Number, data.SupplierId, data.Date, data.CompanyId });

    public Task UpdateInvoice(InvoiceModel data) =>
        _db.SaveData(storedProcedures: "usp_Invoices_Update", new { data.Id, data.TotalNet, data.Number, data.SupplierId, data.Date, data.CompanyId });

    public Task DeleteInvoice(int id) =>
        _db.SaveData(storedProcedures: "dbo.usp_Invoices_Delete", new { Id = id });
}
