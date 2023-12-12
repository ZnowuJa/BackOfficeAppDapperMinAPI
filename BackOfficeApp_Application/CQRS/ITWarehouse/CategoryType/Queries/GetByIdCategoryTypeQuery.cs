using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeApp_Application.CQRS.ITWarehouse.CategoryType.Queries
{
    public class GetByIdCategoryTypeQuery : IRequest<CategoryTypeVM>
    {
        public int Id { get; set; }

        public GetByIdCategoryTypeQuery(int id)
        {
            Id = id;
        }
    }
}
