using BackOfficeAPP_Application;
using BackOfficeApp_Domain.Entities.ITWarehouse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeApp_Application.CQRS.ITWarehouse.CategoryType.Queries;

internal class GetAllCategoryTypeQueryHandler : IRequestHandler<GetAllCategoryTypeQuery, List<CategoryTypeVM>>
{
    private readonly ISqlDataAccess _db;
    public GetAllCategoryTypeQueryHandler(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<List<CategoryTypeVM>> Handle(GetAllCategoryTypeQuery request, CancellationToken cancellationToken) 
    {
        List<CategoryTypeVM> result = new List<CategoryTypeVM>();
        var results = await _db.LoadData<CategoryTypeModel,
            dynamic>(storedProcedures: "dbo.usp_CategoryTypes_Select_All",
                new { });

        foreach (var res in results)
        {
            var item = new CategoryTypeVM();
            item.Id = res.Id;
            item.Name = res.Name;
            result.Add(item);
        }

        return result;

    }
}
