using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.ViewModels.Excels.Mics
{
    public class ExcelErrorVM
    {
        public int Row { get; set; }
        public int? Col { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
