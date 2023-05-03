using Microsoft.EntityFrameworkCore;

namespace MinimalApi.Db;

public class AddressBookDb : DbContext
{
    
    public DbSet<Person> People { get; set; }
    public DbSet<Address> Addresses { get; set; }

    public AddressBookDb(DbContextOptions<AddressBookDb> options) : base(options)
    {
    }
}