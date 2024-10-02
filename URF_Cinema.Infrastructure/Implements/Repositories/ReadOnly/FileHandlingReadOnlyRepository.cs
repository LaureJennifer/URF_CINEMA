using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;

namespace URF_Cinema.Infrastructure.Implements.Repositories.ReadOnly
{
    public class FileHandlingReadOnlyRepository : IFileHandlingReadOnlyRepository
    {
        private readonly string _pathFolder;
        public FileHandlingReadOnlyRepository()
        {
            _pathFolder = Path.Combine(Directory.GetCurrentDirectory(), "SavedFiles");
        }
        public async Task<FileStream?> GetFileStreamAsync(string fileName, string folder)
        {
            var filePath = Path.Combine(_pathFolder, folder, fileName);
            if (File.Exists(filePath))
            {
                var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                return stream;
            }
            return null;
        }
    }
}
