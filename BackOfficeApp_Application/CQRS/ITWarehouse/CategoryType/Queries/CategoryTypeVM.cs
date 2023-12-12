using AutoMapper;
using BackOfficeApp_Application.Mappings;
using BackOfficeApp_Domain.Entities.ITWarehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeApp_Application.CQRS.ITWarehouse.CategoryType.Queries;

public class CategoryTypeVM : IMapFrom<CategoryTypeModel>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CategoryTypeModel, CategoryTypeVM>();
            //.ForMember(ct => ct.Id, map => map.MapFrom(src => src.Id))
            //.ForMember(ct => ct.Name, map => map.MapFrom(src => src.Name));
    }
}
