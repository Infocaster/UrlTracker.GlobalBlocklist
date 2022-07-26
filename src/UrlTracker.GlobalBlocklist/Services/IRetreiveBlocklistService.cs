using System.Threading.Tasks;
using UrlTracker.GlobalBlocklist.Models;

namespace UrlTracker.GlobalBlocklist.Services
{
    public interface IRetreiveBlocklistService
    {
        Task<GlobalSettings> GetGlobalSettings();
    }
}
