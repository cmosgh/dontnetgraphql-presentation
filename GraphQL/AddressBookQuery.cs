using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Database;

// public class AddressBookQuery : ObjectGraphType
// {
//     public AddressBookQuery(AddressBookDb db)
//     {
//         Field<List<Person>>("persons", resolve: context => db.Persons.ToListAsync());
//     }
// }