using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Seat.Request
{
    public class SeatUpdateRequest
    {
        public Guid Id { get; set; }
        public Guid? RoomLayoutId { get; set; }
        public string? Code { get; set; }
        public string? SeatPosition { get; set; }
        public string? Type { get; set; }
        public double? Price { get; set; }
        public EntityStatus? Status { get; set; }
    }
}
