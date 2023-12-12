using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeApp_Domain.Entities.ITWarehouse;

public class UserModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string ADLogonName { get; set; }
    public string ThirdPartyId { get; set; }
    public string MobileNumber { get; set; }
    public string PhoneNumber { get; set; }
    public bool? isDeactivated { get; set; }
    public DateTime? isActivatedDate { get; set; }


}
