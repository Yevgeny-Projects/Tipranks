using System.Threading.Tasks;

namespace CRMInterview.Core
{
    public interface IEmailService
    {
        Task SendAsync(string email, string content);
    }
}