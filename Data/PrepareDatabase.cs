using Microsoft.EntityFrameworkCore;

namespace GraphQLSample.Data;

public static class PrepareDatabase
{
    public static void PrepareDb(this IApplicationBuilder app, bool isProductionEnv)
    {
        if (!isProductionEnv)
        {
            return;
        }

        using var serviceScope = app.ApplicationServices.CreateScope();
        var factory = serviceScope.ServiceProvider.GetService<IDbContextFactory<AppDbContext>>();
        var context = factory?.CreateDbContext();

        context?.Database.Migrate();
    }
}