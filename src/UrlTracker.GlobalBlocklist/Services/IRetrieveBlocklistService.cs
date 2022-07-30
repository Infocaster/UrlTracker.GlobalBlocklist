using System.Threading.Tasks;
using UrlTracker.GlobalBlocklist.Models;

namespace UrlTracker.GlobalBlocklist.Services
{
    public interface IRetrieveBlocklistService
    {
        Task<GlobalSettings> GetGlobalSettings();
    }
}
