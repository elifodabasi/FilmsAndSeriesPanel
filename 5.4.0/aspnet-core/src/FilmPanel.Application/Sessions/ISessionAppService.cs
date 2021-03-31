using System.Threading.Tasks;
using Abp.Application.Services;
using FilmPanel.Sessions.Dto;

namespace FilmPanel.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
