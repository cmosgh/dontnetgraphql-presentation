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

    [GraphQLMetadata("removePerson")]
    public static int removePerson(int id)
    {
        // inject dbcontext
        using var db = new AddressBookDb(new DbContextOptionsBuilder<AddressBookDb>()
            .UseInMemoryDatabase("AddressBook")
            .Options);

        // remove person
        var person = db.People.Find(id);
        if (person == null)
        {
            return 0;
        }

        db.People.Remove(person);
        db.SaveChanges();
        return id;
    }
}