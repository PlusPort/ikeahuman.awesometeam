using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Auth;

/// <summary>
/// Restricts an endpoint to admins. Stands in for real authentication/authorization,
/// which doesn't exist in this project yet: the caller's role is read from the
/// <c>X-User-Role</c> header. Replace with proper auth once that's built.
/// </summary>
public class AdminOnlyAttribute : Attribute, IAuthorizationFilter
{
    public const string RoleHeader = "X-User-Role";
    public const string AdminRole = "Admin";

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var role = context.HttpContext.Request.Headers[RoleHeader].ToString();
        if (!string.Equals(role, AdminRole, StringComparison.OrdinalIgnoreCase))
        {
            context.Result = new ObjectResult(new { message = "Admin access required." })
            {
                StatusCode = StatusCodes.Status403Forbidden
            };
        }
    }
}
