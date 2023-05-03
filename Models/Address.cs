using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

[PrimaryKey("Id")]
public class Address
{
    public int Id { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
}