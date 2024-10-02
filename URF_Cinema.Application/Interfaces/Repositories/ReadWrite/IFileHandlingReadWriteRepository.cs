using URF_Cinema.Application.ViewModels.Excels.Mics;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadWrite
{
    public interface IFileHandlingReadWriteRepository
    {
        Task<ExcelOutputVM> ExcelImport(ExcelImportInputVM obj);
    }
}
