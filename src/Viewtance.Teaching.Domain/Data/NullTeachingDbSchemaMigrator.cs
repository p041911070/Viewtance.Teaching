using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Viewtance.Teaching.Data
{
    /* This is used if database provider does't define
     * ITeachingDbSchemaMigrator implementation.
     */
    public class NullTeachingDbSchemaMigrator : ITeachingDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}