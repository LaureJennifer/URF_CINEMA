using BaseSolution.Application.DataTransferObjects.Booking;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.BlazorServer.Shared;
using Microsoft.AspNetCore.Components;
using System.Reflection.Metadata;

namespace BaseSolution.BlazorServer
{
    public class SaveCustomerId
    {
        public string CustomerId { get;set; }
        public string Name { get;set; }
        public List<BookingDto> ListBooking { get; set; }

        public Type LayoutOption { get; set; } = typeof(CustomerLayout);

        public Roles RoleCode { get; set; }

    }
}
