using Boilerplate.Core.Models.GeneratedModels;
using Boilerplate.Core.Services;
using Boilerplate.Core.Services.MetaService;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Boilerplate.Core.Components.Layout.MetaTags
{
    public class MetaTagsViewComponent : ViewComponent
    {
        private readonly IMetaService _metaHelper;
        private readonly ISiteService _siteService;

        public MetaTagsViewComponent(IMetaService metaHelper, ISiteService siteService)
        {
            _metaHelper = metaHelper;
            _siteService = siteService;
        }

        public IViewComponentResult Invoke(ILayout currentPage)
        {
            var root = _siteService.Root(currentPage?.GetCultureFromDomains());
            var pageTitle = _metaHelper.PageTitle(currentPage);
            var viewModel = new MetaTagsViewModel
            {
                PageTitle = pageTitle,
                MetaDescription = currentPage.MetaDescription,
                RobotsContent = _metaHelper.RobotsContent(currentPage),
                OgImage = _metaHelper.PageMetaImage(currentPage),
                OgTitle = pageTitle,
                OgUrl = currentPage.Url(null, UrlMode.Absolute),
                OgDescription = _metaHelper.PageTeaser(currentPage, 160),
                OgSiteName = root.Name
            };

            return View(viewModel);
        }
    }
}
