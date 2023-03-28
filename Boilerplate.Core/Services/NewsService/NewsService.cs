using Boilerplate.Core.Models.GeneratedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Extensions;

namespace Boilerplate.Core.Services.NewsService
{
    public class NewsService : INewsService
    {
        private readonly ISiteService _siteService;
        public NewsService(ISiteService siteService)
        {
            _siteService = siteService;
        }

        public IEnumerable<News> GetNewsByIds(params int[] ids)
        {
            var newsItems = new List<News>();

            foreach (var id in ids)
            {
                var newsItem = _siteService.ContentQuery.GetById(id);
                if (newsItem is News news)
                {
                    newsItems.Add(news);
                }
            }

            return newsItems;
        }

        public IEnumerable<News> GetLatestSiteNews(string culture, int take = 100, int skip = 0)
        {
            var newsItems = _siteService
              .Root(culture)
              .Descendants(culture)
              .OfType<News>()
              .Where(n => n.DisplayDate <= DateTime.Today)
              .OrderByDescending(n => n.DisplayDate)
              .Skip(skip)
              .Take(take);

            return newsItems;
        }

        public IEnumerable<News> GetLatestNewsForNewsList(int newsListId, string culture, int take = 100, int skip = 0)
        {
            var newsItems = _siteService.ContentQuery
                .GetById(newsListId)
                .Descendants(culture)
                .OfType<News>()
                .Where(n => n.DisplayDate <= DateTime.Today)
                .OrderByDescending(n => n.DisplayDate)
                .Skip(skip)
                .Take(take);

            return newsItems;
        }

        public int GetNewsCountForNewsList(int newsListId, string culture)
        {
            return _siteService.ContentQuery
                .GetById(newsListId)
                .Descendants(culture)
                .OfType<News>()
                .Where(n => n.DisplayDate <= DateTime.Today)
                .Count();
        }
    }
}
