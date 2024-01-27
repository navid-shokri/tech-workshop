using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuthorizationSample.API;

[AttributeUsage(AttributeTargets.Class| AttributeTargets.Method, AllowMultiple = true)]
public class SnappAuthorizationAttribute : Attribute, IAsyncAuthorizationFilter
{
    private readonly IAuthService _authService;

    public SnappAuthorizationAttribute(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
        var accessToken = token?.Split(" ")[1];
        var userData = await _authService.IntrospectTokenAsync(token);
        if (userData == null || !userData.Active)
        {
            context.Result = new ForbidResult();
        }

        context.HttpContext.Items["User"] = userData;

    }
}