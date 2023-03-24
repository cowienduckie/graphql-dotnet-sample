using GraphQLSample.Data;
using GraphQLSample.Models;

namespace GraphQLSample.GraphQL;

public class Query
{
    [UseFiltering]
    [UseSorting]
    public IQueryable<Platform> GetPlatforms(AppDbContext context)
    {
        return context.Platforms;
    }

    [UseFiltering]
    [UseSorting]
    public IQueryable<Command> GetCommands(AppDbContext context)
    {
        return context.Commands;
    }
}