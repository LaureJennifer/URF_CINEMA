using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.ViewModels.Excels.Mics
{
    public class ExcelExportVM
    {
        public string Function { get; set; } = string.Empty;
        public List<ExcelParameterVM> Parameters { get; set; } = new();
        public bool IsTemplate { get; set; } = false;
    }
}
