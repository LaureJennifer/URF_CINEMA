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

            #region Seed Data
            modelBuilder.Entity<RoleEntity>().HasData(
                new RoleEntity { Id = Guid.Parse("e0e12a8a-10e6-4186-b5df-81c7c923ec0f"),Code = "R1", Name = "Admin",Description = "AAA"},
                new RoleEntity { Id = Guid.Parse("bdd5ec52-c76e-4b5a-af34-978f4671d7bb"),Code = "R2", Name = "Staff", Description = "AAA" }
                );

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity { Id = Guid.Parse("b9e15891-c001-4068-99f1-82ab7df84850"),IdentificationNumber = "0123456789",Address = "A1",EducationLevel = "Đại học", Code = "U1",Name="Đỗ Đăng Thiệu",PassWord="Admin123",Email="Thieuadmin123@gmail.com",PhoneNumber="0363615832",UrlImage= "https://tse1.mm.bing.net/th?id=OIP.xqYunaXLEIiIBgbHGncjBQHaHa&pid=Api&rs=1&c=1&qlt=95&w=96&h=96",RoleId= Guid.Parse("e0e12a8a-10e6-4186-b5df-81c7c923ec0f")},
                new UserEntity { Id = Guid.Parse("3e7f0a2e-a567-425c-99b2-c2c4dc63bce8"), IdentificationNumber = "0123456789", Address = "A2", EducationLevel = "Đại học", Code = "U2", Name = "Dương Kiều Trang", PassWord = "Staff123", Email = "Trangstaff123@gmail.com",PhoneNumber = "0363615832", UrlImage = "https://tse1.mm.bing.net/th?id=OIP.xqYunaXLEIiIBgbHGncjBQHaHa&pid=Api&rs=1&c=1&qlt=95&w=96&h=96", RoleId = Guid.Parse("bdd5ec52-c76e-4b5a-af34-978f4671d7bb") }
                );

            modelBuilder.Entity<CustomerEntity>().HasData(
                new CustomerEntity { Id = Guid.Parse("a6d296a5-4d53-4f01-a152-f2a99b6ba836"), Code = "C1", Name = "Đỗ Đăng Thiệu", PassWord = "Customer123", Email = "ThieuCustomer123@gmail.com", UrlImage = "https://tse1.mm.bing.net/th?id=OIP.xqYunaXLEIiIBgbHGncjBQHaHa&pid=Api&rs=1&c=1&qlt=95&w=96&h=96", Address = "Hà Nội", PhoneNumber = "0363615832", IdentificationNumber = "012345678923", DateOfBirth = DateTimeOffset.Parse("2004-10-18"),CustomerType = "Regular" },
                new CustomerEntity { Id = Guid.Parse("ae6067ac-d44f-4540-b753-ad992fdd9adf"), Code = "C2", Name = "Dương Kiều Trang", PassWord = "Customer123", Email = "TrangCustomer123@gmail.com", UrlImage = "https://tse1.mm.bing.net/th?id=OIP.xqYunaXLEIiIBgbHGncjBQHaHa&pid=Api&rs=1&c=1&qlt=95&w=96&h=96", Address = "Tuyên Quang", PhoneNumber = "0363615832", IdentificationNumber = "012345678923", DateOfBirth = DateTimeOffset.Parse("2004-01-02"),CustomerType = "Vip" }
                );

            modelBuilder.Entity<DepartmentEntity>().HasData(
                new DepartmentEntity { Id = Guid.Parse("091d4f10-6da5-44c1-2f17-08dc519d17d1"), Code = "D1", Name = "Thanh Xuân", AddressCode = "01-01-02", AddressCodeFormat = "QG-TP-KV", Email = "ThieuCustomer123@gmail.com", Address = "Thanh Xuân", PhoneNumber = "0363615832"},
                new DepartmentEntity { Id = Guid.Parse("eb73ecc0-a311-45ab-bb7b-bd909062deb7"), Code = "D2", Name = "Đan Phượng", AddressCode = "01-01-02", AddressCodeFormat = "QG-TP-KV", Email = "TrangCustomer123@gmail.com", Address = "Đan Phượng", PhoneNumber = "0363615832"}
                );
            modelBuilder.Entity<FilmEntity>().HasData(
                new FilmEntity
                {
                    Id = Guid.Parse("57a3374b-63a6-40f3-bc5a-7ce3d0dc7486"),
                    Code = "F1",
                    Title = "Cám",
                    Actor = "Lâm Thanh Mỹ, Rima Thanh Vy"
                ,
                    AgeRating = "P18",
                    Description = "Câu chuyện phim là dị bản kinh dị đẫm máu lấy cảm hứng từ truyện cổ tích nổi tiếng Tấm Cám, nội dung chính của phim xoay quanh Cám - em gái cùng cha khác mẹ của Tấm đồng thời sẽ có nhiều nhân vật và chi tiết sáng tạo, gợi cảm giác vừa lạ vừa quen cho khán giả."
                ,
                    DirectedBy = "Trần Hữu Tấn",
                    Genres = "Kinh dị",
                    Duration = "122 phút",
                    Language = "Tiếng Việt",
                    ReleaseDate = DateTimeOffset.Parse("2024-09-24"),
                    PosterURL = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f10%2fban%2Dsao%2Dcua%2D800wx1200h%2D161119%2D100924%2D16.jpg",
                    UrlImage = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f10%2fban%2Dsao%2Dcua%2D800wx1200h%2D161119%2D100924%2D16.jpg",
                    TrailerURL = "https://www.youtube.com/0af18c1c-84bd-4521-852e-f43881dfd307",
                    Script = "2D",
                    Status = Domain.Enums.EntityStatus.Active,
                    CreatedTime = DateTimeOffset.UtcNow
                },
                new FilmEntity
                {
                    Id = Guid.Parse("86797ac1-3236-4aa2-8d0b-eacff3839954"),
                    Code = "F2",
                    Title = "Transformers Một",
                    Actor = "Chris Hemsworth, Brian Tyree Henry, Scarlett Johansson",
                    AgeRating = "C13",
                    Description = "Câu chuyện về nguồn gốc chưa từng được hé lộ của Optimus Prime và Megatron. Hai nhân vật được biết đến như những kẻ thù truyền kiếp, nhưng cũng từng là những người anh em gắn bó, đã thay đổi vận mệnh của Cybertron mãi mãi.",
                    DirectedBy = "Josh Cooley",
                    Genres = "Phiêu lưu, Hoạt hình",
                    Duration = "120 phút",
                    Language = "Tiếng Việt",
                    ReleaseDate = DateTimeOffset.Parse("2024-09-27"),
                    PosterURL = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f11%2ftf1%2Dintl%2Dallspark%2Ddgtl%2Donline%2Dpayoff%2Dkeyart%2Dvie%2D400x633%2D134254%2D110924%2D51.jpg",
                    UrlImage = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f11%2ftf1%2Dintl%2Dallspark%2Ddgtl%2Donline%2Dpayoff%2Dkeyart%2Dvie%2D400x633%2D134254%2D110924%2D51.jpg",
                    TrailerURL = "https://www.youtube.com/c4c6d3f5-e1e8-4720-ab23-827288054b0f7",
                    Script = "3D",
                    Status = Domain.Enums.EntityStatus.Active,
                    CreatedTime = DateTimeOffset.UtcNow,
                }
                );
            modelBuilder.Entity<FilmScheduleEntity>().HasData(
                new FilmScheduleEntity { Id = Guid.Parse("98378032-035c-4a82-b0d9-a42204ed96ee"),ShowDate = DateTimeOffset.Parse("2024-09-24"), ShowTime = DateTimeOffset.Parse("12:00"),Status = Domain.Enums.EntityStatus.Active},
                new FilmScheduleEntity { Id = Guid.Parse("d0031b0d-73f1-40e5-97b5-ef3402775cc0"), ShowDate = DateTimeOffset.Parse("2024-09-24"), ShowTime = DateTimeOffset.Parse("15:00"), Status = Domain.Enums.EntityStatus.Active },
                new FilmScheduleEntity { Id = Guid.Parse("c3f0f455-03e3-4acb-8acc-88a82723d37b"), ShowDate = DateTimeOffset.Parse("2024-09-24"), ShowTime = DateTimeOffset.Parse("18:00"), Status = Domain.Enums.EntityStatus.Active }
                );
            #endregion
            
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
        public DbSet<BookingEntity> BookingEntities { get; set; }
        public DbSet<DepartmentEntity> DepartmentEntities { get; set; }
        public DbSet<DepartmentFilmEntity> DepartmentFilmEntities { get; set; }
        public DbSet<DepartmentProductEntity> DepartmentProductEntities { get; set; }
        public DbSet<CustomerPromotionEntity> CustomerPromotionEntities { get; set; }
        public DbSet<CustomerEntity> CustomerEntities { get; set; }
        public DbSet<FilmDetailEntity> FilmDetailEntities { get; set; }
        public DbSet<FilmEntity> FilmEntities { get; set; }
        public DbSet<FilmScheduleEntity> FilmScheduleEntities { get; set;}
        public DbSet<FilmScheduleRoomEntity> FilmScheduleRoomEntities { get; set; }
        public DbSet<PaymentMethodEntity> PaymentMethodEntities { get; set; }
        public DbSet<ProductEntity> ProductEntities { get; set; }
        public DbSet<PromotionEntity> PromotionEntities { get; set; }

        public DbSet<RoleEntity> RoleEntities { get; set; }
        public DbSet<RoomEntity> RoomEntities { get; set; }
        public DbSet<RoomLayoutEntity> RoomLayoutEntities { get;set; }
        public DbSet<SeatEntity> SeatEntities { get; set; }
        public DbSet<ShiftDepartmentEntity> ShiftDepartmentEntities { get; set; }
        public DbSet<ShiftEntity> ShiftEntities { get; set; }
        public DbSet<ShiftUserEntity> ShiftUserEntities { get; set; }
        public DbSet<TicketEntity> TicketEntities { get; set; }
        public DbSet<UserEntity> UserEntities { get; set; }
        public DbSet<TransactionEntity> TransactionEntities { get; set; }
        #endregion
    }
}
