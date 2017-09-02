using Abp.Authorization;
using ImproveX.Authorization.Roles;
using ImproveX.Authorization.Users;

namespace ImproveX.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
