using URF_Cinema.Application.DataTransferObjects.Bill.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.Bill
{
    public class BillListWithPaginationViewModel :ViewModelBase<ViewBillWithPaginationRequest>
    {
        private readonly IBillReadOnlyRepository _billReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public BillListWithPaginationViewModel(IBillReadOnlyRepository billReadOnlyRepository, ILocalizationService localizationService)
        {
            _billReadOnlyRepository = billReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(ViewBillWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _billReadOnlyRepository.GetBillWithPaginationByAdminAsync(request, cancellationToken);

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
                        Error = _localizationService["Error occurred while getting the list of bill"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "list of bill")
                    }
                };
            }
        }
    }
}
