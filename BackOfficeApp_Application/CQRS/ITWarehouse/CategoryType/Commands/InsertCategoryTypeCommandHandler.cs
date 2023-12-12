using BackOfficeAPP_Application;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeApp_Application.CQRS.ITWarehouse.CategoryType.Commands;
internal class InsertCategoryTypeCommandHandler : IRequestHandler<InsertCategoryTypeCommand, int>
{
    private readonly ISqlDataAccess _db;

    public InsertCategoryTypeCommandHandler(ISqlDataAccess db)
    {
        _db = db;
    }
    public async Task<int> Handle(InsertCategoryTypeCommand request, CancellationToken cancellationToken)
    {
        return _db.SaveDataRes(storedProcedures: "dbo.usp_CategoryTypes_Insert", new { request.Name }).Id;
    }
}
