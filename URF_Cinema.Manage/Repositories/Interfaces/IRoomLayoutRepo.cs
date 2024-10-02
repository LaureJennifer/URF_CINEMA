using URF_Cinema.Application.DataTransferObjects.RoomLayout;
using URF_Cinema.Application.DataTransferObjects.RoomLayout.Request;
using URF_Cinema.Manage.Data;
using URF_Cinema.Manage.Data.ValueObjects.Response;

namespace URF_Cinema.Manage.Repositories.Interfaces
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
