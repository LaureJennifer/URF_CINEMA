using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Application.DataTransferObjects.FilmScheduleRoom;
using URF_Cinema.Application.DataTransferObjects.FilmScheduleRoom.Request;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadOnly
{
    public interface IFilmScheduleRoomReadOnlyRepository
    {
        Task<RequestResult<FilmScheduleRoomDto?>> GetFilmScheduleRoomByIdAsync(Guid idFilmScheduleRoom, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<FilmScheduleRoomDto>>> GetFilmScheduleRoomWithPaginationByAdminAsync(
            ViewFilmScheduleRoomWithPaginationRequest request, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<FilmScheduleRoomDto>>> GetRoomByFilmScheduleWithPaginationByAdminAsync(
            ViewRoomByFilmScheduleWithPaginationRequest request, CancellationToken cancellationToken);
        Task<RequestResult<FilmScheduleRoomDto?>> GetFilmScheduleRoomByShowDateTimeAsync(FilmScheduleRoomFindByDateTimeRequest request, CancellationToken cancellationToken);

        Task<RequestResult<List<FilmScheduleRoomDto>>> GetListFilmScheduleRoomByIdAsync(List<Guid> listIdFilmScheduleRoom, CancellationToken cancellationToken);

    }
}
