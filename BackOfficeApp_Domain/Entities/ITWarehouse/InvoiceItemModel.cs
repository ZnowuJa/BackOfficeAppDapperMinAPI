using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeApp_Domain.Entities.ITWarehouse;
public class InvoiceItemModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Qty { get; set; }
    public int UnitId { get; set; }
    public string UnitShortName { get; set; }
    public int InvoiceId { get; set; }
    public decimal UnitNetPrice { get; set; }

}

