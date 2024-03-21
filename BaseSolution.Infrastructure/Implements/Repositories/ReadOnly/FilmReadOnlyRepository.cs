using AutoMapper;
using AutoMapper.QueryableExtensions;
using Azure.Core;
using BaseSolution.Application.DataTransferObjects.Customer;
using BaseSolution.Application.DataTransferObjects.Film;
using BaseSolution.Application.DataTransferObjects.Film.Request;
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
    public class FilmReadOnlyRepository : IFilmReadOnlyRepository
    {
        private readonly AppReadOnlyDbContext _appReadOnlyDbContext;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;
        
        public FilmReadOnlyRepository(AppReadOnlyDbContext appReadOnlyDbContext, ILocalizationService localizationService, IMapper mapper)
        {
            _appReadOnlyDbContext = appReadOnlyDbContext;       
            _localizationService = localizationService;
            _mapper = mapper;
        }
        public async Task<RequestResult<FilmDto?>> GetFilmByIdAsync(Guid idFilm, CancellationToken cancellationToken)
        {
            try
            {
                var film = await _appReadOnlyDbContext.FilmEntities.AsNoTracking().Where(c => c.Id == idFilm && !c.Deleted).ProjectTo<FilmDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

                return RequestResult<FilmDto?>.Succeed(film);
            }
            catch (Exception e)
            {
                return RequestResult<FilmDto?>.Fail(_localizationService["Film is not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "Film"
                    }
                });
            }
        }

        public async Task<RequestResult<PaginationResponse<FilmDto>>> GetFilmWithPaginationByAdminAsync(ViewFilmWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var film = _appReadOnlyDbContext.FilmEntities.AsNoTracking().Where(x => x.Status != EntityStatus.Deleted).ProjectTo<FilmDto>(_mapper.ConfigurationProvider);
                if (!string.IsNullOrWhiteSpace(request.Title))
                {
                    film = film.Where(x => x.Title.ToLower().Contains(request.Title.ToLower()));
                }
                if (request.Code != null)
                {
                    film = film.Where(x => x.Code == request.Code);
                }
                var result = await film.PaginateAsync(request, cancellationToken);
                return RequestResult<PaginationResponse<FilmDto>>.Succeed(new PaginationResponse<FilmDto>
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    HasNext = result.HasNext,
                    Data = result.Data
                });
            }
            catch (Exception e)
            {

                return RequestResult<PaginationResponse<FilmDto>>.Fail(_localizationService["List of film are not found"], new[]
                {
                    new ErrorItem
                    {
                        Error= e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "list of film"
                    }
                });
            }
        }
    }
}
