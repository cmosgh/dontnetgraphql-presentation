using GraphQL.Types;

namespace MinimalApi.GraphQL;

public class AddressBookSchema : Schema
{
    public AddressBookSchema(IServiceProvider provider) : base(provider)
    {
        Mutation = provider.GetRequiredService<AddressBookMutation>();
        // Query = provider.GetRequiredService<AddressBookQuery>();
    }
}