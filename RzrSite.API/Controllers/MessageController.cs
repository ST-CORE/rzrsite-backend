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
        /// Send email message
        /// </summary>
        /// <param name="isCallback"></param>
        /// <param name="phone"></param>
        /// <param name="productLineName"></param>
        /// <param name="productName"></param>
        /// <returns></returns>
        [HttpGet("/api/message/send")]
        public async Task<IActionResult> SendMessage(bool isCallback, string phone, string productLineName = null, string productName = null)
        {
            var subject = isCallback ? "[RZR-SITE] - Заказан обратный звонок" : "[RZR-SITE] - Запрошены подробности на товар";
            var html = System.IO.File.ReadAllText($"Content/Templates/{(isCallback ? "callback.html" : "place_order.html")}");
            html = html.Replace("{Phone}", phone);
            html = html.Replace("{DomainName}", $"{Request.Scheme}://{Request.Host}{Request.PathBase}");
            if (!string.IsNullOrEmpty(productLineName)) html = html.Replace("{ProductLineName}", productLineName);
            if (!string.IsNullOrEmpty(productName)) html = html.Replace("{ProductName}", productName);
            await _emailService.SendEmailAsync(subject, html);
            return Ok("Sended");
        }
    }
}
