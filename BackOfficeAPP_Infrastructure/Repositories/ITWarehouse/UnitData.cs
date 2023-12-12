using BackOfficeApp_Application.Interfaces.ITWarehouse;
using BackOfficeAPP_Application;
using BackOfficeApp_Domain.Entities.ITWarehouse;



namespace BackOfficeAPP_Infrastructure.Repositories.ITWarehouse;


public class UnitData : IUnitData
{

    private readonly ISqlDataAccess _db;
    public UnitData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<UnitModel>> GetUnits() =>
        _db.LoadData<UnitModel,
            dynamic>(storedProcedures: "dbo.usp_Units_Select_All",
                new { });

    public async Task<UnitModel?> GetUnit(int id)
    {
        var results = await _db.LoadData<UnitModel, dynamic>(
            storedProcedures: "dbo.usp_Units_Select",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertUnit(UnitModel dataModel) =>
        _db.SaveData(storedProcedures: "dbo.usp_Units_Insert", new { dataModel.Name, dataModel.UnitShortName });

    public Task UpdateUnit(UnitModel dataModel) =>
        _db.SaveData(storedProcedures: "usp_Units_Update", new { dataModel.Id, dataModel.Name, dataModel.UnitShortName });

    public Task DeleteUnit(int id) =>
        _db.SaveData(storedProcedures: "dbo.usp_Units_Delete", new { Id = id });
}


