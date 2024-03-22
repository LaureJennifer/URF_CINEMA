using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Film.Request;
using BaseSolution.Application.DataTransferObjects.RoomLayout.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.RoomLayout
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
