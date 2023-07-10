using GuestBook.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace GuestBook.WebAPI.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder MigrateDB(this IApplicationBuilder builder)
    {
        using var scope = builder.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
        using var context = scope?.ServiceProvider.GetRequiredService<GuestBookContext>();
        context?.Database.Migrate();
    
        return builder;
    }
}