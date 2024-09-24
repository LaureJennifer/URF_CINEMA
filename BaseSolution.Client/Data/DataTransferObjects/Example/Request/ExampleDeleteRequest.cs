namespace BaseSolution.BlazorServer.Data.DataTransferObjects.Example.Request
{
    public class ExampleDeleteRequest
    {
        public Guid Id { get; set; }
        public Guid? DeletedBy { get; set; }
    }
}
