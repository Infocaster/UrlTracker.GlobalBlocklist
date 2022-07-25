using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlTracker.GlobalBlocklist.Services
{
    public class RetreiveBlocklistService : IRetreiveBlocklistService
    {
        public async Task<List<string>> GetItemsFromBlocklist()
        {
            //TODO: use an httpClient to get the list of items
            return new List<string>();
        }
    }
}
