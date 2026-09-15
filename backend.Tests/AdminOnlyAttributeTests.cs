using Api.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace Api.Tests;

public class AdminOnlyAttributeTests
{
    private static AuthorizationFilterContext CreateContext(string? role)
    {
        var httpContext = new DefaultHttpContext();
        if (role is not null)
        {
            httpContext.Request.Headers[AdminOnlyAttribute.RoleHeader] = role;
        }

        var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
        return new AuthorizationFilterContext(actionContext, []);
    }

    [Fact]
    public void OnAuthorization_WithAdminRole_AllowsRequest()
    {
        var context = CreateContext("Admin");

        new AdminOnlyAttribute().OnAuthorization(context);

        Assert.Null(context.Result);
    }

    [Fact]
    public void OnAuthorization_WithNonAdminRole_Returns403()
    {
        var context = CreateContext("Employee");

        new AdminOnlyAttribute().OnAuthorization(context);

        var result = Assert.IsType<ObjectResult>(context.Result);
        Assert.Equal(StatusCodes.Status403Forbidden, result.StatusCode);
    }

    [Fact]
    public void OnAuthorization_WithMissingRoleHeader_Returns403()
    {
        var context = CreateContext(null);

        new AdminOnlyAttribute().OnAuthorization(context);

        var result = Assert.IsType<ObjectResult>(context.Result);
        Assert.Equal(StatusCodes.Status403Forbidden, result.StatusCode);
    }
}
