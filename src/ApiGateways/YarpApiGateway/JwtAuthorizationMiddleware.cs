// Middleware for JWT token-based authorization
using System.Net.Http;

internal class JwtAuthorizationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly HttpAuthorizationOptions _options;

    public JwtAuthorizationMiddleware(RequestDelegate next, HttpAuthorizationOptions options)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _options = options ?? throw new ArgumentNullException(nameof(options));
    }

    // Invokes the middleware
    public async Task Invoke(HttpContext context)
    {
        // Check if the request is for Swagger and AllowSwagger option is enabled
        if (_options.AllowSwagger && IsSwaggerRequest(context.Request.Path))
        {
            // Allow access to Swagger without token authorization
            await _next(context);
            return;
        }

        // Extract the JWT token from the Authorization header
        var authorizationHeader = context.Request.Headers["Authorization"];
        if (!Microsoft.Extensions.Primitives.StringValues.IsNullOrEmpty(authorizationHeader) && authorizationHeader.ToString().StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
        {
            var token = authorizationHeader.ToString().Substring("Bearer ".Length);

            try
            {
                // Decode the JWT token payload
                var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as System.IdentityModel.Tokens.Jwt.JwtSecurityToken;

                // Set the user principal from the token claims
                var identity = new System.Security.Claims.ClaimsIdentity(jsonToken?.Claims);

                // Handle "scp" claim
                var scopeClaim = identity.FindFirst("scp");
                if (scopeClaim != null)
                {
                    var scopes = scopeClaim.Value.Split(' ');
                    identity.RemoveClaim(scopeClaim);

                    foreach (var scope in scopes)
                    {
                        identity.AddClaim(new System.Security.Claims.Claim("scp", scope));
                    }
                }

                // Check if the required scope is present in the token
                if (scopeClaim == null
                    || !(scopeClaim.Value.Split(' ').Contains("Diet.Read")
                    || scopeClaim.Value.Split(' ').Contains("Diet.Write")
                    || scopeClaim.Value.Split(' ').Contains("Waste.Read")
                    || scopeClaim.Value.Split(' ').Contains("Waste.Write")))
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("You are not authorized");
                    return;
                }
                else
                {
                    context.Request.Headers.Append("FromApiGateway", "true");
                }

                // Assign the user principal to the current HttpContext
                context.User = new System.Security.Claims.ClaimsPrincipal(identity);
            }
            catch (Microsoft.IdentityModel.Tokens.SecurityTokenException)
            {
                // Token validation failed
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }
            catch (Exception)
            {
                // Other unexpected errors
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                return;
            }
        }
        else
        {
            // No token provided
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }

        // Call the next middleware in the pipeline
        await _next(context);
    }

    // Check if the request is for Swagger
    private bool IsSwaggerRequest(PathString path)
    {
        return path.StartsWithSegments("/swagger");
    }
}

public class HttpAuthorizationOptions
{
    public bool AllowSwagger { get; set; }
}

