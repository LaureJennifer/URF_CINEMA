using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Transaction
{
    public class TransactionDto
    {
        public Guid BillId { get; set; }
        public double Price { get; set; }
        public string PaymentMethodName { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public EntityStatus Status { get; set; }
    }
}
