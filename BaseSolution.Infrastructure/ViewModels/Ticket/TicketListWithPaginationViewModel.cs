using BaseSolution.Application.DataTransferObjects.Booking.Request;
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

namespace BaseSolution.Infrastructure.ViewModels.Ticket
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
