using URF_Cinema.Application.DataTransferObjects.Ticket.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.Statistic.Ticket
{
    public class GetTicketStatisticForQuarterViewModel: ViewModelBase<TicketStatisticRequest>
    {
        private readonly ITicketStatisticReadOnlyRespository _ticketStatisticReadOnlyRespository;
        private readonly ILocalizationService _localizationService;

        public GetTicketStatisticForQuarterViewModel(ITicketStatisticReadOnlyRespository ticketStatisticReadOnlyRespository, ILocalizationService localizationService)
        {
            _ticketStatisticReadOnlyRespository = ticketStatisticReadOnlyRespository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(TicketStatisticRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _ticketStatisticReadOnlyRespository.GetTicketStasticForQuarterAsync(request, cancellationToken);

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
                    Error = _localizationService["Error occurred while getting the list of ticket statistic for quarter"],
                    FieldName = string.Concat(LocalizationString.Common.FailedToGet, "list of ticket statistic for quarter")
                }
            };
            }
        }
    }
}
