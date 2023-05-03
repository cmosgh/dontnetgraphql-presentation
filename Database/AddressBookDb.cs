using Microsoft.EntityFrameworkCore;

namespace MinimalApi.Database;

public class AddressBookDb : DbContext
{
    public AddressBookDb(DbContextOptions<AddressBookDb> options) : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
}