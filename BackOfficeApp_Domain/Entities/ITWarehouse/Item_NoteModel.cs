using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeApp_Domain.Entities.ITWarehouse;

public class Item_NoteModel
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public int NoteId { get; set; }
}
