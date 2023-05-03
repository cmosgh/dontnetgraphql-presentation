using Faker;
using GraphQL;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Db;

// create a base data array with 10 persons that I can filter in query later

public class Query
{
    static IEnumerable<Person> _data = Enumerable.Range(1, 10).Select(i => new Person
    {
        Id = i,
        Name = Faker.Name.FullName(),
        Address = new Address
        {
            Street = Faker.Address.StreetAddress(),
            City = Faker.Address.City(),
            Number = Faker.StringFaker.AlphaNumeric(2)
        }
    });

    [GraphQLMetadata("hello")]
    public static string hello(string? name = "World") => $"Hello {name}!";

    [GraphQLMetadata("person")]
    public static Person person() =>
        new Person
        {
            Id = Faker.NumberFaker.Number(0, 100), Name = Faker.Name.FullName(), Address =
                new Address
                {
                    City = Faker.Address.City(),
                    Street = Faker.Address.StreetAddress(),
                    Number = Faker.StringFaker.AlphaNumeric(2)
                }
        };

    [GraphQLMetadata("persons")]
    public static IEnumerable<Person> persons(string? nameContains)
    {
        // inject db context
        using var db = new AddressBookDb(new DbContextOptionsBuilder<AddressBookDb>()
            .UseInMemoryDatabase("AddressBook")
            .Options);

        // filter by name and if no results return empty list
        return db.People.Where(p => p.Name.Contains(nameContains ?? string.Empty)).ToList();
    }
}