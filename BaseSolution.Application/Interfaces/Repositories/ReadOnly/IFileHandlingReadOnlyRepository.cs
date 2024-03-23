using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.Interfaces.Repositories.ReadOnly
{
    public interface IFileHandlingReadOnlyRepository
    {
        // phương thuwsd này để lấy 
        Task<FileStream?> GetFileStreamAsync(string fileName, string folder);
    }
}
