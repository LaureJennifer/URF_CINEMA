namespace URF_Cinema.Application.Interfaces.Services
{
    public interface ICurrentUser
    {
        Guid? Id { get; }
        string Name { get; }
        string Email { get; }
        public string UserName { get; }
        List<string> RoleCodes { get; }
        List<string> RoleNames { get; }
        public string Localhost
        {
            get;
        }
    }
}
