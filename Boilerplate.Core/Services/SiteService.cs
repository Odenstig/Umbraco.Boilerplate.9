using Boilerplate.Core.Classes;
using Boilerplate.Core.Models.DataModels;
using Boilerplate.Core.Models.GeneratedModels;
using Microsoft.Extensions.Options;
using System.Linq;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;

namespace Boilerplate.Core.Services
{
    public class SiteService : ISiteService
    {
        private readonly IUmbracoContextFactory _umbracoContextFactory;
        private readonly ILocalizationService _localizationService;

        public SiteService(
            IUmbracoContextFactory umbracoContextFactory,
            ILocalizationService localizationService,
            IOptions<SiteSettings> settings)
        {
            _umbracoContextFactory = umbracoContextFactory;
            _localizationService = localizationService;
            Settings = settings.Value;
        }

        public SiteSettings Settings { get; }
        public IPublishedContentCache ContentQuery
        {
            get
            {
                using var umbracoContextReference = _umbracoContextFactory.EnsureUmbracoContext();
                return umbracoContextReference.UmbracoContext.Content;
            }
        }

        public Site Root(string culture)
        {
            var siteRoot = ContentQuery.GetAtRoot().FirstOrDefault(r => r.GetCultureFromDomains() == culture);
            return siteRoot as Site;
        }

        public string Translate(string translationKey, string culture)
        {
            return _localizationService.GetTranslationByCulture(translationKey, culture);
        }

        public static string Culture()
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
        }
    }
}
