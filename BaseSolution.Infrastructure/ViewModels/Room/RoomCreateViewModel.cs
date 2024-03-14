using AutoMapper;
using Azure.Core;
using BaseSolution.Application.DataTransferObjects.Role.Request;
using BaseSolution.Application.DataTransferObjects.Room.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using BaseSolution.Domain.Entities;
using BaseSolution.Infrastructure.Implements.Repositories.ReadOnly;
using BaseSolution.Infrastructure.Implements.Repositories.ReadWrite;
using BaseSolution.Infrastructure.Implements.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.Room
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
                        Error = _localizationService["Error occurred while getting the Room"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "Room")
                    }
                };
            }
        }
    }
}
