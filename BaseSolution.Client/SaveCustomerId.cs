using BaseSolution.Application.DataTransferObjects.Booking;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Client.Shared;
using Microsoft.AspNetCore.Components;
using System.Reflection.Metadata;

namespace BaseSolution.Client
{
    public class SaveCustomerId
    {
        public string CustomerId { get;set; }
        public string Name { get;set; }
        public List<BookingDto> ListBooking { get; set; }

        public Type LayoutOption { get; set; } = typeof(MainLayout);

        public Roles RoleCode { get; set; }

    }
}
