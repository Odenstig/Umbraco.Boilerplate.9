using Boilerplate.Core.Classes;
using Boilerplate.Core.Models.DataModels;
using Boilerplate.Core.Models.GeneratedModels;
using Boilerplate.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models;
using Umbraco.Extensions;

namespace Boilerplate.Core.Components.Layout.PreHeader
{
    public class PreHeaderViewComponent : ViewComponent
    {
        private readonly ISiteService _siteService;
        private readonly CoreHelpers _coreHelpers;

        public PreHeaderViewComponent(ISiteService siteService, CoreHelpers coreHelpers)
        {
            _siteService = siteService;
            _coreHelpers = coreHelpers;
        }

        public IViewComponentResult Invoke(PreHeaderRequest req)
        {
            var topItems = _siteService.Root(req?.CurrentPage?.GetCultureFromDomains()).TopLinks;
            var viewModeLinks = new List<MenuItem>();

            foreach (var topItem in topItems.Where(t => t.Link != null))
            {
                MenuItem menuItem;

                if (topItem.Link.Type == LinkType.External)
                {
                    menuItem = _coreHelpers.ExternalMenuItem(topItem.Link);
                }

                else
                {
                    var page = _siteService.ContentQuery.GetById(topItem.Link.Udi);
                    menuItem = _coreHelpers.MenuItem(page, req.CurrentPage, linkName: topItem.Link.Name);
                }

                viewModeLinks.Add(menuItem);
            }

            return View(new PreHeaderViewModel
            {
                CurrentPageId = req.CurrentPage.Id,
                TopLinks = viewModeLinks,
                Floating = req.Floating
            });
        }
    }
}
