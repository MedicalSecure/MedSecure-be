﻿
//public class UserInfo
//{
//    public static readonly UserInfo Anonymous = new();

//    public bool IsAuthenticated { get; set; }

//    public string NameClaimType { get; set; } = string.Empty;

//    public string RoleClaimType { get; set; } = string.Empty;

//    public ICollection<ClaimValue> Claims { get; set; } = new List<ClaimValue>();

//    public List<string> Roles { get; set; } = new List<string>();

//    public List<string> Permissions { get; set; } = new List<string>();
//}


using System.Security.Claims;

public sealed class UserInfo
{
    public required string UserId { get; init; }
    public required string Name { get; init; }

    public const string UserIdClaimType = "sub";
    public const string NameClaimType = "name";

    public static UserInfo FromClaimsPrincipal(ClaimsPrincipal principal) =>
        new()
        {
            UserId = GetRequiredClaim(principal, UserIdClaimType),
            Name = GetRequiredClaim(principal, NameClaimType),
        };

    public ClaimsPrincipal ToClaimsPrincipal() =>
        new(new ClaimsIdentity(
            [new(UserIdClaimType, UserId), new(NameClaimType, Name)],
            authenticationType: nameof(UserInfo),
            nameType: NameClaimType,
            roleType: null));

    private static string GetRequiredClaim(ClaimsPrincipal principal, string claimType) =>
        principal.FindFirst(claimType)?.Value ?? throw new InvalidOperationException($"Could not find required '{claimType}' claim.");
}

