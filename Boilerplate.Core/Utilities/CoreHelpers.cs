using Boilerplate.Core.Models.DataModels;
using Boilerplate.Core.Models.GeneratedModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.IO;
using System.Linq;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Boilerplate.Core.Classes
{
    public class CoreHelpers
    {
        public MenuItem MenuItem(
            IPublishedContent page, 
            ILayout currentPage,
            string linkName = null,
            int? maxLevel = null,
            int currentLevel = 1)
        {

            if (page == null)
                return null;

            var parentNavItem = new MenuItem
            {
                Id = page.Id,
                Name = linkName ?? page.NavName(),
                Url = page.Url(),
                IsCurrentPage = page.Id == currentPage.Id,
                IsCurrentPageActive = page.IsAncestorOrSelf(currentPage),
                IsExternal = false,
                NavLevel = currentLevel
            };

            var children = page.Children.FilterInvalidPages();
            var hasMaxLevel = maxLevel != null;
            var shouldGetChildren = !hasMaxLevel || (hasMaxLevel && maxLevel > currentLevel);

            if (children.Any() && shouldGetChildren)
            {
                currentLevel++;
                foreach (var child in children)
                {
                    var childNavItem = MenuItem(child, currentPage, currentLevel: currentLevel);
                    parentNavItem.Children.Add(childNavItem);
                }
            }

            return parentNavItem;
        }

        public MenuItem ExternalMenuItem(Link link)
        {
            return new MenuItem
            {
                IsExternal = true,
                Url = link.Url,
                Name = link.Name
            };
        }


        public static string RenderPartialToString(ControllerContext controllerContext, PartialViewResult pvr, ICompositeViewEngine _viewEngine)
        {
            using StringWriter writer = new();
            ViewEngineResult vResult = _viewEngine.FindView(controllerContext, pvr.ViewName, false);
            ViewContext viewContext = new(controllerContext, vResult.View, pvr.ViewData, pvr.TempData, writer, new HtmlHelperOptions());

            vResult.View.RenderAsync(viewContext);

            return writer.GetStringBuilder().ToString();
        }
    }
}
