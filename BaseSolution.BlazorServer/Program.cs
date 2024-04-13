using Autofac.Core;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.BlazorServer.Data;
using BaseSolution.BlazorServer.Repositories;
using BaseSolution.BlazorServer.Repositories.Implements;
using BaseSolution.BlazorServer.Repositories.Interfaces;
using BaseSolution.Infrastructure.Extensions;
using BaseSolution.Infrastructure.Implements.Repositories.ReadOnly;
using BaseSolution.Infrastructure.Implements.Repositories.ReadWrite;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.IdentityModel.Tokens;
using MudBlazor.Services;
using System.Text;

namespace BaseSolution.BlazorServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);
            // Add services to the container.

            builder.Configuration.AddJsonFile("appsettings.json");
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddMudServices(config =>
            {
                config.PopoverOptions.ThrowOnDuplicateProvider = false;
            });
            builder.Services.AddAutoMapper();
            builder.Services.AddLocalization(builder.Configuration);
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddEventBus(builder.Configuration);
            builder.Services.AddFluentValidation();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
            builder.Services.AddTransient<IBookingRepo, BookingRepo>();
            builder.Services.AddTransient<IFilmRepo, FilmRepo>();
            builder.Services.AddTransient<IUserRepo, UserRepo>();
            builder.Services.AddTransient<IRoleRepo, RoleRepo>();
            builder.Services.AddTransient<ICustomerRepo, CustomerRepo>();
            builder.Services.AddTransient<ITicketRepo, TicketRepo>();
            builder.Services.AddTransient<IBillRepo, BillRepo>();
            builder.Services.AddTransient<IRoomRepo, RoomRepo>();
            builder.Services.AddTransient<IDepartmentRepo, DepartmentRepo>();
            builder.Services.AddTransient<IFilmDetailRepo, FilmDetailRepo>();
            builder.Services.AddTransient<IRoomLayoutRepo, RoomLayoutRepo>();
            builder.Services.AddTransient<IRoomRepo, RoomRepo>();
            builder.Services.AddTransient<ISeatRepo, SeatRepo>();
            builder.Services.AddTransient<IFilmScheduleRoomRepo, FilmScheduleRoomRepo>();
            builder.Services.AddTransient<IBillStatisticRepo, BillStatisticRepo>();
            builder.Services.AddTransient<IFilmStatisticRepo, FilmStatisticRepo>();
            builder.Services.AddTransient<IDepartmentFilmRepo, DepartmentFilmRepo>();
            builder.Services.AddTransient<ITransactionRepo, TransactionRepo>();
            builder.Services.AddTransient<IPaymentMethodRepo, PaymentMethodRepo>();
            builder.Services.AddTransient<IRoomByFilmScheduleRepo, RoomByFilmScheduleRepo>();
            builder.Services.AddTransient<IFilmScheduleRepo, FilmScheduleRepo>();

            builder.Services.AddTransient<ILoginRepo, LoginRepo>();

            builder.Services.AddTransient<IFileHandlingReadWriteRepository, FileHandlingReadWriteRepository>();
            builder.Services.AddTransient<IFileHandlingReadOnlyRepository, FileHandlingReadOnlyRepository>();

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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}
