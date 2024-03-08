using BaseSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseSolution.Infrastructure.Database.AppDbContext
{
    public class AppReadOnlyDbContext : DbContext
    {
        public AppReadOnlyDbContext()
        {
        }
        public AppReadOnlyDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppReadOnlyDbContext).Assembly);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=ADMIN\\SQLEXPRESS;Initial Catalog=DA1_Cinema;Integrated Security=True;TrustServerCertificate=true");
            }
        }
        #region DBSet
        public DbSet<BillEntity> BillEntities { get; set; }
        public DbSet<BookingEntity> BookingEntities { get; set; }
        public DbSet<DepartmentEntity> DepartmentEntities { get; set; }
        public DbSet<DepartmentFilmEntity> DepartmentFilmEntities { get; set; }
        public DbSet<CustomerEntity> CustomerEntities { get; set; }
        public DbSet<FilmDetailEntity> FilmDetailEntities { get; set; }
        public DbSet<FilmEntity> FilmEntities { get; set; }
        public DbSet<FilmScheduleEntity> FilmScheduleEntities { get; set;}
        public DbSet<FilmScheduleRoomEntity> FilmScheduleRoomEntities { get; set; }
        public DbSet<PaymentMethodEntity> PaymentMethodEntities { get; set; }
        public DbSet<RoleEntity> RoleEntities { get; set; }
        public DbSet<RoomEntity> RoomEntities { get; set; }
        public DbSet<RoomLayoutEntity> RoomLayoutEntities { get;set; }
        public DbSet<SeatEntity> SeatEntities { get; set; }
        public DbSet<TicketEntity> TicketEntities { get; set; }
        public DbSet<UserEntity> UserEntities { get; set; }
        public DbSet<TransactionEntity> TransactionEntities { get; set; }
        #endregion
    }
}
