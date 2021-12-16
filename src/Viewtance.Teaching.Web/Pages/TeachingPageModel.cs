using Viewtance.Teaching.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Viewtance.Teaching.Web.Pages
{
    /* Inherit your Page Model classes from this class.
     */
    public abstract class TeachingPageModel : AbpPageModel
    {
        protected TeachingPageModel()
        {
            LocalizationResourceType = typeof(TeachingResource);
        }
    }
}