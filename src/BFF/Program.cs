using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Microsoft.Identity.Web;
using OidcProxy.Net;
using OidcProxy.Net.EntraId;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Identity.Client;
using System.IdentityModel.Tokens.Jwt;
using Jose;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.AddServerHeader = false;
});

var services = builder.Services;
var configuration = builder.Configuration;

services.AddScoped<CaeClaimsChallengeService>();
services.AddScoped<MsGraphService>();

var config = configuration
    .GetSection("OidcProxy")
    .Get<EntraIdProxyConfig>();

services.AddEntraIdProxy(config ?? new EntraIdProxyConfig());

builder.Services.AddControllers();

services.AddHttpClient();
services.AddOptions();

var scopes = configuration.GetValue<string>("DownstreamApi:Scopes");
string[] initialScopes = scopes!.Split(' ');

string[] defaultscopes = { "https://graph.microsoft.com/.default" };

services.AddMicrosoftIdentityWebAppAuthentication(configuration, "MicrosoftEntraID")
    .EnableTokenAcquisitionToCallDownstreamApi(defaultscopes)
    .AddMicrosoftGraph(defaultScopes: defaultscopes)
    .AddInMemoryTokenCaches();

services.AddAuthentication()
    .AddMicrosoftAccount(ms =>
    {
        ms.ClientId = configuration["MicrosoftEntraID:ClientId"];
        ms.ClientSecret = configuration["MicrosoftEntraID:ClientSecret"];
        ms.SaveTokens = true;
    });

// The check is only for single scopes
services.Configure<CookieAuthenticationOptions>(CookieAuthenticationDefaults.AuthenticationScheme,
    options => options.Events = new RejectSessionCookieWhenAccountNotInCacheEvents(defaultscopes));

services.AddControllersWithViews(options =>
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));

var app = builder.Build();

app.UseRouting();

app.UseEntraIdProxy();



app.Map("/api/weatherforecast", async (HttpContext context, HttpClient httpClient) =>
{
    // Authenticate the request
    var authenticationResult = await context.AuthenticateAsync();
    if (!authenticationResult.Succeeded)
    {
        // If authentication fails, return 401 Unauthorized
        context.Response.StatusCode = 401;
        return;
    }

    // Retrieve the access token from the authentication result
    var accessTossken = authenticationResult.Properties.GetTokenValue("access_token");
    var accessToken = context.Request.Cookies[".AspNetCore.Cookies"];

    if (string.IsNullOrEmpty(accessToken))
    {
        // If access token is not found, return 401 Unauthorized
        context.Response.StatusCode = 401;
        return;
    }

    // Decode the token to get claims
    var handler = new JwtSecurityTokenHandler();
    JwtSecurityToken jwtToken;

    try
    {
        jwtToken = handler.ReadJwtToken(accessToken);
    }
    catch (ArgumentException)
    {
        context.Response.StatusCode = 401;
        return;
    }

    // Extract claims
    var claims = jwtToken.Claims;



    // Create a confidential client application using your Azure AD client ID and client secret
    var confidentialClientApp = ConfidentialClientApplicationBuilder
        .Create("eca18d02-0eef-4bd9-bb5b-0f051358d451")
        .WithClientSecret("u7y8Q~~lhEC3JOSTideC1cwaEqN6Gy4r3x4IUcLb")
        .WithAuthority(new Uri("https://login.microsoftonline.com/0d7f968d-56cb-4ebf-b490-ee9e8c8c4566"))
        .Build();

    // Define the scopes required for accessing your API
    string[] scopes = { "api://medsecure.onmicrosoft.com/access_as_user" };
   
    // Acquire a token for the specified scopes
    var result = await confidentialClientApp.AcquireTokenForClient(defaultscopes).ExecuteAsync();

    // Extract the access token from the result
   accessToken = result.AccessToken;

    // Set the authorization header with the access token
    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

    try
    {
        // Make the HTTP GET requests to fetch weather forecast data
        var usaResponse = await httpClient.GetAsync("http://localhost:8080/api/WeatherForecast/usa");
        var saharaResponse = await httpClient.GetAsync("http://localhost:8080/api/WeatherForecast/sahara");

        // Check if the responses are successful
        if (usaResponse.IsSuccessStatusCode && saharaResponse.IsSuccessStatusCode)
        {
            // Read the response content as strings
            var usa = await usaResponse.Content.ReadAsStringAsync();
            var sahara = await saharaResponse.Content.ReadAsStringAsync();

            // Return the combined data as JSON in the HTTP response
            await context.Response.WriteAsJsonAsync(new
            {
                usa = usa,
                sahara = sahara
            });
        }
        else
        {
            // If any of the requests fail, return the status code of the failed request
            context.Response.StatusCode = (int)usaResponse.StatusCode;
            return;
        }
    }
    catch (HttpRequestException)
    {
        // Handle exceptions related to HTTP requests
        context.Response.StatusCode = 500; // Internal Server Error
        return;
    }
});

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

// Include MapAccountEndpoints
app.MapAccountEndpoints();

// Include MapUserEndpoints
app.MapUserEndpoints();

app.Run();
