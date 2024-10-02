using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.RoomLayout.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.RoomLayout
{
    public class RoomLayoutCreateViewModel: ViewModelBase<RoomLayoutCreateRequest>
    {
        private readonly IRoomLayoutReadOnlyRepository _roomLayoutReadOnlyRepository;
        private readonly IRoomLayoutReadWriteRepository _roomLayoutReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public RoomLayoutCreateViewModel(IRoomLayoutReadOnlyRepository roomLayoutReadOnlyRepository, IRoomLayoutReadWriteRepository roomLayoutReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _roomLayoutReadOnlyRepository = roomLayoutReadOnlyRepository;
            _roomLayoutReadWriteRepository = roomLayoutReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(RoomLayoutCreateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var createResult = await _roomLayoutReadWriteRepository.AddRoomLayoutAsync(_mapper.Map<RoomLayoutEntity>(request), cancellationToken);

                if (createResult.Success)
                {
                    var result = await _roomLayoutReadOnlyRepository.GetRoomLayoutByIdAsync(createResult.Data, cancellationToken);

                    Data = createResult;
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
                        Error = _localizationService["Error occurred while getting the room layout"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "room layout")
                    }
                };
            }
        }
    }
}
