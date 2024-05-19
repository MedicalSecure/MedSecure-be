using Azure.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using System;
using System.Security.Claims;
using System.Text.Json;

public static class UserConEndpoint
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/user", async context =>
        {
            var msGraphService = context.RequestServices.GetRequiredService<MsGraphService>();
            var user = context.User;
            var userInfo = await CreateUserInfoAsync(user, msGraphService.GetGraphServiceClient());
            await context.Response.WriteAsJsonAsync(userInfo);
        }).AllowAnonymous();
    }

    private static async Task<UserInfo> CreateUserInfoAsync(ClaimsPrincipal claimsPrincipal, GraphServiceClient graphServiceClient)
    {
        if (claimsPrincipal == null || claimsPrincipal.Identity == null || !claimsPrincipal.Identity.IsAuthenticated)
        {
            return UserInfo.Anonymous;
        }

        var userInfo = new UserInfo
        {
            IsAuthenticated = true,
        };

        if (claimsPrincipal.Identity is ClaimsIdentity claimsIdentity)
        {
            if (!string.IsNullOrEmpty(claimsIdentity.RoleClaimType))
            {
                userInfo.RoleClaimType = claimsIdentity.RoleClaimType;
            }
            if (!string.IsNullOrEmpty(claimsIdentity.NameClaimType))
            {
                userInfo.NameClaimType = claimsIdentity.NameClaimType;
            }           
        }
        else
        {
            userInfo.NameClaimType = ClaimTypes.Name;
            userInfo.RoleClaimType = ClaimTypes.Role;
        }

        if (claimsPrincipal.Claims?.Any() ?? false)
        {
            var claims = claimsPrincipal.Claims.Select(u => new ClaimValue(u.Type, u.Value)).ToList();
            userInfo.Claims = claims;
        }

        if (userInfo.Roles.Count() == 0 && userInfo.Permissions.Count() == 0)
        {
            var uid = userInfo.Claims.FirstOrDefault(c => c.Type == "uid");
            if (uid != null)
            {
                var rolesAndPermissions = await graphServiceClient.Users[uid.Value].Extensions.GetAsync();

                userInfo.Roles = new List<string>();
                userInfo.Permissions = new List<string>();

                if (rolesAndPermissions != null && rolesAndPermissions.Value?.FirstOrDefault(c => c.Id == "medsecure.userSettings") is OpenTypeExtension userSettings)
                {
                    if (userSettings.AdditionalData.TryGetValue("Roles", out var rolesData) && rolesData is JsonElement rolesJsonElement)
                    {
                        if (rolesJsonElement.ValueKind == JsonValueKind.Array)
                        {
                            foreach (var role in rolesJsonElement.EnumerateArray())
                            {
                                userInfo.Roles.Add(role.ToString());
                            }
                        }
                        else
                        {
                            userInfo.Roles.Add(rolesJsonElement.ToString());
                        }
                    }

                    if (userSettings.AdditionalData.TryGetValue("Permissions", out var permissionsData) && permissionsData is JsonElement permissionsJsonElement)
                    {
                        if (permissionsJsonElement.ValueKind == JsonValueKind.Array)
                        {
                            foreach (var permission in permissionsJsonElement.EnumerateArray())
                            {
                                userInfo.Permissions.Add(permission.ToString());
                            }
                        }
                        else
                        {
                            userInfo.Permissions.Add(permissionsJsonElement.ToString());
                        }
                    }
                }

                userInfo.Claims.Add(new ClaimValue("Role", string.Join(",", userInfo.Roles)));
                userInfo.Claims.Add(new ClaimValue("Permissions", string.Join(",", userInfo.Permissions)));
            }
        }

        return userInfo;
    }
}
