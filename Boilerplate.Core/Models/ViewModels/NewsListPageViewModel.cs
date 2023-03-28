using Boilerplate.Core.Models.DataModels;
using Boilerplate.Core.Models.GeneratedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Boilerplate.Core.Models.ViewModels
{
    public class NewsListPageViewModel : NewsList
    {
        public NewsListPageViewModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        { }

        public int InitalLoadAmount { get; set; }
        public IEnumerable<News> LatestNews { get; set; }
        public News LatestNewsItem => LatestNews.FirstOrDefault();
        public IEnumerable<News> LatestNewsSkipLatest => LatestNews.Skip(1);
        public bool HasAnyNews => LatestNews.Any();
        public string LatestNewsTitle { get; set; }
        public string Culture { get; set; }
        public bool CanLoadMore { get; set; }
        public string LoadMoreText { get; set; }
    }
}
