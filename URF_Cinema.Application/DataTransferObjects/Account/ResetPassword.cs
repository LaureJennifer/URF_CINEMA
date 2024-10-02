namespace URF_Cinema.Application.DataTransferObjects.Account
{
    public class ResetPassword
    {
        public string PasswordOld { get; set; }
        public string PasswordNew { get; set; }
        public Guid Id { get; set; }
    }
}
