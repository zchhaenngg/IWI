using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ImproveX.Roles.Dto;
using ImproveX.Users.Dto;

namespace ImproveX.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}