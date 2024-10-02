namespace URF_Cinema.Application.DataTransferObjects.Department.Request
{
    public class DepartmentDeleteRequest
    {
        public Guid Id { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTimeOffset DeletedTime { get; set; }
    }
}
