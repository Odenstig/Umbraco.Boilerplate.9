using Boilerplate.Core.Models.GeneratedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common;
using Umbraco.Extensions;

namespace Boilerplate.Core.Classes
{
    public static class ContentExtensions
    {
        public static string NavName(this IPublishedContent page)
        {
            return page.HasProperty("navName") && page.HasValue("navName") ? page.Value<string>("navName") : page.Name;
        }

        public static List<IPublishedContent> FilterInvalidPages(this IEnumerable<IPublishedContent> pages)
        {
            return pages.Where(p => p.IsVisible() && p.ContentType.Alias != "Faqquestion" && p.ContentType.Alias != "folder").ToList();
        }

        public static IPublishedContent GetIPublishedContent(this UmbracoHelper helper, IPublishedContent page, string propertyAlias)
        {
            var id = page.Value<int>(propertyAlias);
            return helper.Content(id);
        }

        public static bool AllowRobotsIndex(this IPublishedContent p)
        {
            if (p.HasProperty("disallowSearchEngineToIndexPage"))
                return !p.Value<bool>("disallowSearchEngineToIndexPage");

            return false;
        }

        public static IEnumerable<IPublishedContent> WhereAllowRobotsIndex(this IEnumerable<ILayout> pages)
        {
            return pages.Where(AllowRobotsIndex);
        }

        public static bool AllowRobotsIndex(this ILayout layout)
        {
            return !layout.DisallowSearchEngineToIndexPage;
        }

        public static bool AllowRobotsFollow(this ILayout layout)
        {
            return !layout.DisallowSearchEngineNavigation;
        }

        // Meta
        public static string PageTeaser(this ILayout page, int truncate = 250)
        {
            var teaser = page.MetaDescription;

            if (!string.IsNullOrEmpty(teaser))
            {
                return teaser.Truncate(truncate);
            }

            teaser = PageMainContent(page);

            if (string.IsNullOrEmpty(teaser))
            {
                return string.Empty;
            }

            teaser = Regex.Replace(teaser.StripHtml(), @"\s+", " ");

            return teaser.Truncate(truncate);
        }

        public static string PageMainImage(this ILayout page, Site root)
        {
            var previewImage = page.ShareImage?.Url() ?? string.Empty;

            if (string.IsNullOrEmpty(previewImage))
            {
                previewImage = root.DefaultImage?.Url();
            }

            if (string.IsNullOrEmpty(previewImage))
            {
                previewImage = Constants.FilesPath.DefaultSocialSharingImage;
            }

            return previewImage.Split('?').First();
        }

        private static string PageMainContent(IPublishedElement page)
        {

            return string.Empty;
            //var content = string.Empty;
            //var contentMiddle = page.GetProperty(Content.GetModelPropertyType(l => l.ContentMiddle).Alias);
            //if (contentMiddle != null && contentMiddle.HasValue())
            //{
            //    content = contentMiddle.Value<IHtmlString>().ToHtmlString();
            //}

            //if (page.HasValue("blocklist"))
            //{
            //    content = GetBlockListText(page.Value<IEnumerable<BlockListItem>>("blocklist"));
            //}

            //return content;
        }

        public static string PageTitle(this ILayout page)
        {
            var windowTitle = page.WindowTitleAndSocialMediaHeader;
            return string.IsNullOrEmpty(windowTitle) ? page.Name : windowTitle;
        }

        public static string RobotsContent(this ILayout page)
        {
            var sb = new StringBuilder();
            sb.Append($"{(page.AllowRobotsIndex() ? Constants.Search.Index : Constants.Search.NoIndex)}," +
                    $"{(page.AllowRobotsFollow() ? Constants.Search.Follow : Constants.Search.NoFollow)}");
            return sb.ToString();
        }

        public static bool AutoHeader(this IPublishedContent page)
        {
            throw new NotImplementedException();
        }

        public static string PageMetaImage(this ILayout page, Site root)
        {
            var baseUrl = root.Url(null, UrlMode.Absolute).TrimEnd("/");
            var metaImagePath =  page.PageMainImage(root);
            return baseUrl + metaImagePath;
        }

        public static string GetTranslationByCulture(this ILocalizationService localizationService, string translationKey, string culture)
        {
            var translationItem = localizationService.GetDictionaryItemByKey(translationKey);
            var translation = translationItem?.Translations.FirstOrDefault(t => t.Language.IsoCode == culture);
            return translation?.Value;
        }
    }
}
