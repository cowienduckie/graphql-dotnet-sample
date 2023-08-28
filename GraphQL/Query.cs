using GraphQLSample.Data;
using GraphQLSample.Models;

namespace GraphQLSample.GraphQL;

public class Query
{
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Platform> GetPlatforms(AppDbContext context)
    {
        return context.Platforms;
    }

    [UseOffsetPaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Command> GetCommands(AppDbContext context)
    {
        return context.Commands;
    }
}