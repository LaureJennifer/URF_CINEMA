using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Role.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.Role
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
