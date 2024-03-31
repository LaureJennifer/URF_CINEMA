using BaseSolution.Application.DataTransferObjects.Room;
using BaseSolution.Application.DataTransferObjects.Room.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.BlazorServer.Data;


namespace BaseSolution.BlazorServer.Repositories.Interfaces
{
    public interface IRoomRepo
    {
        public Task<bool> AddAsync(RoomCreateRequest request);
        public Task<RequestResult<RoomDeleteRequest>> RemoveAsync(RoomDeleteRequest request);
        public Task<bool> UpdateAsync(RoomUpdateRequest request);
        public Task<RequestResult<RoomDto>> GetByIdAsync(Guid id);
        public Task<RoomListWithPaginationViewModel> GetAllActive(ViewRoomWithPaginationRequest request);
    }
}
