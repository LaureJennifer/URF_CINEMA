﻿using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.PaymentMethod.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Infrastructure.ViewModels.PaymentMethod;
using Microsoft.AspNetCore.Mvc;

namespace URF_Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodsController : ControllerBase
    {
        private readonly IPaymentMethodReadOnlyRepository _paymentMethodReadOnlyRepository;
        private readonly IPaymentMethodReadWriteRepository _paymentMethodReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public PaymentMethodsController(IPaymentMethodReadOnlyRepository paymentMethodReadOnlyRepository, IPaymentMethodReadWriteRepository paymentMethodReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _paymentMethodReadOnlyRepository = paymentMethodReadOnlyRepository;
            _paymentMethodReadWriteRepository = paymentMethodReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetListPaymentMethodByAdmin([FromQuery] ViewPaymentMethodWithPaginationRequest request, CancellationToken cancellationToken)
        {
            PaymentMethodListWithPaginationViewModel vm = new(_paymentMethodReadOnlyRepository, _localizationService);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentMethodById(Guid id, CancellationToken cancellationToken)
        {
            PaymentMethodViewModel vm = new(_paymentMethodReadOnlyRepository, _localizationService);

            await vm.HandleAsync(id, cancellationToken);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePaymentMethod(PaymentMethodCreateRequest request, CancellationToken cancellationToken)
        {
            PaymentMethodCreateViewModel vm = new(_paymentMethodReadOnlyRepository, _paymentMethodReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePaymentMethod(PaymentMethodUpdateRequest request, CancellationToken cancellationToken)
        {
            PaymentMethodUpdateViewModel vm = new(_paymentMethodReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePaymentMethod([FromQuery]PaymentMethodDeleteRequest request, CancellationToken cancellationToken)
        {
            PaymentMethodDeleteViewModel vm = new(_paymentMethodReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
    }
}
