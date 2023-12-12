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

public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, CategoryVM>
{
    private readonly ISqlDataAccess _db;
    private IMapper _mapper;
    public GetByIdCategoryQueryHandler(ISqlDataAccess db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<CategoryVM> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
    {   CategoryVM categoryVm = new CategoryVM();

        var result = await _db.LoadData<CategoryModel, dynamic>(
            storedProcedures: "dbo.usp_Categories_Select",
            new { request.Id }) ?? throw new ArgumentNullException(nameof(CategoryModel));

        categoryVm = _mapper.Map<CategoryVM>(result);

        var categoryName = await _db.LoadData<CategoryModel, dynamic>(
            storedProcedures: "dbo.usp_CategoryTypes_Select",
            new { Id = result.First().CategoryTypeId });
        
        categoryVm.CategoryName = categoryName.First().Name ?? string.Empty;
        
        return categoryVm;
    }
}
