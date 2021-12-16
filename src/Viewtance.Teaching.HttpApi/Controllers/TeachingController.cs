using Viewtance.Teaching.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Viewtance.Teaching.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class TeachingController : AbpControllerBase
    {
        protected TeachingController()
        {
            LocalizationResource = typeof(TeachingResource);
        }
    }
}