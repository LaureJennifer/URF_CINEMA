namespace URF_Cinema.Application.DataTransferObjects.Bill.Request
{
    public class BillDeleteRequest
    {
        public Guid Id { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTimeOffset DeletedTime { get; set; }
    }
}
