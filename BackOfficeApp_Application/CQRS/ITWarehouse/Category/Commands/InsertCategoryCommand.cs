using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeApp_Application.CQRS.ITWarehouse.Category.Commands;
public class InsertCategoryCommand : IRequest<int>
{
    //public int Id { get; set; }
    public string Name { get; set; }
    public string? Prefix { get; set; }
    public int CategoryTypeId { get; set; }
    public string? CategoryName { get; set; }
    //public bool? isDeactivated { get; set; }
    //public DateTime? isDeactivatedDate { get; set; }
    //public InsertCategoryCommand(string name, string? prefix, int categoryTypeId)
    //{
    //    Name = name;
    //    Prefix = prefix;
    //    CategoryTypeId = categoryTypeId;
        
    //}
}
