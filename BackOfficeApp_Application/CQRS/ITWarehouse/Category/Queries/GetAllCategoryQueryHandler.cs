using AutoMapper;
using BackOfficeAPP_Application;
using BackOfficeApp_Domain.Entities.ITWarehouse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeApp_Application.CQRS.ITWarehouse.Category.Queries;

public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryVM>>
{
    private readonly ISqlDataAccess _db;
    private IMapper _mapper;
    public GetAllCategoryQueryHandler(ISqlDataAccess db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<List<CategoryVM>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        List<CategoryVM> result = new List<CategoryVM>();

        var queryResults = await _db.LoadData<CategoryModel,
            dynamic>(storedProcedures: "dbo.usp_Categories_Select_All",
                new { });
        foreach (var res in queryResults)
        {
            var categoryVm = _mapper.Map<CategoryVM>(res);
            var categoryName = await _db.LoadData<CategoryModel, dynamic>(
                storedProcedures: "dbo.usp_CategoryTypes_Select",
                new { Id = res.CategoryTypeId });

            categoryVm.CategoryName = categoryName.First().Name ?? string.Empty;

            result.Add(categoryVm);
            
        }

        return result;
    }
}
