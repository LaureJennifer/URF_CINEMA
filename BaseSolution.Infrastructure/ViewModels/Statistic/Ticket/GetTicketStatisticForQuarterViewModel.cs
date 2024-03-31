using BaseSolution.Application.DataTransferObjects.Ticket.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.Statistic.Ticket
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
