using GraphQL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQL(b => b
    .AddAutoSchema<Query>(c=>c.WithMutation<Mutation>()) // schema
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