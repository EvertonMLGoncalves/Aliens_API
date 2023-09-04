using APIALiens.DTOs;

namespace APIALiens.EmailModule
{
    public interface ISmtp
    { 
        Task<string> SendEmail(EmailDTO emailDTO);
    }
}
