using AutoMapper;
using BackOfficeApp_Application.Mappings;
using BackOfficeApp_Domain.Entities.ITWarehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeApp_Application.CQRS.ITWarehouse.Category.Queries;

public class CategoryVM : IMapFrom<CategoryModel>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Prefix { get; set; }
    public int CategoryTypeId { get; set; }
    public string? CategoryName { get; set; }
    public bool? isDeactivated { get; set; }
    public DateTime? isDeactivatedDate { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<CategoryModel, CategoryVM>()
            .ForMember(c => c.Id, map => map.MapFrom(src => src.Id))
            .ForMember(c => c.Name, map => map.MapFrom(src => src.Name))
            .ForMember(c => c.Prefix, map => map.MapFrom(src => src.Prefix))
            .ForMember(c => c.CategoryTypeId, map => map.MapFrom(src => src.CategoryTypeId))
            .ForMember(c => c.isDeactivated, map => map.MapFrom(src => src.isDeactivated))
            .ForMember(c => c.isDeactivatedDate, map => map.MapFrom(src => src.isDeactivatedDate))
            .ForMember(c => c.CategoryName, map => map.Ignore());

}
