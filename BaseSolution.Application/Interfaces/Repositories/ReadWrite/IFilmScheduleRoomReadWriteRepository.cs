using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom.Request;
using BaseSolution.Application.DataTransferObjects.Ticket.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.Interfaces.Repositories.ReadWrite
{
    public interface IFilmScheduleRoomReadWriteRepository
    {
        Task<RequestResult<Guid>> AddFilmScheduleRoomAsync(FilmScheduleRoomEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdateFilmScheduleRoomAsync(FilmScheduleRoomEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeleteFilmScheduleRoomAsync(FilmSheduleRoomDeleteRequest request, CancellationToken cancellationToken);
    }
}
