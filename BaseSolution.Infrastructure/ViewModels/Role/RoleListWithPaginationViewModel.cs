using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Role.Request;
using BaseSolution.Application.DataTransferObjects.User.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
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
    public class RoleListWithPaginationViewModel :ViewModelBase<ViewRoleWithPaginationRequest>
    {
        private readonly IRoleReadOnlyRepository _roleReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public RoleListWithPaginationViewModel(IRoleReadOnlyRepository roleReadOnlyRepository, ILocalizationService localizationService)
        {
            _roleReadOnlyRepository = roleReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(ViewRoleWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _roleReadOnlyRepository.GetRoleWithPaginationByAdminAsync(request, cancellationToken);

                Data = result.Data!;
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
                        Error = _localizationService["Error occurred while getting the list of role"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "list of role")
                    }
                };
            }
        }
    }
}
