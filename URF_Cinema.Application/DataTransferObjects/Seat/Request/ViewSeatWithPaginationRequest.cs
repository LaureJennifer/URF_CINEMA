using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.Seat.Request
{
    public class ViewSeatWithPaginationRequest:PaginationRequest
    {
        public Guid? RoomLayoutId { get; set; }

        public string? RoomLayoutName { get; set; }
        public string? Code { get; set; }
        public EntityTypeSeat? Type { get; set; }
        public double? Price { get; set; }
    }
}
