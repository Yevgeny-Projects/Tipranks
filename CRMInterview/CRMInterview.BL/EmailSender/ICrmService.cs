using CRMInterview.Model;
using System.Threading.Tasks;

namespace CRMInterview.BL
{
    public interface ICrmService
    {
        Task SendAsync(CrmEvent item);
    }
}