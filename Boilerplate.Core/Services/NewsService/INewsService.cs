using Boilerplate.Core.Models.GeneratedModels;
using System.Collections.Generic;

namespace Boilerplate.Core.Services.NewsService
{
    public interface INewsService
    {
        IEnumerable<News> GetNewsByIds(params int[] ids);
        IEnumerable<News> GetLatestNewsForNewsList(int newsListId, string culture, int take = 100, int skip = 0);
        IEnumerable<News> GetLatestSiteNews(string culture, int take = 100, int skip = 0);
        int GetNewsCountForNewsList(int newsListId, string culture);
    }
}