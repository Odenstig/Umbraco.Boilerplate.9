using Boilerplate.Core.Classes;
using Boilerplate.Core.Models.ViewModels;
using Boilerplate.Core.Services.NewsService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace Boilerplate.Web.Controllers
{
    public class NewsSurfaceController : SurfaceController
    {
        private ICompositeViewEngine _viewEngine;
        private readonly INewsService _newsService;

        public NewsSurfaceController(
            ICompositeViewEngine viewEngine,
            IUmbracoContextAccessor umbracoContextAccessor,
            IUmbracoDatabaseFactory databaseFactory,
            ServiceContext services,
            AppCaches appCaches,
            IProfilingLogger profilingLogger,
            IPublishedUrlProvider publishedUrlProvider,
            INewsService newsService)
            : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _newsService = newsService;
            _viewEngine = viewEngine;
        }

        [HttpGet]
        public IActionResult GetNews(int newsListId, int take, int skip, string culture)
        {
            var totalNewsItems = _newsService.GetNewsCountForNewsList(newsListId, culture);
            var newsItems = _newsService.GetLatestNewsForNewsList(newsListId, culture, take, skip);
            var newsItemsCount = newsItems.Count();
            var partialViewResult = PartialView("_NewsItems", new NewsItemsPartialViewModel
            {
                NewsItems = newsItems,
                UseFourColumnLayout = true,
                UseImageLazyLoad = false
            });
   
            var json = new
            {
                PartialView = CoreHelpers.RenderPartialToString(this.ControllerContext, partialViewResult, _viewEngine),
                Skip = skip + take,
                CanLoadMore = totalNewsItems > (skip + newsItemsCount)
            };

            return Json(json);
        }
    }



}
