using Boilerplate.Core.Models.DataModels;
using System.Collections.Generic;

namespace Boilerplate.Core.Components.Layout.PreHeader
{
    public class PreHeaderViewModel
    {
        public int CurrentPageId { get; set; }
        public List<MenuItem> TopLinks { get; set; }
        public bool Floating { get; set; }
    }
}
