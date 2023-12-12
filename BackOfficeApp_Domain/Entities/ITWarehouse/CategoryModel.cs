
namespace BackOfficeApp_Domain.Entities.ITWarehouse;

public class CategoryModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Prefix { get; set; }
    public int CategoryTypeId { get; set; }
    public bool? isDeactivated { get; set; }
    public DateTime? isDeactivatedDate { get; set; }
}
