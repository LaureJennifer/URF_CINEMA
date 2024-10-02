using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Ticket.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.Ticket
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
