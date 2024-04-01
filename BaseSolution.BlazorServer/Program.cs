using Autofac.Core;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.BlazorServer.Data;
using BaseSolution.BlazorServer.Repositories.Implements;
using BaseSolution.BlazorServer.Repositories.Interfaces;
using BaseSolution.Infrastructure.Extensions;
using BaseSolution.Infrastructure.Implements.Repositories.ReadOnly;
using BaseSolution.Infrastructure.Implements.Repositories.ReadWrite;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using MudBlazor.Services;

namespace BaseSolution.BlazorServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);
            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddMudServices();

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
            builder.Services.AddTransient<IFilmScheduleRoomRepo, FilmScheduleRoomRepo>();


            builder.Services.AddHttpClient("API", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["BackEndAPIURL"]!);
                // Cấu hình các thiết lập khác của HttpClient
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

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}
