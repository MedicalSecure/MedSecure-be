using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Yarp.ReverseProxy.Transforms;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Routing;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.AddServerHeader = false;
});

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("OidcProxy:ReverseProxy"));

//builder.Services.AddAuthentication("MicrosoftOidc")
//    .AddOpenIdConnect("MicrosoftOidc", oidcOptions =>
//    {
//        oidcOptions.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//        oidcOptions.CallbackPath = new PathString("/signin-oidc");
//        // oidcOptions.SignedOutCallbackPath = new PathString("/signout-callback-oidc");

//        // Add scopes to the Scope collection
//        oidcOptions.Scope.Add("openid");
//        oidcOptions.Scope.Add("profile");
//        oidcOptions.Scope.Add("offline_access");
//        oidcOptions.Scope.Add("https://graph.microsoft.com/User.Read");
//        oidcOptions.Scope.Add("https://medsecure.onmicrosoft.com/eca18d02-0eef-4bd9-bb5b-0f051358d451/Weather.Get");

//        // Set other OIDC options
//        oidcOptions.Authority = "https://login.microsoftonline.com/0d7f968d-56cb-4ebf-b490-ee9e8c8c4566/v2.0/";
//        oidcOptions.ClientId = builder.Configuration["OidcProxy:EntraId:ClientId"];
//        oidcOptions.ClientSecret = builder.Configuration["OidcProxy:EntraId:ClientSecret"];
//        oidcOptions.ResponseType = OpenIdConnectResponseType.Code;
//        oidcOptions.MapInboundClaims = false;
//        oidcOptions.TokenValidationParameters.NameClaimType = JwtRegisteredClaimNames.Name;
//        oidcOptions.TokenValidationParameters.RoleClaimType = "role";
//    })
//    .AddCookie("Cookies");


//builder.Services.ConfigureCookieOidcRefresh("Cookies", "MicrosoftOidc");


builder.Services.AddAuthentication("MicrosoftOidc")
    .AddOpenIdConnect("MicrosoftOidc", oidcOptions =>
    {
        oidcOptions.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        oidcOptions.CallbackPath = new PathString("/signin-oidc");
        //oidcOptions.SignedOutCallbackPath = new PathString("/signout-callback-oidc");
        oidcOptions.Scope.Add("https://medsecure.onmicrosoft.com/eca18d02-0eef-4bd9-bb5b-0f051358d451/Weather.Get");
        oidcOptions.Authority = "https://login.microsoftonline.com/0d7f968d-56cb-4ebf-b490-ee9e8c8c4566/v2.0/";

        oidcOptions.ClientId = "eca18d02-0eef-4bd9-bb5b-0f051358d451";
        oidcOptions.ClientSecret = "u7y8Q~~lhEC3JOSTideC1cwaEqN6Gy4r3x4IUcLb";

        oidcOptions.ResponseType = OpenIdConnectResponseType.Code;
        oidcOptions.MapInboundClaims = false;
        oidcOptions.TokenValidationParameters.NameClaimType = JwtRegisteredClaimNames.Name;
        oidcOptions.TokenValidationParameters.RoleClaimType = "role";
    })
    .AddCookie("Cookies");

builder.Services.ConfigureCookieOidcRefresh("Cookies", "MicrosoftOidc");

builder.Services.AddAuthorization();

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

//builder.Services.AddFluentUIComponents();

builder.Services.AddScoped<AuthenticationStateProvider, PersistingAuthenticationStateProvider>();

//builder.Services.AddHttpForwarderWithServiceDiscovery();
builder.Services.AddHttpContextAccessor();

var apiBaseAddress = "http://localhost:5041";

//For ACA
if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
{
    apiBaseAddress = "http://weatherapi";
}

builder.Services.AddHttpClient<IWeatherForecaster, ServerWeatherForecaster>(httpClient =>
{
    httpClient.BaseAddress = new(apiBaseAddress);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    //To make https work
    app.UseForwardedHeaders(new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedProto
    });
}

if (app.Environment.IsDevelopment())
{
    app.MapForwarder("/weather-forecast", "https://localhost:7006", transformBuilder =>
    {
        transformBuilder.AddRequestTransform(async transformContext =>
        {
            var accessToken = await transformContext.HttpContext.GetTokenAsync("access_token");
            transformContext.ProxyRequest.Headers.Authorization = new("Bearer", accessToken);
        });
    }).RequireAuthorization();
}
else
{
    app.MapForwarder("/weather-forecast", "http://weatherapi", transformBuilder =>
    {
        transformBuilder.AddRequestTransform(async transformContext =>
        {
            var accessToken = await transformContext.HttpContext.GetTokenAsync("access_token");
            transformContext.ProxyRequest.Headers.Authorization = new("Bearer", accessToken);
        });
    }).RequireAuthorization();
}

app.MapGroup("/authentication").MapLoginAndLogout();

app.MapGroup("/authentication").MapUserInfo();

app.MapGroup("/authentication").MapWeatherForecaster(app.Services.GetRequiredService<IHttpClientFactory>().CreateClient(), app.Services.GetRequiredService<IHttpContextAccessor>());

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();


app.UseEndpoints(endpoints =>
{
    ReverseProxyConventionBuilder reverseProxyConventionBuilder = endpoints.MapReverseProxy();
});

app.Run();
