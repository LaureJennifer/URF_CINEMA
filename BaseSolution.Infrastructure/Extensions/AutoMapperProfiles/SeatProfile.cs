using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseSolution.Application.DataTransferObjects.Seat;
using BaseSolution.Application.DataTransferObjects.Seat.Request;

namespace BaseSolution.Infrastructure.Extensions.AutoMapperProfiles
{
    public class SeatProfile : Profile
    {
        public SeatProfile()
        {
            CreateMap<SeatEntity, SeatDto>()
                .ForMember(des => des.RoomLayoutName, opt => opt.MapFrom(src => src.RoomLayoutEntity.Name));
            CreateMap<SeatCreateRangeRequest, SeatEntity>();
            CreateMap<SeatCreateRequest, SeatEntity>();
            CreateMap<SeatUpdateRequest, SeatEntity>();
        }
    }
}
