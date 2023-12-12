using BackOfficeAPP_Application;
using BackOfficeApp_Domain.Entities.ITWarehouse;
using BackOfficeAPP_Infrastructure.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeAPP_Infrastructure.Repositories.ITWarehouse
{
    internal class _GenericData
    {
        private readonly ISqlDataAccess _db;
        public _GenericData(ISqlDataAccess db)
        {
            _db = db;
        }
        public Task<IEnumerable<CategoryModel>> GetCategories() =>
            _db.LoadData<CategoryModel,
                dynamic>(storedProcedures: "dbo.usp_Categories_Select_All",
                    new { });

        public async Task<CategoryModel?> GetCategory(int id)
        {
            var results = await _db.LoadData<CategoryModel, dynamic>(
                storedProcedures: "dbo.usp_Categories_Select",
                new { Id = id });
            return results.FirstOrDefault();
        }

        public Task InsertCategory(CategoryModel category) =>
            _db.SaveData(storedProcedures: "dbo.usp_Categories_Insert", new { category.Name, category.Prefix, category.CategoryTypeId });

        public Task UpdateCategory(CategoryModel category) =>
            _db.SaveData(storedProcedures: "usp_Categories_Update", new { category.Id, category.Name, category.Prefix, category.CategoryTypeId });

        public Task DeleteCategory(int id) =>
            _db.SaveData(storedProcedures: "dbo.usp_Categories_Delete", new { Id = id });
    }
}
