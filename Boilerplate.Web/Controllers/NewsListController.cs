using Boilerplate.Core.Classes;
using Boilerplate.Core.Models.GeneratedModels;
using Boilerplate.Core.Models.ViewModels;
using Boilerplate.Core.Services;
using Boilerplate.Core.Services.NewsService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Extensions;

namespace Boilerplate.Web.Controllers
{
    public class NewsListController : RenderController
    {
        private readonly IVariationContextAccessor _variationContextAccessor;
        private readonly ServiceContext _serviceContext;
        private readonly INewsService _newsService;
        private readonly ISiteService _siteService;

        public NewsListController(
            ILogger<RenderController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor,
            IVariationContextAccessor variationContextAccessor,
            ServiceContext context,
            INewsService newsService,
            ISiteService siteService) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _variationContextAccessor = variationContextAccessor;
            _serviceContext = context;
            _newsService = newsService;
            _siteService = siteService;
        }

        public override IActionResult Index()
        {
            var initialLoadAmount = 4; 
            var culture = CurrentPage.GetCultureFromDomains();
            var latestNews = _newsService.GetLatestNewsForNewsList(CurrentPage.Id, culture, take: initialLoadAmount).ToList();
            var totalNewsItems = _newsService.GetNewsCountForNewsList(CurrentPage.Id, culture);

            var viewModel = new NewsListPageViewModel(CurrentPage as NewsList, new PublishedValueFallback(_serviceContext, _variationContextAccessor))
            {
                InitalLoadAmount = initialLoadAmount,
                LatestNews = latestNews,
                LatestNewsTitle = _siteService.Translate(TranslationKeys.News_LatestNewsTitle, culture),
                Culture = culture,
                CanLoadMore = totalNewsItems > latestNews.Count,
                LoadMoreText = _siteService.Translate(TranslationKeys.Globals_LoadMore, culture)
            };

            return CurrentTemplate(viewModel);
        }
    }
}
