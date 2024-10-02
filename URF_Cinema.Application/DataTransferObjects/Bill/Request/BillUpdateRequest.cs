using URF_Cinema.Domain.Entities;
using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.Bill.Request
{
    public class BillUpdateRequest
    {
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public int? TicketQuantity { get; set; }
        public string? Description { get; set; }
        public double? TotalPrice { get; set; }
        public EntityStatus? Status { get; set; }
        public CustomerEntity? CustomerEntity { get; set; }

    }
}
