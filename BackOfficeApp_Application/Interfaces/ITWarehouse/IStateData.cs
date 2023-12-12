using BackOfficeApp_Domain.Entities.ITWarehouse;

namespace BackOfficeApp_Application.Interfaces.ITWarehouse;

public interface IStateData
{
    Task DeleteState(int id);
    Task<StateModel?> GetState(int id);
    Task<IEnumerable<StateModel>> GetStates();
    Task InsertState(StateModel item);
    Task UpdateState(StateModel item);
}
