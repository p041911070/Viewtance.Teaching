using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Viewtance.Teaching.Web.Pages
{
    public class IndexModel : TeachingPageModel
    {
        public void OnGet()
        {
            
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}