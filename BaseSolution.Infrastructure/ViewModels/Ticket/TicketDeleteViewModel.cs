using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Booking.Request;
using BaseSolution.Application.DataTransferObjects.Ticket.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
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
    public class TicketDeleteViewModel : ViewModelBase<TicketDeleteRequest>
    {
        private readonly ITicketReadWriteRepository _ticketReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public TicketDeleteViewModel(ITicketReadWriteRepository ticketReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _ticketReadWriteRepository = ticketReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(TicketDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _ticketReadWriteRepository.DeleteTicketAsync(request, cancellationToken);

                Success = result.Success;
                ErrorItems = result.Errors;
                Message = result.Message;
                return;
            }
            catch (Exception)
            {
                Success = false;
                ErrorItems = new[]
                    {
                    new ErrorItem
                    {
                        Error = _localizationService["Error occurred while updating the ticket"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToDelete, "ticket")
                    }
                };
            }
        }
    }
}
