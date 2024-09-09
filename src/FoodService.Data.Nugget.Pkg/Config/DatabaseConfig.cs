using FoodService.Data.Nugget.Pkg.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FoodService.Data.Nugget.Pkg.Config
{
    /// <summary>
    /// Class for configuring the database.
    /// </summary>
    public static class DatabaseConfig
    {
        /// <summary>
        /// Configures the database with the specified SQLServer connection string.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="sqlConnection">The sql connection string.</param>
        public static void ConfigureDatabase(this IServiceCollection services, string sqlConnection)
        {
            services.ConfigureDatabaseMySql(sqlConnection);
        }
    }
}
