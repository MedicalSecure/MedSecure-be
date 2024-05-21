using Microsoft.Graph.Models;
using Microsoft.Graph;
using System.Security.Claims;
using System.Text.Json;

// Add properties to this class and update the server and client AuthenticationStateProviders
// to expose more information about the authenticated user to the client.
public sealed class UserInfo
{
    public required string UserId { get; init; }
    public required string Name { get; init; }
    public IEnumerable<Claim>? Claims { get; private set; }
    public bool IsAuthenticated { get; private set; }

    public const string UserIdClaimType = "sub";
    public const string NameClaimType = "name";

    public static UserInfo FromClaimsPrincipal(ClaimsPrincipal principal) =>
        new()
        {
            UserId = GetRequiredClaim(principal, UserIdClaimType),
            Name = GetRequiredClaim(principal, NameClaimType),
        };


    public static UserInfo? FromClaimsPrincipalToUserInfo(ClaimsPrincipal principal)
    {
        if (principal == null || principal.Identity == null || !principal.Identity.IsAuthenticated)
        {
            return null;
        }

        return new UserInfo
        {
            UserId = GetRequiredClaim(principal, UserIdClaimType),
            Name = GetRequiredClaim(principal, NameClaimType),
            IsAuthenticated = true,
            Claims = principal.Claims.Select(c => new Claim(c.Type, c.Value)).ToList()
        };
    }

    public ClaimsPrincipal ToClaimsPrincipal() =>
        new(new ClaimsIdentity(
            [new(UserIdClaimType, UserId), new(NameClaimType, Name)],
            authenticationType: nameof(UserInfo),
            nameType: NameClaimType,
            roleType: null));

    private static string GetRequiredClaim(ClaimsPrincipal principal, string claimType) =>
        principal.FindFirst(claimType)?.Value ?? throw new InvalidOperationException($"Could not find required '{claimType}' claim.");
}
