using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using UrlTracker.GlobalBlocklist.Filters;
using UrlTracker.GlobalBlocklist.Services;
using UrlTracker.Web;

namespace UrlTracker.GlobalBlocklist.Composers
{
    public class GlobalBlocklistComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddHttpClient<RetrieveBlocklistService>();
            builder.Services.AddSingleton<IRetrieveBlocklistService, RetrieveBlocklistService>();
            builder.ClientErrorFilters()!
                .Append<GlobalBlocklistFilter>();
        }
    }
}
