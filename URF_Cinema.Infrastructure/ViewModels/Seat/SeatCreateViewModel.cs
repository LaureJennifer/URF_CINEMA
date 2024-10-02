using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Seat.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.Seat
{
    public class SeatCreateViewModel : ViewModelBase<SeatCreateRequest>
    {
        private readonly ISeatReadOnlyRepository _seatReadOnlyRepository;
        private readonly ISeatReadWriteRepository _seatReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public SeatCreateViewModel(ISeatReadOnlyRepository SeatReadOnlyRepository, ISeatReadWriteRepository SeatReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _seatReadOnlyRepository = SeatReadOnlyRepository;
            _seatReadWriteRepository = SeatReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }
        public override async Task HandleAsync(SeatCreateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var createResult = await _seatReadWriteRepository.AddSeatAsync(_mapper.Map<SeatEntity>(request), cancellationToken);

                if (createResult.Success)
                {
                    var result = await _seatReadOnlyRepository.GetSeatByIdAsync(createResult.Data, cancellationToken);

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
                        Error = _localizationService["Error occurred while getting the Seat"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "Seat")
                    }
                };
            }
        }
    }
}
