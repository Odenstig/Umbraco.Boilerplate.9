// File#: _1_video

(function () {
    
    function appendVideo(e) {
        var videoId = e.target.dataset.videoid,
            elId = 'video-' + videoId,
            url = "https://www.youtube.com/embed/" + videoId + "?mute=1&modestbranding=1&autohide=1&showinfo=0&autoplay=1&rel=0&enablejsapi=1",
            iframe = '<iframe id="' + elId + '" src="' + url + '" allowfullscreen></iframe>';

        // Append this iframe to the DOM
        e.target.innerHTML = iframe;

        // If Triggerbees Youtube-logging is activated we must log manually (since this iframe is dynamically appended)
        if (typeof YT !== 'undefined' && typeof mtr_youtube !== 'undefined') {
            new YT.Player(elId, {
                events: {
                    'onStateChange': function (event) {
                        mtr_youtube.HandleEvent(event);
                    }
                }
            });
        }
    }

    const videoElements = document.querySelectorAll('.video');
    for (var i = 0; i < videoElements.length; i++) {

        videoElements[i].addEventListener('click', function(event) {
            appendVideo(event);
        });
    }

})();