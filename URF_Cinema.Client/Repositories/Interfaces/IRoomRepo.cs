using URF_Cinema.Application.DataTransferObjects.Room;
using URF_Cinema.Application.DataTransferObjects.Room.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Client.Data;

namespace URF_Cinema.Client.Repositories.Interfaces
{
    public interface IRoomRepo
    {
        public Task<bool> AddAsync(RoomCreateRequest request);
        public Task<RequestResult<RoomDeleteRequest>> RemoveAsync(RoomDeleteRequest request);
        public Task<bool> UpdateAsync(RoomUpdateRequest request);
        public Task<RequestResult<RoomDto>> GetByIdAsync(Guid id);
        public Task<RoomListWithPaginationViewModel> GetAllActive(ViewRoomWithPaginationRequest request);

        public Task<RoomListWithPaginationViewModel> GetRoomByDepartment(ViewRoomWithPaginationRequest request);

    }
}
