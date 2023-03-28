using Boilerplate.Core.Classes;
using Boilerplate.Core.Models.DataModels;
using Boilerplate.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;
using Umbraco.Extensions;

namespace Boilerplate.Core.Components.Layout.Header
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ISiteService _siteService;
        private readonly CoreHelpers _coreHelpers;

        public HeaderViewComponent(ISiteService siteService, CoreHelpers coreHelpers)
        {
            _siteService = siteService;
            _coreHelpers = coreHelpers;
        }

        public IViewComponentResult Invoke(HeaderRequest req)
        {
            var culture = req.CurrentPage?.GetCultureFromDomains();
            var site = _siteService.Root(culture);

            var mainNavigation = site.MainNavigation;
            var topLinkNavigation = site.TopLinks;
            var iconLinks = site.IconLinks;

            var viewModel = new HeaderViewModel
            {
                CurrentPageId = req.CurrentPage.Id,
                SiteUrl = site.Url(),
                SiteLinkTitle = _siteService.Translate(TranslationKeys.Globals_SiteLinkTitle, culture)
            };

            foreach (var navigationItem in mainNavigation.Where(n => n.NavigationLink != null))
            {
                var menuItem = _coreHelpers.MenuItem(
                    navigationItem.NavigationLink,
                    req.CurrentPage,
                    maxLevel: req.MainNavMaxLevel);

                viewModel.MainNavigation.Add(menuItem);
            }

            foreach (var topItem in topLinkNavigation.Where(t => t.Link != null))
            {
                MenuItem menuItem;

                if (topItem.Link.Type == LinkType.External)
                {
                    menuItem = _coreHelpers.ExternalMenuItem(topItem.Link);
                }

                else
                {
                    var page = _siteService.ContentQuery.GetById(topItem.Link.Udi);
                    menuItem = _coreHelpers.MenuItem(
                        page, 
                        req.CurrentPage, 
                        linkName: topItem.Link.Name,
                        maxLevel: req.TopLinksMaxLevel);
                }

                viewModel.TopLinkNavigation.Add(menuItem);
            }

            foreach (var iconLink in iconLinks.Where(i => i.Link != null))
            {
                viewModel.IconLinks.Add(new IconMenuItem
                {
                    Name = iconLink.Link.Name,
                    Url = iconLink.Link.Url,
                    IconName = iconLink.Icon,
                    IsExternal = iconLink.Link.Type == LinkType.External
                });
            }

            return View(viewModel);
        }
    }
}
