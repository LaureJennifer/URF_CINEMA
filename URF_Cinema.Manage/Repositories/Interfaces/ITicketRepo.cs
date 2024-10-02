using URF_Cinema.Application.DataTransferObjects.Ticket.Request;
using URF_Cinema.Application.DataTransferObjects.Ticket;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Manage.Data;

namespace URF_Cinema.Manage.Repositories.Interfaces
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
