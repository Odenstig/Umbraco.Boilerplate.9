using Boilerplate.Core.Models.GeneratedModels;
using Boilerplate.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Extensions;

namespace Boilerplate.Core.Components.Layout.PageScripts
{
    public class PageScriptsViewComponent : ViewComponent
    {
        private readonly ISiteService _siteService;
        public PageScriptsViewComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }

        public IViewComponentResult Invoke(ILayout currentPage)
        {
            var viewModel = new PageScriptsViewModel
            {
                PageScript = currentPage.PageScript,
                ScriptOnAllPages = _siteService.Root(currentPage?.GetCultureFromDomains())?.ScriptOnAllPages
            };

            return View(viewModel);
        }
    }
}
