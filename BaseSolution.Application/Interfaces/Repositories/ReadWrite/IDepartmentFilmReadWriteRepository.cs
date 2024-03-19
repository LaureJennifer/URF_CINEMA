using BaseSolution.Application.DataTransferObjects.Booking.Request;
using BaseSolution.Application.DataTransferObjects.DepartmentFilm.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.Interfaces.Repositories.ReadWrite
{
    public interface IDepartmentFilmReadWriteRepository
    {
        Task<RequestResult<Guid>> AddDepartmentFilmAsync(DepartmentFilmEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdateDepartmentFilmAsync(DepartmentFilmEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeleteDepartmentFilmAsync(DepartmentFilmDeleteRequest request, CancellationToken cancellationToken);
    }
}
