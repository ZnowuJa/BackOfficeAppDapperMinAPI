using BackOfficeApp_Domain.Entities.ITWarehouse;

namespace BackOfficeApp_Application.Interfaces.ITWarehouse;

public interface ICurrencyData
{
    Task DeleteCurrency(int id);
    Task<IEnumerable<CurrencyModel>> GetCurrencies();
    Task<CurrencyModel?> GetCurrency(int id);
    Task InsertCurrency(CurrencyModel currency);
    Task UpdateCurrency(CurrencyModel currency);
}
