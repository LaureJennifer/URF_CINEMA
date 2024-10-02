//using BaseSolution.Application.DataTransferObjects.PaymentMethod;
//using BaseSolution.Application.ValueObjects.Common;
//using BaseSolution.Application.ValueObjects.Response;
//using MediatR;
//using Microsoft.Data.SqlClient;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BaseSolution.Infrastructure.Implements.Services
//{
//    public class GetPayment : IRequest<RequestResult<PaymentMethodDto>>
//    {
//        public Guid Id { get; set; }
//    }
//    public GetPaymentHandler(ICurrentUserService currentUserService,
//            ISqlService sqlService,
//            IConnectionService connectionService)
//    {
//        this.currentUserService = currentUserService;
//        this.sqlService = sqlService;
//        this.connectionService = connectionService;
//    }

//    public Task<RequestResult<PaymentMethodDto>> Handle(GetPayment request,
//        CancellationToken cancellationToken)
//    {
//        var result = new RequestResult<PaymentMethodDto>();

//        try
//        {
//            string connectionString = connectionService.Datebase ?? string.Empty;
//            var paramters = new SqlParameter[]
//            {
//                    new SqlParameter("@PaymentId", request.Id),
//            };
//            (var data, string sqlError) = sqlService.FillDataTable(connectionString,
//                PaymentConstants.SelectByIdSprocName, paramters);
//            var payment = data.AsListObject<PaymentDtos>()?.SingleOrDefault();

//            if (payment != null)
//            {
//                result.Set(true, MessageContants.OK, payment);
//            }
//            else
//            {
//                result.Set(false, MessageContants.NotFound);
//            }

//        }
//        catch (Exception ex)
//        {
//            result.Set(false, MessageContants.Error);
//            result.Errors.Add(new ()
//            {
//                Code = MessageContants.Exception,
//                Message = ex.Message,
//            });
//        }

//        return Task.FromResult(result);
//    }
//}
