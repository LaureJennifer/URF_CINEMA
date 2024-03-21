using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Role.Request;
using BaseSolution.Application.DataTransferObjects.User.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.Role
{
    public class RoleCreateViewModel : ViewModelBase<RoleCreateRequest>
    {
        private readonly IRoleReadOnlyRepository _roleReadOnlyRepository;
        private readonly IRoleReadWriteRepository _roleReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public RoleCreateViewModel(IRoleReadOnlyRepository roleReadOnlyRepository, IRoleReadWriteRepository roleReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _roleReadOnlyRepository = roleReadOnlyRepository;
            _roleReadWriteRepository = roleReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public async override Task HandleAsync(RoleCreateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var createResult = await _roleReadWriteRepository.AddRoleAsync(_mapper.Map<RoleEntity>(request), cancellationToken);
                if (createResult.Success)
                {
                    var result = await _roleReadOnlyRepository.GetRoleByIdAsync(createResult.Data, cancellationToken);

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
            catch
            {

                Success = false;
                ErrorItems = new[]
                {
                    new ErrorItem
                    {
                        Error = _localizationService["Error occurred while getting the role"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "role")
                    }
                };
            }
        }
    }
}
