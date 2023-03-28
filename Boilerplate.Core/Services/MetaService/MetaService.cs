using Boilerplate.Core.Classes;
using Boilerplate.Core.Models.GeneratedModels;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Boilerplate.Core.Services.MetaService
{
    public class MetaService : IMetaService
    {
        private readonly ISiteService _siteService;
        public MetaService(ISiteService siteService)
        {
            _siteService = siteService;
        }

        public string PageTeaser(ILayout page, int truncate = 250)
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

        public string PageMainImage(ILayout page)
        {
            var previewImage = page.ShareImage?.Url() ?? string.Empty;

            if (string.IsNullOrEmpty(previewImage))
            {
                previewImage = _siteService.Root(page?.GetCultureFromDomains()).DefaultImage?.Url();
            }

            if (string.IsNullOrEmpty(previewImage))
            {
                previewImage = Constants.FilesPath.DefaultSocialSharingImage;
            }

            return previewImage.Split('?').First();
        }

        public string PageMetaImage(ILayout page)
        {
            var baseUrl = _siteService.Root(page?.GetCultureFromDomains()).Url(null, UrlMode.Absolute).TrimEnd("/");
            var metaImagePath = PageMainImage(page);
            return baseUrl + metaImagePath;
        }

        private string PageMainContent(IPublishedElement page)
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

        //public static string GetBlockListText(IEnumerable<BlockListItem> blocklist)
        //{
        //    var blockText = "";
        //    bool hasFoundFirstText = false;
        //    foreach (var block in blocklist)
        //    {
        //        switch (block.Content.ContentType.Alias)
        //        {
        //            case "richTextBlock":
        //                {
        //                    var content = (RichTextBlock)block.Content;
        //                    var html = content.Rte;
        //                    blockText = Regex.Replace(html.ToString(), "<.*?>", "");
        //                    blockText = HttpUtility.HtmlDecode(blockText);
        //                    hasFoundFirstText = true;
        //                    break;
        //                }

        //            case "textImageBlock":
        //                {
        //                    var content = (TextImageBlock)block.Content;
        //                    var html = content.Text;
        //                    blockText = Regex.Replace(html.ToString(), "<.*?>", "");
        //                    blockText = HttpUtility.HtmlDecode(blockText);
        //                    hasFoundFirstText = true;
        //                    break;
        //                }

        //            case "twoColBlock":
        //                {
        //                    string text = "";
        //                    var content = (TwoColBlock)block.Content;
        //                    var leftColBlock = content.LeftCol.Where(x => x.Content.ContentType.ToString() == "richTextBlock").FirstOrDefault();
        //                    if (leftColBlock != null)
        //                    {
        //                        var leftColFirstBlock = (RichTextBlock)leftColBlock.Content;
        //                        text = Regex.Replace(leftColFirstBlock.ToString(), "<.*?>", "");
        //                        text = HttpUtility.HtmlDecode(text);
        //                    }

        //                    var rightColBlock = content.RightCol.Where(x => x.Content.ContentType.ToString() == "richTextBlock").FirstOrDefault();
        //                    if (rightColBlock != null)
        //                    {
        //                        var leftColFirstBlock = (RichTextBlock)leftColBlock.Content;
        //                        text = Regex.Replace(leftColFirstBlock.ToString(), "<.*?>", "");
        //                        text = HttpUtility.HtmlDecode(text);
        //                    }

        //                    blockText = text;
        //                    hasFoundFirstText = true;
        //                    break;
        //                }
        //        }
        //        if (hasFoundFirstText)
        //        {
        //            break;
        //        }
        //    }

        //    return blockText;
        //}

        public string PageTitle(ILayout page)
        {
            var windowTitle = page.WindowTitleAndSocialMediaHeader;
            return string.IsNullOrEmpty(windowTitle) ? page.Name : windowTitle;
        }

        //public bool AutoHeader(IPublishedContent page)
        //{
        //    if (page.ContentType.Alias.Equals(NewsList.ModelTypeAlias, StringComparison.OrdinalIgnoreCase))
        //    {
        //        return false;
        //    }

        //    var content = PageMainContent(page);
        //    return !content.Contains("<h1");
        //}


        public string RobotsContent(ILayout page)
        {
            var sb = new StringBuilder();
            sb.Append($"{(page.AllowRobotsIndex() ? Constants.Search.Index : Constants.Search.NoIndex)}," +
                    $"{(page.AllowRobotsFollow() ? Constants.Search.Follow : Constants.Search.NoFollow)}");
            return sb.ToString();
        }

        public bool AutoHeader(IPublishedContent page)
        {
            throw new NotImplementedException();
        }
    }
}
