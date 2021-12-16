using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Viewtance.Teaching.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class TeachingMigrationsDbContextFactory : IDesignTimeDbContextFactory<TeachingMigrationsDbContext>
    {
        public TeachingMigrationsDbContext CreateDbContext(string[] args)
        {
            TeachingEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<TeachingMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new TeachingMigrationsDbContext(builder.Options);
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
