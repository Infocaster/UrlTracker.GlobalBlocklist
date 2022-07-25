using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using UrlTracker.Web.Events.Models;
using UrlTracker.Web.Processing;

namespace UrlTracker.GlobalBlocklist.Filters
{
    public class GlobalBlocklistFilter : IClientErrorFilter
    {

        public ValueTask<bool> EvaluateCandidateAsync(UrlTrackerHandled notification)
            => new ValueTask<bool>(EvaluateCandidate(notification));

        public bool EvaluateCandidate(UrlTrackerHandled notification)
        {
            return true;
        }
    }
}
