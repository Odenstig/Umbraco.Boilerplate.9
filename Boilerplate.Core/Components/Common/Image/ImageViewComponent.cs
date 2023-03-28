using Boilerplate.Core.Classes;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Extensions;

namespace Boilerplate.Core.Components.Common.Image
{
    public class ImageViewComponent : ViewComponent
    {

        /// <summary>
        /// View component to create an optimised image. Can be used both for Umbraco media items or image urls.
        /// /// WebP not yet supported with ImageSharp
        // https://github.com/SixLabors/ImageSharp
        /// </summary>
        public IViewComponentResult Invoke(ImageRequestBase req)
        {
            var viewModel = new ImageViewModel
            {
                IsLazy = req.IsLazy,
                ObjectFit = req.ObjectFit.GetDescription(),
                ClassNames = req.ClassNames
            };

            if (req is ImageMediaRequest imageRequest)
            {
                var imageUrl = imageRequest?.Image?.GetCropUrl(
                    quality: imageRequest?.Quality,
                    width: imageRequest?.Crops?.Width,
                    height: imageRequest?.Crops?.Height,
                    furtherOptions: $"&format={imageRequest.ImageFormat}");

                viewModel.JpegUrl = imageUrl;
                viewModel.AltText = imageRequest.Image?.Value<string>("altText");
            }

            else if (req is ImageUrlRequest imageUrlRequest)
            {
                var imageUrl = imageUrlRequest?.ImageUrl.GetCropUrl(
                    quality: imageUrlRequest?.Quality,
                    width: imageUrlRequest?.Crops?.Width,
                    height: imageUrlRequest?.Crops?.Height,
                    furtherOptions: $"&format={imageUrlRequest.ImageFormat}");

                viewModel.JpegUrl = imageUrl;
                viewModel.AltText = imageUrlRequest.AltText;
            }

            return View(viewModel);
        }
    }
}
