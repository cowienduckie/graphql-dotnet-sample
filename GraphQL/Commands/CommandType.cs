using GraphQLSample.Data;
using GraphQLSample.Models;

namespace GraphQLSample.GraphQL.Commands;

public class CommandType : ObjectType<Command>
{
    protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
    {
        descriptor.Description("Represents any executable command that's available in a command line interface.");

        descriptor
            .Field(c => c.Id)
            .Description("Represents the unique identifier for the command.");

        descriptor
            .Field(c => c.HowTo)
            .Description("Represents the steps needed to execute the command.");

        descriptor
            .Field(c => c.CommandLine)
            .Description("Represents the actual text needed to execute the command.");

        descriptor
            .Field(c => c.Platform)
            .Description("Represents the platform to which the command belongs.")
            .ResolveWith<Resolvers>(r => r.GetPlatform(default!, default!))
            .UseDbContext<AppDbContext>();
    }

    private class Resolvers
    {
        public Platform GetPlatform([Parent] Command command, AppDbContext context)
        {
            return context.Platforms.FirstOrDefault(p => p.Id == command.PlatformId) ??
                   throw new InvalidOperationException("Platform not found.");
        }
    }
}