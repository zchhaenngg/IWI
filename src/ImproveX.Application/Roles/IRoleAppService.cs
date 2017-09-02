using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ImproveX.Roles.Dto;

namespace ImproveX.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
    }
}
