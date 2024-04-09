using BaseSolution.Application.DataTransferObjects.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.Interfaces.Services
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
