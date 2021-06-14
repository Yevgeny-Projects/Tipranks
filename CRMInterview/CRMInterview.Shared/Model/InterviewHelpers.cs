using System;
using System.Collections.Generic;

namespace CRMInterview.Model
{
    public static class InterviewHelpers
    {
        public static List<CrmEvent> CreateDefaultEvents()
        {
            var i = 0;
            var now = DateTime.Now;

            return new List<CrmEvent>()
            {
                new CrmEvent() {
                    Id = ++i,
                    Timestamp = now.AddMinutes(-15),
                    EventType = EventTypeEnum.VisitedPlans,
                    UserEmail = "gilad@gmail.com"
                },
                new CrmEvent()
                {
                    Id = ++i,
                    Timestamp = now.AddHours(-5).AddMinutes(-1),
                    EventType = EventTypeEnum.VisitedPlans,
                    UserEmail = "moshe@gmail.com"
                },
                new CrmEvent()
                {
                    Id = ++i,
                    Timestamp = now.AddHours(-5),
                    EventType = EventTypeEnum.ClickedBuyNow,
                    UserEmail = "moshe@gmail.com"
                },
                new CrmEvent()
                {
                    Id = ++i,
                    Timestamp = now.AddDays(-2).AddMinutes(-2),
                    EventType = EventTypeEnum.VisitedPlans,
                    UserEmail = "jenny@gmail.com"
                },
                new CrmEvent()
                {
                    Id = ++i,
                    Timestamp = now.AddDays(-2).AddMinutes(-1),
                    EventType = EventTypeEnum.ClickedBuyNow,
                    UserEmail = "jenny@gmail.com"
                },
                new CrmEvent()
                {
                    Id = ++i,
                    Timestamp = now.AddDays(-2),
                    EventType = EventTypeEnum.FailedToPay,
                    UserEmail = "jenny@gmail.com"
                },
                new CrmEvent()
                {
                    Id = ++i,
                    Timestamp = now.AddDays(-1),
                    EventType = EventTypeEnum.CompletedPayment,
                    UserEmail = "jenny@gmail.com"
                },
                new CrmEvent()
                {
                    Id = ++i,
                    Timestamp = now.AddMinutes(-3),
                    EventType = EventTypeEnum.CompletedPayment,
                    UserEmail = "moshe@gmail.com"
                }
            };
        }
    }
}