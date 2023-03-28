using Boilerplate.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Boilerplate.Core.Components.Common.SocialMediaLinks
{
    public class SocialMediaLinksViewComponent : ViewComponent
    {
        private readonly ISiteService _siteService;

        public SocialMediaLinksViewComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }

        public IViewComponentResult Invoke(SocialMediaLinksRequest req)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.CultureName;
            var root = _siteService.Root(culture);

            var socialMediaLinks = new List<SocialMediaLinkViewModel>
            {
                new SocialMediaLinkViewModel { Type = SocialMediaType.Facebook, Url = root.Facebook },
                new SocialMediaLinkViewModel { Type = SocialMediaType.LinkedIn, Url = root.LinkedIn },
                new SocialMediaLinkViewModel { Type = SocialMediaType.Instagram, Url = root.Instagram }
            }
            .Where(s => s.Url != null)
            .ToList();

            return View(new SocialMediaLinksViewModel
            {
                Links = socialMediaLinks,
                IconClasses = req.IconClasses,
                IconBgColor = req.IconBgColor
            });
        }
    }
}
