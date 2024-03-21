using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaseSolution.Application.DataTransferObjects.Role;
using BaseSolution.Application.DataTransferObjects.Role.Request;
using BaseSolution.Application.DataTransferObjects.User;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Enums;
using BaseSolution.Infrastructure.Database.AppDbContext;
using BaseSolution.Infrastructure.Extensions;
using BaseSolution.Infrastructure.Implements.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Implements.Repositories.ReadOnly
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
                var role = _appReadOnlyDbContext.RoleEntities.AsNoTracking().Where(x => x.Status != EntityStatus.Deleted).ProjectTo<RoleDto>(_mapper.ConfigurationProvider);
                if (!string.IsNullOrWhiteSpace(request.Code))
                {
                    role = role.Where(x => x.Code.ToLower().Contains(request.Code.ToLower()));
                }
                
                var result = await role.PaginateAsync(request, cancellationToken);
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
