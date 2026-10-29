

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

            return services;
    }
}