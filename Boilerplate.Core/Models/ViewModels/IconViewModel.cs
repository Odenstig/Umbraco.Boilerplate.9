using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.Core.Models.ViewModels
{
    public class IconViewModel
    {
        public string IconName { get; set; }
        public string IconClasses { get; set; }
        public bool HasIconClasses => !string.IsNullOrEmpty(IconClasses);
    }
}
