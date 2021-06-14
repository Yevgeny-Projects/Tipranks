using CRMInterview.Core;
using CRMInterview.DI;
using CRMInterview.Model;
using System;
using System.Threading.Tasks;

namespace CRMInterview.BL
{
    public class VisitedPlansSendingService : ICrmService
    {
        private IEmailService emailService;

        public VisitedPlansSendingService()
        {
            emailService = IoCC.Instance.Resolve<IEmailService>();

        }
        public async Task SendAsync(CrmEvent item)
        {
            await emailService.SendAsync("", "");
        }
    }
}