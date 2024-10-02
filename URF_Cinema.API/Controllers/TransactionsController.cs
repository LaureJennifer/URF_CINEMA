using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Transaction.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Infrastructure.ViewModels.Transaction;
using Microsoft.AspNetCore.Mvc;

namespace URF_Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionReadOnlyRepository _transactionReadOnlyRepository;
        private readonly ITransactionReadWriteRepository _transactionReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public TransactionsController(ITransactionReadOnlyRepository transactionReadOnlyRepository, ITransactionReadWriteRepository transactionReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _transactionReadOnlyRepository = transactionReadOnlyRepository;
            _transactionReadWriteRepository = transactionReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetListTransactionByAdmin([FromQuery] ViewTransactionWithPaginationRequest request, CancellationToken cancellationToken)
        {
            TransactionListWithPaginationViewModel vm = new(_transactionReadOnlyRepository, _localizationService);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionById(Guid id, CancellationToken cancellationToken)
        {
            TransactionViewModel vm = new(_transactionReadOnlyRepository, _localizationService);

            await vm.HandleAsync(id, cancellationToken);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction(TransactionCreateRequest request, CancellationToken cancellationToken)
        {
            TransactionCreateViewModel vm = new(_transactionReadOnlyRepository, _transactionReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTransaction(TransactionUpdateRequest request, CancellationToken cancellationToken)
        {
            TransactionUpdateViewModel vm = new(_transactionReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTransaction([FromQuery]TransactionDeleteRequest request, CancellationToken cancellationToken)
        {
            TransactionDeleteViewModel vm = new(_transactionReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
    }
}
