using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Account
{
    public class ResetPassword
    {
        public string PasswordOld { get; set; }
        public string PasswordNew { get; set; }
        public Guid Id { get; set; }
    }
}
