using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeApp_Application.CQRS.ITWarehouse.CategoryType.Commands;
public class InsertCategoryTypeCommand : IRequest<int>
{
    public string Name { get; set; }
    public InsertCategoryTypeCommand( string name)
    {
        Name = name;
    }

}
