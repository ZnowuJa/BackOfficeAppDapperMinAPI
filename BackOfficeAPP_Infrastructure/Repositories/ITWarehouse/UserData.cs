using BackOfficeApp_Application.Interfaces.ITWarehouse;
using BackOfficeApp_Domain.Entities.ITWarehouse;
using BackOfficeAPP_Application;

namespace BackOfficeAPP_Infrastructure.Repositories.ITWarehouse;

public class UserData : IUserData
{
    private readonly ISqlDataAccess _db;
    public UserData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<UserModel>> GetUsers() =>
        _db.LoadData<UserModel, dynamic>(storedProcedures: "dbo.usp_Users_Select_All", new { });

    public async Task<UserModel?> GetUser(int id)
    {
        var results = await _db.LoadData<UserModel, dynamic>(
            storedProcedures: "dbo.usp_Users_Select",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertUser(UserModel user) =>
        _db.SaveData(storedProcedures: "dbo.usp_Users_Insert", new { user.FirstName, user.LastName, user.ADLogonName, user.ThirdPartyId, user.Email, user.MobileNumber, user.PhoneNumber });

    public Task UpdateUser(UserModel user) =>
        _db.SaveData(storedProcedures: "dbo.usp_Users_Update", new { user.Id, user.FirstName, user.LastName, user.ADLogonName, user.ThirdPartyId, user.Email, user.MobileNumber, user.PhoneNumber });

    public Task DeleteUser(int id) =>
        _db.SaveData(storedProcedures: "dbo.usp_Users_Delete", new { Id = id });

}
