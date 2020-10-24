using Microsoft.AspNetCore.Mvc;
using RzrSite.API.Services;
using System.Threading.Tasks;

namespace RzrSite.API.Controllers
{
    [ApiController]
    [Route("api/Message")]
    public class MessageController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public MessageController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        
        /// <summary>
        /// Send email-message
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        [HttpGet("/api/message/send")]
        public async Task<IActionResult> SendMessage(string subject, string message, string to = null)
        {
            await _emailService.SendEmailAsync(subject, message, to);
            return Ok("Sended");
        }
    }
}
