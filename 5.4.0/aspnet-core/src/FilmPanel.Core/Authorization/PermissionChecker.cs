using Abp.Authorization;
using FilmPanel.Authorization.Roles;
using FilmPanel.Authorization.Users;

namespace FilmPanel.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
