using Boilerplate.Core.Models.GeneratedModels;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Boilerplate.Core.Services.MetaService
{
    public interface IMetaService
    {
        bool AutoHeader(IPublishedContent page);
        string PageMainImage(ILayout page);
        string PageMetaImage(ILayout page);
        string PageTeaser(ILayout page, int truncate = 250);
        string PageTitle(ILayout page);
        string RobotsContent(ILayout page);
    }
}