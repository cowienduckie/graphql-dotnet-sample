using GraphQLSample.Data;
using GraphQLSample.Models;

namespace GraphQLSample.GraphQL.Platforms;

public class PlatformType : ObjectType<Platform>
{
    protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
    {
        descriptor.Description("Represents any software or service that has a command line interface.");

        descriptor
            .Field(p => p.Id)
            .Description("Represents the unique identifier for the platform.");

        descriptor
            .Field(p => p.Name)
            .Description("Represents the name of the platform.");

        descriptor
            .Field(p => p.Publisher)
            .Description("Represents the publisher of the platform.");

        descriptor
            .Field(p => p.Commands)
            .Description("Represents the available commands for the platform.")
            .ResolveWith<Resolvers>(r => r.GetCommands(default!, default!))
            .UseDbContext<AppDbContext>();
    }

    private class Resolvers
    {
        public IQueryable<Command> GetCommands([Parent] Platform platform, AppDbContext context)
        {
            return context.Commands.Where(c => c.PlatformId == platform.Id);
        }
    }
}