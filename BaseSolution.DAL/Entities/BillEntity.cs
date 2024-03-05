using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class BillEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public double Price { get; set; }
        public double TotalPayment { get; set; }
        public string Description { get; set; }
        public UserEntity User { get; set; }
        public List<BillDetailEntity> BillDetailEntities { get; set; }
    }
}
