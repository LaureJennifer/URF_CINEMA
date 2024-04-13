﻿using BaseSolution.Application.DataTransferObjects.Account;
using BaseSolution.Application.DataTransferObjects.Customer.Request;
using BaseSolution.Application.DataTransferObjects.Example.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.Interfaces.Repositories.ReadWrite
{
    public interface ICustomerReadWriteRepository
    {
        Task<RequestResult<Guid>> AddCustomerAsync(CustomerEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdateCustomerAsync(CustomerEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeleteCustomerAsync(CustomerDeleteRequest request, CancellationToken cancellationToken);
        Task<RequestResult<Guid>> RegisterCustomerAsync(CustomerEntity request, CancellationToken cancellationToken);
        Task<RequestResult<Guid>> ResetPasswordCustomerAsync(CustomerEntity entity, CancellationToken cancellationToken);
    }
}
