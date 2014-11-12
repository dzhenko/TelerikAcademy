var app = app || {};

(function(app) {
    'use strict';
    
    app.utility = {
        getRandomString: function() {
            return Math.random().toString(36).substring(2, 15);
        }
    }
}(app));