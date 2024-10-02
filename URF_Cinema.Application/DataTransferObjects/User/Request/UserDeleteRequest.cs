namespace URF_Cinema.Application.DataTransferObjects.User.Request
{
    public class UserDeleteRequest
    {
        public Guid Id { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTimeOffset DeletedTime { get; set; }
    }
}
