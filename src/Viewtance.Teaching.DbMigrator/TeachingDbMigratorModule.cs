using Viewtance.Teaching.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Viewtance.Teaching.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(TeachingEntityFrameworkCoreModule),
        typeof(TeachingApplicationContractsModule)
    )]
    public class TeachingDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options =>
            {
                options.IsJobExecutionEnabled = false;
            });
        }
    }
}
