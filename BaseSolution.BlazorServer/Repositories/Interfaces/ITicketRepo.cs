using BaseSolution.Application.DataTransferObjects.Ticket.Request;
using BaseSolution.Application.DataTransferObjects.Ticket;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.BlazorServer.Data;

namespace BaseSolution.BlazorServer.Repositories.Interfaces
{
    public interface ITicketRepo
    {
        public Task<bool> AddAsync(TicketCreateRequest request);
        public Task<RequestResult<TicketDeleteRequest>> RemoveAsync(TicketDeleteRequest request);
        public Task<bool> UpdateAsync(TicketUpdateRequest request);
        public Task<RequestResult<TicketDto>> GetByIdAsync(Guid id);
        public Task<TicketListWithPaginationViewModel> GetAllActive(ViewTicketWithPaginationRequest request);
    }
}
