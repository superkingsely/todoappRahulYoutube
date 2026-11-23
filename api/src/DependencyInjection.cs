

using Microsoft.EntityFrameworkCore;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
           this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString
            = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<TodoAppDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });

        services.AddAutoMapper(typeof(TodoMappingExtension).Assembly); // register automapper only at infra layer


        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITodoRepository, TodoRepository>();

        return services;
    }

    public static IServiceCollection AddApplication(
           this IServiceCollection services)
    {
        
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITodoService, TodoService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        return services;
    }


}