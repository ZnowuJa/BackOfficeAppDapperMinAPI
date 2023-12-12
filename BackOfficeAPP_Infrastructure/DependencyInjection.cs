using BackOfficeApp_Application.Interfaces.ITWarehouse;
using BackOfficeAPP_Application;
using BackOfficeAPP_Infrastructure.DbAccess;
using BackOfficeAPP_Infrastructure.Repositories.ITWarehouse;
using Microsoft.Extensions.DependencyInjection;


namespace BackOfficeAPP_Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<ISqlDataAccess, SqlDataAccess>();
        services.AddTransient<IUserData, UserData>();
        services.AddTransient<ICategoryTypeData, CategoryTypeData>();
        services.AddTransient<ICategoryData, CategoryData>();
        services.AddTransient<ICompanyData, CompanyData>();
        services.AddTransient<IInvoiceItemData, InvoiceItemData>();
        services.AddTransient<IInvoiceData, InvoiceData>();
        services.AddTransient<IUnitData, UnitData>();
        services.AddTransient<ICompanyTypeData, CompanyTypeData>();
        services.AddTransient<ICurrencyData, CurrencyData>();
        services.AddTransient<IItemData, ItemData>();
        services.AddTransient<IItem_NoteData, Item_NoteData>();
        services.AddTransient<INoteData, NoteData>();
        services.AddTransient<IPartData, PartData>();
        services.AddTransient<IStateData, StateData>();
        services.AddTransient<IVendorData, VendorData>();
        services.AddTransient<IWarehouseData, WarehouseData>();
    }
}
