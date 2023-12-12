using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeApp_Application.CQRS.ITWarehouse.Category.Queries;

public class GetAllCategoryQuery : IRequest<List<CategoryVM>>
{
    
}
