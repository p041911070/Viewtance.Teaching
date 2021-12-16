using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Viewtance.Teaching.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class TeachingPermissionMigrationsDbContextFactory : IDesignTimeDbContextFactory<TeachingPermissionMigrationsDbContext>
    {
        public TeachingPermissionMigrationsDbContext CreateDbContext(string[] args)
        {
            TeachingEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<TeachingPermissionMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("AbpPermissionManagement"));

            return new TeachingPermissionMigrationsDbContext(builder.Options);
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
