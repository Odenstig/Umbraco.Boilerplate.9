////// File#: _2_cookie-warning

////import axios from 'axios';
////import Cookies from 'js-cookie';

////(function () {

////    function initNoticeEvents(notice) {
////        notice.addEventListener('click', function (event) {
////            if (event.target.closest('.js-notice__hide-control')) {
////                event.preventDefault();
////                Util.addClass(notice, 'notice--hide');

////                if (event.target.closest('.accept')) {
////                    Cookies.set(cookieName, true, { expires: 365 });
////                }
////            }
////        });
////    };

////    if (navigator.cookieEnabled) {

////        var cookieName = 'cookiesaccepted';

////        if (!Cookies.get(cookieName)) {

////            // Fetch cookie warning
////            axios.post('/umbraco/surface/partialsurface/cookiewarning', { nodeId: Helper.GetCurrentNodeId() })
////                .then(function (response) {
////                    var target = document.getElementById('js-notices');
////                    if (response.data.length > 0 && target) {
////                        target.insertAdjacentHTML('beforeend', response.data);
////                    } else {
////                        // Disclaimer does not contain any text. Disable it so it doesn't make any more requests
////                        Cookies.set(cookieName, true, { expires: 365 });
////                    }

////                    var noticeElements = document.getElementsByClassName('js-notice');
////                    if (noticeElements.length > 0) {
////                        for (var i = 0; i < noticeElements.length; i++) {
////                            (function (i) {
////                                initNoticeEvents(noticeElements[i]);
////                            })(i);
////                        }
////                    }
////                });
////        }
////    }

////}());