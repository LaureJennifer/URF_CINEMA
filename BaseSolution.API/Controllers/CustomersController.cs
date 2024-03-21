using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Customer.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Infrastructure.Implements.Repositories.ReadOnly;
using BaseSolution.Infrastructure.Implements.Repositories.ReadWrite;
using BaseSolution.Infrastructure.Implements.Services;
using BaseSolution.Infrastructure.ViewModels.Customer;
using BaseSolution.Infrastructure.ViewModels.Example;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerReadOnlyRepository _customerReadOnlyRepository;
        private readonly ICustomerReadWriteRepository _customerReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerReadOnlyRepository customerReadOnlyRepository, ICustomerReadWriteRepository customerReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _customerReadOnlyRepository = customerReadOnlyRepository;
            _customerReadWriteRepository = customerReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetListCustomerByAdmin([FromQuery] ViewCustomerWithPaginationRequest request, CancellationToken cancellationToken)
        {
            CustomerListWithPaginationViewModel vm = new(_customerReadOnlyRepository, _localizationService);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(Guid id, CancellationToken cancellationToken)
        {
            CustomerViewModel vm = new(_customerReadOnlyRepository, _localizationService);

            await vm.HandleAsync(id, cancellationToken);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerCreateRequest request, CancellationToken cancellationToken)
        {
            CustomerCreateViewModel vm = new(_customerReadOnlyRepository, _customerReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(CustomerUpdateRequest request, CancellationToken cancellationToken)
        {
            CustomerUpdateViewModel vm = new(_customerReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(CustomerDeleteRequest request, CancellationToken cancellationToken)
        {
            CustomerDeleteViewModel vm = new(_customerReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
    }
}
