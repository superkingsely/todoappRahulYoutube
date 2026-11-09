

using Microsoft.EntityFrameworkCore;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
           this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString
            = configuration.GetConnectionString("DatabaseConnection");

        services.AddDbContext<TodoAppDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });

        services.AddAutoMapper(typeof(TodoMappingExtension).Assembly); // register automapper only at infra layer


        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    public static IServiceCollection AddApplication(
           this IServiceCollection services)
    {
        
        services.AddScoped<IUserService, UserService>();

        return services;
    }


}