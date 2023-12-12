
namespace BackOfficeAPP_Application;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadData<T, U>(string storedProcedures, U parameters, string connectionId = "Default");
    Task SaveData<T>(string storedProcedures, T parameters, string connectionId = "Default");
    Task<long> SaveDataRes<T>(string storedProcedures, T parameters, string connectionId = "Default");
}
