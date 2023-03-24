using GraphQLSample.Models;

namespace GraphQLSample.GraphQL;

public class Subscription
{
    [Topic]
    [Subscribe]
    public Platform OnPlatformAdded([EventMessage] Platform platform)
    {
        return platform;
    }
}