namespace URF_Cinema.Infrastructure.ViewModels
{
    public class JsonStorageVM<T> where T : class
    {
        public IList<T> Entities { get; set; }
    }
}
