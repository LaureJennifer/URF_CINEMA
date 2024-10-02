namespace URF_Cinema.Application.Interfaces.Repositories.ReadOnly
{
    public interface IFileHandlingReadOnlyRepository
    {
        // phương thuwsd này để lấy 
        Task<FileStream?> GetFileStreamAsync(string fileName, string folder);
    }
}
