using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class FacilityEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<DepartmentEntity> departmentEntities { get; set; }
    }
}
