using System;
using CRMInterview.Core;
using CRMInterview.DI;
using CRMInterview.Model;
using System.Threading.Tasks;

namespace CRMInterview.BL
{
    public class FailedToPaySendingService : ICrmService
    {
        private IEmailService emailService;

        public FailedToPaySendingService()
        {
            emailService = IoCC.Instance.Resolve<IEmailService>();

        }
        public async Task SendAsync(CrmEvent item)
        {
            await emailService.SendAsync("", "");
        }
    }
}