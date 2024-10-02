using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Room.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.Room
{
    public class RoomCreateViewModel : ViewModelBase<RoomCreateRequest>
    {
        private readonly IRoomReadOnlyRepository _roomReadOnlyRepository;
        private readonly IRoomReadWriteRepository _roomReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public RoomCreateViewModel(IRoomReadOnlyRepository RoomReadOnlyRepository, IRoomReadWriteRepository RoomReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _roomReadOnlyRepository = RoomReadOnlyRepository;
            _roomReadWriteRepository = RoomReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }
        public override async Task HandleAsync(RoomCreateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var createResult = await _roomReadWriteRepository.AddRoomAsync(_mapper.Map<RoomEntity>(request), cancellationToken);

                if (createResult.Success)
                {
                    var result = await _roomReadOnlyRepository.GetRoomByIdAsync(createResult.Data, cancellationToken);

                    Data = result.Data!;
                    Success = result.Success;
                    ErrorItems = result.Errors;
                    Message = result.Message;
                    return;
                }

                Success = createResult.Success;
                ErrorItems = createResult.Errors;
                Message = createResult.Message;
            }
            catch (Exception)
            {
                Success = false;
                ErrorItems = new[]
                    {
                    new ErrorItem
                    {
                        Error = _localizationService["Error occurred while getting the room"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "room")
                    }
                };
            }
        }
    }
}
