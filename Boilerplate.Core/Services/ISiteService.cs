using Boilerplate.Core.Models.DataModels;
using Boilerplate.Core.Models.GeneratedModels;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Web.Common;

namespace Boilerplate.Core.Services
{
    public interface ISiteService
    {
        SiteSettings Settings { get; }
        IPublishedContentCache ContentQuery { get; }
        Site Root(string culture);
        string Translate(string translationKey, string culture);
    }
}