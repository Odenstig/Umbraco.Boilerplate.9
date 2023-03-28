using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Strings;

namespace Boilerplate.Core.Components.Common.HeroBoxed
{
    public class HeroBoxedViewModel
    {
        public IHtmlEncodedString HeroText { get; set; }
        public Link HeroLink { get; set; }
        public bool HasLink => HeroLink != null;
        public bool HasImage { get; set; }
        public string DefaultCropUrl { get; set; }
        public string DesktopCropUrl { get; set; }
        public string TabletCropUrl { get; set; }
        public string MobileCropUrl { get; set; }
        public bool IncreasedTopSpace { get; set; }
    }
}
