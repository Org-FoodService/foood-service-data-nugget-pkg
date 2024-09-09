using FoodService.Data.Nugget.Pkg.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace FoodService.Data.Nugget.Pkg.Config
{
    /// <summary>
    /// Class for configuring the database.
    /// </summary>
    public static class MySqlConfig
    {
        /// <summary>
        /// Configures the database with the specified SQLServer connection string.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="sqlConnection">The SQLServer connection string.</param>
        public static void ConfigureDatabaseMySql(this IServiceCollection services, string sqlConnection)
        {
            services.AddDbContext<FoodServiceDbContext>(options =>
                        options.UseMySql(sqlConnection, ServerVersion.AutoDetect(sqlConnection)));
        }

        /// <summary>
        /// Updates the database migration if there are pending migrations.
        /// </summary>
        /// <param name="services">The service collection.</param>
        public static void UpdateMigrationDatabase(this IServiceCollection services)
        {
            // Configure database migration
            using var scope = services.BuildServiceProvider().CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<FoodServiceDbContext>();
            if (dbContext.Database.GetPendingMigrations().Any())
            {
                dbContext.Database.Migrate();
            }
        }
    }
}
