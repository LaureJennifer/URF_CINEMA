using BaseSolution.Application.DataTransferObjects.Room;
using BaseSolution.Application.DataTransferObjects.RoomLayout;
using BaseSolution.BlazorServer.ValueObjects.Response;


namespace BaseSolution.BlazorServer.Repositories.Interfaces
{
    public interface IRoomLayoutRepo
    {
        public Task<RequestResult<RoomLayoutDto>> GetByIdAsync(Guid id);

    }
}
