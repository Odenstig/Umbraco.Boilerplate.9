using Boilerplate.Core.Classes;
using Boilerplate.Core.Models.GeneratedModels;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Boilerplate.Core.Models.ViewModels
{
    public class LeftNavigationViewModel
	{
		public LeftNavigationViewModel(ILayout contentModel)
		{
			this.Items = contentModel.AncestorOrSelf(2).Children.FilterInvalidPages();
			this.Hide = !this.Items.Any() || contentModel.HideInLeftNavigation;
		}

		public IEnumerable<IPublishedContent> Items { get; }

		public bool Hide { get; }
	}
}
