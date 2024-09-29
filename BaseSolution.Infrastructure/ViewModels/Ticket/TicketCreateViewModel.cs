using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Booking.Request;
using BaseSolution.Application.DataTransferObjects.Ticket.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using BaseSolution.Domain.Entities;
using BaseSolution.Infrastructure.Implements.Repositories.ReadWrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.Ticket
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
