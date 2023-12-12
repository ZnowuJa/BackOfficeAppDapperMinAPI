using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeApp_Domain.Entities.ITWarehouse;

public class InvoiceModel
{
    public int Id { get; set; }
    public string? Number { get; set; }
    public int SupplierId { get; set; }

    public DateTime Date {get; set;}
    public decimal TotalNet { get; set; }
    public int CompanyId { get; set; }


}