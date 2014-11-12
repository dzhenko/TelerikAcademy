'use strict';

app.factory('auth', ['$q', 'identity', 'requester', 'baseServiceUrl', 'errorHandler',
    function ($q, identity, requester, baseServiceUrl, errorHandler) {
        var usersApi = baseServiceUrl + '/api/users';

        function register(user) {
            return requester.post(usersApi + '/register', user);
        }

        function login(user) {
            user.grant_type = 'password';
            return requester.post(usersApi + '/login', user)
                .then(function (response) {
                    identity.setCurrentUser(response);
                    // bubbling up the promise
                    return response;
            }, errorHandler);
        }

        function logout() {
            return requester.post(usersApi + '/logout', {}, identity.getAuthorizationToken())
                .then(function (response) {
                    identity.setCurrentUser(undefined);
                    // bubbling up the promise
                    return response;
                }, errorHandler);
        }

        function isAuthenticated() {
            if (identity.isAuthenticated()) {
                return true;
            }
            else {
                // used to reject routes when not authorized
                return $q.reject('not authorized');
            }
        }

        return {
            register: register,
            login: login,
            logout: logout,
            isAuthenticated: isAuthenticated
        }
    }]);