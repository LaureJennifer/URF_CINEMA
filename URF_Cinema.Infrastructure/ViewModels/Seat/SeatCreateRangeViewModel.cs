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
    public class SeatCreateRangeViewModel : ViewModelBase<List<SeatCreateRangeRequest>>
    {
        private readonly ISeatReadWriteRepository _seatReadWriteRepository;
        private readonly ISeatReadOnlyRepository _seatReadOnlyRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public SeatCreateRangeViewModel(ISeatReadWriteRepository seatReadWriteRepository, ISeatReadOnlyRepository seatReadOnlyRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _seatReadWriteRepository = seatReadWriteRepository;
            _seatReadOnlyRepository = seatReadOnlyRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(List<SeatCreateRangeRequest> data, CancellationToken cancellationToken)
        {
            try
            {
                var resultCreate = await _seatReadWriteRepository.CreateRangeSeatAsync(_mapper.Map<List<SeatEntity>>(data), cancellationToken);
                if (resultCreate.Success)
                {
                    var result = await _seatReadOnlyRepository.GetListSeatByIdAsync(resultCreate.Data, cancellationToken);
                    Data = result.Data!;
                    Success = result.Success;
                    ErrorItems = result.Errors;
                    Message = result.Message;
                    return;
                }
                Success = resultCreate.Success;
                ErrorItems = resultCreate.Errors;
                Message = resultCreate.Message;
            }
            catch (Exception)
            {
                Success = false;
                ErrorItems = new[]
                    {
                    new ErrorItem
                    {
                        Error = _localizationService["Error occurred while getting the seat"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "seat")
                    }
                };
            }
        }
    }
}
