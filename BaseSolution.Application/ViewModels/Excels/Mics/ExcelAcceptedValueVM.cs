using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.ViewModels.Excels.Mics
{
    public class ExcelAcceptedValueVM
    {
        public string ColumnName { get; set; } = string.Empty;
        public List<string> AcceptedValues { get; set; } = new();
        public bool MatchCase { get; set; } = false;
    }
}
