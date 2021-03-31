using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace FilmPanel.Controllers
{
    public abstract class FilmPanelControllerBase: AbpController
    {
        protected FilmPanelControllerBase()
        {
            LocalizationSourceName = FilmPanelConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
