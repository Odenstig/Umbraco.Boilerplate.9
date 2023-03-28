using Boilerplate.Core.Models.GeneratedModels;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Strings;
using Umbraco.Extensions;

namespace Boilerplate.Core.Components.Common.Hero
{
    public class HeroViewComponent : ViewComponent
    {
        // WebP not yet supported with ImageSharp
        // https://github.com/SixLabors/ImageSharp
        public IViewComponentResult Invoke(ILayout currentPage)
        {
            var quality = 80;

            // Cannot use ValueFor with fallback for ILayout
            var text = currentPage.Value<IHtmlEncodedString>("heroText", fallback: Fallback.ToLanguage);
            var isLightText = currentPage.Value<bool>("heroLightText", fallback: Fallback.ToLanguage);
            var image = currentPage.Value<MediaWithCrops>("heroImage", fallback: Fallback.ToLanguage);

            var viewModel = new HeroViewModel
            {
                HeroText = text,
                IsLightHeroText = isLightText,
                HasImage = image != null,
                DefaultCropUrl = image?.GetCropUrl(width: 1680, height: 520, quality: quality, furtherOptions: "&format=jpg"),
                DesktopCropUrl = image?.GetCropUrl(width: 1800, height: 700, quality: quality, furtherOptions: "&format=jpg"),
                TabletCropUrl = image?.GetCropUrl(width: 1000, height: 400, quality: quality, furtherOptions: "&format=jpg"),
                MobileCropUrl = image?.GetCropUrl(width: 640, height: 720, quality: quality, furtherOptions: "&format=jpg")
            };

            return View(viewModel);
        }
    }
}
