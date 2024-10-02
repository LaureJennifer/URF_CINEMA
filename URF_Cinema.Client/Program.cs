using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.IdentityModel.Tokens;
using MudBlazor.Services;
using Radzen;
using System.Text;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Client.Components;
using URF_Cinema.Client.Data.Extensions;
using URF_Cinema.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRadzenComponents();
builder.Services.AddMudServices();
//builder.Services.AddMudServices(config =>
//{
//    config.PopoverOptions.ThrowOnDuplicateProvider = false;
//});
builder.Services.AddAutoMapper();
builder.Services.AddLocalization(builder.Configuration);
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddEventBus(builder.Configuration);
builder.Services.AddFluentValidation();
builder.Services.AddAuthorizationCore();
builder.Services.AddConfigAPI(builder.Configuration);
builder.Services.AddBlazoredToast();
//builder.Configuration.AddJsonFile("appsettings.json");
builder.Services.Configure<RecaptchaOption>(builder.Configuration.GetSection(nameof(RecaptchaOption)));
builder.Services.AddSession(options =>
{
    // Configure session options here
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(ConstsToken.SecretKey)),
        ValidateIssuer = true,
        ValidIssuer = ConstsToken.Issuer,
        ValidateAudience = true,
        ValidAudience = ConstsToken.Audience,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
    };
});

builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["BackEndAPIURL"]!);
    // Cấu hình các thiết lập khác của HttpClient
});

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
