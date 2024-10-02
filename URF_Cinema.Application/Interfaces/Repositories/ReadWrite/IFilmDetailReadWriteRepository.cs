using URF_Cinema.Application.DataTransferObjects.FilmDetail.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadWrite
{
    public interface IFilmDetailReadWriteRepository
    {
        Task<RequestResult<Guid>> AddFilmDetailAsync(FilmDetailEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdateFilmDetailAsync(FilmDetailEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeleteFilmDetailAsync(FilmDetailDeleteRequest request, CancellationToken cancellationToken);


    }
}
