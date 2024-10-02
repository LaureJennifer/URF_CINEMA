using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Room.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.Room
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
