using System.Security.Claims;

namespace Microsoft.AspNetCore.Routing;

internal static class UserInfoEndpoint
{
    internal static void MapUserInfo(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("");

        group.MapGet("/userinfo", async context =>
        {
            var user = context.User;
            var userInfo = UserInfo.FromClaimsPrincipalToUserInfo(user);
            await context.Response.WriteAsJsonAsync(userInfo);
        }).AllowAnonymous();
    }
}


