var HttpJSON = (function () {

    function getJSON(url, headers) {
        var def = Q.defer();

        headers = headers || {};

        $.ajax({
            url: url,
            type: 'GET',
            success: function (data) {
                def.resolve(data);
            },
            error: function (error) {
                def.reject(error);
            },
            headers: headers
        });

        return def.promise;
    }

    function postJSON(url, object, headers) {
        var def = Q.defer();

        headers = headers || {};

        $.ajax({
            url: url,
            type: 'POST',
            data: object,
            success: function (data) {
                def.resolve(data);
            },
            error: function (error) {
                def.reject(error);
            },
            headers: headers
        });

        return def.promise;
    }

    return {
        getJSON: getJSON,
        postJSON: postJSON
    }
}())