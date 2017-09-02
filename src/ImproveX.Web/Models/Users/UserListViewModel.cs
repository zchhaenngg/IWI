using System.Collections.Generic;
using ImproveX.Roles.Dto;
using ImproveX.Users.Dto;

namespace ImproveX.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}