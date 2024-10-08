﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using URF_Cinema.Application.DataTransferObjects.Booking;
using URF_Cinema.Application.DataTransferObjects.Booking.Request;
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
    public class BookingReadOnlyRepository : IBookingReadOnlyRepository
    {
        private readonly AppReadOnlyDbContext _appReadOnlyDbContext;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;
        public BookingReadOnlyRepository(AppReadOnlyDbContext appReadOnlyDbContext, IMapper mapper, ILocalizationService localizationService)
        {
            _appReadOnlyDbContext = appReadOnlyDbContext;
            _mapper = mapper;
            _localizationService = localizationService;
        }
        public async Task<RequestResult<BookingDto?>> GetBookingByIdAsync(Guid idBooking, CancellationToken cancellationToken)
        {
            try
            {
                var booking_ = await _appReadOnlyDbContext.BookingEntities.AsNoTracking().Where(x => x.Id == idBooking).ProjectTo<BookingDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);
                return RequestResult<BookingDto?>.Succeed(booking_);

            }
            catch (Exception e)
            {

                return RequestResult<BookingDto?>.Fail(_localizationService["Booking is not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "booking"
                    }
                });
            }
        }

        public async Task<RequestResult<PaginationResponse<BookingDto>>> GetBookingWithPaginationByAdminAsync(ViewBookingWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var bookings = _appReadOnlyDbContext.BookingEntities.AsNoTracking().ProjectTo<BookingDto>(_mapper.ConfigurationProvider);
                if (request.Id!=null){
                    bookings = bookings.Where(x => x.Id == request.Id);
                }
                if (request.DepartmentId != null)
                {
                    bookings = bookings.Where(x => x.DepartmentId == request.DepartmentId);
                }
                if (request.SeatId!=null)
                {
                    bookings = bookings.Where(x => x.SeatId==request.SeatId);
                }
                if (request.RoomId != null)
                {
                    bookings = bookings.Where(x => x.RoomId == request.RoomId);
                }
                if (request.FilmId != null)
                {
                    bookings = bookings.Where(x => x.FilmId == request.FilmId);
                }
                if (request.FilmScheduleId != null)
                {
                    bookings = bookings.Where(x => x.FilmScheduleId == request.FilmScheduleId);
                }
                if (request.ExpiredTime != null)
                {
                    bookings = bookings.Where(x => x.ExpiredTime == request.ExpiredTime);
                }
                if (request.CreatedTime != null)
                {
                    bookings = bookings.Where(x => x.CreatedTime == request.CreatedTime);
                }
                if (request.SeatStatus != null)
                {
                    bookings = bookings.Where(x => x.SeatStatus == request.SeatStatus);
                }
                var result = await bookings.Where(x => x.SeatStatus != EntityStatus.Deleted).PaginateAsync(request, cancellationToken);
                
                return RequestResult<PaginationResponse<BookingDto>>.Succeed(new PaginationResponse<BookingDto>
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    HasNext = result.HasNext,
                    Data = result.Data
                });
            }
            catch (Exception e)
            {

                return RequestResult<PaginationResponse<BookingDto>>.Fail(_localizationService["List of booking are not found"], new[]
                {
                    new ErrorItem
                    {
                        Error= e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "list of booking"
                    }
                });
            }
        }
    }
}
