using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Viewtance.Teaching
{
    [Dependency(ReplaceServices = true)]
    public class TeachingBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Teaching";
    }
}
