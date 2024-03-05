using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class DepartmentEntity
    {
        public Guid Id { get; set; }
        public Guid FacilityId { get; set; }
        public string Name { get; set; }
        public string Email {  get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public List<DepartmentFilmEntity> DepartmentFilm { get; set; }
        public List<DepartmentRoomEntity> DepartmentRoomEntities { get; set; }
        public FacilityEntity Facility { get; set; }
        public DepartmentEntity()
        {
            DepartmentFilm = new List<DepartmentFilmEntity>();
        }
    }
}
