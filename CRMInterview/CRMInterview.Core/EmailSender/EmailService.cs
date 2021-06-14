using System;
using System.Threading.Tasks;

namespace CRMInterview.Core
{
    /// <summary>
    /// The class will contain send mail logic
    /// </summary>
    public class EmailSendingService : IEmailService
    {
        public async Task SendAsync(string email, string content)
        {
            Console.WriteLine($"Sent {content} to {email}.");
        }
    }
}