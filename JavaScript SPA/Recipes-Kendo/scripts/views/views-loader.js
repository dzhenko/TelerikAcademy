define(function() {
    function loadView(name) {
        var cachedViews = {};

        var promise = new RSVP.Promise(function (resolve, reject) {
            if (cachedViews[name]) {
                resolve(cachedViews[name]);
            }
            else {
                $.ajax({
                    url: 'scripts/views/' + name + '/' + name + '.html',
                    success: function (html) {
                        cachedViews[name] = html;
                        resolve(html);
                    },
                    error: function (err) {
                        reject(err);
                    }
                });
            }
        });
        return promise;
    }

    return {
        loadView: loadView
    }
});