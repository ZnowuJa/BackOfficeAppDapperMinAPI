using BackOfficeApp_Application.CQRS.ITWarehouse.Category.Queries;
using BackOfficeApp_Application.Interfaces.ITWarehouse;
using BackOfficeAPP_Application;
using BackOfficeApp_Domain.Entities.ITWarehouse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeApp_Application.CQRS.ITWarehouse.Category.Commands;
internal class InsertCategoryCommandHandler : IRequestHandler<InsertCategoryCommand, int>
{
    private readonly ISqlDataAccess _db;
    //private 
    
    public InsertCategoryCommandHandler(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<int> Handle(InsertCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new CategoryVM 
        {
            Name = request.Name,
            Prefix = request.Prefix,
            CategoryTypeId = request.CategoryTypeId,
            CategoryName = request.CategoryName,
        };
        var id = _db.SaveDataRes(storedProcedures: "dbo.usp_Categories_Insert", category).Id;

        return id;
    }
}
