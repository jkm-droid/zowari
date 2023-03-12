using System.ComponentModel.DataAnnotations.Schema;
using Domain.Contracts;

namespace Domain.Entities;

public class Country: BaseEntity
{
    [Column("CountryId")]
    public Guid Id { get; set; }
    public string Iso { get; set; }
    public string Name { get; set; }
    public string NiceName { get; set; }
    public string Iso3 { get; set; }
    public int NumCode { get; set; }
    public int PhoneCode { get; set; }
}