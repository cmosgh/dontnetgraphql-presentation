using Faker.Resources;
using GraphQL;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Db;
using MinimalApi.GraphQL;

[GraphQLMetadata("mutation")]
public class Mutation
{
    [GraphQLMetadata("createPerson")]
    public static Person createPerson(string name, int age)
    {
        // inject dbcontext
        using var db = new AddressBookDb(new DbContextOptionsBuilder<AddressBookDb>()
            .UseInMemoryDatabase("AddressBook")
            .Options);

        // add person
        var person = new Person
        {
            Name = name,
            Age = age
        };

        db.People.Add(person);
        db.SaveChanges();
        return person;
    }
}