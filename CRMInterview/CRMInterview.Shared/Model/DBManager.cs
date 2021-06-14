using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRMInterview.Model;

namespace CRMInterview.Model
{
    public interface IEventRepository : IDisposable
    {
        /// <summary>
        /// Retrieves all the events
        /// </summary>
        /// <returns>A list of events</returns>
        Task<List<CrmEvent>> GetEventsAsync();
        /// <summary>
        /// Add an event. Note that your ID will be ignored, and an ID will be set for you.
        /// </summary>
        /// <param name="crmEvent"></param>
        /// <returns></returns>
        Task<CrmEvent> AddEventAsync(CrmEvent crmEvent);

        /// <summary>
        /// A queryable for querying over our data.
        /// </summary>
        /// <returns>A queryable for querying over our data.</returns>
        IQueryable<CrmEvent> Query();
    }


    public class InMemoryEventRepository : IEventRepository
    {
        private readonly List<CrmEvent> _events;
        public InMemoryEventRepository()
        {
            _events = InterviewHelpers.CreateDefaultEvents();
        }

        public void Dispose() { }
        public Task<List<CrmEvent>> GetEventsAsync()
        {
            return Task.FromResult(_events);
        }

        public async Task<CrmEvent> AddEventAsync(CrmEvent crmEvent)
        {
            crmEvent.Id = _events.Max(x => x.Id) + 1;
            _events.Add(crmEvent);
            return crmEvent;
        }

        public IQueryable<CrmEvent> Query()
        {
            return _events.AsQueryable();
        }
    }
}
