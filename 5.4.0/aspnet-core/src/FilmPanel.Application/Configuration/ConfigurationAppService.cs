using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using FilmPanel.Configuration.Dto;

namespace FilmPanel.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : FilmPanelAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
