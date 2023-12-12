using BackOfficeApp_Application.Interfaces.ITWarehouse;
using BackOfficeAPP_Application;
using BackOfficeApp_Domain.Entities.ITWarehouse;
using BackOfficeAPP_Infrastructure.DbAccess;


namespace BackOfficeAPP_Infrastructure.Repositories.ITWarehouse;

public class InvoiceItemData : IInvoiceItemData
{

    private readonly ISqlDataAccess _db;
    public InvoiceItemData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<InvoiceItemModel>> GetInvoiceItems() =>
        _db.LoadData<InvoiceItemModel,
            dynamic>(storedProcedures: "dbo.usp_InvoiceItems_Select_All",
                new { });

    public async Task<InvoiceItemModel?> GetInvoiceItem(int id)
    {
        var results = await _db.LoadData<InvoiceItemModel, dynamic>(
            storedProcedures: "dbo.usp_InvoiceItems_Select",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertInvoiceItem(InvoiceItemModel dataModel) =>
        _db.SaveData(storedProcedures: "dbo.usp_InvoiceItems_Insert", new { dataModel.Name, dataModel.Qty, dataModel.UnitId, dataModel.UnitShortName, dataModel.InvoiceId, dataModel.UnitNetPrice });

    public Task UpdateInvoiceItem(InvoiceItemModel dataModel) =>
        _db.SaveData(storedProcedures: "usp_InvoiceItems_Update", new { dataModel.Id, dataModel.Name, dataModel.Qty, dataModel.UnitId, dataModel.UnitShortName, dataModel.InvoiceId, dataModel.UnitNetPrice });

    public Task DeleteInvoiceItem(int id) =>
        _db.SaveData(storedProcedures: "dbo.usp_InvoiceItems_Delete", new { Id = id });
}
