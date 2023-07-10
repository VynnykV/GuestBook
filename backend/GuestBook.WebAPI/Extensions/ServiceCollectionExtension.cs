using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using GuestBook.BLL.Interfaces;
using GuestBook.BLL.MappingProfiles;
using GuestBook.BLL.Services;
using GuestBook.WebAPI.Validators;

namespace GuestBook.WebAPI.Extensions;

public static class ServiceCollectionExtension
{
    public static void RegisterCustomServices(this IServiceCollection services)
    {
        services.AddTransient<IPostService, PostService>();
        services.AddTransient<ICommentService, CommentService>();
    }
    
    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetAssembly(typeof(PostProfile)));
    }
    
    public static void AddValidation(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<PostCreateDTOValidator>();
    }
}