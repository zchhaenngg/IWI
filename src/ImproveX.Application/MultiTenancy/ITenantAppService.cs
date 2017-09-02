using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ImproveX.MultiTenancy.Dto;

namespace ImproveX.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
