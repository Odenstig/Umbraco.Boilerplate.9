using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.Core.Components.Common.Image
{
    public class ImageViewModel
    {
        public string JpegUrl { get; set; }
        public string WebPUrl { get; set; }
        public bool IsLazy { get; set; }
        public string AltText { get; set; }
        public string ObjectFit { get; set; }
        public string ClassNames { get; set; }
        public bool HasClassNames => !string.IsNullOrEmpty(ClassNames);
        public bool HasObjectFit => ObjectFit != "none";
        public bool HasImage => !string.IsNullOrEmpty(JpegUrl);
    }
}
