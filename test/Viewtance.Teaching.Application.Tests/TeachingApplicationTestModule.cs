using Volo.Abp.Modularity;

namespace Viewtance.Teaching
{
    [DependsOn(
        typeof(TeachingApplicationModule),
        typeof(TeachingDomainTestModule)
        )]
    public class TeachingApplicationTestModule : AbpModule
    {

    }
}