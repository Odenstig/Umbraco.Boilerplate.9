using Boilerplate.Core.Models.GeneratedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.Core.Models.ViewModels
{
    public class NewsItemsPartialViewModel
    {
        public bool UseFourColumnLayout { get; set; }
        public bool UseImageLazyLoad { get; set; }
        public IEnumerable<News> NewsItems { get; set; }
        public bool HasNewsItems => NewsItems.Any();
    }
}
