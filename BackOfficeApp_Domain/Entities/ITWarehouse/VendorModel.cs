using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeApp_Domain.Entities.ITWarehouse;

public class VendorModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool isDeactivated { get; set; }
    public DateTime isDeactivatedDate { get; set; }

}
