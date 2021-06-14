using CRMInterview.Core;
using CRMInterview.DI;
using CRMInterview.Model;
using System;
using System.Threading.Tasks;

namespace CRMInterview.BL
{
    public class ClickedBuyNowSendingService : ICrmService
    {

        private IEmailService emailService;

        public ClickedBuyNowSendingService()
        {
            emailService = IoCC.Instance.Resolve<IEmailService>();

        }
        public async Task SendAsync(CrmEvent item)
        {
            await emailService.SendAsync("", "");
        }
    }
}