define([], function () {
    // in case session storage is not supported
    (function () {
        window.localStorage = window.localStorage || {
            setItem: function(key, data) {
                document.cookie = key + '=' + data + '; expires=Thu, 30 Apr 2053 21:44:00 UTC; path=/';
            },
            getItem: function (key) {
                var cookieValue = document.cookie;
                var cookieStartsAt = cookieValue.indexOf(" " + key + "=");
                if (cookieStartsAt == -1) {
                    cookieStartsAt = cookieValue.indexOf(key + "=");
                }
                if (cookieStartsAt == -1) {
                    cookieValue = null;
                }
                else {
                    cookieStartsAt = cookieValue.indexOf("=", cookieStartsAt) + 1;
                    var cookieEndsAt = cookieValue.indexOf(";", cookieStartsAt);
                    if (cookieEndsAt == -1) {
                        cookieEndsAt = cookieValue.length;
                    }
                    cookieValue = cookieValue.substring(cookieStartsAt, cookieEndsAt);
                }
                return cookieValue;
            }
        }
    }())

    function setUserName(value) {
        value = value || 'Guest';

        window.localStorage.setItem('crowd-chat-username', value);
    }

    function getUsername() {
        return window.localStorage.getItem('crowd-chat-username');
    }

    return {
        username: {
            get: getUsername,
            set: setUserName
        }
    }
})