using Viewtance.Teaching.Localization;
using Volo.Abp.Application.Services;

namespace Viewtance.Teaching
{
    /* Inherit your application services from this class.
     */
    public abstract class TeachingAppService : ApplicationService
    {
        protected TeachingAppService()
        {
            LocalizationResource = typeof(TeachingResource);
        }
    }
}
