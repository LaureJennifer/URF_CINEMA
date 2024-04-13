using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels
{
    public class CreateJsonStorage<T> where T : class
    {
        public IList<T> Entities { get; set; }
    }
}
