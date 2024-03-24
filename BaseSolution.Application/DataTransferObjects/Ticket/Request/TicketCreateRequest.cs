using BaseSolution.Domain.Entities;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Ticket.Request
{
    public class TicketCreateRequest
    {
        public Guid BillId { get; set; }
        public Guid FilmId { get; set; }
        public Guid BookingId { get; set; }
        public string Code { get; set; }
        public EntityStatus Status { get; set; }

    }
}
