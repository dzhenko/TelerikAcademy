'use strict';

// manages the user services
app.factory('auth', function(requester, rootUrl) {
    var registerEndPoint = 'api/Account/Register';
    var loginEndpoint = 'Token';
    var logoutEndpoint = 'api/Account/Logout';

    function registerUser(username, password) {
        return requester.post(rootUrl + registerEndPoint, {
            Email: username,
            Password: password,
            ConfirmPassword: password
        });
    }

    function loginUser(username, password) {
        return requester.post(rootUrl + loginEndpoint, {
            grant_type: 'password',
            Username: username,
            Password: password
        });
    }

    function logoutUser(token) {
        return requester.post(rootUrl + logoutEndpoint, undefined, token);
    }

    return {
        register : registerUser,
        login: loginUser,
        logout: logoutUser
    }
});