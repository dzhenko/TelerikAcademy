var app = app || {};

(function(app) {
    'use strict';
    document.addEventListener("deviceready", function () {
        function login(email, password) {
            return app.requester.user.login(email, password)
                .then(function(data) {
                    localStorage.setItem("recipesBearerToken", data.access_token);
                    localStorage.setItem("username", data.userName);

                    $('#loggedOutFooter').hide();
                    $('#loggedInFooter').show().css('display', 'table');
                
                    return data;
                }, app.errorHandler);
        };
    
        function register(email, password, confirmPassword) {
            return app.requester.user.register(email, password, confirmPassword);
        }

        function logout() {
            return app.requester.user.logout()
                .then(function(data) {
                    localStorage.removeItem("recipesBearerToken");
                    localStorage.removeItem("username");
                
                    $('#loggedInFooter').hide();
                    $('#loggedOutFooter').show().css('display', 'table');
                }, app.errorHandler);
        }
    
        app.auth = {
            login: login,
            logout: logout,
            register: register,
            token: function() {
                return localStorage.getItem("recipesBearerToken");
            },
            isAuthenticated: function() {
                return localStorage.getItem("recipesBearerToken") !== null;
            }
        }
    });
}(app));