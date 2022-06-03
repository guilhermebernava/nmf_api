using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace NativeInjector;

public class NativeInjector
{
    public static void InjectServices(IServiceCollection services)
    {
        services.AddScoped<DbContext, UserContext>();
        services.AddDbContext<UserContext>(options =>
        {
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
        services.AddTransient<IDbContext, UserContext>();
    }
}

