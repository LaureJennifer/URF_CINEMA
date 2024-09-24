using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.DataTransferObjects.Ticket;
using BaseSolution.Application.DataTransferObjects.VnPayment;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Domain.Entities;
using BaseSolution.Infrastructure.Database.AppDbContext;
using BaseSolution.Infrastructure.Extensions;
using BaseSolution.Infrastructure.Implements.Services;
using BaseSolution.Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;
namespace BaseSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly AppReadWriteDbContext _dbContext;
        private readonly IVnPayService _vnPayService;

        public CartsController(AppReadWriteDbContext dbContext, IVnPayService vnPayService)
        {
            _dbContext = dbContext;
            _vnPayService = vnPayService;
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutVM model, string payment = "COD")
        {
            if (ModelState.IsValid)
            {
                //    var customerId =  HttpContext.User.Claims.SingleOrDefault(p => p.Type == AppRole.Id).Value;
                //    var customer = new CustomerEntity();
                //    if (model.GiongKhachHang)
                //    {
                //        customer = _dbContext.CustomerEntities.SingleOrDefault(kh => kh.Id == Guid.Parse(customerId));
                //    }
                //    var bill_ = new BillDto()
                //    {
                //        CustomerId = Guid.Parse(customerId),
                //        CustomerName = model.HoTen ?? customer.Name,
                //        TotalPrice = model.TotalPrice,
                //        CreatedTime = DateTimeOffset.UtcNow,
                //        Description = model.GhiChu,
                //        Status = Domain.Enums.EntityStatus.Active
                //    };
                //    _dbContext.Database.BeginTransaction();
                //    try
                //    {
                //        _dbContext.Database.CommitTransaction();
                //        _dbContext.Add(bill_);
                //        _dbContext.SaveChanges();
                //        var cthd = new List<TicketEntity>();
                //        cthd.Add(new TicketEntity
                //        {
                //            BillId = bill_.Id,
                //            BookingId = Guid.NewGuid(),
                //            FilmId =  model.filmID,
                //            Price = model.TotalPrice
                //        });
                //        _dbContext.AddRange(cthd);
                //        _dbContext.SaveChanges();
                //    }
                //    catch(Exception)
                //    {
                //        throw new Exception     return View("Success");
                //    }
                //    catch
                //    {
                //        db.Database.RollbackTransaction();
                //    }
                //}

                //return View(Cart);
                BillEntity billEntity = new();

            if (payment == "Thanh toán VNPay")
                {
                    var vnPayModel = new VnPayRequest
                    {
                        TotalPrice = billEntity.TotalPrice,
                        CreatedDate = DateTime.Now,
                        Description = $"{model.HoTen} {model.DienThoai}",
                        FullName = model.HoTen,
                        BookingId = Guid.NewGuid(),
                    };
                    return Ok(_vnPayService.CreatePaymentUrl(HttpContext, vnPayModel));
                }
                var customerId = HttpContext.User.Claims.SingleOrDefault(p => p.Type == MySetting.CLAIM_CUSTOMERID).Value;
                var customer = new Domain.Entities.CustomerEntity();
                if (model.GiongKhachHang)
                {
                    customer = _dbContext.CustomerEntities.SingleOrDefault(kh => kh.Id == Guid.Parse(customerId));
                }

                var bill = new BillDto
                {
                    CustomerId = Guid.Parse(customerId),
                    CustomerName = model.HoTen ?? customer.Name,
                    CreatedTime = DateTime.Now,
                    Status = 0,
                    Description = model.GhiChu
                };

                _dbContext.Database.BeginTransaction();
                try
                {

                    _dbContext.Add(bill);
                    _dbContext.SaveChanges();

                    List<BookingEntity> _lst = new();
                    var cthds = new List<TicketEntity>();
                    foreach (var item in _lst)
                    {
                        cthds.Add(new TicketEntity
                        {
                            //BillId = bill.Id,
                            Price = bill.TotalPrice,
                            //FilmId = item.Id,
                        });
                    }
                    _dbContext.TicketEntities.AddRange(cthds);
                    _dbContext.SaveChanges();
                    _dbContext.Database.CommitTransaction();

                    return Ok("Success");
                }
                catch
                {
                    _dbContext.Database.RollbackTransaction();
                }
            }

            return Ok("Success");
        }
        [HttpGet]
        public async Task<IActionResult> PaymentCallBack()
        {
            var response = _vnPayService.PaymentExecute(Request.Query);

            if (response == null || response.VnPayResponseCode != "00")
            {
                var errorMessage = $"Lỗi thanh toán VN Pay: {response.VnPayResponseCode}";
                return BadRequest(errorMessage);
            }

            // Lưu đơn hàng vào database

            var successMessage = "Thanh toán VNPay thành công";
            return Ok(successMessage);

        }
    }
}
