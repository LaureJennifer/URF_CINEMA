namespace URF_Cinema.Application.DataTransferObjects.Bill.Request
{
    public class BillCreateRequest
    {
        public Guid CustomerId { get; set; }
        public Guid DepartmentId { get; set; }
        public string Description { get; set; } = string.Empty;
        public double TotalPrice { get; set; }
        public string Code { get; set; }
    }
}
