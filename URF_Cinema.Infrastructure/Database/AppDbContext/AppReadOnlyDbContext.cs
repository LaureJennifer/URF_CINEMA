using Microsoft.EntityFrameworkCore;
using URF_Cinema.Domain.Entities;
using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Infrastructure.Database.AppDbContext
{
    public class AppReadOnlyDbContext : DbContext
    {
        public AppReadOnlyDbContext()
        {
            
        }
        public AppReadOnlyDbContext(DbContextOptions<AppReadOnlyDbContext> options) : base(options)
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
                new DepartmentEntity
                {
                    Id = Guid.Parse("5fbe2704-18dd-4a5d-a053-a7fafe74ca00"), // GUID dưới dạng chuỗi
                    Code = "DEP001",
                    Name = "Cơ Sở 1",
                    Email = "coso1@example.com",
                    PhoneNumber = "0123456789",
                    AddressCode = "ADDR001",
                    Address = "123 Đường ABC, Quận 1, TP.HCM",
                    Latitude = 10.762622,
                    Longitude = 106.660172,
                    OpeningHours = "08:00",
                    ClosingHours = "17:00",
                    Status = EntityStatus.Active,
                    CreatedTime = DateTimeOffset.Now,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.Now,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                },
                new DepartmentEntity
                {
                    Id = Guid.Parse("4517d09f-4c1c-486f-b0de-fd36db91cbcb"),
                    Code = "DEP003",
                    Name = "Cơ Sở 3",
                    Email = "coso3@example.com",
                    PhoneNumber = "0123456780",
                    AddressCode = "ADDR003",
                    Address = "789 Đường DEF, Quận 3, TP.HCM",
                    Latitude = 10.773197,
                    Longitude = 106.691699,
                    OpeningHours = "08:00",
                    ClosingHours = "17:00",
                    Status = EntityStatus.Active,
                    CreatedTime = DateTimeOffset.Now,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.Now,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                },
                new DepartmentEntity
                {
                    Id = Guid.Parse("d9de26d3-77c2-4791-bb48-ccf7fe407877"),
                    Code = "DEP004",
                    Name = "Cơ Sở 4",
                    Email = "coso4@example.com",
                    PhoneNumber = "0123456781",
                    AddressCode = "ADDR004",
                    Address = "321 Đường GHI, Quận 4, TP.HCM",
                    Latitude = 10.732845,
                    Longitude = 106.693589,
                    OpeningHours = "08:00",
                    ClosingHours = "17:00",
                    Status = EntityStatus.Active,
                    CreatedTime = DateTimeOffset.Now,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.Now,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                }
               
                );
            modelBuilder.Entity<DepartmentFilmEntity>().HasData(
                new DepartmentFilmEntity { Id = Guid.Parse("c542dc4b-26a3-4dad-bb9a-5a6ef3df461b"), DepartmentId = Guid.Parse("5fbe2704-18dd-4a5d-a053-a7fafe74ca00"), FilmId = Guid.Parse("345b2f74-5f5a-4bd7-b251-c1f4086857b7"), Status = EntityStatus.Active },
                new DepartmentFilmEntity { Id = Guid.Parse("7656c0a6-18b8-4f99-933b-a8ae0725d54f"), DepartmentId = Guid.Parse("5fbe2704-18dd-4a5d-a053-a7fafe74ca00"), FilmId = Guid.Parse("6240feb7-1c07-4f9b-a117-0b0de95a32be"), Status = EntityStatus.Active },
                new DepartmentFilmEntity { Id = Guid.Parse("e5e4f93f-0c58-445d-9ed7-da2312183dd2"), DepartmentId = Guid.Parse("5fbe2704-18dd-4a5d-a053-a7fafe74ca00"), FilmId = Guid.Parse("6355ea51-ac92-42a6-a522-fa1ee2a0b4fd"), Status = EntityStatus.Active },
                new DepartmentFilmEntity { Id = Guid.Parse("1b55d173-b5d2-4db1-9cf2-4f73fb881543"), DepartmentId = Guid.Parse("5fbe2704-18dd-4a5d-a053-a7fafe74ca00"), FilmId = Guid.Parse("b6a96c37-2e5c-433d-aced-b068533e25a3"), Status = EntityStatus.Active },
                new DepartmentFilmEntity { Id = Guid.Parse("1d249fb6-31f7-4ebe-90ee-edbb26f7a0ed"), DepartmentId = Guid.Parse("5FBE2704-18DD-4A5D-A053-A7FAFE74CA00"), FilmId = Guid.Parse("768f3171-8c7a-4fbe-9abf-3a3cacf0d781"), Status = EntityStatus.Active },
                new DepartmentFilmEntity { Id = Guid.Parse("98477805-047d-4796-bd94-5311d90420b8"), DepartmentId = Guid.Parse("5fbe2704-18dd-4a5d-a053-a7fafe74ca00"), FilmId = Guid.Parse("8d106586-bbce-4441-b39b-9802c3adba3f"), Status = EntityStatus.Active },
              
                new DepartmentFilmEntity { Id = Guid.Parse("eb5cd342-b6ef-4046-9caa-24dd2e1308c4"), DepartmentId = Guid.Parse("4517d09f-4c1c-486f-b0de-fd36db91cbcb"), FilmId = Guid.Parse("345b2f74-5f5a-4bd7-b251-c1f4086857b7"), Status = EntityStatus.Active },
                new DepartmentFilmEntity { Id = Guid.Parse("9cab0b29-fe47-4753-b0b0-add4d9ddd333"), DepartmentId = Guid.Parse("4517d09f-4c1c-486f-b0de-fd36db91cbcb"), FilmId = Guid.Parse("6240feb7-1c07-4f9b-a117-0b0de95a32be"), Status = EntityStatus.Active },
                new DepartmentFilmEntity { Id = Guid.Parse("e3ac37a3-92cd-4e71-bbb8-1294840a1ac1"), DepartmentId = Guid.Parse("4517d09f-4c1c-486f-b0de-fd36db91cbcb"), FilmId = Guid.Parse("6355ea51-ac92-42a6-a522-fa1ee2a0b4fd"), Status = EntityStatus.Active },
                new DepartmentFilmEntity { Id = Guid.Parse("95b95e31-e23f-4f32-a6ca-c33cc0d60a58"), DepartmentId = Guid.Parse("4517d09f-4c1c-486f-b0de-fd36db91cbcb"), FilmId = Guid.Parse("b6a96c37-2e5c-433d-aced-b068533e25a3"), Status = EntityStatus.Active },
                new DepartmentFilmEntity { Id = Guid.Parse("17ec0bfa-a638-4bf9-b3d5-a237f44e039f"), DepartmentId = Guid.Parse("4517d09f-4c1c-486f-b0de-fd36db91cbcb"), FilmId = Guid.Parse("768f3171-8c7a-4fbe-9abf-3a3cacf0d781"), Status = EntityStatus.Active },
                new DepartmentFilmEntity { Id = Guid.Parse("ce364268-7b33-494e-b439-af93b79aa6ff"), DepartmentId = Guid.Parse("4517d09f-4c1c-486f-b0de-fd36db91cbcb"), FilmId = Guid.Parse("8d106586-bbce-4441-b39b-9802c3adba3f"), Status = EntityStatus.Active },//
             
                new DepartmentFilmEntity { Id = Guid.Parse("eb052e7b-6081-4d65-bd8f-be564a279ad6"), DepartmentId = Guid.Parse("d9de26d3-77c2-4791-bb48-ccf7fe407877"), FilmId = Guid.Parse("345b2f74-5f5a-4bd7-b251-c1f4086857b7"), Status = EntityStatus.Active },
                new DepartmentFilmEntity { Id = Guid.Parse("66dc1e55-f636-43b7-97d5-fc34764471ee"), DepartmentId = Guid.Parse("d9de26d3-77c2-4791-bb48-ccf7fe407877"), FilmId = Guid.Parse("6240feb7-1c07-4f9b-a117-0b0de95a32be"), Status = EntityStatus.Active },
                new DepartmentFilmEntity { Id = Guid.Parse("d7ddc391-8056-4444-8378-6f756c202eb7"), DepartmentId = Guid.Parse("d9de26d3-77c2-4791-bb48-ccf7fe407877"), FilmId = Guid.Parse("6355ea51-ac92-42a6-a522-fa1ee2a0b4fd"), Status = EntityStatus.Active },
                new DepartmentFilmEntity { Id = Guid.Parse("28a68b4e-7936-4ba2-8eb6-65e759c59ed7"), DepartmentId = Guid.Parse("d9de26d3-77c2-4791-bb48-ccf7fe407877"), FilmId = Guid.Parse("b6a96c37-2e5c-433d-aced-b068533e25a3"), Status = EntityStatus.Active },
                new DepartmentFilmEntity { Id = Guid.Parse("c5dc7213-bf65-42e0-adb3-fbc918624d44"), DepartmentId = Guid.Parse("d9de26d3-77c2-4791-bb48-ccf7fe407877"), FilmId = Guid.Parse("768f3171-8c7a-4fbe-9abf-3a3cacf0d781"), Status = EntityStatus.Active },
                new DepartmentFilmEntity { Id = Guid.Parse("7c2dc055-c4c4-4b07-b041-b935a437c8b4"), DepartmentId = Guid.Parse("d9de26d3-77c2-4791-bb48-ccf7fe407877"), FilmId = Guid.Parse("8d106586-bbce-4441-b39b-9802c3adba3f"), Status = EntityStatus.Active }
               
                 );

            modelBuilder.Entity<DepartmentProductEntity>().HasData(
                new DepartmentProductEntity { Id = Guid.NewGuid(), DepartmentId = Guid.Parse("5FBE2704-18DD-4A5D-A053-A7FAFE74CA00"), ProductId = Guid.Parse("77F9B2C6-3F21-4441-A6D4-04615F0F9B8D") },
                new DepartmentProductEntity { Id = Guid.NewGuid(), DepartmentId = Guid.Parse("D9DE26D3-77C2-4791-BB48-CCF7FE407877"), ProductId = Guid.Parse("77F9B2C6-3F21-4441-A6D4-04615F0F9B8D") },
                new DepartmentProductEntity { Id = Guid.NewGuid(), DepartmentId = Guid.Parse("4517D09F-4C1C-486F-B0DE-FD36DB91CBCB"), ProductId = Guid.Parse("77F9B2C6-3F21-4441-A6D4-04615F0F9B8D") },//
                new DepartmentProductEntity { Id = Guid.NewGuid(), DepartmentId = Guid.Parse("5FBE2704-18DD-4A5D-A053-A7FAFE74CA00"), ProductId = Guid.Parse("A9811229-DEA6-4EC5-BE3F-14151054EB54") },
                new DepartmentProductEntity { Id = Guid.NewGuid(), DepartmentId = Guid.Parse("D9DE26D3-77C2-4791-BB48-CCF7FE407877"), ProductId = Guid.Parse("A9811229-DEA6-4EC5-BE3F-14151054EB54") },
                new DepartmentProductEntity { Id = Guid.NewGuid(), DepartmentId = Guid.Parse("4517D09F-4C1C-486F-B0DE-FD36DB91CBCB"), ProductId = Guid.Parse("A9811229-DEA6-4EC5-BE3F-14151054EB54") },//
                new DepartmentProductEntity { Id = Guid.NewGuid(), DepartmentId = Guid.Parse("5FBE2704-18DD-4A5D-A053-A7FAFE74CA00"), ProductId = Guid.Parse("E7F18E78-5BDE-4369-87A6-2697283E7858") },
                new DepartmentProductEntity { Id = Guid.NewGuid(), DepartmentId = Guid.Parse("D9DE26D3-77C2-4791-BB48-CCF7FE407877"), ProductId = Guid.Parse("E7F18E78-5BDE-4369-87A6-2697283E7858") },
                new DepartmentProductEntity { Id = Guid.NewGuid(), DepartmentId = Guid.Parse("4517D09F-4C1C-486F-B0DE-FD36DB91CBCB"), ProductId = Guid.Parse("E7F18E78-5BDE-4369-87A6-2697283E7858") },//
                new DepartmentProductEntity { Id = Guid.NewGuid(), DepartmentId = Guid.Parse("5FBE2704-18DD-4A5D-A053-A7FAFE74CA00"), ProductId = Guid.Parse("FA7555DD-4E6D-4C76-8669-6554FF0873CD") },
                new DepartmentProductEntity { Id = Guid.NewGuid(), DepartmentId = Guid.Parse("D9DE26D3-77C2-4791-BB48-CCF7FE407877"), ProductId = Guid.Parse("FA7555DD-4E6D-4C76-8669-6554FF0873CD") },
                new DepartmentProductEntity { Id = Guid.NewGuid(), DepartmentId = Guid.Parse("4517D09F-4C1C-486F-B0DE-FD36DB91CBCB"), ProductId = Guid.Parse("FA7555DD-4E6D-4C76-8669-6554FF0873CD") },//
                new DepartmentProductEntity { Id = Guid.NewGuid(), DepartmentId = Guid.Parse("5FBE2704-18DD-4A5D-A053-A7FAFE74CA00"), ProductId = Guid.Parse("72300188-AB7B-42DD-AB9B-9F4538508833") },
                new DepartmentProductEntity { Id = Guid.NewGuid(), DepartmentId = Guid.Parse("D9DE26D3-77C2-4791-BB48-CCF7FE407877"), ProductId = Guid.Parse("72300188-AB7B-42DD-AB9B-9F4538508833") },
                new DepartmentProductEntity { Id = Guid.NewGuid(), DepartmentId = Guid.Parse("4517D09F-4C1C-486F-B0DE-FD36DB91CBCB"), ProductId = Guid.Parse("72300188-AB7B-42DD-AB9B-9F4538508833") },//
                new DepartmentProductEntity { Id = Guid.NewGuid(), DepartmentId = Guid.Parse("5FBE2704-18DD-4A5D-A053-A7FAFE74CA00"), ProductId = Guid.Parse("52831BB3-6AD0-464D-BD4D-A1973E9A9CFB") },
                new DepartmentProductEntity { Id = Guid.NewGuid(), DepartmentId = Guid.Parse("D9DE26D3-77C2-4791-BB48-CCF7FE407877"), ProductId = Guid.Parse("52831BB3-6AD0-464D-BD4D-A1973E9A9CFB") }
               );
            modelBuilder.Entity<FilmEntity>().HasData(
                new FilmEntity
                {
                    Id = Guid.Parse("345b2f74-5f5a-4bd7-b251-c1f4086857b7"),
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
                    Id = Guid.Parse("6240feb7-1c07-4f9b-a117-0b0de95a32be"),
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
                },
                new FilmEntity
                {
                    Id = Guid.Parse("6355ea51-ac92-42a6-a522-fa1ee2a0b4fd"),
                    Code = "F001",
                    Title = "The Shawshank Redemption",
                    TrailerURL = "https://www.youtube.com/c4c6d3f5-e1e8-4720-ab23-827288054b0f7",
                    Description = "Two imprisoned men bond over a number of years.",
                    PosterURL = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f24%2fb%2Dn%2Dsao%2Dc%2Da%2Dm%2Dom%2Dm%2Dpayoff%2Dposter%2Dkthuoc%2Dfacebook%2D154037%2D240924%2D43.jpg",
                    UrlImage = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f24%2fb%2Dn%2Dsao%2Dc%2Da%2Dm%2Dom%2Dm%2Dpayoff%2Dposter%2Dkthuoc%2Dfacebook%2D154037%2D240924%2D43.jpg",
                    DirectedBy = "Frank Darabont",
                    Language = "English",
                    Actor = "Tim Robbins, Morgan Freeman",
                    ReleaseDate = new DateTimeOffset(new DateTime(1994, 9, 22)),
                    Duration = "142 min",
                    Script = "Screenplay by Frank Darabont",
                    Genres = "Drama",
                    AgeRating = "R",
                    CreatedTime = DateTimeOffset.Now,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.Now,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                },
                new FilmEntity
                {
                    Id = Guid.Parse("b6a96c37-2e5c-433d-aced-b068533e25a3"),
                    Code = "F002",
                    Title = "Inception",
                    TrailerURL = "https://www.youtube.com/c4c6d3f5-e1e8-4720-ab23-827288054b0f7",
                    Description = "A thief who steals corporate secrets.",
                    PosterURL = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f24%2f1%2Dteaser%2Dposter%2D111142%2D240924%2D92.png",
                    UrlImage = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f24%2f1%2Dteaser%2Dposter%2D111142%2D240924%2D92.png",
                    DirectedBy = "Christopher Nolan",
                    Language = "English",
                    Actor = "Leonardo DiCaprio, Joseph Gordon-Levitt",
                    ReleaseDate = new DateTimeOffset(new DateTime(2010, 7, 16)),
                    Duration = "148 min",
                    Script = "Screenplay by Christopher Nolan",
                    Genres = "Action, Sci-Fi, Thriller",
                    AgeRating = "PG-13",
                    CreatedTime = DateTimeOffset.Now,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.Now,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                },
                new FilmEntity
                {
                    Id = Guid.Parse("768f3171-8c7a-4fbe-9abf-3a3cacf0d781"),
                    Code = "F003",
                    Title = "Parasite",
                    TrailerURL = "https://www.youtube.com/c4c6d3f5-e1e8-4720-ab23-827288054b0f7",
                    Description = "Greed and class discrimination threaten the newly formed relationship.",
                    PosterURL = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f24%2f1%2Dteaser%2Dposter%2D111142%2D240924%2D92.png",
                    UrlImage = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f24%2f1%2Dteaser%2Dposter%2D111142%2D240924%2D92.png",
                    DirectedBy = "Bong Joon-ho",
                    Language = "Korean",
                    Actor = "Kang-ho Song, Sun-kyun Lee",
                    ReleaseDate = new DateTimeOffset(new DateTime(2019, 5, 30)),
                    Duration = "132 min",
                    Script = "Screenplay by Bong Joon-ho, Han Jin-won",
                    Genres = "Thriller, Drama",
                    AgeRating = "R",
                    CreatedTime = DateTimeOffset.Now,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.Now,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                },
                new FilmEntity
                {
                    Id = Guid.Parse("8d106586-bbce-4441-b39b-9802c3adba3f"),
                    Code = "F004",
                    Title = "The Dark Knight",
                    TrailerURL = "https://www.youtube.com/c4c6d3f5-e1e8-4720-ab23-827288054b0f7",
                    Description = "When the Joker emerges, he wreaks havoc on Gotham.",
                    PosterURL = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f24%2f1%2Dteaser%2Dposter%2D111142%2D240924%2D92.png",
                    UrlImage = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f24%2f1%2Dteaser%2Dposter%2D111142%2D240924%2D92.png",
                    DirectedBy = "Christopher Nolan",
                    Language = "English",
                    Actor = "Christian Bale, Heath Ledger",
                    ReleaseDate = new DateTimeOffset(new DateTime(2008, 7, 18)),
                    Duration = "152 min",
                    Script = "Screenplay by Jonathan Nolan, Christopher Nolan",
                    Genres = "Action, Crime, Drama",
                    AgeRating = "PG-13",
                    CreatedTime = DateTimeOffset.Now,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.Now,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                },
                new FilmEntity
                {
                    Id = Guid.Parse("5ca9e7dd-79f2-4a3a-8614-a4ea802811ea"),
                    Code = "F005",
                    Title = "Forrest Gump",
                    TrailerURL = "https://www.youtube.com/c4c6d3f5-e1e8-4720-ab23-827288054b0f7",
                    Description = "The presidencies of Kennedy and Johnson unfold through the perspective of an Alabama man.",
                    PosterURL = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f24%2f1%2Dteaser%2Dposter%2D111142%2D240924%2D92.png",
                    UrlImage = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f24%2f1%2Dteaser%2Dposter%2D111142%2D240924%2D92.png",
                    DirectedBy = "Robert Zemeckis",
                    Language = "English",
                    Actor = "Tom Hanks, Robin Wright",
                    ReleaseDate = new DateTimeOffset(new DateTime(1994, 7, 6)),
                    Duration = "142 min",
                    Script = "Screenplay by Eric Roth",
                    Genres = "Drama, Romance",
                    AgeRating = "PG-13",
                    CreatedTime = DateTimeOffset.Now,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.Now,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                },
                new FilmEntity
                {
                    Id = Guid.Parse("ae89959a-694b-48f6-a43d-6d4d6295fe07"),
                    Code = "F006",
                    Title = "The Matrix",
                    TrailerURL = "https://www.youtube.com/c4c6d3f5-e1e8-4720-ab23-827288054b0f7",
                    Description = "A computer hacker learns about the true nature of his reality.",
                    PosterURL = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f24%2f1%2Dteaser%2Dposter%2D111142%2D240924%2D92.png",
                    UrlImage = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f24%2f1%2Dteaser%2Dposter%2D111142%2D240924%2D92.png",
                    DirectedBy = "Lana Wachowski, Lilly Wachowski",
                    Language = "English",
                    Actor = "Keanu Reeves, Laurence Fishburne",
                    ReleaseDate = new DateTimeOffset(new DateTime(1999, 3, 31)),
                    Duration = "136 min",
                    Script = "Screenplay by Lana Wachowski, Lilly Wachowski",
                    Genres = "Action, Sci-Fi",
                    AgeRating = "R",
                    CreatedTime = DateTimeOffset.Now,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.Now,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                },
                new FilmEntity
                {
                    Id = Guid.Parse("30621161-0e98-4718-89cb-ab396f43dab8"),
                    Code = "F007",
                    Title = "The Godfather",
                    TrailerURL = "https://www.youtube.com/c4c6d3f5-e1e8-4720-ab23-827288054b0f7",
                    Description = "An organized crime dynasty's aging patriarch transfers control to his reluctant son.",
                    PosterURL = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f24%2f1%2Dteaser%2Dposter%2D111142%2D240924%2D92.png",
                    UrlImage = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f24%2f1%2Dteaser%2Dposter%2D111142%2D240924%2D92.png",
                    DirectedBy = "Francis Ford Coppola",
                    Language = "English",
                    Actor = "Marlon Brando, Al Pacino",
                    ReleaseDate = new DateTimeOffset(new DateTime(1972, 3, 24)),
                    Duration = "175 min",
                    Script = "Screenplay by Mario Puzo, Francis Ford Coppola",
                    Genres = "Crime, Drama",
                    AgeRating = "R",
                    CreatedTime = DateTimeOffset.Now,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.Now,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                },
                new FilmEntity
                {
                    Id = Guid.Parse("f5dd1012-e558-423d-aac8-937fd3922438"),
                    Code = "F008",
                    Title = "Gladiator",
                    TrailerURL = "https://www.youtube.com/c4c6d3f5-e1e8-4720-ab23-827288054b0f7",
                    Description = "A former Roman general seeks vengeance against a corrupt emperor.",
                    PosterURL = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f19%2fscreenshot%2D2024%2D09%2D19%2D154629%2D154714%2D190924%2D43.png",
                    UrlImage = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f19%2fscreenshot%2D2024%2D09%2D19%2D154629%2D154714%2D190924%2D43.png",
                    DirectedBy = "Ridley Scott",
                    Language = "English",
                    Actor = "Russell Crowe, Joaquin Phoenix",
                    ReleaseDate = new DateTimeOffset(new DateTime(2000, 5, 5)),
                    Duration = "155 min",
                    Script = "Screenplay by David Franzoni, John Logan, William Nicholson",
                    Genres = "Action, Adventure, Drama",
                    AgeRating = "R",
                    CreatedTime = DateTimeOffset.Now,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.Now,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                },
                new FilmEntity
                {
                    Id = Guid.Parse("c32c98d0-5346-410e-8ea7-bf29a7a93037"),
                    Code = "F009",
                    Title = "The Silence of the Lambs",
                    TrailerURL = "https://www.youtube.com/c4c6d3f5-e1e8-4720-ab23-827288054b0f7",
                    Description = "A young FBI cadet seeks help from an incarcerated cannibal killer.",
                    PosterURL = "https://files.betacorp.vn/media%2fimages%2f2024%2f08%2f20%2fz5748072757139%2D098d7f499c425ecb70ba5314e41623dc%2D101253%2D200824%2D22.jpg",
                    UrlImage = "https://files.betacorp.vn/media%2fimages%2f2024%2f08%2f20%2fz5748072757139%2D098d7f499c425ecb70ba5314e41623dc%2D101253%2D200824%2D22.jpg",
                    DirectedBy = "Jonathan Demme",
                    Language = "English",
                    Actor = "Jodie Foster, Anthony Hopkins",
                    ReleaseDate = new DateTimeOffset(new DateTime(1991, 2, 14)),
                    Duration = "118 min",
                    Script = "Screenplay by Ted Tally",
                    Genres = "Crime, Drama, Thriller",
                    AgeRating = "R",
                    CreatedTime = DateTimeOffset.Now,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.Now,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                },
                new FilmEntity
                {
                    Id = Guid.Parse("1210299a-3ed6-4130-ab4f-08f5905f4e4f"),
                    Code = "F010",
                    Title = "Titanic",
                    TrailerURL = "https://www.youtube.com/c4c6d3f5-e1e8-4720-ab23-827288054b0f7",
                    Description = "A young aristocrat falls in love on the ill-fated R.M.S. Titanic.",
                    PosterURL = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f18%2fscreenshot%2D2024%2D09%2D18%2D174001%2D174048%2D180924%2D28.png",
                    UrlImage = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f18%2fscreenshot%2D2024%2D09%2D18%2D174001%2D174048%2D180924%2D28.png",
                    DirectedBy = "James Cameron",
                    Language = "English",
                    Actor = "Leonardo DiCaprio, Kate Winslet",
                    ReleaseDate = new DateTimeOffset(new DateTime(1997, 12, 19)),
                    Duration = "195 min",
                    Script = "Screenplay by James Cameron",
                    Genres = "Drama, Romance",
                    AgeRating = "PG-13",
                    CreatedTime = DateTimeOffset.Now,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.Now,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                },
                new FilmEntity
                {
                    Id = Guid.Parse("9cafea92-f3bb-49c2-becf-0152e4923f98"),
                    Code = "F011",
                    Title = "Avatar",
                    TrailerURL = "https://www.youtube.com/c4c6d3f5-e1e8-4720-ab23-827288054b0f7",
                    Description = "A paraplegic Marine on a unique mission on Pandora.",
                    PosterURL = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f11%2fscreenshot%2D2024%2D09%2D11%2D142147%2D142241%2D110924%2D24.png",
                    UrlImage = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f11%2fscreenshot%2D2024%2D09%2D11%2D142147%2D142241%2D110924%2D24.png",
                    DirectedBy = "James Cameron",
                    Language = "English",
                    Actor = "Sam Worthington, Zoe Saldana",
                    ReleaseDate = new DateTimeOffset(new DateTime(2009, 12, 18)),
                    Duration = "162 min",
                    Script = "Screenplay by James Cameron",
                    Genres = "Action, Adventure, Sci-Fi",
                    AgeRating = "PG-13",
                    CreatedTime = DateTimeOffset.Now,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.Now,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                },
                new FilmEntity
                {
                    Id = Guid.Parse("4d9531fc-9a76-4f88-9c14-f85748b65f23"),
                    Code = "F012",
                    Title = "The Lord of the Rings: The Return of the King",
                    TrailerURL = "https://www.youtube.com/c4c6d3f5-e1e8-4720-ab23-827288054b0f7",
                    Description = "Gandalf and Aragorn lead the War of Men against Sauron.",
                    PosterURL = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f11%2ftf1%2Dintl%2Dallspark%2Ddgtl%2Donline%2Dpayoff%2Dkeyart%2Dvie%2D400x633%2D134254%2D110924%2D51.jpg",
                    UrlImage = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f11%2ftf1%2Dintl%2Dallspark%2Ddgtl%2Donline%2Dpayoff%2Dkeyart%2Dvie%2D400x633%2D134254%2D110924%2D51.jpg",
                    DirectedBy = "Peter Jackson",
                    Language = "English",
                    Actor = "Elijah Wood, Viggo Mortensen",
                    ReleaseDate = new DateTimeOffset(new DateTime(2003, 12, 17)),
                    Duration = "201 min",
                    Script = "Screenplay by Fran Walsh, Philippa Boyens, Peter Jackson",
                    Genres = "Action, Adventure, Fantasy",
                    AgeRating = "PG-13",
                    CreatedTime = DateTimeOffset.Now,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.Now,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                },
                new FilmEntity
                {
                    Id = Guid.Parse("56900623-9148-44b4-9fca-1bf6796447b1"),
                    Code = "F013",
                    Title = "Fight Club",
                    TrailerURL = "https://www.youtube.com/c4c6d3f5-e1e8-4720-ab23-827288054b0f7",
                    Description = "An insomniac office worker forms an underground fight club.",
                    PosterURL = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f19%2f482wx722h%2D162630%2D190924%2D83.jpg",
                    UrlImage = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f19%2f482wx722h%2D162630%2D190924%2D83.jpg",
                    DirectedBy = "David Fincher",
                    Language = "English",
                    Actor = "Brad Pitt, Edward Norton",
                    ReleaseDate = new DateTimeOffset(new DateTime(1999, 10, 15)),
                    Duration = "139 min",
                    Script = "Screenplay by Jim Uhls",
                    Genres = "Drama",
                    AgeRating = "R",
                    CreatedTime = DateTimeOffset.Now,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.Now,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                },
                new FilmEntity
                {
                    Id = Guid.Parse("68b9a90f-4e8c-49ed-bfff-67a17695b1e0"),
                    Code = "F014",
                    Title = "The Social Network",
                    TrailerURL = "https://www.youtube.com/c4c6d3f5-e1e8-4720-ab23-827288054b0f7",
                    Description = "Harvard students create Facebook amidst personal and legal complications.",
                    PosterURL = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f25%2fz5866468283137%2D9b2f599d1b6e8559b953b4194e12540f%2D173644%2D250924%2D93.jpg",
                    UrlImage = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f25%2fz5866468283137%2D9b2f599d1b6e8559b953b4194e12540f%2D173644%2D250924%2D93.jpg",
                    DirectedBy = "David Fincher",
                    Language = "English",
                    Actor = "Jesse Eisenberg, Andrew Garfield",
                    ReleaseDate = new DateTimeOffset(new DateTime(2010, 10, 1)),
                    Duration = "120 min",
                    Script = "Screenplay by Aaron Sorkin",
                    Genres = "Biography, Drama",
                    AgeRating = "PG-13",
                    CreatedTime = DateTimeOffset.Now,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.Now,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                },
                new FilmEntity
                {
                    Id = Guid.Parse("20adbaec-242e-4e36-88a1-8f05cd53e7ee"),
                    Code = "F015",
                    Title = "Saving Private Ryan",
                    TrailerURL = "https://www.youtube.com/c4c6d3f5-e1e8-4720-ab23-827288054b0f7",
                    Description = "In WWII, a group of U.S. soldiers goes behind enemy lines.",
                    PosterURL = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f24%2f1%2Dteaser%2Dposter%2D111142%2D240924%2D92.png",
                    UrlImage = "https://files.betacorp.vn/media%2fimages%2f2024%2f09%2f24%2f1%2Dteaser%2Dposter%2D111142%2D240924%2D92.png",
                    DirectedBy = "Steven Spielberg",
                    Language = "English",
                    Actor = "Tom Hanks, Matt Damon",
                    ReleaseDate = new DateTimeOffset(new DateTime(1998, 7, 24)),
                    Duration = "169 min",
                    Script = "Screenplay by Robert Rodat",
                    Genres = "Drama, War",
                    AgeRating = "R",
                    CreatedTime = DateTimeOffset.Now,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.Now,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                },
                new FilmEntity
                {
                    Id = Guid.Parse("6160c0ca-00e5-4677-ba92-2b0decac4599"),
                    Code = "F016",
                    Title = "The Lion King",
                    TrailerURL = "https://www.youtube.com/c4c6d3f5-e1e8-4720-ab23-827288054b0f7",
                    Description = "Lion prince Simba flees his kingdom but returns to reclaim his throne.",
                    PosterURL = "https://files.betacorp.vn/media%2fimages%2f2024%2f08%2f27%2f400x633%2D13%2D093512%2D270824%2D67.jpg",
                    UrlImage = "https://files.betacorp.vn/media%2fimages%2f2024%2f08%2f27%2f400x633%2D13%2D093512%2D270824%2D67.jpg",
                    DirectedBy = "Roger Allers, Rob Minkoff",
                    Language = "English",
                    Actor = "Matthew Broderick, Jeremy Irons",
                    ReleaseDate = new DateTimeOffset(new DateTime(1994, 6, 15)),
                    Duration = "88 min",
                    Script = "Screenplay by Irene Mecchi, Jonathan Roberts, Linda Woolverton",
                    Genres = "Animation, Adventure, Drama",
                    AgeRating = "G",
                    CreatedTime = DateTimeOffset.Now,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.Now,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                    }
                );
            modelBuilder.Entity<FilmScheduleEntity>().HasData(
                new FilmScheduleEntity { Id = Guid.Parse("98378032-035c-4a82-b0d9-a42204ed96ee"),ShowDate = DateTimeOffset.Parse("2024-09-24"), ShowTime = DateTimeOffset.Parse("12:00"),Status = Domain.Enums.EntityStatus.Active},
                new FilmScheduleEntity { Id = Guid.Parse("d0031b0d-73f1-40e5-97b5-ef3402775cc0"), ShowDate = DateTimeOffset.Parse("2024-09-24"), ShowTime = DateTimeOffset.Parse("15:00"), Status = Domain.Enums.EntityStatus.Active },
                new FilmScheduleEntity { Id = Guid.Parse("c3f0f455-03e3-4acb-8acc-88a82723d37b"), ShowDate = DateTimeOffset.Parse("2024-09-24"), ShowTime = DateTimeOffset.Parse("18:00"), Status = Domain.Enums.EntityStatus.Active }
                );

            var schedules = new List<FilmScheduleEntity>();
            var startDate = DateTimeOffset.Now.Date; // Ngày bắt đầu

            for (int i = 0; i < 15; i++)
            {
                var showDate = startDate.AddDays(i); // Ngày chiếu
                var startHour = 8; // Bắt đầu từ 8h sáng
                var endHour = 23; // Kết thúc trước 12h đêm

                // Lịch chiếu bắt đầu từ 8h sáng
                for (var hour = startHour; hour <= endHour; hour += 2) // Tăng giờ theo bước 2
                {
                    // Thêm lịch chiếu cho giờ hiện tại
                    schedules.Add(new FilmScheduleEntity
                    {
                        Id = Guid.NewGuid(),
                        ShowDate = showDate,
                        ShowTime = new DateTimeOffset(showDate.Year, showDate.Month, showDate.Day, hour, 0, 0, TimeSpan.Zero),
                        Status = EntityStatus.Active,
                        CreatedTime = DateTimeOffset.Now,
                        CreatedBy = Guid.NewGuid(),
                        ModifiedTime = DateTimeOffset.Now,
                        ModifiedBy = Guid.NewGuid(),
                        Deleted = false,
                        DeletedBy = null,
                        DeletedTime = DateTimeOffset.MinValue
                    });

                    // Thêm lịch chiếu cho 2 tiếng 30 phút sau
                    var nextShowTime = hour + 2 + 30.0 / 60; // Cộng thêm 2h30
                    if (nextShowTime <= endHour + 0.5) // Đảm bảo không vượt quá 12h đêm
                    {
                        schedules.Add(new FilmScheduleEntity
                        {
                            Id = Guid.NewGuid(),
                            ShowDate = showDate,
                            ShowTime = new DateTimeOffset(showDate.Year, showDate.Month, showDate.Day, (int)nextShowTime, 0, 0, TimeSpan.Zero),
                            Status = EntityStatus.Active,
                            CreatedTime = DateTimeOffset.Now,
                            CreatedBy = Guid.NewGuid(),
                            ModifiedTime = DateTimeOffset.Now,
                            ModifiedBy = Guid.NewGuid(),
                            Deleted = false,
                            DeletedBy = null,
                            DeletedTime = DateTimeOffset.MinValue
                        });
                    }
                }
            }

            modelBuilder.Entity<FilmScheduleEntity>().HasData(schedules);
            modelBuilder.Entity<FilmDetailEntity>().HasData(
                new FilmDetailEntity() { Id = Guid.NewGuid(), FilmId = Guid.Parse("6355ea51-ac92-42a6-a522-fa1ee2a0b4fd"), FilmScheduleId = Guid.Parse("c3f0f455-03e3-4acb-8acc-88a82723d37b") },
                new FilmDetailEntity() { Id = Guid.NewGuid(), FilmId = Guid.Parse("345b2f74-5f5a-4bd7-b251-c1f4086857b7"), FilmScheduleId = Guid.Parse("d0031b0d-73f1-40e5-97b5-ef3402775cc0") },
                new FilmDetailEntity() { Id = Guid.NewGuid(), FilmId = Guid.Parse("6240feb7-1c07-4f9b-a117-0b0de95a32be"), FilmScheduleId = Guid.Parse("98378032-035c-4a82-b0d9-a42204ed96ee") },
                new FilmDetailEntity() { Id = Guid.NewGuid(), FilmId = Guid.Parse("8d106586-bbce-4441-b39b-9802c3adba3f"), FilmScheduleId = Guid.Parse("c3f0f455-03e3-4acb-8acc-88a82723d37b") },
                new FilmDetailEntity() { Id = Guid.NewGuid(), FilmId = Guid.Parse("345b2f74-5f5a-4bd7-b251-c1f4086857b7"), FilmScheduleId = Guid.Parse("98378032-035c-4a82-b0d9-a42204ed96ee") },
                new FilmDetailEntity() { Id = Guid.NewGuid(), FilmId = Guid.Parse("b6a96c37-2e5c-433d-aced-b068533e25a3"), FilmScheduleId = Guid.Parse("d0031b0d-73f1-40e5-97b5-ef3402775cc0") }

                );
            modelBuilder.Entity<FilmScheduleRoomEntity>().HasData(
                new FilmScheduleRoomEntity { Id = Guid.NewGuid(), FilmScheduleId = Guid.Parse("98378032-035c-4a82-b0d9-a42204ed96ee"), RoomId = Guid.Parse("3a1e5c44-74f6-4d4e-9b65-3bcbafc7f99e"), Status = EntityStatus.Active },
                new FilmScheduleRoomEntity { Id = Guid.NewGuid(), FilmScheduleId = Guid.Parse("d0031b0d-73f1-40e5-97b5-ef3402775cc0"), RoomId = Guid.Parse("3a1e5c44-74f6-4d4e-9b65-3bcbafc7f99e"), Status = EntityStatus.Active },
                new FilmScheduleRoomEntity { Id = Guid.NewGuid(), FilmScheduleId = Guid.Parse("c3f0f455-03e3-4acb-8acc-88a82723d37b"), RoomId = Guid.Parse("3a1e5c44-74f6-4d4e-9b65-3bcbafc7f99e"), Status = EntityStatus.Active },
                new FilmScheduleRoomEntity { Id = Guid.NewGuid(), FilmScheduleId = Guid.Parse("98378032-035c-4a82-b0d9-a42204ed96ee"), RoomId = Guid.Parse("9f5f4f20-1bcb-4f26-b2c9-0e5e5bcbbf80"), Status = EntityStatus.Active },
                new FilmScheduleRoomEntity { Id = Guid.NewGuid(), FilmScheduleId = Guid.Parse("d0031b0d-73f1-40e5-97b5-ef3402775cc0"), RoomId = Guid.Parse("9f5f4f20-1bcb-4f26-b2c9-0e5e5bcbbf80"), Status = EntityStatus.Active },
                new FilmScheduleRoomEntity { Id = Guid.NewGuid(), FilmScheduleId = Guid.Parse("c3f0f455-03e3-4acb-8acc-88a82723d37b"), RoomId = Guid.Parse("9f5f4f20-1bcb-4f26-b2c9-0e5e5bcbbf80"), Status = EntityStatus.Active },
                new FilmScheduleRoomEntity { Id = Guid.NewGuid(), FilmScheduleId = Guid.Parse("98378032-035c-4a82-b0d9-a42204ed96ee"), RoomId = Guid.Parse("41e6e0d1-1c93-4b7d-8e0e-4f113f2f7cd7"), Status = EntityStatus.Active },
                new FilmScheduleRoomEntity { Id = Guid.NewGuid(), FilmScheduleId = Guid.Parse("d0031b0d-73f1-40e5-97b5-ef3402775cc0"), RoomId = Guid.Parse("41e6e0d1-1c93-4b7d-8e0e-4f113f2f7cd7"), Status = EntityStatus.Active },
                new FilmScheduleRoomEntity { Id = Guid.NewGuid(), FilmScheduleId = Guid.Parse("c3f0f455-03e3-4acb-8acc-88a82723d37b"), RoomId = Guid.Parse("41e6e0d1-1c93-4b7d-8e0e-4f113f2f7cd7"), Status = EntityStatus.Active },
                new FilmScheduleRoomEntity { Id = Guid.NewGuid(), FilmScheduleId = Guid.Parse("98378032-035c-4a82-b0d9-a42204ed96ee"), RoomId = Guid.Parse("2e47e14a-6f50-46b8-bc1f-6e8d6f2e7e6c"), Status = EntityStatus.Active },
                new FilmScheduleRoomEntity { Id = Guid.NewGuid(), FilmScheduleId = Guid.Parse("d0031b0d-73f1-40e5-97b5-ef3402775cc0"), RoomId = Guid.Parse("2e47e14a-6f50-46b8-bc1f-6e8d6f2e7e6c"), Status = EntityStatus.Active },
                new FilmScheduleRoomEntity { Id = Guid.NewGuid(), FilmScheduleId = Guid.Parse("c3f0f455-03e3-4acb-8acc-88a82723d37b"), RoomId = Guid.Parse("2e47e14a-6f50-46b8-bc1f-6e8d6f2e7e6c"), Status = EntityStatus.Active }
                );

            modelBuilder.Entity<RoomLayoutEntity>().HasData(
            new RoomLayoutEntity
            {
                Id = Guid.Parse("6160c0ca-00e5-4677-ba92-2b0decac4599"),
                Name = "Bố Cục 1",
                Description = "Bố cục phòng cơ bản với 10 chỗ ngồi.",
                CreatedTime = DateTimeOffset.Now,
                Status = EntityStatus.Active,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new RoomLayoutEntity
            {
                Id = Guid.Parse("159ff24d-0c51-4dcf-93b8-4d4655966644"),
                Name = "Bố Cục 2",
                Description = "Bố cục phòng với bàn họp lớn.",
                CreatedTime = DateTimeOffset.Now,
                Status = EntityStatus.Active,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new RoomLayoutEntity
            {
                Id = Guid.Parse("d981b720-1a69-42cc-9c3d-4a22d7ffae51"),
                Name = "Bố Cục 3",
                Description = "Bố cục phòng với 20 chỗ ngồi.",
                CreatedTime = DateTimeOffset.Now,
                Status = EntityStatus.Active,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new RoomLayoutEntity
            {
                Id = Guid.Parse("8a3bd201-edb8-4071-be47-ac4e443a39ac"),
                Name = "Bố Cục 4",
                Description = "Bố cục phòng giảng dạy với bàn ghế di động.",
                CreatedTime = DateTimeOffset.Now,
                Status = EntityStatus.Active,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new RoomLayoutEntity
            {
                Id = Guid.Parse("4929115d-dfd8-406a-a23f-c09898c17ddd"),
                Name = "Bố Cục 5",
                Description = "Bố cục phòng hội thảo với thiết bị âm thanh.",
                CreatedTime = DateTimeOffset.Now,
                Status = EntityStatus.Active,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new RoomLayoutEntity
            {
                Id = Guid.Parse("55b74b2c-db2f-487b-9095-29b4863c854d"),
                Name = "Bố Cục 6",
                Description = "Bố cục phòng làm việc nhóm.",
                CreatedTime = DateTimeOffset.Now,
                Status = EntityStatus.Active,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new RoomLayoutEntity
            {
                Id = Guid.Parse("3529f4af-81ef-466a-a4bc-54f8c931e328"),
                Name = "Bố Cục 7",
                Description = "Bố cục phòng với không gian mở.",
                CreatedTime = DateTimeOffset.Now,
                Status = EntityStatus.Active,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new RoomLayoutEntity
            {
                Id = Guid.Parse("b39cd1f1-dcc1-42e6-b9d6-b7664ce0a25f"),
                Name = "Bố Cục 8",
                Description = "Bố cục phòng đa năng.",
                CreatedTime = DateTimeOffset.Now,
                Status = EntityStatus.Active,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new RoomLayoutEntity
            {
                Id = Guid.Parse("c8603224-3762-4566-877c-295df12531af"),
                Name = "Bố Cục 9",
                Description = "Bố cục phòng với không gian thư giãn.",
                CreatedTime = DateTimeOffset.Now,
                Status = EntityStatus.Active,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new RoomLayoutEntity
            {
                Id = Guid.Parse("f8a1d7de-101b-432c-b456-67e22ab013a0"), // GUID mới
                Name = "Bố Cục 10",
                Description = "Bố cục phòng với 30 chỗ ngồi cho sự kiện lớn.",
                CreatedTime = DateTimeOffset.Now,
                Status = EntityStatus.Active,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            }
        );
            modelBuilder.Entity<SeatEntity>().HasData(
                 new SeatEntity
                 {
                     Id = Guid.Parse("13c48467-2e36-476f-9653-c154d08d60bd"),
                     RoomLayoutId = Guid.Parse("159ff24d-0c51-4dcf-93b8-4d4655966644"),
                     Description = "Ghế 1, hàng A",
                     Code = "A1",
                     Row = "A",
                     SeatColumn = 1,
                     Type = EntityTypeSeat.normal,
                     Price = 100.00,
                     CreatedTime = DateTimeOffset.Now,
                     CreatedBy = Guid.NewGuid(),
                     ModifiedTime = DateTimeOffset.Now,
                     ModifiedBy = Guid.NewGuid(),
                     Deleted = false,
                     DeletedBy = null,
                     DeletedTime = DateTimeOffset.MinValue
                 },
                 new SeatEntity
                 {
                     Id = Guid.Parse("692753cc-e7b2-4c6b-abe6-ba78b7d21f9c"),
                     RoomLayoutId = Guid.Parse("159ff24d-0c51-4dcf-93b8-4d4655966644"),
                     Description = "Ghế 2, hàng A",
                     Code = "A2",
                     Row = "A",
                     SeatColumn = 2,
                     Type = EntityTypeSeat.vip,
                     Price = 100.00,
                     CreatedTime = DateTimeOffset.Now,
                     CreatedBy = Guid.NewGuid(),
                     ModifiedTime = DateTimeOffset.Now,
                     ModifiedBy = Guid.NewGuid(),
                     Deleted = false,
                     DeletedBy = null,
                     DeletedTime = DateTimeOffset.MinValue
                 },
                 new SeatEntity
                 {
                     Id = Guid.Parse("12722b21-bf41-41f6-bb82-e67f75253c18"),
                     RoomLayoutId = Guid.Parse("159ff24d-0c51-4dcf-93b8-4d4655966644"),
                     Description = "Ghế 1, hàng B",
                     Code = "B1",
                     Row = "B",
                     SeatColumn = 1,
                     Type = EntityTypeSeat.vip,
                     Price = 150.00,
                     CreatedTime = DateTimeOffset.Now,
                     CreatedBy = Guid.NewGuid(),
                     ModifiedTime = DateTimeOffset.Now,
                     ModifiedBy = Guid.NewGuid(),
                     Deleted = false,
                     DeletedBy = null,
                     DeletedTime = DateTimeOffset.MinValue
                 },
                 new SeatEntity
                 {
                     Id = Guid.Parse("8b1734cd-1295-4eeb-87c7-6cbe70fe114d"),
                     RoomLayoutId = Guid.Parse("159ff24d-0c51-4dcf-93b8-4d4655966644"),
                     Description = "Ghế 1, hàng C",
                     Code = "C1",
                     Row = "C",
                     SeatColumn = 1,
                     Type = EntityTypeSeat.vip,
                     Price = 100.00,
                     CreatedTime = DateTimeOffset.Now,
                     CreatedBy = Guid.NewGuid(),
                     ModifiedTime = DateTimeOffset.Now,
                     ModifiedBy = Guid.NewGuid(),
                     Deleted = false,
                     DeletedBy = null,
                     DeletedTime = DateTimeOffset.MinValue
                 },
                 new SeatEntity
                 {
                     Id = Guid.Parse("00c7afb6-1e53-403b-bcd1-0d3740467713"),
                     RoomLayoutId = Guid.Parse("159ff24d-0c51-4dcf-93b8-4d4655966644"),
                     Description = "Ghế 3, hàng A",
                     Code = "A3",
                     Row = "A",
                     SeatColumn = 3,
                     Type = EntityTypeSeat.normal,
                     Price = 100.00,
                     CreatedTime = DateTimeOffset.Now,
                     CreatedBy = Guid.NewGuid(),
                     ModifiedTime = DateTimeOffset.Now,
                     ModifiedBy = Guid.NewGuid(),
                     Deleted = false,
                     DeletedBy = null,
                     DeletedTime = DateTimeOffset.MinValue
                 },
                 new SeatEntity
                 {
                     Id = Guid.Parse("cdfd2c69-af94-4790-af5a-ad7631959fdd"),
                     RoomLayoutId = Guid.Parse("159ff24d-0c51-4dcf-93b8-4d4655966644"),
                     Description = "Ghế 10, hàng C",
                     Code = "C10",
                     Row = "C",
                     SeatColumn = 10,
                     Type = EntityTypeSeat.normal,
                     Price = 100.00,
                     CreatedTime = DateTimeOffset.Now,
                     CreatedBy = Guid.NewGuid(),
                     ModifiedTime = DateTimeOffset.Now,
                     ModifiedBy = Guid.NewGuid(),
                     Deleted = false,
                     DeletedBy = null,
                     DeletedTime = DateTimeOffset.MinValue
                 },
                 new SeatEntity
                 {
                     Id = Guid.Parse("5f11a01a-4144-4f93-9b55-a988da45424b"),
                     RoomLayoutId = Guid.Parse("159ff24d-0c51-4dcf-93b8-4d4655966644"),
                     Description = "Ghế 6, hàng A",
                     Code = "A6",
                     Row = "A",
                     SeatColumn = 6,
                     Type = EntityTypeSeat.normal,
                     Price = 100.00,
                     CreatedTime = DateTimeOffset.Now,
                     CreatedBy = Guid.NewGuid(),
                     ModifiedTime = DateTimeOffset.Now,
                     ModifiedBy = Guid.NewGuid(),
                     Deleted = false,
                     DeletedBy = null,
                     DeletedTime = DateTimeOffset.MinValue
                 },
                 new SeatEntity
                 {
                     Id = Guid.Parse("a58b8605-d529-4d60-97eb-e76a5bb1529a"),
                     RoomLayoutId = Guid.Parse("159ff24d-0c51-4dcf-93b8-4d4655966644"),
                     Description = "Ghế 5, hàng B",
                     Code = "B5",
                     Row = "B",
                     SeatColumn = 5,
                     Type = EntityTypeSeat.vip,
                     Price = 150.00,
                     CreatedTime = DateTimeOffset.Now,
                     CreatedBy = Guid.NewGuid(),
                     ModifiedTime = DateTimeOffset.Now,
                     ModifiedBy = Guid.NewGuid(),
                     Deleted = false,
                     DeletedBy = null,
                     DeletedTime = DateTimeOffset.MinValue
                 },
                 new SeatEntity
                 {
                     Id = Guid.Parse("e724f652-9bf8-4a8c-b517-d188684bf10b"),
                     RoomLayoutId = Guid.Parse("159ff24d-0c51-4dcf-93b8-4d4655966644"),
                     Description = "Ghế 5, hàng C",
                     Code = "C5",
                     Row = "C",
                     SeatColumn = 5,
                     Type = EntityTypeSeat.normal,
                     Price = 100.00,
                     CreatedTime = DateTimeOffset.Now,
                     CreatedBy = Guid.NewGuid(),
                     ModifiedTime = DateTimeOffset.Now,
                     ModifiedBy = Guid.NewGuid(),
                     Deleted = false,
                     DeletedBy = null,
                     DeletedTime = DateTimeOffset.MinValue
                 },
                 // Thêm tiếp cho đến 30 ghế
                 new SeatEntity
                 {
                     Id = Guid.Parse("321392bd-810e-4c5b-9612-7142643d8596"),
                     RoomLayoutId = Guid.Parse("159ff24d-0c51-4dcf-93b8-4d4655966644"),
                     Description = "Ghế 4, hàng A",
                     Code = "A4",
                     Row = "A",
                     SeatColumn = 4,
                     Type = EntityTypeSeat.normal,
                     Price = 100.00,
                     CreatedTime = DateTimeOffset.Now,
                     CreatedBy = Guid.NewGuid(),
                     ModifiedTime = DateTimeOffset.Now,
                     ModifiedBy = Guid.NewGuid(),
                     Deleted = false,
                     DeletedBy = null,
                     DeletedTime = DateTimeOffset.MinValue
                 },
                 new SeatEntity
                 {
                     Id = Guid.Parse("6a845d3f-e49b-4887-9692-cd139a84c6a6"),
                     RoomLayoutId = Guid.Parse("159ff24d-0c51-4dcf-93b8-4d4655966644"),
                     Description = "Ghế 2, hàng B",
                     Code = "B2",
                     Row = "B",
                     SeatColumn = 2,
                     Type = EntityTypeSeat.vip,
                     Price = 150.00,
                     CreatedTime = DateTimeOffset.Now,
                     CreatedBy = Guid.NewGuid(),
                     ModifiedTime = DateTimeOffset.Now,
                     ModifiedBy = Guid.NewGuid(),
                     Deleted = false,
                     DeletedBy = null,
                     DeletedTime = DateTimeOffset.MinValue
                 },
                 new SeatEntity
                 {
                     Id = Guid.Parse("c02c26f3-0e1c-449f-9965-9a43ed0bfe62"),
                     RoomLayoutId = Guid.Parse("8a3bd201-edb8-4071-be47-ac4e443a39ac"),
                     Description = "Ghế 3, hàng C",
                     Code = "C3",
                     Row = "C",
                     SeatColumn = 3,
                     Type = EntityTypeSeat.normal,
                     Price = 100.00,
                     CreatedTime = DateTimeOffset.Now,
                     CreatedBy = Guid.NewGuid(),
                     ModifiedTime = DateTimeOffset.Now,
                     ModifiedBy = Guid.NewGuid(),
                     Deleted = false,
                     DeletedBy = null,
                     DeletedTime = DateTimeOffset.MinValue
                 },
                 new SeatEntity
                 {
                     Id = Guid.Parse("3d1dc040-0d96-49f9-b201-d29e24f407c2"),
                     RoomLayoutId = Guid.Parse("8a3bd201-edb8-4071-be47-ac4e443a39ac"),
                     Description = "Ghế 4, hàng B",
                     Code = "B4",
                     Row = "B",
                     SeatColumn = 4,
                     Type = EntityTypeSeat.vip,
                     Price = 150.00,
                     CreatedTime = DateTimeOffset.Now,
                     CreatedBy = Guid.NewGuid(),
                     ModifiedTime = DateTimeOffset.Now,
                     ModifiedBy = Guid.NewGuid(),
                     Deleted = false,
                     DeletedBy = null,
                     DeletedTime = DateTimeOffset.MinValue
                 },
                 new SeatEntity
                 {
                     Id = Guid.Parse("482c5431-e515-430a-9608-da6877113033"),
                     RoomLayoutId = Guid.Parse("8a3bd201-edb8-4071-be47-ac4e443a39ac"),
                     Description = "Ghế 6, hàng C",
                     Code = "C6",
                     Row = "C",
                     SeatColumn = 6,
                     Type = EntityTypeSeat.normal,
                     Price = 100.00,
                     CreatedTime = DateTimeOffset.Now,
                     CreatedBy = Guid.NewGuid(),
                     ModifiedTime = DateTimeOffset.Now,
                     ModifiedBy = Guid.NewGuid(),
                     Deleted = false,
                     DeletedBy = null,
                     DeletedTime = DateTimeOffset.MinValue
                 },

            new SeatEntity
            {
                Id = Guid.Parse("eee63918-34da-422c-8940-3d68e3ece20c"),
                RoomLayoutId = Guid.Parse("8a3bd201-edb8-4071-be47-ac4e443a39ac"),
                Description = "Ghế 7, hàng A",
                Code = "A7",
                Row = "A",
                SeatColumn = 7,
                Type = EntityTypeSeat.vip,
                Price = 150.00,
                CreatedTime = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new SeatEntity
            {
                Id = Guid.Parse("644e9c1d-8c33-4fd5-80c2-0f90d962972f"),
                RoomLayoutId = Guid.Parse("8a3bd201-edb8-4071-be47-ac4e443a39ac"),
                Description = "Ghế 6, hàng B",
                Code = "B6",
                Row = "B",
                SeatColumn = 6,
                Type = EntityTypeSeat.normal,
                Price = 100.00,
                CreatedTime = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new SeatEntity
            {
                Id = Guid.Parse("055318ce-8515-4e36-a7ef-efeb5245e8de"),
                RoomLayoutId = Guid.Parse("8a3bd201-edb8-4071-be47-ac4e443a39ac"),
                Description = "Ghế 6, hàng C",
                Code = "C6",
                Row = "C",
                SeatColumn = 6,
                Type = EntityTypeSeat.vip,
                Price = 150.00,
                CreatedTime = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new SeatEntity
            {
                Id = Guid.Parse("db349dba-b56a-4460-b65d-43e62264514c"),
                RoomLayoutId = Guid.Parse("8a3bd201-edb8-4071-be47-ac4e443a39ac"),
                Description = "Ghế 8, hàng A",
                Code = "A8",
                Row = "A",
                SeatColumn = 8,
                Type = EntityTypeSeat.normal,
                Price = 100.00,
                CreatedTime = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new SeatEntity
            {
                Id = Guid.Parse("1e298a97-0c7f-42ef-8307-18f50d79ce0c"),
                RoomLayoutId = Guid.Parse("8a3bd201-edb8-4071-be47-ac4e443a39ac"),
                Description = "Ghế 7, hàng B",
                Code = "B7",
                Row = "B",
                SeatColumn = 7,
                Type = EntityTypeSeat.vip,
                Price = 150.00,
                CreatedTime = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new SeatEntity
            {
                Id = Guid.Parse("2a566ea0-813b-44f4-9550-8920f4cf1bc9"),
                RoomLayoutId = Guid.Parse("8a3bd201-edb8-4071-be47-ac4e443a39ac"),
                Description = "Ghế 7, hàng C",
                Code = "C7",
                Row = "C",
                SeatColumn = 7,
                Type = EntityTypeSeat.normal,
                Price = 100.00,
                CreatedTime = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new SeatEntity
            {
                Id = Guid.Parse("1938992f-9822-4824-8ead-5d6a329b7314"),
                RoomLayoutId = Guid.Parse("8a3bd201-edb8-4071-be47-ac4e443a39ac"),
                Description = "Ghế 9, hàng A",
                Code = "A9",
                Row = "A",
                SeatColumn = 9,
                Type = EntityTypeSeat.vip,
                Price = 150.00,
                CreatedTime = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new SeatEntity
            {
                Id = Guid.Parse("9bd13c50-c44a-4b63-abf7-a3f57d2f9df1"),
                RoomLayoutId = Guid.Parse("8a3bd201-edb8-4071-be47-ac4e443a39ac"),
                Description = "Ghế 8, hàng B",
                Code = "B8",
                Row = "B",
                SeatColumn = 8,
                Type = EntityTypeSeat.normal,
                Price = 100.00,
                CreatedTime = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new SeatEntity
            {
                Id = Guid.Parse("b7992e09-7a10-44ee-a298-1e97ec3a6e39"),
                RoomLayoutId = Guid.Parse("8a3bd201-edb8-4071-be47-ac4e443a39ac"),
                Description = "Ghế 10, hàng A",
                Code = "A10",
                Row = "A",
                SeatColumn = 10,
                Type = EntityTypeSeat.normal,
                Price = 100.00,
                CreatedTime = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new SeatEntity
            {
                Id = Guid.Parse("27443a3d-00d4-4a05-aad3-c9ac4f7e35b4"),
                RoomLayoutId = Guid.Parse("8a3bd201-edb8-4071-be47-ac4e443a39ac"),
                Description = "Ghế 9, hàng B",
                Code = "B9",
                Row = "B",
                SeatColumn = 9,
                Type = EntityTypeSeat.vip,
                Price = 150.00,
                CreatedTime = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new SeatEntity
            {
                Id = Guid.Parse("45c37905-963f-40eb-8936-760771d5d389"),
                RoomLayoutId = Guid.Parse("8a3bd201-edb8-4071-be47-ac4e443a39ac"),
                Description = "Ghế 8, hàng C",
                Code = "C8",
                Row = "C",
                SeatColumn = 8,
                Type = EntityTypeSeat.normal,
                Price = 100.00,
                CreatedTime = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new SeatEntity
            {
                Id = Guid.Parse("92caf269-eaf5-4b71-929e-683522088914"),
                RoomLayoutId = Guid.Parse("8a3bd201-edb8-4071-be47-ac4e443a39ac"),
                Description = "Ghế 11, hàng A",
                Code = "A11",
                Row = "A",
                SeatColumn = 11,
                Type = EntityTypeSeat.vip,
                Price = 150.00,
                CreatedTime = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new SeatEntity
            {
                Id = Guid.Parse("09af5d35-1912-4289-93a5-bfbce9646140"),
                RoomLayoutId = Guid.Parse("8a3bd201-edb8-4071-be47-ac4e443a39ac"),
                Description = "Ghế 10, hàng B",
                Code = "B10",
                Row = "B",
                SeatColumn = 10,
                Type = EntityTypeSeat.normal,
                Price = 100.00,
                CreatedTime = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new SeatEntity
            {
                Id = Guid.Parse("011ff5d4-0083-443e-bd25-fbefa6ca0095"),
                RoomLayoutId = Guid.Parse("8a3bd201-edb8-4071-be47-ac4e443a39ac"),
                Description = "Ghế 9, hàng C",
                Code = "C9",
                Row = "C",
                SeatColumn = 9,
                Type = EntityTypeSeat.vip,
                Price = 150.00,
                CreatedTime = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new SeatEntity
            {
                Id = Guid.Parse("3c0c699e-9281-439b-adda-290ca50a3451"),
                RoomLayoutId = Guid.Parse("8a3bd201-edb8-4071-be47-ac4e443a39ac"),
                Description = "Ghế 12, hàng A",
                Code = "A12",
                Row = "A",
                SeatColumn = 12,
                Type = EntityTypeSeat.normal,
                Price = 100.00,
                CreatedTime = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new SeatEntity
            {
                Id = Guid.Parse("be99019a-7b2d-4bfb-9030-c70927812860"),
                RoomLayoutId = Guid.Parse("8a3bd201-edb8-4071-be47-ac4e443a39ac"),
                Description = "Ghế 11, hàng B",
                Code = "B11",
                Row = "B",
                SeatColumn = 11,
                Type = EntityTypeSeat.vip,
                Price = 150.00,
                CreatedTime = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new SeatEntity
            {
                Id = Guid.Parse("8df9e985-b080-41c7-b72b-16ef0c35f8ad"),
                RoomLayoutId = Guid.Parse("8a3bd201-edb8-4071-be47-ac4e443a39ac"),
                Description = "Ghế 10, hàng C",
                Code = "C10",
                Row = "C",
                SeatColumn = 10,
                Type = EntityTypeSeat.normal,
                Price = 100.00,
                CreatedTime = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            }
        );
            modelBuilder.Entity<ProductEntity>().HasData(
            new ProductEntity
            {
                Id = Guid.Parse("dfb93593-31f3-42b1-9b83-c8970286481e"),
                Code = "P001",
                Name = "Bỏng Ngô Vị Bơ",
                Price = 25.00,
                Quantity = 150,
                Description = "Bỏng ngô giòn tan vị bơ thơm ngon.",
                ImageUrl = "url_to_image_popcorn_butter",
                Status = EntityStatus.Active,
                CreatedTime = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new ProductEntity
            {
                Id = Guid.Parse("2043fe16-58b2-455d-aaff-e60eb1287457"),
                Code = "P002",
                Name = "Bỏng Ngô Vị Phô Mai",
                Price = 30.00,
                Quantity = 150,
                Description = "Bỏng ngô phô mai đặc biệt.",
                ImageUrl = "url_to_image_popcorn_cheese",
                Status = EntityStatus.Active,
                CreatedTime = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new ProductEntity
            {
                Id = Guid.Parse("77f9b2c6-3f21-4441-a6d4-04615f0f9b8d"),
                Code = "D001",
                Name = "Nước Ngọt Cola",
                Price = 20.00,
                Quantity = 150,
                Description = "Nước ngọt Cola mát lạnh.",
                ImageUrl = "url_to_image_cola",
                Status = EntityStatus.Active,
                CreatedTime = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new ProductEntity
            {
                Id = Guid.Parse("53e52295-bf95-4100-bacd-e4facc805562"),
                Code = "D002",
                Name = "Nước Ngọt Sprite",
                Price = 20.00,
                Quantity = 150,
                Description = "Nước ngọt Sprite sảng khoái.",
                ImageUrl = "url_to_image_sprite",
                Status = EntityStatus.Active,
                CreatedTime = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new ProductEntity
            {
                Id = Guid.Parse("e7f18e78-5bde-4369-87a6-2697283e7858"),
                Code = "C001",
                Name = "Combo Bỏng Ngô và Nước Ngọt",
                Price = 40.00,
                Quantity = 150,
                Description = "Combo bao gồm 1 bịch bỏng ngô và 1 chai nước ngọt.",
                ImageUrl = "url_to_image_combo",
                Status = EntityStatus.Active,
                CreatedTime = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new ProductEntity
            {
                Id = Guid.Parse("52831bb3-6ad0-464d-bd4d-a1973e9a9cfb"),
                Code = "P003",
                Name = "Bỏng Ngô Vị Caramel",
                Price = 35.00,
                Quantity = 150,
                Description = "Bỏng ngô caramel ngọt ngào.",
                ImageUrl = "url_to_image_popcorn_caramel",
                Status = EntityStatus.Active,
                CreatedTime = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new ProductEntity
            {
                Id = Guid.Parse("72300188-ab7b-42dd-ab9b-9f4538508833"),
                Code = "D003",
                Name = "Nước Ngọt Fanta",
                Price = 20.00,
                Quantity = 150,
                Description = "Nước ngọt Fanta vị trái cây.",
                ImageUrl = "url_to_image_fanta",
                Status = EntityStatus.Active,
                CreatedTime = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new ProductEntity
            {
                Id = Guid.Parse("a9811229-dea6-4ec5-be3f-14151054eb54"),
                Code = "C002",
                Name = "Combo Nước Ngọt và Bỏng Ngô Vị Phô Mai",
                Price = 45.00,
                Quantity = 150,
                Description = "Combo bao gồm 1 chai nước ngọt và 1 bịch bỏng ngô vị phô mai.",
                ImageUrl = "url_to_image_combo_cheese",
                Status = EntityStatus.Active,
                CreatedTime = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new ProductEntity
            {
                Id = Guid.Parse("fa7555dd-4e6d-4c76-8669-6554ff0873cd"),
                Code = "P004",
                Name = "Bỏng Ngô Vị Hành",
                Price = 30.00,
                Quantity = 150,
                Description = "Bỏng ngô vị hành thơm ngon.",
                ImageUrl = "url_to_image_popcorn_onion",
                Status = EntityStatus.Active,
                CreatedTime = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            },
            new ProductEntity
            {
                Id = Guid.Parse("b7be567b-8fec-44cd-8686-e66bff73c437"),
                Code = "D004",
                Name = "Nước Ngọt 7UP",
                Price = 20.00,
                Quantity = 150,
                Description = "Nước ngọt 7UP mát lạnh.",
                ImageUrl = "url_to_image_7up",
                Status = EntityStatus.Active,
                CreatedTime = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
                ModifiedTime = DateTimeOffset.Now,
                ModifiedBy = Guid.NewGuid(),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = DateTimeOffset.MinValue
            }
        );
            var rooms = new List<RoomEntity>
            {
                new RoomEntity
                {
                    Id = Guid.Parse("3a1e5c44-74f6-4d4e-9b65-3bcbafc7f99e"),
                    RoomLayoutId = Guid.Parse("159ff24d-0c51-4dcf-93b8-4d4655966644"),
                    DepartmentId = Guid.Parse("5fbe2704-18dd-4a5d-a053-a7fafe74ca00"),
                    Capacity = 30,
                    Code = "R001",
                    SoundSystem = "Yes",
                    ScreenSize = "55 inches",
                    RoomType = "Conference",
                    Status = EntityStatus.Active,
                    CreatedTime = DateTimeOffset.UtcNow,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.UtcNow,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                },
                new RoomEntity
                {
                    Id = Guid.Parse("9f5f4f20-1bcb-4f26-b2c9-0e5e5bcbbf80"),
                    RoomLayoutId = Guid.Parse("159ff24d-0c51-4dcf-93b8-4d4655966644"),
                    DepartmentId = Guid.Parse("5fbe2704-18dd-4a5d-a053-a7fafe74ca00"),
                    Capacity = 50,
                    Code = "R002",
                    SoundSystem = "Yes",
                    ScreenSize = "75 inches",
                    RoomType = "Seminar",
                    Status = EntityStatus.Active,
                    CreatedTime = DateTimeOffset.UtcNow,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.UtcNow,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                },
                new RoomEntity
                {
                    Id = Guid.Parse("41e6e0d1-1c93-4b7d-8e0e-4f113f2f7cd7"),
                    RoomLayoutId = Guid.Parse("159ff24d-0c51-4dcf-93b8-4d4655966644"),
                    DepartmentId = Guid.Parse("5fbe2704-18dd-4a5d-a053-a7fafe74ca00"),
                    Capacity = 20,
                    Code = "R003",
                    SoundSystem = "No",
                    ScreenSize = "40 inches",
                    RoomType = "Meeting",
                    Status = EntityStatus.Active,
                    CreatedTime = DateTimeOffset.UtcNow,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.UtcNow,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                },
                new RoomEntity
                {
                    Id = Guid.Parse("2e47e14a-6f50-46b8-bc1f-6e8d6f2e7e6c"),
                    RoomLayoutId = Guid.Parse("6160c0ca-00e5-4677-ba92-2b0decac4599"),
                    DepartmentId = Guid.Parse("4517d09f-4c1c-486f-b0de-fd36db91cbcb"),
                    Capacity = 15,
                    Code = "R004",
                    SoundSystem = "Yes",
                    ScreenSize = "32 inches",
                    RoomType = "Workshop",
                    Status = EntityStatus.Active,
                    CreatedTime = DateTimeOffset.UtcNow,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.UtcNow,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                },
                new RoomEntity
                {
                    Id = Guid.Parse("f67c1e5d-5c8f-4a5e-8e3b-7e7b6d2a4c8b"),
                    RoomLayoutId = Guid.Parse("6160c0ca-00e5-4677-ba92-2b0decac4599"),
                    DepartmentId = Guid.Parse("4517d09f-4c1c-486f-b0de-fd36db91cbcb"),
                    Capacity = 100,
                    Code = "R005",
                    SoundSystem = "Yes",
                    ScreenSize = "85 inches",
                    RoomType = "Auditorium",
                    Status = EntityStatus.Active,
                    CreatedTime = DateTimeOffset.UtcNow,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.UtcNow,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                },
                new RoomEntity
                {
                    Id = Guid.Parse("8c4e1d5a-2b3f-4d4e-b6e2-4e8c5f1a0f1e"),
                    RoomLayoutId = Guid.Parse("6160c0ca-00e5-4677-ba92-2b0decac4599"),
                    DepartmentId = Guid.Parse("4517d09f-4c1c-486f-b0de-fd36db91cbcb"),
                    Capacity = 10,
                    Code = "R006",
                    SoundSystem = "No",
                    ScreenSize = "24 inches",
                    RoomType = "Interview",
                    Status = EntityStatus.Active,
                    CreatedTime = DateTimeOffset.UtcNow,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.UtcNow,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                },
                new RoomEntity
                {
                    Id = Guid.Parse("f2b3e1c2-6c3f-4b0f-b5e6-2b4c3e1d4f8f"),
                    RoomLayoutId = Guid.Parse("6160c0ca-00e5-4677-ba92-2b0decac4599"),
                    DepartmentId = Guid.Parse("d9de26d3-77c2-4791-bb48-ccf7fe407877"),
                    Capacity = 25,
                    Code = "R007",
                    SoundSystem = "Yes",
                    ScreenSize = "50 inches",
                    RoomType = "Training",
                    Status = EntityStatus.Active,
                    CreatedTime = DateTimeOffset.UtcNow,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.UtcNow,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                },
                new RoomEntity
                {
                    Id = Guid.Parse("4c8d3f5a-2b3f-4c4e-9e2e-3d0e1b5a2a1f"),
                    RoomLayoutId = Guid.Parse("6160c0ca-00e5-4677-ba92-2b0decac4599"),
                    DepartmentId = Guid.Parse("d9de26d3-77c2-4791-bb48-ccf7fe407877"),
                    Capacity = 40,
                    Code = "R008",
                    SoundSystem = "Yes",
                    ScreenSize = "65 inches",
                    RoomType = "Classroom",
                    Status = EntityStatus.Active,
                    CreatedTime = DateTimeOffset.UtcNow,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.UtcNow,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                },
                new RoomEntity
                {
                    Id = Guid.Parse("7f4e2c8d-3b1f-4c5e-a5d3-2f0b8c6e1f4e"),
                    RoomLayoutId = Guid.Parse("6160c0ca-00e5-4677-ba92-2b0decac4599"),
                    DepartmentId = Guid.Parse("d9de26d3-77c2-4791-bb48-ccf7fe407877"),
                    Capacity = 35,
                    Code = "R009",
                    SoundSystem = "No",
                    ScreenSize = "60 inches",
                    RoomType = "Focus Room",
                    Status = EntityStatus.Active,
                    CreatedTime = DateTimeOffset.UtcNow,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.UtcNow,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                },
                new RoomEntity
                {
                    Id = Guid.Parse("1e7f2c8d-9a1e-4b3f-b5c3-2e0b5f7c4d8e"),
                    RoomLayoutId = Guid.Parse("6160c0ca-00e5-4677-ba92-2b0decac4599"),
                    DepartmentId = Guid.Parse("d9de26d3-77c2-4791-bb48-ccf7fe407877"),
                    Capacity = 70,
                    Code = "R010",
                    SoundSystem = "Yes",
                    ScreenSize = "72 inches",
                    RoomType = "Lounge",
                    Status = EntityStatus.Active,
                    CreatedTime = DateTimeOffset.UtcNow,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedTime = DateTimeOffset.UtcNow,
                    ModifiedBy = Guid.NewGuid(),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = DateTimeOffset.MinValue
                }
            };
            modelBuilder.Entity<RoomEntity>().HasData(rooms);

            #endregion

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=TRANG\\SQLEXPRESS;Initial Catalog=DA1_Cinema410;Integrated Security=True;TrustServerCertificate=true");
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
        public DbSet<TicketEntity> TicketEntities { get; set; }
        public DbSet<UserEntity> UserEntities { get; set; }
        public DbSet<TransactionEntity> TransactionEntities { get; set; }
        #endregion
    }
}
