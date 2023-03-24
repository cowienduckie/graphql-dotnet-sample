using GraphQL.Server.Ui.Voyager;
using GraphQLSample.Data;
using GraphQLSample.GraphQL;
using GraphQLSample.GraphQL.Commands;
using GraphQLSample.GraphQL.Platforms;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsProduction())
{
    builder.Services.AddPooledDbContextFactory<AppDbContext>(
        opt => opt.UseSqlServer(
            builder.Configuration.GetConnectionString("DbConn"),
            b => { b.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null); })
    );
}
else
{
    builder.Services.AddPooledDbContextFactory<AppDbContext>(
        opt => opt.UseInMemoryDatabase("InMem")
    );
}

builder.Services
    .AddGraphQLServer()
    .RegisterDbContext<AppDbContext>(DbContextKind.Pooled)
    .AddQueryType<Query>()
    .AddType<PlatformType>()
    .AddType<CommandType>()
    .AddFiltering()
    .AddSorting()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions();

var app = builder.Build();

app.UseWebSockets();

app.MapGraphQL();

app.UseGraphQLVoyager("/graphql-voyager", new VoyagerOptions
{
    GraphQLEndPoint = "/graphql"
});

app.PrepareDb(app.Environment.IsProduction());

app.Run();