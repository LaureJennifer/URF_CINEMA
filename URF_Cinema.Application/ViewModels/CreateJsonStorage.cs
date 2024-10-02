namespace URF_Cinema.Infrastructure.ViewModels
{
    public class CreateJsonStorage<T> where T : class
    {
        public IList<T> Entities { get; set; }
    }
}
