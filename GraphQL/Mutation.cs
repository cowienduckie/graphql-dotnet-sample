using GraphQLSample.Data;
using GraphQLSample.GraphQL.Commands;
using GraphQLSample.GraphQL.Platforms;
using GraphQLSample.Models;
using HotChocolate.Subscriptions;

namespace GraphQLSample.GraphQL;

public class Mutation
{
    public async Task<AddPlatformPayload> AddPlatformAsync(
        AddPlatformInput input,
        AppDbContext context,
        [Service] ITopicEventSender eventSender,
        CancellationToken cancellationToken)
    {
        var platform = new Platform
        {
            Name = input.Name,
            Publisher = input.Publisher
        };

        context.Platforms.Add(platform);
        await context.SaveChangesAsync(cancellationToken);

        await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded), platform, cancellationToken);

        return new AddPlatformPayload(platform);
    }

    public async Task<AddCommandPayload> AddCommandAsync(AddCommandInput input, AppDbContext context)
    {
        var command = new Command
        {
            HowTo = input.HowTo,
            CommandLine = input.CommandLine,
            PlatformId = input.PlatformId
        };

        context.Commands.Add(command);
        await context.SaveChangesAsync();

        return new AddCommandPayload(command);
    }
}