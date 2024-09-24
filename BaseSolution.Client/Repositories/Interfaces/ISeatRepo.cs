using BaseSolution.Application.DataTransferObjects.Seat;
using BaseSolution.Application.DataTransferObjects.Seat.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Client.Data;

namespace BaseSolution.Client.Repositories.Interfaces
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
