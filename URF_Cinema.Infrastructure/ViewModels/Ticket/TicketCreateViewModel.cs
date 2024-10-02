using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Ticket.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.Ticket
{
    public class TicketCreateViewModel:ViewModelBase<TicketCreateRequest>
    {
        private readonly ITicketReadOnlyRepository _ticketReadOnlyRepository;
        private readonly ITicketReadWriteRepository _ticketReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public TicketCreateViewModel(ITicketReadOnlyRepository ticketReadOnlyRepository, ITicketReadWriteRepository ticketReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _ticketReadOnlyRepository = ticketReadOnlyRepository;
            _ticketReadWriteRepository = ticketReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(TicketCreateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var createResult = await _ticketReadWriteRepository.AddTicketAsync(_mapper.Map<TicketEntity>(request), cancellationToken);

                if (createResult.Success)
                {
                    var result = await _ticketReadOnlyRepository.GetTicketByIdAsync(createResult.Data, cancellationToken);

                    Data = result.Data!;
                    Success = result.Success;
                    ErrorItems = result.Errors;
                    Message = result.Message;
                    return;
                }

                Success = createResult.Success;
                ErrorItems = createResult.Errors;
                Message = createResult.Message;
            }
            catch (Exception)
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
