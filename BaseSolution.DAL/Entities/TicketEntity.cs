using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class TicketEntity : EntityBase
    {
        public Guid Id { get; set; }
        public Guid BillId { get; set;}
        public Guid FilmId { get; set;}
        public Guid BookingId { get; set;}
        public string Code {  get; set;}
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public BillEntity BillEntity { get; set; }
        public FilmEntity FilmEntity { get; set; }
        public BookingEntity BookingEntity { get; set; }
    }
}
