using URF_Cinema.Application.DataTransferObjects.Film.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadWrite
{
    public interface IFilmReadWriteRepository
    {
        Task<RequestResult<Guid>> AddFilmAsync(FilmEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdateFilmAsync(FilmEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeleteFilmAsync(FilmDeleteRequest request, CancellationToken cancellationToken);
    }
}
