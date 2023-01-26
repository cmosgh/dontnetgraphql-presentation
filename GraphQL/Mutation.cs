using GraphQL;
using MinimalApi.GraphQL;

[GraphQLMetadata("mutation" )]
public class Mutation
{
    public static Person AddPerson(AddPersonInput input)
    {
        return new Person
        {
            Id = Faker.NumberFaker.Number(0, 100),
            Name = input.Name,
            Age = input.Age,
            Address = null
        };
    }
}