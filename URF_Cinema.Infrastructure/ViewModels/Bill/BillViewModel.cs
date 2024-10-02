using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.Bill
{
    public class BillViewModel : ViewModelBase<Guid>
    {
        private readonly IBillReadOnlyRepository _billReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public BillViewModel(IBillReadOnlyRepository billReadOnlyRepository, ILocalizationService localizationService)
        {
            _billReadOnlyRepository = billReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(Guid idBill, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _billReadOnlyRepository.GetBillByIdAsync(idBill, cancellationToken);
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
                        Error = _localizationService["Error occurred while getting the bill"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "bill")
                    }
                };
            }
        }
    }
}
