using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Scalar.AspNetCore;
using VetClinic.Auth.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.AddServiceDefaults();
builder.Services.AddAuthentication("Cookies")
.AddCookie()
.AddGoogle(options =>
{
    options.ClientId = builder.Configuration["Auth:Google:ClientId"];
    options.ClientSecret = builder.Configuration["Auth:Google:ClientSecret"];
    options.Scope.Add("email");
    options.Scope.Add("profile");
    options.CallbackPath = new PathString("/auth/signin-google-123");
    //options.SaveTokens = true;
});

builder.Services.AddAuthorization();
builder.Services.AddSingleton<JwtTokenService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
        options.WithTitle("My .NET 10 API")
            .WithTheme(ScalarTheme.Moon) // Use themes like Dark, Moon, Purple, etc.
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
    );
}

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultEndpoints();
app.MapGet("/", () => "Hello World!");

// login
app.MapGet("/auth/login", () => 
    Results.Challenge(
        new AuthenticationProperties{ RedirectUri = "https://localhost:7095/auth/callback" }, 
        [GoogleDefaults.AuthenticationScheme]));

// callback
app.MapGet("/auth/callback", async (HttpContext context, JwtTokenService jwtTokenService) =>
{
    var result = await context.AuthenticateAsync();
    if (!result.Succeeded)
    {
        return Results.Unauthorized();
    }
    
    var email = result.Principal.FindFirstValue(ClaimTypes.Email);
    var accessToken = jwtTokenService.CreateToken(Guid.NewGuid(), email);
    return Results.Ok(new
        { accessToken }
    );

});

app.Run();