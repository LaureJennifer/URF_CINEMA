using BaseSolution.Application.DataTransferObjects.VnPayment;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Implements.Services
{
    public class VnPayService : IVnPayService
    {
        private readonly IConfiguration _config;

        public VnPayService(IConfiguration config)
        {
            _config = config;
        }
        public string CreatePaymentUrl(HttpContext context, VnPayRequest request)
        {
            var tick = DateTimeOffset.UtcNow.Ticks.ToString();
            var vnpay = new VnPayLibrary();
            vnpay.AddRequestData("vnp_Version", _config["VnPay:Version"]);
            vnpay.AddRequestData("vnp_Command", _config["VnPay:Command"]);
            vnpay.AddRequestData("vnp_TmnCode", _config["VnPay:TmnCode"]);
            vnpay.AddRequestData("vnp_Amount", (request.TotalPrice * 100).ToString()); //Số tiền thanh toán. Số tiền không mang các ký tự phân tách thập phân, phần nghìn, ký tự tiền tệ. Để gửi số tiền thanh toán là 100,000 VND (một trăm nghìn VNĐ) thì merchant cần nhân thêm 100 lần (khử phần thập phân), sau đó gửi sang VNPAY là: 10000000
            vnpay.AddRequestData("vnp_CreateDate", request.CreatedDate.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", _config["VnPay:CurrCode"]);
            vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress(context));
            vnpay.AddRequestData("vnp_Locale", _config["VnPay:Locale"]);
            vnpay.AddRequestData("vnp_OrderInfo", "Thanh toán đơn hàng:" + request.BookingId);
            vnpay.AddRequestData("vnp_OrderType", "other"); //default value: other
            vnpay.AddRequestData("vnp_ReturnUrl", _config["VnPay:PaymentBackUrl"]);
            vnpay.AddRequestData("vnp_TxnRef", tick); // Mã tham chiếu của giao dịch tại hệ thống của merchant. Mã này là duy nhất dùng để phân biệt các đơn hàng gửi sang VNPAY. Không được trùng lặp trong ngày
            
            ////Add Params of 2.1.0 Version
            //vnpay.AddRequestData("vnp_ExpireDate", txtExpire.Text);
            ////Billing
            //vnpay.AddRequestData("vnp_Bill_Mobile", txt_billing_mobile.Text.Trim());
            //vnpay.AddRequestData("vnp_Bill_Email", txt_billing_email.Text.Trim());
            //var fullName = txt_billing_fullname.Text.Trim();
            //if (!String.IsNullOrEmpty(fullName))
            //{
            //    var indexof = fullName.IndexOf(' ');
            //    vnpay.AddRequestData("vnp_Bill_FirstName", fullName.Substring(0, indexof));
            //    vnpay.AddRequestData("vnp_Bill_LastName", fullName.Substring(indexof + 1, fullName.Length - indexof - 1));
            //}
            //vnpay.AddRequestData("vnp_Bill_Address", txt_inv_addr1.Text.Trim());
            //vnpay.AddRequestData("vnp_Bill_City", txt_bill_city.Text.Trim());
            //vnpay.AddRequestData("vnp_Bill_Country", txt_bill_country.Text.Trim());
            //vnpay.AddRequestData("vnp_Bill_State", "");
            //// Invoice
            //vnpay.AddRequestData("vnp_Inv_Phone", txt_inv_mobile.Text.Trim());
            //vnpay.AddRequestData("vnp_Inv_Email", txt_inv_email.Text.Trim());
            //vnpay.AddRequestData("vnp_Inv_Customer", txt_inv_customer.Text.Trim());
            //vnpay.AddRequestData("vnp_Inv_Address", txt_inv_addr1.Text.Trim());
            //vnpay.AddRequestData("vnp_Inv_Company", txt_inv_company.Text);
            //vnpay.AddRequestData("vnp_Inv_Taxcode", txt_inv_taxcode.Text);
            //vnpay.AddRequestData("vnp_Inv_Type", cbo_inv_type.SelectedItem.Value);

            var paymentUrl = vnpay.CreateRequestUrl(_config["VnPay:BaseUrl"], _config["VnPay:HashSecret"]);
            return paymentUrl;
        }

        public VnPaymentDto PaymentExecute(IQueryCollection collections)
        {
            var vnpay = new VnPayLibrary();
            foreach(var (key,value) in collections)
            {
                if(!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
                {
                    vnpay.AddResponseData(key, value.ToString());
                }
            }
            var vnp_bookingId = Convert.ToInt32(vnpay.GetResponseData("vnp_TxnRef"));
            var vnp_TransactionId = Convert.ToInt32(vnpay.GetResponseData("vnp_TransactionNo"));
            var vnp_SecureHash = collections.FirstOrDefault(p => p.Key == "vnp_SecureHash").Value;
            var vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
            var vnp_OrderInfo = vnpay.GetResponseData("vnp_OrderInfo");
            bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash, _config["VnPay:HashSecret"]);
            if (!checkSignature)
            {
                return new VnPaymentDto
                {
                    Success = false
                };
            }
            return new VnPaymentDto
            {
                Success = true,
                PaymentMethod = "VnPay",
                BookingDescription = vnp_OrderInfo,
                BookingId = vnp_bookingId.ToString(),
                TransactionId = vnp_TransactionId.ToString(),
                Token = vnp_SecureHash,
                VnPayResponseCode = vnp_ResponseCode,
            };
        }
    }
}
