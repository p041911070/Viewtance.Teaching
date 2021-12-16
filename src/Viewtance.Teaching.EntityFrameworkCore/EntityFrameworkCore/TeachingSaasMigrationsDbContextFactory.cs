using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Viewtance.Teaching.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class TeachingSaasMigrationsDbContextFactory : IDesignTimeDbContextFactory<TeachingSaasMigrationsDbContext>
    {
        public TeachingSaasMigrationsDbContext CreateDbContext(string[] args)
        {
            TeachingEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<TeachingSaasMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Saas"));

            return new TeachingSaasMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Viewtance.Teaching.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
