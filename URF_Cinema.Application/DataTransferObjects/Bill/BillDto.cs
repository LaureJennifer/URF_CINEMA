using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.Bill
{
    public class BillDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid DepartmentId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string DepartmentName { get; set; }
        public string Code { get; set; }

        public int TicketQuantity { get; set; }
        public string Description { get; set; }
        public double TotalPrice { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public EntityStatus Status { get; set; }
    }
}
