using AutoMapper;
using AutoMapper.QueryableExtensions;
using URF_Cinema.Application.DataTransferObjects.Role;
using URF_Cinema.Application.DataTransferObjects.Role.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Enums;
using URF_Cinema.Infrastructure.Database.AppDbContext;
using URF_Cinema.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace URF_Cinema.Infrastructure.Implements.Repositories.ReadOnly
{
    public class RoleReadOnlyRepository : IRoleReadOnlyRepository
    {
        private readonly AppReadOnlyDbContext _appReadOnlyDbContext;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;
        public RoleReadOnlyRepository(AppReadOnlyDbContext appReadOnlyDbContext, IMapper mapper, ILocalizationService localizationService)
        {
            _appReadOnlyDbContext = appReadOnlyDbContext;
            _mapper = mapper;
            _localizationService = localizationService;
        }
        public async Task<RequestResult<RoleDto?>> GetRoleByIdAsync(Guid idRole, CancellationToken cancellationToken)
        {
            try
            {
                var role = await _appReadOnlyDbContext.RoleEntities.AsNoTracking().Where(x => x.Id == idRole).ProjectTo<RoleDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);
                return RequestResult<RoleDto?>.Succeed(role);

            }
            catch (Exception e)
            {

                return RequestResult<RoleDto?>.Fail(_localizationService["Role is not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "role"
                    }
                });
            }
        }

        public async Task<RequestResult<PaginationResponse<RoleDto>>> GetRoleWithPaginationByAdminAsync(ViewRoleWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var roles = _appReadOnlyDbContext.RoleEntities.AsNoTracking().Where(x => x.Status != EntityStatus.Deleted).ProjectTo<RoleDto>(_mapper.ConfigurationProvider);
                if (!string.IsNullOrWhiteSpace(request.Code))
                {
                    roles = roles.Where(x => x.Code.ToLower().Contains(request.Code.ToLower()));
                }
                
                var result = await roles.PaginateAsync(request, cancellationToken);
                return RequestResult<PaginationResponse<RoleDto>>.Succeed(new PaginationResponse<RoleDto>
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    HasNext = result.HasNext,
                    Data = result.Data
                });
            }
            catch (Exception e)
            {

                return RequestResult<PaginationResponse<RoleDto>>.Fail(_localizationService["List of role are not found"], new[]
                {
                    new ErrorItem
                    {
                        Error= e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "list of role"
                    }
                });
            }
        }
    }
}
