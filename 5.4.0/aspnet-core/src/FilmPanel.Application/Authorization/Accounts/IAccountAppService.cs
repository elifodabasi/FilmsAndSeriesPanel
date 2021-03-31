using System.Threading.Tasks;
using Abp.Application.Services;
using FilmPanel.Authorization.Accounts.Dto;

namespace FilmPanel.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
