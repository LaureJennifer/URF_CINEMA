using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class DepartmentEntity : IEntityBase
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email {  get; set; }
        public string PhoneNumber { get; set; }
        public string AddressCode { get; set; }
        public string AddressCodeFormat {  get; set; }
        public string Address { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTimeOffset ModifiedTime { get; set; }
        public Guid? ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTimeOffset DeletedTime { get; set; }
        
        public EntityStatus EntityStatus { get; set; }
        public List<DepartmentFilmEntity> DepartmentFilms { get; set; }
        public List<RoomEntity> Rooms { get; set; }
    }
}
