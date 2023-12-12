using BackOfficeAPP_Application;
using BackOfficeApp_Domain.Entities.ITWarehouse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeApp_Application.CQRS.ITWarehouse.CategoryType.Queries;
public class GetByIdCategoryTypeQueryHandler : IRequestHandler<GetByIdCategoryTypeQuery, CategoryTypeVM>
{
    private readonly ISqlDataAccess _db;

    public GetByIdCategoryTypeQueryHandler(ISqlDataAccess db)
    {
        _db = db;
    }
    
    public async Task<CategoryTypeVM> Handle(GetByIdCategoryTypeQuery request, CancellationToken cancellationToken)
    {
        var results = await _db.LoadData<CategoryTypeModel, dynamic>(
            storedProcedures: "dbo.usp_CategoryTypes_Select",
            new { request.Id });
        CategoryTypeVM categoryTypeVM = new CategoryTypeVM();
        categoryTypeVM.Id = results.First().Id;
        categoryTypeVM.Name = results.First().Name;

        return categoryTypeVM;
    }
}
