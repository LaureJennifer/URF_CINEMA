using BaseSolution.Application.DataTransferObjects.RoomLayout;
using BaseSolution.Application.DataTransferObjects.RoomLayout.Request;
using BaseSolution.Client.Data;
using BaseSolution.Client.ValueObjects.Response;

namespace BaseSolution.Client.Repositories.Interfaces
{
    public interface IRoomLayoutRepo
    {
        public Task<bool> AddAsync(RoomLayoutCreateRequest request);
        public Task<RoomLayoutListWithPaginationViewModel> GetAllActive(ViewRoomLayoutWithPaginationRequest request);
        public Task<RequestResult<RoomLayoutDto>> GetByIdAsync(Guid id);
        public Task<RequestResult<RoomLayoutDto>> GetByNameAsync(string roomLayoutName);
        public Task<bool> RemoveAsync(RoomLayoutDeleteRequest request);
        public Task<bool> UpdateAsync(RoomLayoutUpdateRequest request);
    }
}
