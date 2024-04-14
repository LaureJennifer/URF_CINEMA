using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class JsonStorage
    {
        public Guid Id { get; set; }
        public string JsonList { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
