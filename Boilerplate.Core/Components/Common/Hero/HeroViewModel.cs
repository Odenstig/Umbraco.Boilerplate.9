using Umbraco.Cms.Core.Strings;

namespace Boilerplate.Core.Components.Common.Hero
{
    public class HeroViewModel
    {
        public IHtmlEncodedString HeroText { get; set; }
        public bool IsLightHeroText { get; set; }
        public bool HasImage { get; set; }
        public string DefaultCropUrl { get; set; }
        public string DesktopCropUrl { get; set; }
        public string TabletCropUrl { get; set; }
        public string MobileCropUrl { get; set; }
    }
}
