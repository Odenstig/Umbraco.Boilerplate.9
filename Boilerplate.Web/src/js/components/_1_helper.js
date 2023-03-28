// File#: _1_helper

(function () {
    // Helper function
    function Helper() { };

    // Debouncer for resize. Fire resize event resize has been still for 200ms. 
    Helper.Debouncer = function (func, timeout) {
        var timeoutID, timeout = timeout || 200;
        return function () {
            var scope = this, args = arguments;
            clearTimeout(timeoutID);
            timeoutID = setTimeout(function () {
                func.apply(scope, Array.prototype.slice.call(args));
            }, timeout);
        }
    }

    Helper.GetCurrentNodeId = function () {
        return document.body.dataset.currentNode;
    }

    window.Helper = Helper;

}());