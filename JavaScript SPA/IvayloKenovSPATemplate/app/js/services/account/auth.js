'use strict';

app.factory('auth', ['$q', 'identity', 'requester', 'baseServiceUrl', 'errorHandler',
    function ($q, identity, requester, baseServiceUrl, errorHandler) {
        var usersApi = baseServiceUrl + '/api/users';

        function register(username, password) {
            return requester.post(baseServiceUrl + '/api/Account/Register', {
                Email: username,
                Password: password,
                ConfirmPassword: password
            });
        }

        function login(username, password) {
            return requester.post(baseServiceUrl + '/Token', {
                grant_type: 'password',
                Username: username,
                Password: password
            }).then(function (response) {
                identity.setCurrentUser(response);
                return response;
            }, errorHandler);
        }

        function logout() {
            return requester.post(baseServiceUrl + '/api/Account/Logout', {}, identity.getAuthorizationToken())
                .then(function (response) {
                    identity.setCurrentUser(undefined);
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