using BaseSolution.Domain.Entities;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Booking
{
    public class BookingDto
    {
        public Guid Id { get; set; }
        public Guid SeatId { get; set; }
        public Guid RoomId { get; set; }
        public string SeatCode { get; set; }
        public string RoomCode { get; set; }
        public EntityStatus SeatStatus { get; set; }

        public DateTimeOffset ExpiredTime { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
    }
}
