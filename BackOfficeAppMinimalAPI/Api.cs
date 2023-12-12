using BackOfficeApp_Application.CQRS.ITWarehouse.Category.Commands;
using BackOfficeApp_Application.CQRS.ITWarehouse.Category.Queries;
using BackOfficeApp_Application.CQRS.ITWarehouse.CategoryType.Queries;
using BackOfficeApp_Application.Interfaces.ITWarehouse;
using BackOfficeApp_Domain.Entities.ITWarehouse;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using System.Runtime.CompilerServices;


namespace BackOfficeAppMinimalAPI;

public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        ////Users Endpoints
        app.MapGet("/API/Users", GetUsers);
        app.MapGet("/API/Users/{id}", GetUser);
        app.MapPost("/API/Users", InsertUser);
        app.MapPut("/API/Users", UpdateUser);
        app.MapDelete("/API/Users", DeleteUser);
       
        ////CategoryType Endpoints
        
        app.MapGet("/API/CategoryTypes", async (IMediator mediator) =>
            await mediator.Send(new GetAllCategoryTypeQuery()) is var res ? Results.Ok(res):Results.NotFound());
        
        app.MapGet("/API/CategoryTypes/{id}", async (IMediator mediator, int id) =>
            await mediator.Send(new GetByIdCategoryTypeQuery(id)) is var res ? Results.Ok(res):Results.NotFound());

        app.MapPost("/API/CategoryTypes", InsertCategoryType);

        app.MapPut("/API/CategoryTypes", UpdateCategoryType);
        app.MapDelete("/API/CategoryTypes", DeleteCategoryType);
        ////Categories Endpoints
        app.MapGet("/API/Categories", GetCategories);
        app.MapGet("/API/Categories/{id}", GetCategory);
        app.MapPost("/API/Categories", async (IMediator mediator) =>
            await mediator.Send(new InsertCategoryCommand()) is var res ? Results.Ok(res) : Results.NotFound());

        //app.MapPost("/API/Categories", InsertCategory);
        app.MapPut("/API/Categories", UpdateCategory);
        app.MapDelete("/API/Categories", DeleteCategory);
        ////Companies Endpoints
        app.MapGet("/API/Companies", GetCompanies);
        app.MapGet("/API/Companies/{id}", GetCompany);
        app.MapPost("/API/Companies", InsertCompany);
        app.MapPut("/API/Companies", UpdateCompany);
        app.MapDelete("/API/Companies", DeleteCompany);
        ////InvoiceItems Endpoints
        app.MapGet("/API/InvoiceItems", GetInvoiceItems);
        app.MapGet("/API/InvoiceItems/{id}", GetInvoiceItem);
        app.MapPost("/API/InvoiceItems", InsertInvoiceItem);
        app.MapPut("/API/InvoiceItems", UpdateInvoiceItem);
        app.MapDelete("/API/InvoiceItems", DeleteInvoiceItem);
        ////Invoices Endpoints
        app.MapGet("/API/Invoices", GetInvoices);
        app.MapGet("/API/Invoices/{id}", GetInvoice);
        app.MapPost("/API/Invoices", InsertInvoice);
        app.MapPut("/API/Invoices", UpdateInvoice);
        app.MapDelete("/API/Invoices", DeleteInvoice);
        ////Units Endpoints
        app.MapGet("/API/Units", GetUnits);
        app.MapGet("/API/Units/{id}", GetUnit);
        app.MapPost("/API/Units", InsertUnit);
        app.MapPut("/API/Units", UpdateUnit);
        app.MapDelete("/API/Units", DeleteUnit);
        ////CompanyType Endpoints
        app.MapGet("/API/CompanyTypes", GetCompanyTypes);
        app.MapGet("/API/CompanyTypes/{id}", GetCompanyType);
        app.MapPost("/API/CompanyTypes", InsertCompanyType);
        app.MapPut("/API/CompanyTypes", UpdateCompanyType);
        app.MapDelete("/API/CompanyTypes", DeleteCompanyType);
        ////Currency Endpoints
        app.MapGet("/API/Currencies", GetCurrencies);
        app.MapGet("/API/Currencies/{id}", GetCurrency);
        app.MapPost("/API/Currencies", InsertCurrency);
        app.MapPut("/API/Currencies", UpdateCurrency);
        app.MapDelete("/API/Currencies", DeleteCurrency);
        ////Item Endpoints
        app.MapGet("/API/Items", GetItems);
        app.MapGet("/API/Items/{id}", GetItem);
        app.MapPost("/API/Items", InsertItem);
        app.MapPut("/API/Items", UpdateItem);
        app.MapDelete("/API/Items", DeleteItem);
        ////Item_Note Endpoints
        app.MapGet("/API/Item_Notes", GetItem_Notes);
        app.MapGet("/API/Item_Notes/{id}", GetItem_Note);
        app.MapPost("/API/Item_Notes", InsertItem_Note);
        app.MapPut("/API/Item_Notes", UpdateItem_Note);
        app.MapDelete("/API/Item_Notes", DeleteItem_Note);
        ////Note Endpoints
        app.MapGet("/API/Notes", GetNotes);
        app.MapGet("/API/Notes/{id}", GetNote);
        app.MapPost("/API/Notes", InsertNote);
        app.MapPut("/API/Notes", UpdateNote);
        app.MapDelete("/API/Notes", DeleteNote);
        ////Part Endpoints
        app.MapGet("/API/Parts", GetParts);
        app.MapGet("/API/Parts/{id}", GetPart);
        app.MapPost("/API/Parts", InsertPart);
        app.MapPut("/API/Parts", UpdatePart);
        app.MapDelete("/API/Parts", DeletePart);
        ////State Endpoints
        app.MapGet("/API/States", GetStates);
        app.MapGet("/API/States/{id}", GetState);
        app.MapPost("/API/States", InsertState);
        app.MapPut("/API/States", UpdateState);
        app.MapDelete("/API/States", DeleteState);
        ////Warehouse Endpoints
        app.MapGet("/API/Warehouses", GetWarehouses);
        app.MapGet("/API/Warehouses/{id}", GetWarehouse);
        app.MapPost("/API/Warehouses", InsertWarehouse);
        app.MapPut("/API/Warehouses", UpdateWarehouse);
        app.MapDelete("/API/Warehouses", DeleteWarehouse);

    }
    /////////////////////////////////////////////////////
    /// Users Methods
    /////////////////////////////////////////////////////
    private static async Task<IResult> GetUsers(IUserData data)
    {
        try
        {
            Console.WriteLine(Results.Ok(await data.GetUsers()));
            //Console.ReadLine();
            return Results.Ok(await data.GetUsers());

        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> GetUser(int id, IUserData data)
    {
        try
        {
            var results = await data.GetUser(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> InsertUser(UserModel item, IUserData data)
    {
        try
        {
            await data.InsertUser(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateUser(UserModel item, IUserData data)
    {
        try
        {
            await data.UpdateUser(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteUser(int id, IUserData data)
    {
        try
        {
            await data.DeleteUser(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    /////////////////////////////////////////////////////
    /// CategoryType Methods
    /////////////////////////////////////////////////////
    private static async Task<IResult> GetCategoryTypes(ICategoryTypeData data)
    {
        try
        {
            return Results.Ok(await data.GetCategoryTypes());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> GetCategoryType(int id, ICategoryTypeData data)
    {
        try
        {
            var results = await data.GetCategoryType(id);
            if (results == null)
                return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> InsertCategoryType(CategoryTypeModel item, ICategoryTypeData data)
    {
        try
        {
            await data.InsertCategoryType(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateCategoryType(CategoryTypeModel item, ICategoryTypeData data)
    {
        try
        {
            await data.UpdateCategoryType(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteCategoryType(int id, ICategoryTypeData data)
    {
        try
        {
            await data.DeleteCategoryType(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    /////////////////////////////////////////////////////
    /// Categories Methods
    /////////////////////////////////////////////////////
    private static async Task<IResult> GetCategories(ICategoryData data)
    {
        try
        {
            return Results.Ok(await data.GetCategories());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> GetCategory(int id, ICategoryData data)
    {
        try
        {
            var results = await data.GetCategory(id);
            if (results == null)
                return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> InsertCategory(CategoryModel item, ICategoryData data)
    {
        try
        {
            await data.InsertCategory(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateCategory(CategoryModel item, ICategoryData data)
    {
        try
        {
            await data.UpdateCategory(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteCategory(int id, ICategoryData data)
    {
        try
        {
            await data.DeleteCategory(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }


    /////////////////////////////////////////////////////
    /// Companies Methods
    /////////////////////////////////////////////////////
    private static async Task<IResult> GetCompanies(ICompanyData data)
    {
        try
        {
            return Results.Ok(await data.GetCompanies());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> GetCompany(int id, ICompanyData data)
    {
        try
        {
            var results = await data.GetCompany(id);
            if (results == null)
                return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> InsertCompany(CompanyModel item, ICompanyData data)
    {
        try
        {
            await data.InsertCompany(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateCompany(CompanyModel item, ICompanyData data)
    {
        try
        {
            await data.UpdateCompany(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteCompany(int id, ICompanyData data)
    {
        try
        {
            await data.DeleteCompany(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    /////////////////////////////////////////////////////
    /// InvoiceItem Methods
    /////////////////////////////////////////////////////
    private static async Task<IResult> GetInvoiceItems(IInvoiceItemData data)
    {
        try
        {
            return Results.Ok(await data.GetInvoiceItems());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> GetInvoiceItem(int id, IInvoiceItemData data)
    {
        try
        {
            var results = await data.GetInvoiceItem(id);
            if (results == null)
                return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> InsertInvoiceItem(InvoiceItemModel item, IInvoiceItemData data)
    {
        try
        {
            await data.InsertInvoiceItem(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateInvoiceItem(InvoiceItemModel item, IInvoiceItemData data)
    {
        try
        {
            await data.UpdateInvoiceItem(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteInvoiceItem(int id, IInvoiceItemData data)
    {
        try
        {
            await data.DeleteInvoiceItem(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    /////////////////////////////////////////////////////
    /// Invoice Methods
    /////////////////////////////////////////////////////
    private static async Task<IResult> GetInvoices(IInvoiceData data)
    {
        try
        {
            return Results.Ok(await data.GetInvoices());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> GetInvoice(int id, IInvoiceData data)
    {
        try
        {
            var results = await data.GetInvoice(id);
            if (results == null)
                return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> InsertInvoice(InvoiceModel item, IInvoiceData data)
    {
        try
        {
            await data.InsertInvoice(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateInvoice(InvoiceModel item, IInvoiceData data)
    {
        try
        {
            await data.UpdateInvoice(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteInvoice(int id, IInvoiceData data)
    {
        try
        {
            await data.DeleteInvoice(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }


    /////////////////////////////////////////////////////
    /// Unit Methods
    /////////////////////////////////////////////////////
    private static async Task<IResult> GetUnits(IUnitData data)
    {
        try
        {
            return Results.Ok(await data.GetUnits());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> GetUnit(int id, IUnitData data)
    {
        try
        {
            var results = await data.GetUnit(id);
            if (results == null)
                return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> InsertUnit(UnitModel item, IUnitData data)
    {
        try
        {
            await data.InsertUnit(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateUnit(UnitModel item, IUnitData data)
    {
        try
        {
            await data.UpdateUnit(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteUnit(int id, IUnitData data)
    {
        try
        {
            await data.DeleteUnit(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    /////////////////////////////////////////////////////
    /// CompanyType Methods
    /////////////////////////////////////////////////////
    private static async Task<IResult> GetCompanyTypes(ICompanyTypeData data)
    {
        try
        {
            return Results.Ok(await data.GetCompanyTypes());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> GetCompanyType(int id, ICompanyTypeData data)
    {
        try
        {
            var results = await data.GetCompanyType(id);
            if (results == null)
                return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> InsertCompanyType(CompanyTypeModel item, ICompanyTypeData data)
    {
        try
        {
            await data.InsertCompanyType(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateCompanyType(CompanyTypeModel item, ICompanyTypeData data)
    {
        try
        {
            await data.UpdateCompanyType(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteCompanyType(int id, ICompanyTypeData data)
    {
        try
        {
            await data.DeleteCompanyType(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    /////////////////////////////////////////////////////
    /// Currency Methods
    /////////////////////////////////////////////////////
    private static async Task<IResult> GetCurrencies(ICurrencyData data)
    {
        try
        {
            return Results.Ok(await data.GetCurrencies());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> GetCurrency(int id, ICurrencyData data)
    {
        try
        {
            var results = await data.GetCurrency(id);
            if (results == null)
                return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> InsertCurrency(CurrencyModel item, ICurrencyData data)
    {
        try
        {
            await data.InsertCurrency(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateCurrency(CurrencyModel item, ICurrencyData data)
    {
        try
        {
            await data.UpdateCurrency(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteCurrency(int id, ICurrencyData data)
    {
        try
        {
            await data.DeleteCurrency(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    /////////////////////////////////////////////////////
    /// Item Methods
    /////////////////////////////////////////////////////
    private static async Task<IResult> GetItems(IItemData data)
    {
        try
        {
            return Results.Ok(await data.GetItems());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> GetItem(int id, IItemData data)
    {
        try
        {
            var results = await data.GetItem(id);
            if (results == null)
                return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> InsertItem(ItemModel item, IItemData data)
    {
        try
        {
            await data.InsertItem(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateItem(ItemModel item, IItemData data)
    {
        try
        {
            await data.UpdateItem(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteItem(int id, IItemData data)
    {
        try
        {
            await data.DeleteItem(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    /////////////////////////////////////////////////////
    /// Notes Methods
    /////////////////////////////////////////////////////
    private static async Task<IResult> GetNotes(INoteData data)
    {
        try
        {
            return Results.Ok(await data.GetNotes());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> GetNote(int id, INoteData data)
    {
        try
        {
            var results = await data.GetNote(id);
            if (results == null)
                return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> InsertNote(NoteModel item, INoteData data)
    {
        try
        {
            await data.InsertNote(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateNote(NoteModel item, INoteData data)
    {
        try
        {
            await data.UpdateNote(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteNote(int id, INoteData data)
    {
        try
        {
            await data.DeleteNote(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    /////////////////////////////////////////////////////
    /// Item_Notes Methods
    /////////////////////////////////////////////////////
    private static async Task<IResult> GetItem_Notes(IItem_NoteData data)
    {
        try
        {
            return Results.Ok(await data.GetItems_Notes());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> GetItem_Note(int id, IItem_NoteData data)
    {
        try
        {
            var results = await data.GetItem_Note(id);
            if (results == null)
                return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> InsertItem_Note(Item_NoteModel item, IItem_NoteData data)
    {
        try
        {
            await data.InsertItem_Note(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateItem_Note(Item_NoteModel item, IItem_NoteData data)
    {
        try
        {
            await data.UpdateItem_Note(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteItem_Note(int id, IItem_NoteData data)
    {
        try
        {
            await data.DeleteItem_Note(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    /////////////////////////////////////////////////////
    /// Parts Methods
    /////////////////////////////////////////////////////
    private static async Task<IResult> GetParts(IPartData data)
    {
        try
        {
            return Results.Ok(await data.GetParts());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> GetPart(int id, IPartData data)
    {
        try
        {
            var results = await data.GetPart(id);
            if (results == null)
                return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> InsertPart(PartModel item, IPartData data)
    {
        try
        {
            await data.InsertPart(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdatePart(PartModel item, IPartData data)
    {
        try
        {
            await data.UpdatePart(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeletePart(int id, IPartData data)
    {
        try
        {
            await data.DeletePart(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    /////////////////////////////////////////////////////
    /// States Methods
    /////////////////////////////////////////////////////
    private static async Task<IResult> GetStates(IStateData data)
    {
        try
        {
            return Results.Ok(await data.GetStates());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> GetState(int id, IStateData data)
    {
        try
        {
            var results = await data.GetState(id);
            if (results == null)
                return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> InsertState(StateModel item, IStateData data)
    {
        try
        {
            await data.InsertState(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateState(StateModel item, IStateData data)
    {
        try
        {
            await data.UpdateState(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteState(int id, IStateData data)
    {
        try
        {
            await data.DeleteState(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    /////////////////////////////////////////////////////
    /// Warehouses Methods
    /////////////////////////////////////////////////////
    private static async Task<IResult> GetWarehouses(IWarehouseData data)
    {
        try
        {
            return Results.Ok(await data.GetWarehouses());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> GetWarehouse(int id, IWarehouseData data)
    {
        try
        {
            var results = await data.GetWarehouse(id);
            if (results == null)
                return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> InsertWarehouse(WarehouseModel item, IWarehouseData data)
    {
        try
        {
            await data.InsertWarehouse(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateWarehouse(WarehouseModel item, IWarehouseData data)
    {
        try
        {
            await data.UpdateWarehouse(item);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteWarehouse(int id, IWarehouseData data)
    {
        try
        {
            await data.DeleteWarehouse(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

}

