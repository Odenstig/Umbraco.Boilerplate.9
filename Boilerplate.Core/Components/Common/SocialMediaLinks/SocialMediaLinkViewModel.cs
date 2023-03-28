using System.Collections.Generic;

namespace Boilerplate.Core.Components.Common.SocialMediaLinks
{
    public class SocialMediaLinksViewModel
    {
        public List<SocialMediaLinkViewModel> Links { get; set; } = new List<SocialMediaLinkViewModel>();
        public string IconClasses { get; set; }
        public string IconBgColor { get; set; }
        public bool HasIconClasses => !string.IsNullOrEmpty(IconClasses);
    }

    public class SocialMediaLinkViewModel
    {
        public SocialMediaType Type { get; set; }
        public string Url { get; set; }
    }

    public class SocialMediaLinksRequest
    {
        public string IconClasses { get; set; }
        public string IconBgColor { get; set; } = "#71150f";
    }

    public enum SocialMediaType
    {
        Facebook,
        Instagram,
        LinkedIn
    }


}
