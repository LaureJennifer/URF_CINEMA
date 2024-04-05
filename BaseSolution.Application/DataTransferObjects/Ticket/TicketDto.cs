using BaseSolution.Domain.Entities;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Ticket
{
    public class TicketDto
    {
        public Guid Id { get; set; }
        public Guid BillId { get; set; }
        public string DepartmentName { get; set; }
        public string FilmName { get; set; }
        public string SeatCode { get; set; }
        public string RoomCode { get; set; }
        public double Price { get; set; }
        public DateTimeOffset ShowDate { get; set; }
        public DateTimeOffset ShowTime { get; set; }
        public string Code { get; set; }
        public EntityStatus Status { get; set; }
        public DateTimeOffset CreatedTime { get; set; }

    }
}
