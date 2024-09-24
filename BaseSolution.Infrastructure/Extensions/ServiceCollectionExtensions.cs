using BaseSolution.Application.DataTransferObjects.Account.Request;
using BaseSolution.Application.Interfaces.Login;
using BaseSolution.Application.Interfaces.Repositories;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Infrastructure.Database.AppDbContext;
using BaseSolution.Infrastructure.Implements.Repositories;
using BaseSolution.Infrastructure.Implements.Repositories.Login;
using BaseSolution.Infrastructure.Implements.Repositories.ReadOnly;
using BaseSolution.Infrastructure.Implements.Repositories.ReadWrite;
using BaseSolution.Infrastructure.Implements.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static BaseSolution.Application.DataTransferObjects.Account.Request.LoginInputRequest;

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

            services.AddTransient<IRoomReadWriteRepository, RoomReadWriteRepository>();
            services.AddTransient<IRoomReadOnlyRepository, RoomReadOnlyRepository>();

            services.AddTransient<IBillReadWriteRepository, BillReadWriteRepository>();
            services.AddTransient<IBillReadOnlyRepository, BillReadOnlyRepository>();

            services.AddTransient<IBookingReadWriteRepository, BookingReadWriteRepository>();
            services.AddTransient<IBookingReadOnlyRepository, BookingReadOnlyRepository>();

            services.AddTransient<ITicketReadOnlyRepository, TicketReadOnlyRepository>();
            services.AddTransient<ITicketReadWriteRepository, TicketReadWriteRepository>();

            services.AddTransient<IFilmDetailReadOnlyRepository, FilmDetailReadOnlyRepository>();
            services.AddTransient<IFilmDetailReadWriteRepository, FilmDetailReadWriteRepository>();

            services.AddTransient<IDepartmentFilmReadWriteRepository, DepartmentFilmReadWriteRepository>();
            services.AddTransient<IDepartmentFilmReadOnlyRepository, DepartmentFilmReadOnlyRepository>();

            services.AddTransient<IFilmScheduleRoomReadWriteRepository, FilmScheduleRoomReadWriteRepository>();
            services.AddTransient<IFilmScheduleRoomReadOnlyRepository, FilmScheduleRoomReadOnlyRepository>();

            services.AddTransient<ITransactionReadWriteRepository, TransactionReadWriteRepository>();
            services.AddTransient<ITransactionReadOnlyRepository, TransactionReadOnlyRepository>();

            services.AddTransient<IBillStatisticReadOnlyRespository, BillStatisticReadOnlyRespository>();

            services.AddTransient<ITicketStatisticReadOnlyRespository, TicketStatisticReadOnlyRespository>();

            services.AddTransient<IFilmStatisticReadOnlyRespository, FilmStatisticReadOnlyRespository>();

            services.AddTransient<EntityStatusExtensions>();

            services.AddScoped<IValidator<LoginInputRequest>, LoginValication>();
            services.AddTransient<ILoginService, LoginService>();

            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ICurrentUser, CurrentUser>();
            //services.AddSingleton<IVnPayService, VnPayService>();

            return services;
        }
    }
}