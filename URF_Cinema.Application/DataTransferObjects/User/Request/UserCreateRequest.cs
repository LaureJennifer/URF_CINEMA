namespace URF_Cinema.Application.DataTransferObjects.User.Request
{
    public class UserCreateRequest
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UrlImage { get; set; }
        public Guid RoleId { get; set; }    
    }
}
