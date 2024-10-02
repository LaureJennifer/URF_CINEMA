using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.RoomLayout.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.RoomLayout
{
    public class RoomLayoutDeleteViewModel : ViewModelBase<RoomLayoutDeleteRequest>
    {
        private readonly IRoomLayoutReadWriteRepository _roomLayoutReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public RoomLayoutDeleteViewModel(IRoomLayoutReadWriteRepository roomLayoutReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _roomLayoutReadWriteRepository = roomLayoutReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(RoomLayoutDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _roomLayoutReadWriteRepository.DeleteRoomLayoutAsync(request, cancellationToken);

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
                        Error = _localizationService["Error occurred while updating the room layout"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToDelete, "room layout")
                    }
                };
            }
        }
    }
}
