using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Merchant
{
    public class SetActiveMerchant
    {
        public Guid? Id { get; set; }
        public bool IsActive { get; set; }
    }
}
