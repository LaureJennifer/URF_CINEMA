using BaseSolution.Application.DataTransferObjects.Film.Request;
using BaseSolution.Application.DataTransferObjects.Seat.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.Seat
{
    public class SeatListWithPaginationViewModel: ViewModelBase<ViewSeatWithPaginationRequest>
    {
        private readonly ISeatReadOnlyRepository _seatReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public SeatListWithPaginationViewModel(ISeatReadOnlyRepository seatReadOnlyRepository, ILocalizationService localizationService)
        {
            _seatReadOnlyRepository = seatReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(ViewSeatWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _seatReadOnlyRepository.GetSeatWithPaginationByAdminAsync(request, cancellationToken);

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
                        Error = _localizationService["Error occurred while getting the list of seat"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "list of seat")
                    }
                };
            }
        }
    }
}
