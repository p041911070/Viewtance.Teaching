using Viewtance.Teaching.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Viewtance.Teaching
{
    [DependsOn(
        typeof(TeachingEntityFrameworkCoreTestModule)
        )]
    public class TeachingDomainTestModule : AbpModule
    {

    }
}