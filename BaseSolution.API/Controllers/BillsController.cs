using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Seat.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Infrastructure.Implements.Repositories.ReadWrite;
using BaseSolution.Infrastructure.Implements.Services;
using BaseSolution.Infrastructure.ViewModels.Seat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly IBillReadOnlyRepository _billReadOnlyRepository;
        private readonly IBillReadWriteRepository _billReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public BillsController(IBillReadOnlyRepository billReadOnlyRepository, IBillReadWriteRepository billReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _billReadOnlyRepository = billReadOnlyRepository;
            _billReadWriteRepository = billReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }
        // GET api/<ExampleController>/5
        //[HttpGet]
        //public async Task<IActionResult> Get([FromQuery] ViewBillWithPaginationRequest request, CancellationToken cancellationToken)
        //{
        //    BillListWithPaginationViewModel vm = new(_seatReadOnlyRepository, _localizationService);

        //    await vm.HandleAsync(request, cancellationToken);

        //    return Ok(vm);
        //}

        //// GET api/<ExampleController>/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        //{
        //    BillViewModel vm = new(_seatReadOnlyRepository, _localizationService);

        //    await vm.HandleAsync(id, cancellationToken);

        //    return Ok(vm);
        //}

        [HttpPost]
        public async Task<IActionResult> Post(BillCreateRequest request, CancellationToken cancellationToken)
        {
            BillCreateViewModel vm = new(_billReadOnlyRepository, _billReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpPut]
        public async Task<IActionResult> Put(BillUpdateRequest request, CancellationToken cancellationToken)
        {
            BillUpdateViewModel vm = new(_billReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(BillDeleteRequest request, CancellationToken cancellationToken)
        {
            BillDeleteViewModel vm = new(_billReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
    }
}
