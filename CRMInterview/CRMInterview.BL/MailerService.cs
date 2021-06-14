using CRMInterview.DI;
using CRMInterview.Model;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;

namespace CRMInterview.BL
{
    /// <summary>
    /// The class represents scheduler logic
    /// </summary>
    public class MailerService : IMailerService
    {

        #region Members

        private readonly IScheduler scheduler;
        #endregion Members

        public MailerService()
        {
            NameValueCollection props = new NameValueCollection
            {
                { "quartz.serializer.type", "binary" },
                { "quartz.scheduler.instanceName", "MyScheduler" },
                { "quartz.jobStore.type", "Quartz.Simpl.RAMJobStore, Quartz" },
                { "quartz.threadPool.threadCount", "3" }
            };
            StdSchedulerFactory factory = new StdSchedulerFactory(props);
            scheduler = factory.GetScheduler().ConfigureAwait(false).GetAwaiter().GetResult();

        }


        public void Start()
        {
            //_log.Info("Starting...");
            scheduler.Start().ConfigureAwait(false).GetAwaiter().GetResult();
            ScheduleJobs();
            //_log.Info("Started succesfully.");
        }

        public void Stop()
        {
            //_log.Info("Stopping...");
            scheduler.Shutdown().ConfigureAwait(false).GetAwaiter().GetResult();
            //_log.Info("Stopped succesfully.");
        }

        public void Pause()
        {
        }

        public void Resume()
        {
        }

        public void Shutdown()
        {
        }



        /// <summary>
        /// Create scheduled job
        /// For now, I use here GetEventsAsync, but will be better solution to use Query
        /// and build different Job for each EventTypeEnum
        /// </summary>
        /// <returns></returns>
        public async Task<bool> ScheduleJobs()
        {
            var rep = new InMemoryEventRepository();
            var mailEvents = await rep.GetEventsAsync();
            StartProccess(mailEvents);
            return true;
        }

        private async Task StartProccess(List<CrmEvent> mailEvents)
        {

            foreach (CrmEvent item in mailEvents)
            {

                IJobDetail job = JobBuilder.Create<MailJob>()
                .WithIdentity("job" + item.EventType, "group1")
                .Build();

                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("trigger" + item.EventType, "group1")
                    .StartNow()
                    .WithSimpleSchedule(x => x
                        .WithIntervalInMinutes(2)
                        .RepeatForever())
                    .Build();
                job.JobDataMap.Add("user", item);

                // Tell quartz to schedule the job using our trigger
                await scheduler.ScheduleJob(job, trigger);
            }
        }


    }
}
