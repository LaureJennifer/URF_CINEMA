using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.RoomLayout.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.RoomLayout
{
    public class RoomLayoutUpdateViewModel:ViewModelBase<RoomLayoutUpdateRequest>
    {
        private readonly IRoomLayoutReadWriteRepository _roomLayoutReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public RoomLayoutUpdateViewModel(IRoomLayoutReadWriteRepository roomLayoutReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _roomLayoutReadWriteRepository = roomLayoutReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(RoomLayoutUpdateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _roomLayoutReadWriteRepository.UpdateRoomLayoutAsync(_mapper.Map<RoomLayoutEntity>(request), cancellationToken);

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
                        FieldName = string.Concat(LocalizationString.Common.FailedToUpdate, "room layout")
                    }
                };
            }
        }
    }
}
