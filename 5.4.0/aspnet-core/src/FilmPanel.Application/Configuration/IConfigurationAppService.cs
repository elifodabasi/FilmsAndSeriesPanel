using System.Threading.Tasks;
using FilmPanel.Configuration.Dto;

namespace FilmPanel.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
