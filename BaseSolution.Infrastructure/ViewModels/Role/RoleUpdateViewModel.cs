using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Role.Request;
using BaseSolution.Application.DataTransferObjects.User.Request;
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

namespace BaseSolution.Infrastructure.ViewModels.Role
{
    public class RoleUpdateViewModel : ViewModelBase<RoleUpdateRequest>
    {
        private readonly IRoleReadWriteRepository _roleReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public RoleUpdateViewModel(IRoleReadWriteRepository roleReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _roleReadWriteRepository = roleReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }
        public async override Task HandleAsync(RoleUpdateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _roleReadWriteRepository.UpdateRoleAsync(_mapper.Map<RoleEntity>(request), cancellationToken);

                Success = result.Success;
                ErrorItems = result.Errors;
                Message = result.Message;
                return;
            }
            catch
            {


                Success = false;
                ErrorItems = new[]
                    {
                    new ErrorItem
                    {
                        Error = _localizationService["Error occurred while updating the role"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToUpdate, "role")
                    }
                };
            }
        }
    }
}
