using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom.Request;
using BaseSolution.Application.DataTransferObjects.RoomLayout.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.Interfaces.Repositories.ReadWrite
{
    public interface IRoomLayoutReadWriteRepository
    {
        Task<RequestResult<Guid>> AddRoomLayoutAsync(RoomLayoutEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdateRoomLayoutAsync(RoomLayoutEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeleteRoomLayoutAsync(RoomLayoutDeleteRequest request, CancellationToken cancellationToken);

    }
}
