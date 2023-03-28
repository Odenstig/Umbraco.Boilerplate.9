using System.ComponentModel;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Boilerplate.Core.Components.Common.Image
{
    public class ImageRequestBase
    {
        public bool IsLazy { get; set; }
        public int Quality { get; set; } = 80;
        public ImageRequestCrops Crops { get; set; }
        public ObjectFitType ObjectFit { get; set; } = ObjectFitType.None;
        public string ClassNames { get; set; }
        public string ImageFormat { get; set; } = "jpg";
    }

    public class ImageMediaRequest : ImageRequestBase
    {
        public IPublishedContent Image { get; set; }
    }

    public class ImageUrlRequest : ImageRequestBase
    {
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
    }


    public class ImageRequestCrops
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public enum ObjectFitType
    {
        [Description("cover")]
        Cover,
        [Description("contain")]
        Contain,
        [Description("none")]
        None
    }
}
