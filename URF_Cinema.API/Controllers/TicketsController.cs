using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Ticket.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Infrastructure.ViewModels.Ticket;
using Microsoft.AspNetCore.Mvc;

namespace URF_Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketReadOnlyRepository _ticketReadOnlyRepository;
        private readonly ITicketReadWriteRepository _ticketReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public TicketsController(ITicketReadOnlyRepository ticketReadOnlyRepository, ITicketReadWriteRepository ticketReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _ticketReadOnlyRepository = ticketReadOnlyRepository;
            _ticketReadWriteRepository = ticketReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetListTicketByAdmin([FromQuery] ViewTicketWithPaginationRequest request, CancellationToken cancellationToken)
        {
            TicketListWithPaginationViewModel vm = new(_ticketReadOnlyRepository, _localizationService);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketById(Guid id, CancellationToken cancellationToken)
        {
            TicketViewModel vm = new(_ticketReadOnlyRepository, _localizationService);

            await vm.HandleAsync(id, cancellationToken);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(TicketCreateRequest request, CancellationToken cancellationToken)
        {
            TicketCreateViewModel vm = new(_ticketReadOnlyRepository, _ticketReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTicket(TicketUpdateRequest request, CancellationToken cancellationToken)
        {
            TicketUpdateViewModel vm = new(_ticketReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTicket([FromQuery]TicketDeleteRequest request, CancellationToken cancellationToken)
        {
            TicketDeleteViewModel vm = new(_ticketReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
    }
}
