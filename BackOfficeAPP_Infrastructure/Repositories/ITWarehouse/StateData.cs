using BackOfficeApp_Application.Interfaces.ITWarehouse;
using BackOfficeApp_Domain.Entities.ITWarehouse;
using BackOfficeAPP_Application;

namespace BackOfficeAPP_Infrastructure.Repositories.ITWarehouse;

public class StateData : IStateData
{
    private readonly ISqlDataAccess _db;
    public StateData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<StateModel>> GetStates() =>
        _db.LoadData<StateModel,
            dynamic>(storedProcedures: "dbo.usp_States_Select_All",
                new { });

    public async Task<StateModel?> GetState(int id)
    {
        var results = await _db.LoadData<StateModel, dynamic>(
            storedProcedures: "dbo.usp_States_Select",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertState(StateModel item) =>
        _db.SaveData(storedProcedures: "dbo.usp_States_Insert", new { item.Name, item.Description });

    public Task UpdateState(StateModel item) =>
        _db.SaveData(storedProcedures: "usp_States_Update", new { item.Id, item.Name, item.Description });

    public Task DeleteState(int id) =>
        _db.SaveData(storedProcedures: "dbo.usp_States_Delete", new { Id = id });
}
