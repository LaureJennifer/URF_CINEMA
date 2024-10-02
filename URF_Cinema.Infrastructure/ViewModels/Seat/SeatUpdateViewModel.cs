using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Seat.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.Seat
{
    public class SeatUpdateViewModel : ViewModelBase<SeatUpdateRequest>
    {
        private readonly ISeatReadWriteRepository _seatReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public SeatUpdateViewModel(ISeatReadWriteRepository SeatReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _seatReadWriteRepository = SeatReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }
        public override async Task HandleAsync(SeatUpdateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _seatReadWriteRepository.UpdateSeatAsync(_mapper.Map<SeatEntity>(request), cancellationToken);

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
                        Error = _localizationService["Error occurred while updating the Seat"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToUpdate, "Seat")
                    }
                };
            }
        }
    }
}
