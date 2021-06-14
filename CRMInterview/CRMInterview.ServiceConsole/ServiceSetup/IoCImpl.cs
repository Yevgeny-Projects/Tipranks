using CRMInterview.BL;
using CRMInterview.Core;
using CRMInterview.DI;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRMInterview.ServiceConsole.ServiceSetup
{
    public class IoCImpl
    {
        public IoCImpl()
        {
        }

        #region Public methods

        public void Configure()
        {
            IoCC.Instance.Register<IEmailService>(new EmailSendingService());
            IoCC.Instance.Register<ICrmService>(new VisitedPlansSendingService());
            IoCC.Instance.Register<ICrmService>(new ClickedBuyNowSendingService());
            IoCC.Instance.Register<ICrmService>(new FailedToPaySendingService());
            IoCC.Instance.Register<ICrmService>(new CompletedPaymentSendingService());
            IoCC.Instance.Register<IMailerService>(new MailerService());
        }

        #endregion Public methods
    }
}