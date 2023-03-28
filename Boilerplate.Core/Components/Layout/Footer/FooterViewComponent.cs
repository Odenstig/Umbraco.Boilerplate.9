using Boilerplate.Core.Classes;
using Boilerplate.Core.Models.GeneratedModels;
using Boilerplate.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Extensions;

namespace Boilerplate.Core.Components.Layout.Footer
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly ISiteService _siteService;

        public FooterViewComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }

        public IViewComponentResult Invoke(ILayout currentPage)
        {
            var culture = currentPage?.GetCultureFromDomains();
            var root = _siteService.Root(culture);
            var viewModel = new FooterViewModel();

            if (root != null)
            {
                viewModel.BottomsLinks = root.FooterBottomLinks.ToList();
                viewModel.SiteUrl = root.Url();
                viewModel.SiteLinkTitle = _siteService.Translate(TranslationKeys.Globals_SiteLinkTitle, culture);

                for (int i = 0; i < root.FooterBlocks.Count; i++)
                {
                    viewModel.Sections.Add(new FooterBlockViewModel
                    {
                        Block = root.FooterBlocks[i],
                        Order = i
                    });
                }
            }

            return View(viewModel);
        }
    }
}
