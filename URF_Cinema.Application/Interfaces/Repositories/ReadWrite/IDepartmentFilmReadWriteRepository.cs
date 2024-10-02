using URF_Cinema.Application.DataTransferObjects.DepartmentFilm.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadWrite
{
    public interface IDepartmentFilmReadWriteRepository
    {
        Task<RequestResult<Guid>> AddDepartmentFilmAsync(DepartmentFilmEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdateDepartmentFilmAsync(DepartmentFilmEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeleteDepartmentFilmAsync(DepartmentFilmDeleteRequest request, CancellationToken cancellationToken);
    }
}
