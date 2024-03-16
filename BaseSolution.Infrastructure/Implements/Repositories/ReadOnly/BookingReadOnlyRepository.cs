using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaseSolution.Application.DataTransferObjects.Booking;
using BaseSolution.Application.DataTransferObjects.Booking.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Enums;
using BaseSolution.Infrastructure.Database.AppDbContext;
using BaseSolution.Infrastructure.Implements.Services;
using BaseSolution.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Implements.Repositories.ReadOnly
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

                return RequestResult<BookingDto?>.Fail(_localizationService["BookingDto is not found"], new[]
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
                var query = _appReadOnlyDbContext.BookingEntities.AsNoTracking().ProjectTo<BookingDto>(_mapper.ConfigurationProvider);

                if (!string.IsNullOrWhiteSpace(request.SearchString))
                {
                    query = query.Where(x => x.NameCustomer.Contains(request.SearchString!));
                }
                var result = await query.Where(x => x.Status != EntityStatus.InActive).PaginateAsync(request, cancellationToken);
                foreach (var item in result.Data!)
                {
                    item.ServiceAmount = item.TotalService * item.ServicePrice;
                    item.RoomAmount = UtilityExtensions.TinhTien(item.CheckInReality, item.CheckOutReality, item.RoomPrice, item.PrePaid);
                    item.TotalAmount = item.ServiceAmount + item.RoomAmount;
                }
                return RequestResult<PaginationResponse<RoombookingDto>>.Succeed(new PaginationResponse<RoombookingDto>
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    HasNext = result.HasNext,
                    Data = result.Data
                });
            }
            catch (Exception e)
            {

                return RequestResult<PaginationResponse<RoombookingDto>>.Fail(_localizationService["List of roombooking are not found"], new[]
                {
                    new ErrorItem
                    {
                        Error= e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "list of roombooking"
                    }
                });
            }
        }
    }
}
