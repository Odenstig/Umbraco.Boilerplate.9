using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.Blocks;

namespace Boilerplate.Core.Components.Layout.Footer
{
    public class FooterViewModel
    {
        public string SiteUrl { get; set; }
        public string SiteLinkTitle { get; set; }
        public List<FooterBlockViewModel> Sections { get; set; } = new List<FooterBlockViewModel>(); 
        public List<Link> BottomsLinks { get; set; } = new List<Link>();
        public bool HasBottomLinks => BottomsLinks.Any();
    }

    public class FooterBlockViewModel
    {
        public int Order { get; set; }
        public BlockListItem Block { get; set; }
    }
}
