using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeApp_Application.CQRS.ITWarehouse.Company.Queries;

public class CompanyVM
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string VATID { get; set; }
    public string? Street { get; set; }
    public string? Building { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public string? CountryCode { get; set; }
    public string? ContactPerson { get; set; }
    public string? ContactPersonMobile { get; set; }
    public string? ContactPersonEmail { get; set; }
    public string? CompanyTypeId { get; set; }
}
