using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using Microsoft.Extensions.Caching.Memory;
using UrlTracker.GlobalBlocklist.Services;
using UrlTracker.Web.Events.Models;
using UrlTracker.Web.Processing;

namespace UrlTracker.GlobalBlocklist.Filters
{
    public class GlobalBlocklistFilter : IClientErrorFilter
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IRetreiveBlocklistService _retreiveBlocklistService;

        public GlobalBlocklistFilter(IMemoryCache memoryCache, IRetreiveBlocklistService retreiveBlocklistService)
        {
            _memoryCache = memoryCache;
            _retreiveBlocklistService = retreiveBlocklistService;
        }

        public ValueTask<bool> EvaluateCandidateAsync(UrlTrackerHandled notification)
            => new ValueTask<bool>(EvaluateCandidate(notification));

        public async Task<bool> EvaluateCandidate(UrlTrackerHandled notification)
        {
            var url = notification.Url.ToString();

            var blockedItems = _memoryCache.Get<List<string>>(Defaults.Cache.CacheKey);

            //TODO: defensive programming!
            if (blockedItems.Count == 0)
            {
                var globalSettings = await _retreiveBlocklistService.GetGlobalSettings();
                blockedItems = globalSettings.GlobalBlocklist;

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(24));

                _memoryCache.Set(Defaults.Cache.CacheKey, blockedItems, cacheEntryOptions);
            }

            foreach (var item in blockedItems)
            {
                if (url.Contains(item)) return false;
            }

            return true;
        }
    }
}
