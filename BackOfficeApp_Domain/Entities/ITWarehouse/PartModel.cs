using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeApp_Domain.Entities.ITWarehouse;

public class PartModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryID { get; set; }
    public int VendorId { get; set; }
    public string Description { get; set; }
    public string Photo { get; set; }
    public int WarrantyPeriod { get; set; }
    public bool isCurrentlyOrderable { get; set; }
    public bool isDeactivated { get; set; }
    public DateTime isDeactivatedDate { get; set; }

}