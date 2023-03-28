using Boilerplate.Core.Models.GeneratedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Boilerplate.Core.Models.ViewModels
{
    public class NewsPageViewModel : News
    {
        public NewsPageViewModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback) : 
            base(content, publishedValueFallback)
        { }

        public bool DisplayDatePassed { get; set; }
        public string FormattedDisplayDate { get; set; }
        public string PlaceholderText  { get; set; }
    }
}
