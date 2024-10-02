namespace URF_Cinema.Client.Data.DataTransferObjects.Example.Request
{
    public class ExampleDeleteRequest
    {
        public Guid Id { get; set; }
        public Guid? DeletedBy { get; set; }
    }
}
