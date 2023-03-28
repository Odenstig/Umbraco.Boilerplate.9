using Boilerplate.Core.Models.DataModels;
using Boilerplate.Core.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class NewsLetterSurfaceController : SurfaceController
    {
        private readonly ILogger<NewsLetterSurfaceController> _logger;

        public NewsLetterSurfaceController(
           IUmbracoContextAccessor umbracoContextAccessor,
           IUmbracoDatabaseFactory databaseFactory,
           ServiceContext services,
           AppCaches appCaches,
           IProfilingLogger profilingLogger,
           IPublishedUrlProvider publishedUrlProvider,
           ILogger<NewsLetterSurfaceController> logger
           )
           : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _logger = logger;
        }


        [HttpPost]
        public IActionResult Register([FromForm] NewsLetterFormViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors
                                           .Select(e => e.ErrorMessage).ToArray())
                                           .Where(m => m.Value.Any());

                    return BadRequest(new { Errors = errors });
                }

                return Ok();
            }

            catch (Exception e)
            {
                _logger.LogWarning("Failed to subscribe to newsletter", e.Message);
                return StatusCode(500);
            }
        }

        [IgnoreAntiforgeryToken]
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok("OIK");
        }

        [HttpGet]
        public IActionResult GetNews(int newsListId)
        {
            return Ok("OK");
        }
    }
}
