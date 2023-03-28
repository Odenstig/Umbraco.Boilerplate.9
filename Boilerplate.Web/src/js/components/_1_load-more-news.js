// File#: _1_load-more-news

import axios from 'axios';

(function () {

    var newsListContainer = document.getElementsByClassName('news-list__news')[0];
    var loadMoreContainer = document.getElementsByClassName('news-list__load-more')[0];
    var loadMoreBtn = document.getElementsByClassName('news-list__load-more-btn')[0];

    if (loadMoreBtn && loadMoreContainer && newsListContainer) {
        loadMoreBtn.addEventListener('click', function () {

            Util.addClass(loadMoreContainer, 'news-list__load-more--loading');

            var newsListId = newsListContainer.dataset.newslist;
            var take = newsListContainer.dataset.take;
            var skip = newsListContainer.dataset.skip;
            var culture = newsListContainer.dataset.culture;

            axios.get('/umbraco/surface/newssurface/getnews', { params: { newsListId, take, skip, culture } })
                .then(response => {
                    if (response.status === 200) {
                        var data = response.data;
                        newsListContainer.insertAdjacentHTML('beforeend', data.partialView);
                        if (!data.canLoadMore) {
                            Util.addClass(loadMoreContainer, 'news-list__load-more--hide');
                            Util.setAttributes(newsListContainer, { 'data-skip': data.skip });
                        } else {
                            Util.setAttributes(newsListContainer, { 'data-skip': data.skip });
                            Util.removeClass(loadMoreContainer, 'news-list__load-more--loading');
                        }
                    } else {
                        console.log('Error loading news..')
                    }
                })
                .catch(error => console.log(error))
        });
    }
})();