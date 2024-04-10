using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.DataTransferObjects.Ticket;
using BaseSolution.Application.DataTransferObjects.Ticket.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Infrastructure.Database.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using BaseSolution.Application.DataTransferObjects.FilmDetail;
using BaseSolution.Application.DataTransferObjects.FilmDetail.Request;
using BaseSolution.Infrastructure.Extensions;

namespace BaseSolution.Infrastructure.Implements.Repositories.ReadOnly
{
    public class FilmDetailReadOnlyRepository : IFilmDetailReadOnlyRepository
    {
        private readonly AppReadOnlyDbContext _appReadOnlyDbContext;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public FilmDetailReadOnlyRepository(AppReadOnlyDbContext appReadOnlyDbContext, IMapper mapper, ILocalizationService localizationService)
        {
            _appReadOnlyDbContext = appReadOnlyDbContext;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<RequestResult<FilmDetailDto?>> GetFilmDetailByIdAsync(Guid idFilmDetail, CancellationToken cancellationToken)
        {
            try
            {
                var filmDetail = await _appReadOnlyDbContext.FilmDetailEntities.AsNoTracking().Where(c => c.Id == idFilmDetail && !c.Deleted).ProjectTo<FilmDetailDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

                return RequestResult<FilmDetailDto?>.Succeed(filmDetail);
            }
            catch (Exception e)
            {
                return RequestResult<FilmDetailDto?>.Fail(_localizationService["Film detail is not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "Film detail"
                    }
                });
            }
        }
        public async Task<RequestResult<PaginationResponse<FilmDetailDto>>> GetFilmDetailWithPaginationByAdminAsync(ViewFilmDetailWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var filmDetails = _appReadOnlyDbContext.FilmDetailEntities.AsNoTracking().ProjectTo<FilmDetailDto>(_mapper.ConfigurationProvider);
                if (request.FilmId!=null)
                {
                    filmDetails = filmDetails.Where(x => x.FilmId == request.FilmId);
                }
                if (request.FilmScheduleId != null)
                {
                    filmDetails = filmDetails.Where(x => x.FilmScheduleId == request.FilmScheduleId);
                }
                if (!string.IsNullOrWhiteSpace(request.FilmName))
                {
                    filmDetails = filmDetails.Where(x => x.Title == request.FilmName);
                }
                if (request.Status !=null)
                {
                    filmDetails = filmDetails.Where(x => x.Status == request.Status);
                }
                var result = await filmDetails.PaginateAsync(request, cancellationToken);


                return RequestResult<PaginationResponse<FilmDetailDto>>.Succeed(new PaginationResponse<FilmDetailDto>()
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    HasNext = result.HasNext,
                    Data = result.Data
                });
            }
            catch (Exception e)
            {
                return RequestResult<PaginationResponse<FilmDetailDto>>.Fail(_localizationService["List of film detail are not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "list of film detail"
                    }
                });
            }
        }
    }
}
