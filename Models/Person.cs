
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

[PrimaryKey("Id")]
public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    
    public Address? Address { get; set; }
}