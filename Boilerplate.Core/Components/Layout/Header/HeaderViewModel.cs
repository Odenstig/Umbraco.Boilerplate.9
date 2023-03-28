using Boilerplate.Core.Models.DataModels;
using System.Collections.Generic;

namespace Boilerplate.Core.Components.Layout.Header
{
    public class HeaderViewModel
    {
        public string SiteUrl { get; set; }
        public string SiteLinkTitle { get; set; }
        public int CurrentPageId { get; set; }
        public List<MenuItem> MainNavigation { get; set; } = new List<MenuItem>();
        public List<MenuItem> TopLinkNavigation { get; set; } = new List<MenuItem>();
        public List<IconMenuItem> IconLinks { get; set; } = new List<IconMenuItem>();
    }
}
