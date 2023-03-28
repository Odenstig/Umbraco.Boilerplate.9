using Boilerplate.Core.Classes;
using Boilerplate.Core.Models.GeneratedModels;
using Boilerplate.Core.Models.ViewModels;
using Boilerplate.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Extensions;

namespace Boilerplate.Web.Controllers
{
    public class NewsController : RenderController
    {
        private readonly IVariationContextAccessor _variationContextAccessor;
        private readonly ServiceContext _serviceContext;
        private readonly ISiteService _siteService;

        public NewsController(
            ILogger<RenderController> logger, 
            ICompositeViewEngine compositeViewEngine, 
            IUmbracoContextAccessor umbracoContextAccessor, 
            IVariationContextAccessor variationContextAccessor,
            ISiteService siteService,
            ServiceContext context) : 
            base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _variationContextAccessor = variationContextAccessor;
            _serviceContext = context;
            _siteService = siteService;
        }

        public override IActionResult Index()
        {
            var model = CurrentPage as News;
            var culture = model.GetCultureFromDomains();
            var viewModel = new NewsPageViewModel(model, new PublishedValueFallback(_serviceContext, _variationContextAccessor))
            {
                DisplayDatePassed = model.DisplayDate < DateTime.Now,
                PlaceholderText = _siteService.Translate(TranslationKeys.News_PlaceholderText, culture),
                FormattedDisplayDate = model.DisplayDate
                    .ToString("dd MMMM, yyyy", CultureInfo.GetCultureInfo(culture))
                    .ToUpper()
            };

            return CurrentTemplate(viewModel);
        }
    }
}
