using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Room.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.Room
{
    public class RoomUpdateViewModel : ViewModelBase<RoomUpdateRequest>
    {
        private readonly IRoomReadWriteRepository _roomReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public RoomUpdateViewModel(IRoomReadWriteRepository RoomReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _roomReadWriteRepository = RoomReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }
        public override async Task HandleAsync(RoomUpdateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _roomReadWriteRepository.UpdateRoomAsync(_mapper.Map<RoomEntity>(request), cancellationToken);

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
                        FieldName = string.Concat(LocalizationString.Common.FailedToUpdate, "room")
                    }
                };
            }
        }
    }
}
