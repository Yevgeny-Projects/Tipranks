using System.Threading.Tasks;

namespace CRMInterview.BL
{
    public interface IMailerService
    {
        public Task<bool> ScheduleJobs();
        public void Start();

        public void Stop();

        public void Pause();

        public void Resume();

        public void Shutdown();

    }
}