using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Viewtance.Teaching.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class TeachingIdentityMigrationsDbContextFactory : IDesignTimeDbContextFactory<TeachingIdentityMigrationsDbContext>
    {
        public TeachingIdentityMigrationsDbContext CreateDbContext(string[] args)
        {
            TeachingEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<TeachingIdentityMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("AbpIdentity"));

            return new TeachingIdentityMigrationsDbContext(builder.Options);
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
