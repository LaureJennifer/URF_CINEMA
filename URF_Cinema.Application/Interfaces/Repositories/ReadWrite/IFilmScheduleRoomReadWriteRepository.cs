using URF_Cinema.Application.DataTransferObjects.FilmScheduleRoom.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadWrite
{
    public interface IFilmScheduleRoomReadWriteRepository
    {
        Task<RequestResult<Guid>> AddFilmScheduleRoomAsync(FilmScheduleRoomEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdateFilmScheduleRoomAsync(FilmScheduleRoomEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeleteFilmScheduleRoomAsync(FilmScheduleRoomDeleteRequest request, CancellationToken cancellationToken);

        Task<RequestResult<List<Guid>>> CreateRangeFilmScheduleRoomAsync(List<FilmScheduleRoomEntity> requests, CancellationToken cancellationToken);

    }
}
