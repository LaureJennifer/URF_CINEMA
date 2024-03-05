using BaseSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Database.AppDbContext
{
    public class AppReadWriteDbContext : DbContext
    {

        public AppReadWriteDbContext()
        {
        }
        public AppReadWriteDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppReadWriteDbContext).Assembly);
            modelBuilder.Entity<DepartmentFilmEntity>()
            .HasNoKey();
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
        public DbSet<BillDetailEntity> BillDetailEntities { get; set; }
        public DbSet<DepartmentEntity> DepartmentEntities { get; set; }
        public DbSet<DepartmentFilmEntity> DepartmentFilmEntities { get; set; }
        public DbSet<DepartmentRoomEntity> DepartmentRoomEntities { get; set; }
        public DbSet<FacilityEntity> FacilityEntities { get; set; }
        public DbSet<FilmEntity> FilmEntities { get; set; }
        public DbSet<FilmScheduleEntity> FilmScheduleEntities { get; set; }
        public DbSet<RoleEntity> RoleEntities { get; set; }
        public DbSet<RoomEntity> RoomEntities { get; set; }
        public DbSet<RoomSeatEntity> RoomSeatEntities { get; set; }
        public DbSet<SeatEntity> SeatEntities { get; set; }
        public DbSet<SneakShowEntity> SneakShowEntities { get; set; }
        public DbSet<UserEntity> UserEntities { get; set; }
        public DbSet<UserRoleEntity> UserRoleEntities { get; set; }
        #endregion
    }
}
