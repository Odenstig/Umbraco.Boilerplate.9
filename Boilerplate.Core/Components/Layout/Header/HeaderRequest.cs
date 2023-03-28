using Boilerplate.Core.Models.GeneratedModels;

namespace Boilerplate.Core.Components.Layout.Header
{
    public class HeaderRequest
    {
        public ILayout CurrentPage { get; set; }
        public int? MainNavMaxLevel { get; set; }
        public int? TopLinksMaxLevel { get; set; }
    }
}
