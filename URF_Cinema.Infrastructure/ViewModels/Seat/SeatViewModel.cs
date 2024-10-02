using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.Seat
{
    public class SeatViewModel : ViewModelBase<Guid>
    {
        private readonly ISeatReadOnlyRepository _seatReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public SeatViewModel(ISeatReadOnlyRepository seatReadOnlyRepository, ILocalizationService localizationService)
        {
            _seatReadOnlyRepository = seatReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(Guid idSeat, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _seatReadOnlyRepository.GetSeatByIdAsync(idSeat, cancellationToken);
                Data = result.Data!;
                Success = result.Success;
                ErrorItems = result.Errors;
                Message = result.Message;
                return;
            }
            catch
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
