using BaseSolution.Application.ViewModels.Excels.Mics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.Interfaces.Repositories.ReadWrite
{
    public interface IFileHandlingReadWriteRepository
    {
        Task<ExcelOutputVM> ExcelImport(ExcelImportInputVM obj);
    }
}
