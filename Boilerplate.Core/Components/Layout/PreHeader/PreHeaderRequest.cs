using Boilerplate.Core.Models.GeneratedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.Core.Components.Layout.PreHeader
{
    public class PreHeaderRequest
    {
        public ILayout CurrentPage { get; set; }
        public bool Floating { get; set; }
    }
}
