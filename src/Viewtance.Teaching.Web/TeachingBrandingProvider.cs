using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Viewtance.Teaching.Web
{
    [Dependency(ReplaceServices = true)]
    public class TeachingBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Teaching";
    }
}
