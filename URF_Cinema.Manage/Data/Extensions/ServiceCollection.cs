using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Manage.Repositories;
using URF_Cinema.Manage.Repositories.Implements;
using URF_Cinema.Manage.Repositories.Interfaces;
using URF_Cinema.Infrastructure.Implements.Repositories.ReadOnly;
using Microsoft.AspNetCore.Components.Authorization;

namespace URF_Cinema.Manage.Data.Extensions
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddConfigAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
            services.AddTransient<IBookingRepo, BookingRepo>();
            services.AddTransient<IFilmRepo, FilmRepo>();
            services.AddTransient<IUserRepo, UserRepo>();
            services.AddTransient<IRoleRepo, RoleRepo>();
            services.AddTransient<ICustomerRepo, CustomerRepo>();
            services.AddTransient<ITicketRepo, TicketRepo>();
            services.AddTransient<IBillRepo, BillRepo>();
            services.AddTransient<IRoomRepo, RoomRepo>();
            services.AddTransient<IDepartmentRepo, DepartmentRepo>();
            services.AddTransient<IFilmDetailRepo, FilmDetailRepo>();
            services.AddTransient<IRoomLayoutRepo, RoomLayoutRepo>();
            services.AddTransient<IRoomRepo, RoomRepo>();
            services.AddTransient<ISeatRepo, SeatRepo>();
            services.AddTransient<IFilmScheduleRoomRepo, FilmScheduleRoomRepo>();
            services.AddTransient<IBillStatisticRepo, BillStatisticRepo>();
            services.AddTransient<IFilmStatisticRepo, FilmStatisticRepo>();
            services.AddTransient<IDepartmentFilmRepo, DepartmentFilmRepo>();
            services.AddTransient<ITransactionRepo, TransactionRepo>();
            services.AddTransient<IPaymentMethodRepo, PaymentMethodRepo>();
            services.AddTransient<IRoomByFilmScheduleRepo, RoomByFilmScheduleRepo>();
            services.AddTransient<IFilmScheduleRepo, FilmScheduleRepo>();
            services.AddTransient<ISendMailCustomer, SendMailCustomer>();
            services.AddTransient<ILoginRepo, LoginRepo>();
            //services.AddTransient<IFileHandlingReadWriteRepository, FileHandlingReadWriteRepository>();
            services.AddTransient<IFileHandlingReadOnlyRepository, FileHandlingReadOnlyRepository>();

            return services;
        }
    }
}
