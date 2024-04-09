using BaseSolution.Application.DataTransferObjects.FilmSchedule.Request;
using BaseSolution.Application.DataTransferObjects.FilmSchedule;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom;
using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom.Request;
using BaseSolution.Application.DataTransferObjects.User;

namespace BaseSolution.Application.Interfaces.Repositories.ReadOnly
{
    public interface IFilmScheduleRoomReadOnlyRepository
    {
        Task<RequestResult<FilmScheduleRoomDto?>> GetFilmScheduleRoomByIdAsync(Guid idFilmScheduleRoom, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<FilmScheduleRoomDto>>> GetFilmScheduleRoomWithPaginationByAdminAsync(
            ViewFilmScheduleRoomWithPaginationRequest request, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<FilmScheduleRoomDto>>> GetRoomByFilmScheduleWithPaginationByAdminAsync(
            ViewRoomByFilmScheduleWithPaginationRequest request, CancellationToken cancellationToken);
        Task<RequestResult<FilmScheduleRoomDto?>> GetFilmScheduleRoomByShowDateTimeAsync(FilmScheduleRoomFindByDateTimeRequest request, CancellationToken cancellationToken);

    }
}
