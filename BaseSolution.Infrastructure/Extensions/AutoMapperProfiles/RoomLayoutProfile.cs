using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseSolution.Application.DataTransferObjects.RoomLayout;
using BaseSolution.Application.DataTransferObjects.RoomLayout.Request;

namespace BaseSolution.Infrastructure.Extensions.AutoMapperProfiles
{
    public class RoomLayoutProfile : Profile
    {
        public RoomLayoutProfile()
        {
            CreateMap<RoomLayoutEntity, RoomLayoutDto>();
            CreateMap<RoomLayoutCreateRequest, RoomLayoutEntity>();
            CreateMap<RoomLayoutUpdateRequest, RoomLayoutEntity>();
        }
    }
}
