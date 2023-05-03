using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Database;


namespace MinimalApi.GraphQL;

public class CreatePersonInputType : InputObjectGraphType
{
    public CreatePersonInputType()
    {
        Name = "CreatePersonInput";
        Field<NonNullGraphType<StringGraphType>>("name");
        Field<NonNullGraphType<IntGraphType>>("age");
    }
}

public class AddressBookMutation : ObjectGraphType
{
    public AddressBookMutation(AddressBookDb db)
    {
        Name = "mutation";
        Field<Person>("createPerson").Argument<CreatePersonInputType>("input").Resolve(context =>
        {
            var person = new Person
            {
                Name = context.GetArgument<string>("name"),
                Age = context.GetArgument<int>("age")
            };

            db.Persons.Add(person);
            db.SaveChanges();
            return person;
        });
    }
}