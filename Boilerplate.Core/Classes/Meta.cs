using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Boilerplate.Core.Models.GeneratedModels;
using Newtonsoft.Json.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Core;
using Umbraco.Extensions;
using Content = Boilerplate.Core.Models.GeneratedModels.Content;

namespace Boilerplate.Core.Classes
{
    //TODO: Maybe rewrite to MetaHelper using DI
    public static class Meta
    {
        public static string PageTeaser(ILayout page, int truncate = 250)
        {
            var teaser = page.MetaDescription;
            if (!string.IsNullOrEmpty(teaser))
            {
                return teaser.Truncate(truncate);
            }

            //teaser = PageMainContent(page);

            if (string.IsNullOrEmpty(teaser))
            {
                return string.Empty;
            }

            teaser = Regex.Replace(teaser.StripHtml(), @"\s+", " ");

            return teaser.Truncate(truncate);
        }

        public static string PageMainImage(ILayout page)
        {
            var previewImage = page.ShareImage?.Url() ?? string.Empty;

            if (string.IsNullOrEmpty(previewImage))
            {
                var site = page.AncestorOrSelf<Site>();
                previewImage = site.DefaultImage?.Url();
            }

            if (string.IsNullOrEmpty(previewImage))
            {
                previewImage = Constants.FilesPath.DefaultSocialSharingImage;
            }

            return previewImage.Split('?').First();
        }

        //private static string PageMainContent(IPublishedElement page)
        //{
        //    var content = string.Empty;
        //    var contentMiddle = page.GetProperty(Content.GetModelPropertyType(l => l.ContentMiddle).Alias);
        //    if (contentMiddle != null && contentMiddle.HasValue())
        //    {
        //        content = contentMiddle.Value<IHtmlString>().ToHtmlString();
        //    }

        //    if (page.HasValue("blocklist"))
        //    {
        //        content = GetBlockListText(page.Value<IEnumerable<BlockListItem>>("blocklist"));
        //    }

        //    return content;
        //}


        public static string PageTitle(ILayout page)
        {
            var windowTitle = page.WindowTitleAndSocialMediaHeader;
            return string.IsNullOrEmpty(windowTitle) ? page.Name : windowTitle;

        }

        //public static bool AutoHeader(this IPublishedContent page)
        //{
        //    if (page.ContentType.Alias.Equals(NewsList.ModelTypeAlias, StringComparison.OrdinalIgnoreCase))
        //    {
        //        return false;
        //    }

        //    var content = PageMainContent(page);
        //    return !content.Contains("<h1");
        //}


        public static string RobotsContent(ILayout page)
        {
            var sb = new StringBuilder();
            sb.Append($"{(page.AllowRobotsIndex() ? Constants.Search.Index : Constants.Search.NoIndex)}," +
                    $"{(page.AllowRobotsFollow() ? Constants.Search.Follow : Constants.Search.NoFollow)}");
            return sb.ToString();
        }
    }
}