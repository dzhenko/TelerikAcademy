var app = app || {};

(function(app) {
    'use strict';
    
    app.validator = {
        isValidEmail: function(email) {
            var isValidEmail = email && typeof email === 'string' && 
                                  email.length >= 4 && email.length <= 20;
            return isValidEmail === true ? true : false;  
        },
        isValidPassword: function(password) {
            var isValidPassword = password && typeof password === 'string' &&
                                  password.length >= 4 && password.length <= 20;
            return isValidPassword === true ? true : false;  ;  
        },
        passwordsMatches: function(password, confirmPassword) {
            if (password && confirmPassword && password === confirmPassword) {
                return true;
            }
            return false;
        }
    }
}(app));