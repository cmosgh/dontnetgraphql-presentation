public class Query
{
    public static string hello(string? name = "World") => $"Hello {name}!";

    // expose generic person query
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

    // expose a list of persons
    public static IEnumerable<Person> persons() => Enumerable.Range(1, 10).Select(i => new Person
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
}