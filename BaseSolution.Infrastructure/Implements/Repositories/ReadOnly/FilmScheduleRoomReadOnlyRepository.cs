using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaseSolution.Application.DataTransferObjects.FilmSchedule;
using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom;
using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom.Request;
using BaseSolution.Application.DataTransferObjects.User;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Enums;
using BaseSolution.Infrastructure.Database.AppDbContext;
using BaseSolution.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Implements.Repositories.ReadOnly
{
    public class FilmScheduleRoomReadOnlyRepository : IFilmScheduleRoomReadOnlyRepository
    {
        private readonly AppReadOnlyDbContext _appReadOnlyDbContext;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public FilmScheduleRoomReadOnlyRepository(AppReadOnlyDbContext appReadOnlyDbContext, IMapper mapper, ILocalizationService localizationService)
        {
            _appReadOnlyDbContext = appReadOnlyDbContext;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<RequestResult<FilmScheduleRoomDto?>> GetFilmScheduleRoomByIdAsync(Guid idFilmScheduleRoom, CancellationToken cancellationToken)
        {
            try
            {
                var filmScheduleRoom = await _appReadOnlyDbContext.FilmScheduleRoomEntities.AsNoTracking().Where(c => c.Id == idFilmScheduleRoom && !c.Deleted).ProjectTo<FilmScheduleRoomDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

                return RequestResult<FilmScheduleRoomDto?>.Succeed(filmScheduleRoom);
            }
            catch (Exception e)
            {
                return RequestResult<FilmScheduleRoomDto?>.Fail(_localizationService["Film schedule room is not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "Film schedule room"
                    }
                });
            }
        }

        public async Task<RequestResult<PaginationResponse<FilmScheduleRoomDto>>> GetFilmScheduleRoomWithPaginationByAdminAsync(ViewFilmScheduleRoomWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var filmScheduleRooms = _appReadOnlyDbContext.FilmScheduleRoomEntities.AsNoTracking().Where(x => x.Status != EntityStatus.Deleted).ProjectTo<FilmScheduleRoomDto>(_mapper.ConfigurationProvider);
                if (request.RoomId != null)
                {
                    filmScheduleRooms = filmScheduleRooms.Where(x => x.RoomId == request.RoomId);
                }
                if (request.FilmScheduleId != null)
                {
                    filmScheduleRooms = filmScheduleRooms.Where(x => x.FilmScheduleId == request.FilmScheduleId);
                }
                if (request.ShowDate != null)
                {
                    filmScheduleRooms = filmScheduleRooms.Where(x => x.ShowDate == request.ShowDate);
                }
                if (request.ShowTime != null)
                {
                    filmScheduleRooms = filmScheduleRooms.Where(x => x.ShowTime == request.ShowTime);
                }
                if (!string.IsNullOrWhiteSpace(request.RoomCode))
                {
                    filmScheduleRooms = filmScheduleRooms.Where(x => x.RoomCode.ToLower().Contains(request.RoomCode.ToLower()));
                }
                var result = await filmScheduleRooms.PaginateAsync(request, cancellationToken);
                return RequestResult<PaginationResponse<FilmScheduleRoomDto>>.Succeed(new PaginationResponse<FilmScheduleRoomDto>
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    HasNext = result.HasNext,
                    Data = result.Data
                });
            }
            catch (Exception e)
            {

                return RequestResult<PaginationResponse<FilmScheduleRoomDto>>.Fail(_localizationService["List of film schedule room are not found"], new[]
                {
                    new ErrorItem
                    {
                        Error= e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "list of film schedule room"
                    }
                });
            }
        }

        public async Task<RequestResult<FilmScheduleRoomDto?>> GetFilmScheduleRoomByShowDateTimeAsync(FilmScheduleRoomFindByDateTimeRequest request, CancellationToken cancellationToken)
        {
            try
            {               
                var filmScheduleRoom = await _appReadOnlyDbContext.FilmScheduleRoomEntities.AsNoTracking()
                    .Where(x => x.FilmScheduleEntity.ShowDate == request.ShowDate && x.FilmScheduleEntity.ShowTime == request.ShowTime)
                    .ProjectTo<FilmScheduleRoomDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);
                return RequestResult<FilmScheduleRoomDto?>.Succeed(filmScheduleRoom); 

            }
            catch (Exception e)
            {
                return RequestResult<FilmScheduleRoomDto?>.Fail(_localizationService["Film schedule room is not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "film schedule room"
                    }
                });
            }
        }

        public async Task<RequestResult<PaginationResponse<FilmScheduleRoomDto>>> GetRoomByFilmScheduleWithPaginationByAdminAsync(ViewRoomByFilmScheduleWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var filmScheduleRooms = _appReadOnlyDbContext.FilmScheduleRoomEntities.AsNoTracking().Where(x => x.Status != EntityStatus.Deleted).ProjectTo<FilmScheduleRoomDto>(_mapper.ConfigurationProvider);
               
                if (request.FilmScheduleId != null)
                {
                    filmScheduleRooms = filmScheduleRooms.Where(x => x.FilmScheduleId == request.FilmScheduleId);
                }
               
                var result = await filmScheduleRooms.PaginateAsync(request, cancellationToken);
                return RequestResult<PaginationResponse<FilmScheduleRoomDto>>.Succeed(new PaginationResponse<FilmScheduleRoomDto>
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    HasNext = result.HasNext,
                    Data = result.Data
                });
            }
            catch (Exception e)
            {

                return RequestResult<PaginationResponse<FilmScheduleRoomDto>>.Fail(_localizationService["List of film schedule room are not found"], new[]
                {
                    new ErrorItem
                    {
                        Error= e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "list of film schedule room"
                    }
                });
            }
        }
    }
}
