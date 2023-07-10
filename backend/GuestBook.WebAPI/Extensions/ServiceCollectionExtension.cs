using System.Reflection;
using GuestBook.BLL.Interfaces;
using GuestBook.BLL.MappingProfiles;
using GuestBook.BLL.Services;

namespace GuestBook.WebAPI.Extensions;

public static class ServiceCollectionExtension
{
    public static void RegisterCustomServices(this IServiceCollection services)
    {
        services.AddTransient<IPostService, PostService>();
    }
    
    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetAssembly(typeof(PostProfile)));
    }
}