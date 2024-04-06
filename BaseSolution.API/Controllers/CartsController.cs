//using BaseSolution.Application.DataTransferObjects.Bill;
//using BaseSolution.Application.DataTransferObjects.Customer;
//using BaseSolution.Application.DataTransferObjects.Ticket;
//using BaseSolution.Application.DataTransferObjects.VnPayment;
//using BaseSolution.Application.Interfaces.Services;
//using BaseSolution.Domain.Entities;
//using BaseSolution.Infrastructure.Database.AppDbContext;
//using BaseSolution.Infrastructure.Extensions;
//using BaseSolution.Infrastructure.ViewModels;
//using Microsoft.AspNetCore.Mvc;
//namespace BaseSolution.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CartsController : ControllerBase
//    {
//        private readonly AppReadWriteDbContext _dbContext;
//        private readonly IVnPayService _vnPayService;

//        public CartsController(AppReadWriteDbContext dbContext, IVnPayService vnPayService)
//        {
//            _dbContext = dbContext;
//            _vnPayService = vnPayService;
//        }

//        public List<CartItem> Cart => HttpContext.Session.Get<List<CartItem>>(MySetting.CART_KEY) ?? new List<CartItem>();

//        [HttpPost]
//        public async Task<IActionResult> Checkout(CheckoutVM model, string payment = "COD")
//        {
//            if (ModelState.IsValid)
//            {
//                if (payment == "Thanh toán VNPay")
//                {
//                    var vnPayModel = new VnPayRequest
//                    {
//                        TotalPrice = Cart.Sum(x=>x.ThanhTien),
//                        CreatedDate = DateTime.Now,
//                        Description = $"{model.HoTen} {model.DienThoai}",
//                        FullName = model.HoTen,
//                        BookingId = Guid.NewGuid(),
//                    };
//                    return Redirect(_vnPayService.CreatePaymentUrl(HttpContext, vnPayModel));
//                }
//                var customerId = HttpContext.User.Claims.SingleOrDefault(p => p.Type == MySetting.CLAIM_CUSTOMERID).Value;
//                var customer = new Domain.Entities.CustomerEntity();
//                if (model.GiongKhachHang)
//                {
//                    customer = _dbContext.CustomerEntities.SingleOrDefault(kh => kh.Id == Guid.Parse(customerId));
//                }

//                var bill = new BillDto
//                {
//                    CustomerId = Guid.Parse(customerId),
//                    CustomerName = model.HoTen ?? customer.Name,
//                    CreatedTime = DateTime.Now,
//                    Status = 0,
//                    Description = model.GhiChu
//                };

//                _dbContext.Database.BeginTransaction();
//                try
//                {

//                    _dbContext.Add(bill);
//                    _dbContext.SaveChanges();

//                    var cthds = new List<TicketDto>();
//                    foreach (var item in Cart)
//                    {
//                        cthds.Add(new TicketDto
//                        {
//                            BillId = bill.Id,
//                            Price = bill.TotalPrice,
//                        });
//                    }
//                    _dbContext.AddRange(cthds);
//                    _dbContext.SaveChanges();
//                    _dbContext.Database.CommitTransaction();

//                    HttpContext.Session.Set<List<CartItem>>(MySetting.CART_KEY, new List<CartItem>());

//                    return View("Success");
//                }
//                catch
//                {
//                    db.Database.RollbackTransaction();
//                }
//            }

//            return View(Cart);
//        }
//        }

//        public IActionResult PaymentCallBack()
//        {
//            var response = _vnPayService.PaymentExecute(Request.Query);
//            if (response == null || response.VnPayResponseCode != "00")
//            {
//                TempData["ErrorMessage"] = $"Lỗi thanh toán VN Pay: {response?.VnPayResponseCode}";
//                return RedirectToAction("PaymentFail");
//            }
            
//        }
//    }
//}
