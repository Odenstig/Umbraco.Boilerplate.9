using Boilerplate.Core.Models.GeneratedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Boilerplate.Core.Models.ViewModels
{
    public class LayoutViewModel
    {
        public LayoutViewModel(ILayout currentPage)
        {
            UseFloatingHeader = currentPage.Value<bool>("useFloatingHeader", fallback: Fallback.ToLanguage);
        }

        public bool UseFloatingHeader { get; set; }
    }
}
