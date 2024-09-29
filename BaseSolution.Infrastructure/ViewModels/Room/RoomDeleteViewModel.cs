using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Example.Request;
using BaseSolution.Application.DataTransferObjects.Room.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using BaseSolution.Infrastructure.Implements.Repositories.ReadWrite;
using BaseSolution.Infrastructure.Implements.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.Room
{
    public class RoomDeleteViewModel : ViewModelBase<RoomDeleteRequest>
    {
        private readonly IRoomReadWriteRepository _roomReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public RoomDeleteViewModel(IRoomReadWriteRepository RoomReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _roomReadWriteRepository = RoomReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }
        public override async Task HandleAsync(RoomDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _roomReadWriteRepository.DeleteRoomAsync(request, cancellationToken);

                Success = result.Success;
                ErrorItems = result.Errors;
                Message = result.Message;
                return;
            }
            catch (Exception)
            {
                Success = false;
                ErrorItems = new[]
                    {
                    new ErrorItem
                    {
                        Error = _localizationService["Error occurred while updating the room"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToDelete, "room")
                    }
                };
            }
        }
    }
}
