using BackOfficeApp_Application.Interfaces.ITWarehouse;
using BackOfficeAPP_Application;
using BackOfficeApp_Domain.Entities.ITWarehouse;
using BackOfficeAPP_Infrastructure.DbAccess;


namespace BackOfficeAPP_Infrastructure.Repositories.ITWarehouse;

public class CurrencyData : ICurrencyData
{
    private readonly ISqlDataAccess _db;
    public CurrencyData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<CurrencyModel>> GetCurrencies() =>
        _db.LoadData<CurrencyModel,
            dynamic>(storedProcedures: "dbo.usp_Currencies_Select_All",
                new { });

    public async Task<CurrencyModel?> GetCurrency(int id)
    {
        var results = await _db.LoadData<CurrencyModel, dynamic>(
            storedProcedures: "dbo.usp_Currencies_Select",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertCurrency(CurrencyModel currency) =>
        _db.SaveData(storedProcedures: "dbo.usp_Currencies_Insert", new { currency.Name });

    public Task UpdateCurrency(CurrencyModel currency) =>
        _db.SaveData(storedProcedures: "usp_Currencies_Update", new { currency.Id, currency.Name });

    public Task DeleteCurrency(int id) =>
        _db.SaveData(storedProcedures: "dbo.usp_Currencies_Delete", new { Id = id });
}
