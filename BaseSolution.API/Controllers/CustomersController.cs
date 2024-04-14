using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Account;
using BaseSolution.Application.DataTransferObjects.Account.Request;
using BaseSolution.Application.DataTransferObjects.Customer;
using BaseSolution.Application.DataTransferObjects.Customer.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Infrastructure.Extensions;
using BaseSolution.Infrastructure.Implements.Repositories.ReadOnly;
using BaseSolution.Infrastructure.Implements.Repositories.ReadWrite;
using BaseSolution.Infrastructure.Implements.Services;
using BaseSolution.Infrastructure.ViewModels;
using BaseSolution.Infrastructure.ViewModels.Customer;
using BaseSolution.Infrastructure.ViewModels.Example;
using BaseSolution.Infrastructure.ViewModels.Login;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Threading;

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
        private string _verifyCode = string.Empty;

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
        //[HttpGet("{username}")]
        //public async Task<IActionResult> GetCustomerByUserName(string name, CancellationToken cancellationToken)
        //{
        //    CustomerNameViewModel vm = new(_customerReadOnlyRepository, _localizationService);

        //    await vm.HandleAsync(name, cancellationToken);

        //    return Ok(vm);
        //}

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
        public async Task<IActionResult> DeleteCustomer([FromQuery]CustomerDeleteRequest request, CancellationToken cancellationToken)
        {
            CustomerDeleteViewModel vm = new(_customerReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request, CancellationToken cancellationToken)
        {
            CustomerRegisterViewModel vm = new(_customerReadOnlyRepository, _customerReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
        [HttpGet("{identification}/details")]
        public async Task<IActionResult> GetIdentificationNumber(string identification, CancellationToken cancellationToken)
        {
            CustomerIdentificationViewModel vm = new(_customerReadOnlyRepository, _localizationService);

            await vm.HandleAsync(identification, cancellationToken);
            if (vm.Data != null)
            {
                CustomerDto result = (CustomerDto)vm.Data;
                return Ok(result);
            }
            return Ok(vm);
        }
        [HttpGet("checkEmailExist")]
        public async Task<IActionResult> GetEmail(string email, CancellationToken cancellationToken)
        {
            CustomerEmailViewModel vm = new(_customerReadOnlyRepository, _localizationService);

            await vm.HandleAsync(email, cancellationToken);
            if (vm.Data != null)
            {
                CustomerDto result = (CustomerDto)vm.Data;
                return Ok(result);
            }
            return Ok(vm);
        }

        [AllowAnonymous]
        [HttpPost("sendGmail")]
        public async Task<IActionResult> SendGmailAsync([FromBody] string emailAddress)
        {
            _verifyCode = UtilityExtensions.GenerateRandomString(6);
            if (EmailVerification.SetCodeForEmail(emailAddress, _verifyCode))
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("thieuddph45736@fpt.edu.vn"));
                email.To.Add(MailboxAddress.Parse(emailAddress));
                email.Subject = "Mã đăng nhập";

                var body = new TextPart("html")
                {
                    Text = "<h1><strong>" + _verifyCode + "</strong></h1>"
                };
                email.Body = body;

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync("thieuddph45736@fpt.edu.vn", "qwpmktwcosxgxirs");
                    await client.SendAsync(email);
                    client.Disconnect(true);
                }
            }
            return Ok();
        }
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPassword signInPassword, CancellationToken cancellationToken)
        {
            CustomerResetViewModel vm = new(_customerReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(signInPassword, cancellationToken);

            return Ok(vm);
        }
    }
}
