using URF_Cinema.Application.DataTransferObjects.Email;

namespace URF_Cinema.Application.Interfaces.Services
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
