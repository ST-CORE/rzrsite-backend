using System.Threading.Tasks;

namespace RzrSite.API.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string subject, string message, string email = null);
    }
}
