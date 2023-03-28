using Boilerplate.Core.Classes;
using Boilerplate.Core.Models.GeneratedModels;
using Umbraco.Extensions;

namespace Boilerplate.Core.Models.DataModels
{
    public class NewsItem
    {
        public NewsItem(News contentModel)
        {
            Url = contentModel.Url();
            Name = contentModel.Name;
            CreateDate = contentModel.CreateDate.ToString("yyyy-MM-dd");
            Teaser = Meta.PageTeaser(contentModel, 100);
            ImageUrl = contentModel.HeroImage != null
                ? contentModel.HeroImage.Url()
                : Constants.FilesPath.DefaultSocialSharingImage;
        }

        public string Url { get; }
        public string Name { get; }
        public string CreateDate { get; }
        public string Teaser { get; }
        public string ImageUrl { get; set; }
    }
}
