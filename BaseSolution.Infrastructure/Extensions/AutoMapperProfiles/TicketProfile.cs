using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Domain.Entities;
using BaseSolution.Application.DataTransferObjects.Ticket;
using BaseSolution.Application.DataTransferObjects.Ticket.Request;

namespace BaseSolution.Infrastructure.Extensions.AutoMapperProfiles
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<TicketEntity, TicketDto>();
            CreateMap<TicketCreateRequest, TicketEntity>();
            CreateMap<TicketUpdateRequest, TicketEntity>();
        }
    }
}
