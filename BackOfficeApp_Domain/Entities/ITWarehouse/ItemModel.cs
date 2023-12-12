using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeApp_Domain.Entities.ITWarehouse;

public class ItemModel
{
    public int Id { get; set; }
    public int PartId { get; set; }
    public int StateId { get; set; }
    public string AssetTagNumber { get; set; }
    public string SerialNumber { get; set; }
    public DateTime LastSeen { get; set; }
    public int InvoiceItemId { get; set; }
    public int InvoiceId { get; set; }
    public int UserId { get; set; }
    public int WarehouseId { get; set; }
    public bool isDeactivated { get; set; }
    public DateTime isDeactivatedDate { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; }
    public DateTime PurchaseDate { get; set; }

   
}
