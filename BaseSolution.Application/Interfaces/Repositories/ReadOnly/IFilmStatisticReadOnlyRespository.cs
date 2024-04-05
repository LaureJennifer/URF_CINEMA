using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.ValueObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseSolution.Application.DataTransferObjects.Film;
using BaseSolution.Application.DataTransferObjects.Film.Request;

namespace BaseSolution.Application.Interfaces.Repositories.ReadOnly
{
    public interface IFilmStatisticReadOnlyRespository
    {
        Task<RequestResult<List<FilmStatisticForMonthDto>>> GetFilmStatisticForMonthAsync(
       FilmStatisticRequest request, CancellationToken cancellationToken);
        Task<RequestResult<List<FilmStatisticForQuarterDto>>> GetFilmStatisticForQuarterAsync(
        FilmStatisticRequest request, CancellationToken cancellationToken);
        Task<RequestResult<List<FilmStatisticForYearDto>>> GetFilmStatisticForYearAsync(
        FilmStatisticRequest request, CancellationToken cancellationToken);
    }
}
