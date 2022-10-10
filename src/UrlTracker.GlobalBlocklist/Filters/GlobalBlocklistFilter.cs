using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Umbraco.Cms.Core.Models;
using UrlTracker.GlobalBlocklist.Services;
using UrlTracker.Web.Processing;

namespace UrlTracker.GlobalBlocklist.Filters
{
    public class GlobalBlocklistFilter : IClientErrorFilter
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IRetrieveBlocklistService _retreiveBlocklistService;

        public GlobalBlocklistFilter(IMemoryCache memoryCache, IRetrieveBlocklistService retreiveBlocklistService)
        {
            _memoryCache = memoryCache;
            _retreiveBlocklistService = retreiveBlocklistService;
        }

        public async ValueTask<bool> EvaluateCandidateAsync(HttpContext context)
        {
            var url = string.Concat(context.Request.Scheme, "://", context.Request.Host, context.Request.Path, context.Request.QueryString);
            var blockedItems = _memoryCache.Get<List<string>>(Defaults.Cache.CacheKey);

            if (blockedItems == null)
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
