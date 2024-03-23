using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.ViewModels.Excels.Mics
{
    public class ExcelValidationResultVM
    {
        public List<int> ValidRows { get; set; } = new();
        public MemoryStream? MemoryStream { get; set; }
    }
}
