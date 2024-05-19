using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

public static class AccountEndpoints
{
    public static void MapAccountEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/account/login", async context =>
        {
            string? returnUrl = context.Request.Query["returnUrl"];
            string? claimsChallenge = context.Request.Query["claimsChallenge"];
            var result = Login(returnUrl, claimsChallenge);
            await result.ExecuteAsync(context);
        });

        endpoints.MapPost("/api/account/logout", async context =>
        {
            var result = await LogoutAsync(context);
            await result.ExecuteAsync(context);
        });
    }

    public static IResult Login(string? returnUrl, string? claimsChallenge)
    {
        var properties = GetAuthProperties(returnUrl);

        if (!string.IsNullOrEmpty(claimsChallenge))
        {
            string jsonString = claimsChallenge.Replace("\\", "").Trim('"');
            properties.Items["claims"] = jsonString;
        }

        return Results.Challenge(properties);
    }

    public static async Task<IResult> LogoutAsync(HttpContext context)
    {
        // Sign out the user from CookieAuthenticationDefaults.AuthenticationScheme
        await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        // Sign out the user from a custom authentication scheme named "Cookies"
        await context.SignOutAsync("Cookies");

        // Clear cookies by setting their expiration time to the past
        foreach (var cookie in context.Request.Cookies.Keys)
        {
            context.Response.Cookies.Delete(cookie);
        }

        // Clear session data
        context.Session.Clear();

        // Redirect the user after logout
        return Results.Redirect("/");
    }

    private static AuthenticationProperties GetAuthProperties(string? returnUrl)
    {
        const string pathBase = "/";

        if (string.IsNullOrEmpty(returnUrl))
        {
            returnUrl = pathBase;
        }
        else if (!Uri.IsWellFormedUriString(returnUrl, UriKind.Relative))
        {
            returnUrl = new Uri(returnUrl, UriKind.Absolute).PathAndQuery;
        }
        else if (returnUrl[0] != '/')
        {
            returnUrl = $"{pathBase}{returnUrl}";
        }

        return new AuthenticationProperties { RedirectUri = returnUrl };
    }
}
