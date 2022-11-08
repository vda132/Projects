using ASP.Net.MediatR.Contacts.Helpers;
using ASP.Net.MediatR.Contacts.Repositories;
using ASP.Net.MediatR.Contacts.Services;
using ASP.Net.MediatR.DAL;
using ASP.Net.MediatR.DAL.Repositories;
using ASP.Net.MediatR.Services.Helpers;
using ASP.Net.MediatR.Services.Services;

namespace ASP.Net.MediatR.API.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
        services.AddTransient<IDatabaseInitializer, DataBaseInitializer>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderDetailService, OrderDetailService>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
    }
}
