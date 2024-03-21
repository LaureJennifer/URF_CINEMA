using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Role.Request;
using BaseSolution.Application.DataTransferObjects.User.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.Role
{
    public class RoleDeleteViewModel : ViewModelBase<RoleDeleteRequest>
    {
        public readonly IRoleReadWriteRepository _roleReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public RoleDeleteViewModel(IRoleReadWriteRepository roleReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _roleReadWriteRepository = roleReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public async override Task HandleAsync(RoleDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _roleReadWriteRepository.DeleteRoleAsync(request, cancellationToken);

                Success = result.Success;
                ErrorItems = result.Errors;
                Message = result.Message;
                return;
            }
            catch (Exception)
            {
                Success = false;
                ErrorItems = new[]
                    {
                    new ErrorItem
                    {
                        Error = _localizationService["Error occurred while updating the role"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToDelete, "role")
                    }
                };
            }
        }
    }
}
