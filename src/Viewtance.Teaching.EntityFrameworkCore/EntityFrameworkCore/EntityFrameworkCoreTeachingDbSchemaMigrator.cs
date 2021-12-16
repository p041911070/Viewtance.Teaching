using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Viewtance.Teaching.Data;
using Volo.Abp.DependencyInjection;

namespace Viewtance.Teaching.EntityFrameworkCore
{
    public class EntityFrameworkCoreTeachingDbSchemaMigrator
        : ITeachingDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreTeachingDbSchemaMigrator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the TeachingDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<TeachingIdentityMigrationsDbContext>()
                .Database
                .MigrateAsync();
            await _serviceProvider
                .GetRequiredService<TeachingIdentityServerMigrationsDbContext>()
                .Database
                .MigrateAsync();
            await _serviceProvider
                .GetRequiredService<TeachingPermissionMigrationsDbContext>()
                .Database
                .MigrateAsync();
            await _serviceProvider
                .GetRequiredService<TeachingSaasMigrationsDbContext>()
                .Database
                .MigrateAsync();
            await _serviceProvider
                .GetRequiredService<TeachingAuditLoggingMigrationsDbContext>()
                .Database
                .MigrateAsync();
            await _serviceProvider
                .GetRequiredService<TeachingMigrationsDbContext>()
                .Database
                .MigrateAsync();
            await _serviceProvider
                .GetRequiredService<TeachingDbContext>()
                .Database
                .MigrateAsync();

        }
    }
}
