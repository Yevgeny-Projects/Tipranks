using CRMInterview.DI;
using CRMInterview.Model;
using Quartz;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMInterview.BL
{
    /// <summary>
    /// The class represents MailJob logic
    /// As a feature, we need to inject into the constructor an ICrmService class 
    /// </summary>
    internal class MailJob : IJob
    {
        //private static readonly ILog _log = LogManager.GetLogger(typeof(UserManagementService));
        private IDictionary<EventTypeEnum, ICrmService> mailDictionary;

        public MailJob()
        {
            MailDictionaryInit();

        }
        public Task Execute(IJobExecutionContext context)
        {
            CrmEvent item = (CrmEvent)context.JobDetail.JobDataMap["item"];

            var service = mailDictionary[item.EventType];
            service.SendAsync(item);


            return Task.CompletedTask;
        }

        /// <summary>
        /// Init mailDictionary
        /// </summary>
        private void MailDictionaryInit()
        {
            mailDictionary = new Dictionary<EventTypeEnum, ICrmService>();
            mailDictionary[EventTypeEnum.ClickedBuyNow] = IoCC.Instance.Resolve<ClickedBuyNowSendingService>();
            mailDictionary[EventTypeEnum.CompletedPayment] = IoCC.Instance.Resolve<CompletedPaymentSendingService>();
            mailDictionary[EventTypeEnum.FailedToPay] = IoCC.Instance.Resolve<FailedToPaySendingService>();
            mailDictionary[EventTypeEnum.VisitedPlans] = IoCC.Instance.Resolve<VisitedPlansSendingService>();
        }
    }
}