using System.ComponentModel.DataAnnotations.Schema;
using Domain.Contracts;

namespace Domain.Entities;

public class Admin: BaseEntity
{
    [Column("AdminId")]
    public  Guid Id { get; set; }
    public string Username {get;set;}
    public string Name   {get;set;}
    public string Email  {get;set;}
    public string Password {get;set;}
}