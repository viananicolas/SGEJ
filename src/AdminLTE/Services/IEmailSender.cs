using System.Threading.Tasks;

namespace SGEJ.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
