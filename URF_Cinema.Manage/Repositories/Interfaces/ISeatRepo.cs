using URF_Cinema.Application.DataTransferObjects.Seat;
using URF_Cinema.Application.DataTransferObjects.Seat.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Manage.Data;

namespace URF_Cinema.Manage.Repositories.Interfaces
{
    public interface ISeatRepo
    {
        public Task<bool> AddAsync(SeatCreateRequest request);
        public Task<bool> RemoveAsync(SeatDeleteRequest request);
        public Task<bool> UpdateAsync(SeatUpdateRequest request);
        public Task<RequestResult<SeatDto>> GetByIdAsync(Guid id);
        public Task<SeatListWithPaginationViewModel> GetAllActive(ViewSeatWithPaginationRequest request);

        public Task<bool> AddRangeAsync(List<SeatCreateRangeRequest> request);
    }
}
