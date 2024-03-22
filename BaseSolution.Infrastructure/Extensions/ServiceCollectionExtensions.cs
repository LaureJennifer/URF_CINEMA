using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Infrastructure.Database.AppDbContext;
using BaseSolution.Infrastructure.Implements.Repositories.ReadOnly;
using BaseSolution.Infrastructure.Implements.Repositories.ReadWrite;
using BaseSolution.Infrastructure.Implements.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaseSolution.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            #region App DBContext
            services.AddDbContextPool<AppReadOnlyDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });

            services.AddDbContextPool<AppReadWriteDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });
            #endregion

            services.AddDbContextPool<ExampleReadOnlyDbContext>(options =>
            {
                // Configure your DbContext options here
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });

            services.AddDbContextPool<ExampleReadWriteDbContext>(options =>
            {
                // Configure your DbContext options here
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });

            services.AddTransient<ILocalizationService, LocalizationService>();
            services.AddTransient<IUserReadOnlyRepository, UserReadOnlyRepository>();
            services.AddTransient<IUserReadWriteRepository, UserReadWriteRepository>();
            services.AddTransient<ICustomerReadWriteRepository, CustomerReadWriteRepository>();
            services.AddTransient<ICustomerReadOnlyRepository, CustomerReadOnlyRepository>();
            services.AddTransient<IFilmReadWriteRepository, FilmReadWriteRepository>();
            services.AddTransient<IFilmReadOnlyRepository, FilmReadOnlyRepository>();
            services.AddTransient<IRoleReadWriteRepository, RoleReadWriteRepository>();
            services.AddTransient<IRoleReadOnlyRepository, RoleReadOnlyRepository>();
            services.AddTransient<IDepartmentReadWriteRepository, DepartmentReadWriteRepository>();
            services.AddTransient<IDepartmentReadOnlyRepository, DepartmentReadOnlyRepository>();
            services.AddTransient<IFilmScheduleReadWriteRepository, FilmScheduleReadWriteRepository>();
            services.AddTransient<IFilmScheduleReadOnlyRepository, FilmScheduleReadOnlyRepository>();
            services.AddTransient<IRoomLayoutReadWriteRepository, RoomLayoutReadWriteRepository>();
            services.AddTransient<IRoomLayoutReadOnlyRepository, RoomLayoutReadOnlyRepository>();
            services.AddTransient<IPaymentMethodReadWriteRepository, PaymentMethodReadWriteRepository>();
            services.AddTransient<IPaymentMethodReadOnlyRepository, PaymentMethodReadOnlyRepository>();
            services.AddTransient<ISeatReadWriteRepository, SeatReadWriteRepository>();
            services.AddTransient<ISeatReadOnlyRepository, SeatReadOnlyRepository>();
            return services;
        }
    }
}