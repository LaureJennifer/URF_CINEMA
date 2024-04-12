using BaseSolution.Application.DataTransferObjects.RoomLayout;
using BaseSolution.Application.DataTransferObjects.RoomLayout.Request;
using BaseSolution.Application.DataTransferObjects.Seat.Request;
using BaseSolution.Application.DataTransferObjects.User.Request;
using BaseSolution.BlazorServer.Data;
using BaseSolution.BlazorServer.ValueObjects.Response;
namespace BaseSolution.BlazorServer.Repositories.Interfaces
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
