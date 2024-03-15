using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Film.Request;
using BaseSolution.Application.DataTransferObjects.FilmSchedule.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.Interfaces.Repositories.ReadWrite
{
    public interface IFilmScheduleReadWriteRepository
    {
        Task<RequestResult<Guid>> AddFilmScheduleAsync(FilmScheduleEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdateFilmScheduleAsync(FilmScheduleEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeleteFilmScheduleAsync(FilmScheduleDeleteRequest request, CancellationToken cancellationToken);
    }
}
