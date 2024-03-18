using BaseSolution.Application.DataTransferObjects.Film.Request;
using BaseSolution.Application.DataTransferObjects.Film;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseSolution.Application.DataTransferObjects.FilmSchedule;
using BaseSolution.Application.DataTransferObjects.FilmSchedule.Request;

namespace BaseSolution.Application.Interfaces.Repositories.ReadOnly
{
    public interface IFilmScheduleReadOnlyRepository
    {
        Task<RequestResult<FilmScheduleDto?>> GetFilmScheduleByIdAsync(Guid idFilmSchedule, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<FilmScheduleDto>>> GetFilmScheduleWithPaginationByAdminAsync(
            ViewFilmScheduleWithPaginationRequest request, CancellationToken cancellationToken);
    }
}
