﻿using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Role.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.Role
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
