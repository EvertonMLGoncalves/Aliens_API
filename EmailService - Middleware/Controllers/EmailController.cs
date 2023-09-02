using EmailService.DTOs;
using EmailService.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace EmailService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    { 
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost] 
        public IActionResult SendEmail (EmailDTO emailDTO)
        {
            _emailService.SendEmail(emailDTO);
            return Ok("email enviado com sucesso");
        }
    }
}
