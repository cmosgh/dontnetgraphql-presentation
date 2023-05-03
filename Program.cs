using System.Reflection;
using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Database;
using MinimalApi.GraphQL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IServiceProvider>(c => new FuncServiceProvider(type => c.GetRequiredService(type)));
builder.Services.AddDbContext<AddressBookDb>(options => options.UseInMemoryDatabase("AddressBook")); // dbcontext
builder.Services.AddScoped<AddressBookMutation>();
builder.Services.AddScoped<AddressBookSchema>();

builder.Services.AddGraphQL(b => b
    .AddGraphTypes() // schema
    .AddSystemTextJson()); // serializer

var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseWebSockets();
app.UseGraphQL(); // default path is /graphql

// use playground only in devmode
if (app.Environment.IsDevelopment())
{
    app.UseGraphQLPlayground(
        "/graphqli", // url to host Playground at
        new GraphQL.Server.Ui.Playground.PlaygroundOptions
        {
            GraphQLEndPoint = "/graphql", // url of GraphQL endpoint
            SubscriptionsEndPoint = "/graphql", // url of GraphQL endpoint
        });
}

await app.RunAsync();