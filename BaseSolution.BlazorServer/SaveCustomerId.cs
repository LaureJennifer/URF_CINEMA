using BaseSolution.Application.DataTransferObjects.Booking;

namespace BaseSolution.BlazorServer
{
    public class SaveCustomerId
    {
        public string CustomerId { get;set; }
        public List<BookingDto> ListBooking { get; set; }    
    }
}
