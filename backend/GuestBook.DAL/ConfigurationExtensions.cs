using GuestBook.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GuestBook.DAL;

public static class ConfigurationExtensions
{
    public static void ConfigureDALServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddGuestBookContext(configuration);
    }
    
    private static void AddGuestBookContext(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionString = configuration["ConnectionStrings:DbConnection"];
        
        serviceCollection.AddDbContext<GuestBookContext>(options =>
            options.UseSqlServer(
                connectionString,
                opt => opt.MigrationsAssembly(typeof(GuestBookContext).Assembly.GetName().Name)));
    }
}