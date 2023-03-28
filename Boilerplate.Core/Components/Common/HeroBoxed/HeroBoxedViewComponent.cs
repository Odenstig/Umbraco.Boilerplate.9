using Boilerplate.Core.Models.GeneratedModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Strings;
using Umbraco.Extensions;

namespace Boilerplate.Core.Components.Common.HeroBoxed
{

    public class HeroBoxedViewComponent : ViewComponent
    {
        // WebP not yet supported with ImageSharp
        // https://github.com/SixLabors/ImageSharp
        public IViewComponentResult Invoke(ILayout currentPage)
        {
            var quality = 80;

            // Cannot use ValueFor with fallback for ILayout
            var text = currentPage.Value<IHtmlEncodedString>("heroBoxedText", fallback: Fallback.ToLanguage);
            var image = currentPage.Value<MediaWithCrops>("heroBoxedImage", fallback: Fallback.ToLanguage);
            var link = currentPage.Value<Link>("heroBoxedLink", fallback: Fallback.ToLanguage);
            var useFloatingHeader = currentPage.Value<bool>("useFloatingHeader", fallback: Fallback.ToLanguage);

            var viewModel = new HeroBoxedViewModel
            {
                HeroText = text,
                HasImage = image != null,
                HeroLink = link,
                DefaultCropUrl = image?.GetCropUrl(width: 863, height: 479, quality: quality, furtherOptions: "&format=jpg"),
                DesktopCropUrl = image?.GetCropUrl(width: 711, height: 544, quality: quality, furtherOptions: "&format=jpg"),
                TabletCropUrl = image?.GetCropUrl(width: 757, height: 425, quality: quality, furtherOptions: "&format=jpg"),
                MobileCropUrl = image?.GetCropUrl(width: 442, height: 248, quality: quality, furtherOptions: "&format=jpg"),
                IncreasedTopSpace = useFloatingHeader
            };
            
            return View(viewModel);
        }
    }
}
