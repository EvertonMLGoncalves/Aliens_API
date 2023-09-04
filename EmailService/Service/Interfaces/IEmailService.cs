using EmailService.DTOs;

namespace EmailService.Service.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(EmailDTO emailDTO);
    }
}
