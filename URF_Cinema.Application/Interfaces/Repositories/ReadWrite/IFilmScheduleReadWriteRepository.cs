using URF_Cinema.Application.DataTransferObjects.FilmSchedule.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadWrite
{
    public interface IFilmScheduleReadWriteRepository
    {
        Task<RequestResult<Guid>> AddFilmScheduleAsync(FilmScheduleEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdateFilmScheduleAsync(FilmScheduleEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeleteFilmScheduleAsync(FilmScheduleDeleteRequest request, CancellationToken cancellationToken);
    }
}
