// Provides local storage support if none is found
(function () {
    if (!window.localStorage) {
        var cookiesModule = (function () {
            if (!String.prototype.startsWith) {
                String.prototype.startsWith = function (str) {
                    if (this.length < str.length) {
                        return false;
                    }
                    for (var i = 0; i < str.length; i++) {
                        if (this[i] !== str[i]) {
                            return false;
                        }
                    }
                    return true;
                }
            }

            function getCookie(name) {
                var allCookies = document.cookie;

                var indexStart = allCookies.indexOf(name + "=");

                if (indexStart == -1) {
                    return null;
                }
                indexStart = allCookies.indexOf('=', indexStart);
                indexEnd = allCookies.indexOf(';', indexStart);

                if (indexEnd == -1) {
                    indexEnd = allCookies.length - 1;
                }
                var returned = allCookies.substring(indexStart + 1, indexEnd);
                return returned;
            }

            function makeCookie(name, value, days) {
                var date = new Date();
                date.setDate(date.getDate() + days);
                if (days) {
                    value += ' ; expires=' + date.toUTCString();
                }
                document.cookie = name + "=" + value;
            }

            function removeCookie(name) {
                makeCookie(name, "", -1);
            }

            return {
                get: getCookie,
                set: makeCookie,
                remove: removeCookie,
            };
        }());

        window.localStorage = (function () {

            function setItem(key, value) {
                cookiesModule.set('JLocalStorage' + key, value, 10000);
            }

            function getItem(key) {
                cookiesModule.get('JLocalStorage' + key);
            }

            function removeItem(key) {
                cookiesModule.remove('JLocalStorage' + key);
            }

            return {
                setItem: setItem,
                getItem: getItem,
                removeItem: removeItem,
            }
        }());
    }
}())