using System.Threading.Tasks;

namespace SGEJ.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
