using BaseSolution.Application.DataTransferObjects.Ticket.Request;
using BaseSolution.Application.DataTransferObjects.Ticket;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseSolution.Application.DataTransferObjects.FilmDetail;
using BaseSolution.Application.DataTransferObjects.FilmDetail.Request;

namespace BaseSolution.Application.Interfaces.Repositories.ReadOnly
{
    public interface IFilmDetailReadOnlyRepository
    {
        Task<RequestResult<FilmDetailDto?>> GetFilmDetailByIdAsync(Guid idFilmDetail, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<FilmDetailDto>>> GetFilmDetailWithPaginationByAdminAsync(
            ViewFilmDetailWithPaginationRequest request, CancellationToken cancellationToken);
    }
}
