using FoodService.Data.Nugget.Pkg.Config;
using FoodService.Data.Nugget.Pkg.Context;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace FoodService.Data.Nugget.Pkg
{
    public class FoodServiceDbContextFactory : IDesignTimeDbContextFactory<FoodServiceDbContext>
    {
        public FoodServiceDbContext CreateDbContext(string[] args)
        {
            var services = new ServiceCollection();
            string sqlConnection = "server=localhost;userid=root;pwd=root;port=3306;database=FoodServiceDb;sslmode=none;AllowPublicKeyRetrieval=True;";

            services.ConfigureDatabase(sqlConnection);
            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider.GetRequiredService<FoodServiceDbContext>();
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
