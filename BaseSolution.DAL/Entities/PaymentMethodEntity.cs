using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class PaymentMethodEntity
    {
        public Guid Id { get; set; }
        public Guid TransactionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TransactionEntity TransactionEntity{ get; set; }
    }
}
