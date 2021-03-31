using Abp.Application.Services;
using FilmPanel.MultiTenancy.Dto;

namespace FilmPanel.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

