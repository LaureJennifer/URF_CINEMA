using URF_Cinema.Application.DataTransferObjects.Ticket.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.Ticket
{
    public class TicketListWithPaginationViewModel: ViewModelBase<ViewTicketWithPaginationRequest>
    {
        private readonly ITicketReadOnlyRepository _ticketReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public TicketListWithPaginationViewModel(ITicketReadOnlyRepository ticketReadOnlyRepository, ILocalizationService localizationService)
        {
            _ticketReadOnlyRepository = ticketReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(ViewTicketWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _ticketReadOnlyRepository.GetTicketWithPaginationByAdminAsync(request, cancellationToken);

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
                        Error = _localizationService["Error occurred while getting the list of ticket"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "list of ticket")
                    }
                };
            }
        }
    }
}
