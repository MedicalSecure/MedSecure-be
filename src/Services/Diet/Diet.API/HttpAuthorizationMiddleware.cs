
using System;
using System.Net;

namespace Diet.API;

// Middleware for HTTP-based authorization
internal class HttpAuthorizationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly HttpAuthorizationOptions _options;

    public HttpAuthorizationMiddleware(RequestDelegate next, HttpAuthorizationOptions options)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _options = options ?? throw new ArgumentNullException(nameof(options));
    }

    public async Task Invoke(HttpContext context)
    {
        // Check if the request is for Swagger endpoint and allowed
        if (_options.AllowSwagger && IsSwaggerEndpoint(context))
        {
            await _next(context);
            return;
        }

        // Check if the request does not come from the API gateway
        if (_options.OnlyFromApiGateway && !IsRequestFromApiGateway(context))
        {
            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            return;
        }

        // Allow the request to continue
        await _next(context);
    }

    private bool IsSwaggerEndpoint(HttpContext context)
    {
        return context.Request.Path.StartsWithSegments("/swagger");
    }

    private bool IsRequestFromApiGateway(HttpContext context)
        {
            var originHeader = context.Request.Headers["Origin"];
            var fromApiGatewayHeader = context.Request.Headers["FromApiGateway"];

            // Check if the request has both the Origin header and FromApiGateway header
            return !string.IsNullOrEmpty(originHeader) &&
                   originHeader.ToString().Equals("https://localhost:4200", StringComparison.OrdinalIgnoreCase) &&
                   fromApiGatewayHeader == "true";
        }
}

internal class HttpAuthorizationOptions
{
    public bool AllowSwagger { get; set; }
    public bool OnlyFromApiGateway { get; set; }
}
