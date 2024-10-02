using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.Ticket
{
    public class TicketViewModel:ViewModelBase<Guid>
    {
        private readonly ITicketReadOnlyRepository _ticketReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public TicketViewModel(ITicketReadOnlyRepository ticketReadOnlyRepository, ILocalizationService localizationService)
        {
            _ticketReadOnlyRepository = ticketReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(Guid idTicket, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _ticketReadOnlyRepository.GetTicketByIdAsync(idTicket, cancellationToken);
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
                        Error = _localizationService["Error occurred while getting the ticket"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "ticket")
                    }
                };
            }
        }
    }
}
