using BaseSolution.Application.DataTransferObjects.Room;
using BaseSolution.BlazorServer.ValueObjects.Response;

namespace BaseSolution.BlazorServer.Repositories.Interfaces
{
    public interface IRoomRepo
    {
        public Task<RequestResult<RoomDto>> GetByIdAsync(Guid id);

    }
}
